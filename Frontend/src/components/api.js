import axios from 'axios'
import qs from 'qs'

const axiosClient = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  paramsSerializer: (params) => qs.stringify(params, {arrayFormat: 'repeat'})
})

export async function getOrganizations() {
  return axiosClient.get('organizations')
}

const queryOptionsToParams = queryOptions => {
    return {
      tagIds: queryOptions.filter(option => option.type === 'tag').map(option => option.propertyId),
      orgIds: queryOptions.filter(option => option.type === 'org').map(option => option.propertyId)
    }
  }

export async function getInternshipPositions(queryOptions) {
  return axiosClient.get('internshippositions', { params: queryOptionsToParams(queryOptions) })
}

export async function countInternshipPositions(queryOptions) {
  return axiosClient.get('internshippositions/count', { params: queryOptionsToParams(queryOptions) })
}

export async function getTags() {
  return axiosClient.get('tags')
}

export async function getSearchQueryOptions() {
  return axiosClient.get('search')
}
