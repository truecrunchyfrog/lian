<script setup>
  import { ref } from 'vue'
  import * as api from '../components/api.js'

  const organizations = ref([])

  api.getOrganizations()
    .then(r => organizations.value = r.data)
</script>

<template>
  Sök LIA

  <button class="button">button</button>

  <ul>
    <li v-for="org in organizations">
      {{ org }}
    </li>
  </ul>
</template>
