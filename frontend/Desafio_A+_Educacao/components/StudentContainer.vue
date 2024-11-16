<template>
    <v-main>
        <v-container>
            <StudentActions @searchUpdated="$event => search = $event" />
            <v-row justify="center">
                <v-col cols="12">
                    <StudentList :students="students" :loading="loading" :error="error" :page="page"
                        :itemsPerPage="itemsPerPage" @pageUpdated="$event => page = $event"
                        @itemsPerPageUpdated="$event => itemsPerPage = $event" />
                </v-col>
            </v-row>
        </v-container>
    </v-main>
</template>

<script setup>
import StudentList from './StudentList.vue';

const { students, loading, error, page, itemsPerPage, search } = useStudentService()

// Esse layout define a estrutura com a barra lateral e o cabeçalho conforme o mockup.
</script>

<style>
/* Customizações adicionais de estilo */
</style>