<script setup>
  import { useSeoMeta } from '@unhead/vue'
  import { ref } from 'vue'
  import { useRouter, useRoute } from 'vue-router'
  import * as api from '../components/api.js'
  import InternshipTermCard from '../components/InternshipTermCard.vue'
  import InternshipTermCardsContainer from '../components/InternshipTermCardsContainer.vue'

  useSeoMeta({
    title: 'Resultat'
  })

  const internshipTerms = ref([])

  const router = useRouter()
  const route = useRoute()

  api.getInternshipTerms(route.query.t)
    .then(r => internshipTerms.value = r.data)
</script>

<template v-show="internshipTerms">
  <h1>{{ internshipTerms.length }} plats<span v-show="internshipTerms.length !== 1">er</span></h1>

  <InternshipTermCardsContainer>
    <InternshipTermCard v-for="term in internshipTerms" :term="term" />
  </InternshipTermCardsContainer>
</template>
