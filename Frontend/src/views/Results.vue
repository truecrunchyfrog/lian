<script setup>
  import { computed, ref } from 'vue'
  import { useSeoMeta } from '@unhead/vue'
  import { useRouter, useRoute } from 'vue-router'
  import * as api from '../components/api.js'
  import InternshipPositionCard from '../components/InternshipPositionCard.vue'
  import InternshipPositionCardsContainer from '../components/InternshipPositionCardsContainer.vue'
  import SearchInput from '../components/SearchInput.vue'

  useSeoMeta({
    title: 'Resultat'
  })

  const router = useRouter()
  const route = useRoute()

  const selectedOptions = ref([])
  const internshipPositions = ref([])

  const setOptionsFromQuery = () =>
    selectedOptions.value = [
      ...[...(route.query.t || [])].map(tagId => { return { propertyId: parseInt(tagId), type: 'tag' } }),
      ...[...(route.query.o || [])].map(orgId => { return { propertyId: parseInt(orgId), type: 'org' } })
    ]

  setOptionsFromQuery()

  const updateResults = () =>
    api.getInternshipPositions(selectedOptions.value)
      .then(r => internshipPositions.value = r.data)

  updateResults()

  const updateQuery = () =>
    router.push({
      query: {
        t: selectedOptions.value.filter(option => option.type == 'tag').map(t => t.propertyId),
        o: selectedOptions.value.filter(option => option.type == 'org').map(o => o.propertyId),
      }
    })

  const updateFromSelected = () => {
    updateQuery()
    updateResults()
  }

  const addTag = tagId => {
    if (selectedOptions.value.some(option => option.propertyId === tagId)) return

    selectedOptions.value = selectedOptions.value.concat({ propertyId: tagId, type: 'tag' })
    updateFromSelected()
  }
</script>

<template v-show="internshipPositions">
  <h1>{{ internshipPositions.length }} plats<span v-show="internshipPositions.length !== 1">er</span></h1>

  <SearchInput v-model="selectedOptions" @input="updateFromSelected" />

  <InternshipPositionCardsContainer>
    <InternshipPositionCard
        v-for="position in internshipPositions"
        :position="position"
        @use-tag="addTag" />
  </InternshipPositionCardsContainer>
</template>
