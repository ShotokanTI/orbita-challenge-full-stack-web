// composables/useStudentService.ts
import { ref, onMounted } from 'vue'
import { fetchStudents, updateStudent, type Student } from '~/services/studentService'
import type { Ref } from 'vue'

export interface StudentService {
    items: Student[],
    totalItems: number,
    totalPages: number,
    pageNumber: number
    pageSize: number
}

export function useStudentService() {
    const students: Ref<StudentService | null> = ref(null)
    const loading = ref(false)
    const error = ref(null)
    const page = ref(1)
    const itemsPerPage = ref(10)
    const search = ref("")

    async function loadStudentsService() {
        loading.value = true
        error.value = null

        try {
            const { data, pending, error } = await fetchStudents(page.value, itemsPerPage.value, search.value)
            loading.value = pending.value
            error.value = error.value
            students.value = data.value as StudentService
        } catch (err) {
            console.log(err)
        } finally {
            loading.value = false
        }
    }

    async function updateStudentService(studentData: Student) {
        try {
            await updateStudent(studentData)
        } catch (err) {
            console.log(err)
        }
    }

    onMounted(loadStudentsService)

    watch([page, itemsPerPage, search], () => {
        loadStudentsService()
    })

    return {
        students,
        loading,
        error,
        page,
        itemsPerPage,
        search,
        loadStudentsService,
        updateStudentService
    }
}
