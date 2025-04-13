<script setup>
  import { useSeoMeta } from '@unhead/vue'
  import { ref, computed } from 'vue'
  import * as api from '../components/api.js'
  import SearchInput from '../components/SearchInput.vue'

  useSeoMeta({
    description: 'Hitta din praktikplats med Lian!'
  })

  const selectedOptions = ref([])
  const selectedOptionsAsQuery = computed(() => {
    return {
      t: selectedOptions.value.filter(opt => opt.type === 'tag').map(opt => opt.propertyId),
      o: selectedOptions.value.filter(opt => opt.type === 'org').map(opt => opt.propertyId)
    }
  })
  const selectedOptionsPositionCount = ref(null)

  const fetchPositionCount = () => {
    if (selectedOptions.value.length)
      api.countInternshipPositions(selectedOptions.value)
        .then(r => selectedOptionsPositionCount.value = r.data)
    else
      selectedOptionsPositionCount.value = null
  }
</script>

<template>
  <section class="content">
    <h5>
      Hitta din praktikplats med
      <img src="/src/assets/logos/fit.svg" alt="Lian" />
    </h5>

    <SearchInput v-model="selectedOptions" @input="fetchPositionCount" />

    <router-link :to="{ path: 'platser', query: selectedOptionsAsQuery }">
      <button class="button">
        <span v-if="selectedOptionsPositionCount != null">
          Sök
          {{ selectedOptionsPositionCount }}
          plats<span v-show="selectedOptionsPositionCount !== 1">er</span>
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
