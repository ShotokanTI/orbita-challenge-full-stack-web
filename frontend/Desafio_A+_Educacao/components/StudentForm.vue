<template>
    <v-container>
      <v-row>
        <v-col cols="12" md="8" lg="6">
          <v-form ref="formRef">
            <v-text-field
              v-model="student.name"
              label="Nome"
              required
            ></v-text-field>
            <v-text-field
              v-model="student.email"
              label="E-mail"
              required
            ></v-text-field>
            <v-text-field
              v-model="student.registration"
              label="Registro Acadêmico"
              required
            ></v-text-field>
            <v-text-field
              v-model="student.cpf"
              label="CPF"
              required
            ></v-text-field>
  
            <v-btn color="primary" @click="saveStudent">Salvar</v-btn>
            <v-btn color="secondary" @click="cancel">Cancelar</v-btn>
          </v-form>
        </v-col>
      </v-row>
    </v-container>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  
  const student = ref({
    name: '',
    email: '',
    registration: '',
    cpf: ''
  })
  
  const formRef = ref(null)
  
  function saveStudent() {
    if (formRef.value.validate()) {
      // lógica para salvar aluno
    }
  }
  
  function cancel() {
    return navigateTo({path:'management'})
  }
  </script>
  