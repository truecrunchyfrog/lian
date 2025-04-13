<script setup>
  defineProps(['position'])
  defineEmits(['useTag'])
</script>

<template>
  <section class="card">
    <h1 class="org-title">
      {{ position.organization.name }}
    </h1>
    <div v-for="tag in position.tags" @click="$emit('useTag', tag.id)" class="tag">
      {{ tag.name }}
    </div>
  </section>
</template>

<style scoped>
  .card {
    display: inline-block;
    padding: 1em;
    background: var(--color-background-3);
  }

  .org-title {
    font-size: 1.8em;
  }

  .tag {
    padding: 0 .4em;
    margin: .4em;

    display: inline-block;

    background: var(--color-button-1);
    color: var(--color-button-text);
    border-radius: 3px;

    cursor: pointer;
  }
</style>
