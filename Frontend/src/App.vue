<script setup>
  import NavigationMenu from './components/NavigationMenu.vue'
</script>

<template>
  <NavigationMenu />

  <main>
    <router-view />
  </main>
</template>

<style scoped>
  main {
    padding: 2rem;
  }
</style>
