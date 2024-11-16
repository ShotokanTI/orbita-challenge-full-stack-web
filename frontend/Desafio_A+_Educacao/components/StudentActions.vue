<template>
    <v-row align="end">
        <v-col cols="6">
            <v-text-field @click:clear="searchUpdated" clearable hide-details @input="searchUpdated" label="Digite sua busca"
                prepend-inner-icon="mdi-magnify" class="mb-4"></v-text-field>
        </v-col>
        <v-col cols="6">
            <v-btn color="primary" @click="navigateTo({ path: 'register' })" class="mb-4">
                Cadastrar Aluno
            </v-btn>
        </v-col>
    </v-row>
</template>

<script setup lang="ts">
const emit = defineEmits(['searchUpdated'])

function searchUpdated(event:any) {
    emit('searchUpdated', event.target.value);
}
</script>