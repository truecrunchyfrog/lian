import axios from 'axios'
import qs from 'qs'

const axiosClient = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  paramsSerializer: (params) => qs.stringify(params, {arrayFormat: 'repeat'})
})

export async function getOrganizations() {
  return axiosClient.get('organizations')
}

export async function getInternshipTerms(tagIds) {
  return axiosClient.get('internshipterms', { params: { tagIds: tagIds } })
}

export async function countInternshipTerms(tagIds) {
  return axiosClient.get('internshipterms/count', tagIds)
}

export async function getTags() {
  return axiosClient.get('tags')
}
