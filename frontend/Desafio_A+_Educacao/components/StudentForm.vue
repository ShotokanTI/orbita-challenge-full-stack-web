<template>
  <v-main>
    <v-container>
      <v-row>
        <v-col cols="12" md="8" lg="6">
          <v-form ref="formRef">
            <v-text-field v-model="student.name" label="Nome" required></v-text-field>
            <v-text-field v-model="student.email" label="E-mail" required></v-text-field>
            <v-text-field :disabled="student.ra ? true:false" v-model="student.ra" label="Registro Acadêmico" required></v-text-field>
            <v-text-field :disabled="student.cpf ? true:false" v-model="student.cpf" label="CPF" required></v-text-field>

            <v-btn color="primary" @click="saveStudent">Salvar</v-btn>
            <v-btn color="secondary" @click="cancel">Cancelar</v-btn>
          </v-form>
        </v-col>
      </v-row>
    </v-container>
  </v-main>
</template>

<script setup lang="ts">
import { ref } from 'vue'
const useRoute = useRouter();
const {updateStudentService} = useStudentService()

const student = ref({
  name: '',
  email: '',
  ra: '',
  cpf: ''
})

onMounted(() => {
  if(useRoute.options.history.state?.student !== undefined){
    student.value = JSON.parse(useRoute.options.history.state.student as string)
  }
})

const formRef = ref(null)

function saveStudent() {
  updateStudentService(student.value)
}

function cancel() {
  return navigateTo({ path: 'management' })
}
</script>