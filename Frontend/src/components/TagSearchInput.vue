<script setup>
  import { ref } from 'vue'

  const tags = ref(null)
  const selectedTags = ref([])

  const fetchTags = () => {
    if (!tags.value) {
      loading.value = true
      api.getTags().then(r => {
        tags.value = r.data
        loading.value = false
      })
    }
  }
</script>

<template>
  <v-select
      multiple
      label="name"
      v-model="selectedTags"
      :options="tags || []"
      @open="fetchTags"
      @option:selected="fetchTermCount"
      @option:deselected="fetchTermCount"
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
      <input v-bind="attributes" v-on="events" class="input" style="background: none; border:
      none; outline: none;" />
    </template>

    <template #option="{ name, termsWithTag }">
      <div class="select-option">
        <h3 class="select-option">
          {{ name }}
        </h3>
        <h5>
          {{ termsWithTag }}
          plats<span v-show="termsWithTag !== 1">er</span>
        </h5>
      </div>
    </template>

    <template #selected-option-container="{ option, deselect, multiple, disabled }">
      <button @click="deselect(option)" class="button" style="margin: 0 .1em; padding: .2em .5em;">
        {{ option.name }}
      </button>
    </template>

    <template #no-options><span></span></template>
  </v-select>
</template>

<style>
  .vs__dropdown-toggle {
    border: none;
  }

  .vs__selected {
    background: var(--color-button-2);
    border: none;
  }

  .vs__dropdown-menu {
    background: var(--color-background-1);
  }
</style>
