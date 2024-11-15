<template>
  <v-container>
    <v-row>
      <v-col cols="12" md="8" lg="6">
        <v-text-field
          v-model="search"
          label="Digite sua busca"
          prepend-inner-icon="mdi-magnify"
          @input="handleSearch"
          class="mb-4"
        ></v-text-field>

        <v-btn color="primary" @click="navigateToCreateStudent" class="mb-4">
          Cadastrar Aluno
        </v-btn>

        <v-data-table
          :headers="headers"
          :items="students"
          :server-items-length="totalStudents"
          :items-per-page="itemsPerPage"
          :loading="loading"
          :page.sync="page"
          :items-per-page.sync="itemsPerPage"
          class="elevated mt-4"
          @update:page="fetchStudents"
          @update:items-per-page="fetchStudents"
        >
          <template #item.actions="{ item }">
            <v-btn icon color="primary" @click="editStudent(item)">
              <v-icon>mdi-pencil</v-icon>
            </v-btn>
            <v-btn icon color="red" @click="deleteStudent(item)">
              <v-icon>mdi-delete</v-icon>
            </v-btn>
          </template>
        </v-data-table>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { ref, watch, onMounted } from 'vue'

const search = ref('')
const students = ref([])
const totalStudents = ref(0)
const itemsPerPage = ref(10)
const page = ref(1)
const loading = ref(false)

const headers = [
  { title: 'Registro Acadêmico', key: 'ra' },
  { title: 'Nome', key: 'name' },
  { title: 'CPF', key: 'cpf' },
  { title: 'Ações', key: 'actions', sortable: false }
]

function fetchStudents() {
  loading.value = true
  // Simulando uma chamada para o backend
  setTimeout(() => {
    // Em um caso real, aqui você chamaria o backend, enviando page.value e itemsPerPage.value
    // Exemplo de chamada:
    // const response = await axios.get('/api/students', { params: { page: page.value, itemsPerPage: itemsPerPage.value, search: search.value } });
    // students.value = response.data.items;
    // totalStudents.value = response.data.total;

    students.value = [
      { ra: 101235, name: 'Paula Souza', cpf: '121.999.999-99' },
      { ra: 111687, name: 'João Silva', cpf: '122.999.999-99' },
      { ra: 111365, name: 'Marina Miranda', cpf: '123.999.999-99' },
      { ra: 101299, name: 'Maurício Souza', cpf: '124.999.999-99' }
    ]
    totalStudents.value = 4
    loading.value = false
  }, 1000)
}

function handleSearch() {
  // Reinicia a paginação ao fazer uma nova busca
  page.value = 1
  fetchStudents()
}

function navigateToCreateStudent() {
  return navigateTo({path:'register'})
}

function editStudent(student) {
  // lógica de edição de aluno
}

function deleteStudent(student) {
  // lógica para exclusão de aluno
}

onMounted(fetchStudents)
watch([page, itemsPerPage], fetchStudents)
</script>

<style scoped>
.elevated {
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  border-radius: 8px;
}
</style>
