<script setup>
  import { useSeoMeta } from '@unhead/vue'
  import { ref } from 'vue'
  import * as api from '../components/api.js'
  import 'vue-select/dist/vue-select.css'

  useSeoMeta({
    description: 'Hitta din praktikplats med Lian!'
  })

  const loading = ref(false)
  const selectedTagsInternshipTermCount = ref(null)

  const fetchTermCount = () => {
    if (selectedTags.value.length)
      api.countInternshipTerms(selectedTags.value.map(t => t.id))
        .then(r => selectedTagsInternshipTermCount.value = r.data)
    else
      selectedTagsInternshipTermCount.value = null
  }
</script>

<template>
  <section class="content">
    <h5>
      Hitta din praktikplats med
      <img src="/src/assets/logos/fit.svg" alt="Lian" />
    </h5>

    <router-link :to="{ path: 'platser', query: { t: selectedTags.map(t => t.id) } }">
      <button class="button">
        <span v-if="selectedTagsInternshipTermCount != null">
          Sök
          {{ selectedTagsInternshipTermCount }}
          plats<span v-show="selectedTagsInternshipTermCount !== 1">er</span>
        </span>
        <span v-else>
          Leta bland allt
        </span>
      </button>
    </router-link>
  </section>
</template>

<style scoped>
  .content {
    display: block;
    width: 600px;
    margin: 0 auto;
    font-size: 2em;
    max-width: 100%;
    text-align: center;
  }

  .content img {
    height: 1em;
    vertical-align: middle;
  }
</style>
