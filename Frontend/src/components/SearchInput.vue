<script setup>
  import { ref } from 'vue'
  import * as api from '../components/api.js'
  import 'vue-select/dist/vue-select.css'

  defineEmits(['input'])

  const selected = defineModel({ required: true })

  const queryOptions = ref(null)
  const loading = ref(false)

  const fetchQueryOptions = () => {
    if (queryOptions.value) return

    loading.value = true
    api.getSearchQueryOptions().then(r => {
      queryOptions.value = r.data
      loading.value = false
    })
  }

  if (selected.value.length)
    fetchQueryOptions()
</script>

<template>
  <v-select
      multiple
      v-model="selected"
      :reduce="option => { return { propertyId: option.propertyId, type: option.type } }"
      :options="queryOptions || []"
      @open="fetchQueryOptions"
      @input="$emit('input')"
      @option:selected="$emit('input')"
      @option:deselected="$emit('input')"
      :loading="loading"
      :close-on-select="false"
      placeholder="Vad vill du ha för LIA?"
      class="input">
    <template #list-header>
      <li style="text-align: center;">
        Vad vill du praktisera med?
      </li>
    </template>

    <template #search="{ attributes, events }">
      <input v-bind="attributes" v-on="events" class="input" style="background: none; border: none; outline: none;" />
    </template>

    <template #option="{ propertyId, type, label, availablePositions, imageHref }">
      <div class="option">
        <img
        src="data:image/svg+xml,%3csvg%20version='1.2'%20xmlns='http://www.w3.org/2000/svg'%20viewBox='0%200%20512%20184'%20width='512'%20height='184'%3e%3ctitle%3ev4_short_L%3c/title%3e%3cstyle%3e%20.s0%20{%20fill:%20%2320b33d%20}%20%3c/style%3e%3cpath%20id='lian'%20class='s0'%20d='m31.4%2096.3h-31.3v-88.5l31.3-6.8zm88.4%2014.7h-31.3v-67.1h31.3zm51.1%2024.4q0-15.3%208.1-28.3%208.2-13.2%2026.9-21.4%2018.8-8.5%2050.4-9.5l21.5-0.7v22.1l-20.1%202.1q-22.1%202-34.1%207.1-11.9%205.1-16.3%2011.9-4.4%206.5-4.4%2014%200%2010.5%206.1%2016.7%206.5%205.7%2017%205.7%2014.7%200%2028.3-7.4%2013.9-7.5%2025.9-20.8v24.5q-9.9%2013.6-25.9%2023.2-16%209.1-35.1%209.1-12.6%200-23.8-5.7-10.9-5.8-17.7-16.7-6.8-10.9-6.8-25.9zm16-89.2l-10.9-26.6q11.9-7.4%2029.3-12.5%2017.3-5.5%2033-5.5%2019.4%200%2034.7%207.5%2015.3%207.5%2024.2%2022.8%209.2%2015%209.2%2037.8v69.1q0%207.2%200.3%2013.3%200.7%205.8%202.1%2013.3l2.7%2014.9h-29.3l-7.2-34v-72.9q0-22.4-10.5-32-10.6-9.8-29.3-9.8-13.6%200-25.2%204-11.6%204.1-23.1%2010.6zm176.7-26.2l-2.8-15h29.3l7.2%2034.1v141.2h-31.4v-133.8q0-7.1-0.6-12.9-0.4-6.1-1.7-13.6zm28.6%2038.5v-24.6q11.2-14.3%2026.5-23.1%2015.3-9.2%2032.4-9.2%2017.3%200%2030.9%207.8%2014%207.9%2021.8%2023.5%208.2%2015.7%208.2%2039.9v107.5h-31.3v-103.5q0-16-5.1-25.8-4.8-10.2-13.3-15-8.5-4.8-19.4-4.8-13.6%200-26.6%207.2-12.9%207.1-24.1%2020.1zm-272.4%2067.8v24.5q-11.2%2014.3-26.5%2023.1-15.3%209.2-32.4%209.2-17.3%200-30.9-7.8-14-7.9-21.8-23.5-8.2-15.7-8.2-39.8v-16.7h31.3v12.6q0%2016%205.1%2025.8%204.8%2010.3%2013.3%2015%208.5%204.8%2019.4%204.8%2013.6%200%2026.6-7.2%2012.9-7.1%2024.1-20zm-15.3-94.8c-8.6%200-15.5-6.9-15.5-15.5%200-8.6%206.9-15.5%2015.5-15.5%208.6%200%2015.5%206.9%2015.5%2015.5%200%208.6-6.9%2015.5-15.5%2015.5z'/%3e%3c/svg%3e"
        class="thumbnail" />
        <span class="label">
          {{ label }}
        </span>
        <span class="metadata">
          {{ availablePositions }}
          plats<span v-show="availablePositions !== 1">er</span>
        </span>
      </div>
    </template>

    <template #selected-option-container="{ option, deselect, multiple, disabled }">
      <button v-show="option.label != null" @click="deselect(option)" class="button" style="margin: 0 .1em; padding: .2em .5em;">
        {{ option.label }}
      </button>
    </template>

    <template #no-options><span></span></template>
  </v-select>
</template>

<style scoped>
  .option {
    display: grid;
    grid-template-columns:
      2em 1fr;
    grid-template-rows: auto;
    grid-template-areas:
      "thumbnail label"
      "thumbnail metadata";
    padding: .3em;
  }

  .thumbnail, .label, .metadata {
    margin: 0 .5em;
  }

  .thumbnail {
    grid-area: "thumbnail";
    width: 100%;
    margin: auto;
  }

  .label {
    grid-area: "label";
    font-size: 1.4em;
  }

  .metadata {
    grid-area: "metadata";
    font-size: .8em;
  }
</style>

<style>
  .vs__dropdown-toggle {
    border: none !important;
  }

  .vs__selected {
    background: var(--color-button-2);
    border: none;
  }

  .vs__dropdown-menu {
    background: var(--color-background-1);
  }
</style>
