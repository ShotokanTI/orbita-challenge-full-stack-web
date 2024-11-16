// services/studentService.ts

import { useFetch, useRuntimeConfig } from '#app'
import { nextTick } from 'vue';

// Tipo de dado para o aluno (opcional, mas ajuda com TypeScript)
export interface Student {
    name: string;
    email: string;
    cpf: string;
    ra:string
}

// Função para buscar a lista de alunos com paginação e busca
export async function fetchStudents(pageNumber = 1, pageSize = 10, search = "") {
    const config = useRuntimeConfig()
    const searchParam = search ? `?search=${search}` : ''
    
    await nextTick()

    const fetch = await useFetch<StudentService>(`${config.public.apiBaseUrl}/StudentResource${searchParam}`, {
        method: 'GET',
        params: {
            pageNumber,
            pageSize,
        },
    })
    return fetch

    // if (error.value) {
    //     console.error('Erro ao buscar alunos:', error.value)
    //     throw error.value
    // }
}

// Função para criar um novo aluno
export async function createStudent(studentData: Student) {
    const config = useRuntimeConfig()
    const { data, error } = await useFetch(`${config.public.apiBaseUrl}/StudentResource`, {
        method: 'POST',
        body: studentData,
        headers: {
            'Content-Type': 'application/json'
        }
    })

    if (error.value) {
        console.error('Erro ao criar aluno:', error.value)
        throw error.value
    }
    return data.value
}

// Função para atualizar os dados de um aluno
export async function updateStudent(studentData: Student) {
    const config = useRuntimeConfig()
    const { data, error } = await useFetch(`${config.public.apiBaseUrl}/StudentResource`, {
        method: 'PUT',
        body: studentData,
        headers: {
            'Content-Type': 'application/json'
        }
    })

    if (error.value) {
        console.error('Erro ao atualizar aluno:', error.value)
        throw error.value
    }
    return data.value
}

// Função para excluir um aluno
export async function deleteStudent(studentId: number) {
    const config = useRuntimeConfig()
    const { data, error } = await useFetch(`${config.public.apiBaseUrl}/StudentResource/${studentId}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    })

    if (error.value) {
        console.error('Erro ao excluir aluno:', error.value)
        throw error.value
    }
    return data.value
}
