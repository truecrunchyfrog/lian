<script setup>
  defineProps(['term'])
  defineEmits(['use-tag'])
</script>

<template>
  <div class="internship-term-card">
    <summary class="org-title">
      {{ term.organization.name }}
    </summary>
    <router-link v-for="tag in term.tags" @click="$emit('use-tag', tag.id)" class="tag" append :to="{ query: { ...$route.query, t: [...$route.query.t.filter(i => i != tag.id), tag.id] } }">
      {{ tag.name }}
    </router-link>
  </div>
</template>

<style scoped>
  .internship-term-card {
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
  }
</style>
