<template>
  <v-data-table-server dirty v-if="students && students.items" :headers="headers" :items="students.items"
    :items-length="students.totalItems" :items-per-page="itemsPerPage" :loading="loading" :page.sync="page"
    class="elevated mt-4" height="400px" @update:page="($event) => $emit('pageUpdated', $event)"
    @update:items-per-page="($event) => $emit('itemsPerPageUpdated', $event)">
    <template #item.actions="{ item }">
      <v-btn icon color="primary" @click="navigateTo({ path: 'register', state: { student: JSON.stringify(item) } })">
        <v-icon>mdi-pencil</v-icon>
      </v-btn>
      <v-btn icon color="red" @click="">
        <v-icon>mdi-delete</v-icon>
      </v-btn>
    </template>
  </v-data-table-server>
</template>

<script setup lang="ts">
defineProps({
  students: Array as unknown as PropType<StudentService>,
  loading: Boolean,
  page: Number,
  itemsPerPage: Number,
})

const headers = [
  { title: 'Registro Acadêmico', key: 'ra' },
  { title: 'Id', key: 'id' },
  { title: 'Nome', key: 'name' },
  { title: 'Email', key: 'email' },
  { title: 'CPF', key: 'cpf' },
  { title: 'Ações', key: 'actions', sortable: false }
]

</script>

<style scoped>
.elevated {
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  border-radius: 8px;
}
</style>
