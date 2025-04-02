<script setup>
  import { ref } from 'vue'
  import axios from 'axios'

  const api = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL
  })

  const showNavMenu = ref(true)
  const toggleNavMenu = () => showNavMenu.value = !showNavMenu.value
</script>

<template>
  <nav>
    <router-link to="/" class="logo">
      <img src="/src/assets/logo.svg" alt="Logga" />
    </router-link>

    <button @click="toggleNavMenu" class="toggle-nav-menu" />

    <menu class="nav-menu" :class="{ hidden: showNavMenu }">
      <button @click="toggleNavMenu" class="close" />

      <section @click="toggleNavMenu" class="nav-items">
        <router-link to="/">Hem</router-link>
        <router-link to="/om-lian">Om</router-link>
      </section>
    </menu>
  </nav>

  <main>
    <router-view />
  </main>
</template>

<style scoped>
  main {
    padding: 2rem;
  }

  nav {
    display: flex;
    justify-content: space-between;
    padding: 0 2rem;
    height: 8rem;
    background: #233326;
  }

  nav .logo {
    display: contents;
  }

  .nav-menu {
    display: flex;
  }

  .nav-items {
    display: contents;
  }

  .nav-items a {
    font-size: 2rem;
    color: var(--color-text);
  }

  .toggle-nav-menu, .nav-menu > .close {
    width: 4rem;

    background: none;
    border: none;

    cursor: pointer;
  }

  .toggle-nav-menu::after,
  .toggle-nav-menu::before {
    content: "";
    display: block;
    margin: 8pt;
    border-top: 6pt solid var(--c-primary-1);
  }

  .nav-menu > .close {
    position: absolute;
    top: 0;
    right: 0;
    margin: 1.5em 3em;
    width: 3em;
    height: 3em;
  }

  .nav-menu > .close::after,
              .close::before {
    content: "";
    position: absolute;
    width: 100%;
    height: 10%;

    background: var(--color-text);
    transform: rotate(45deg);
  }

  .nav-menu > .close::after {
    transform: rotate(135deg);
  }

  @media (min-width: 1024px) {
    .toggle-nav-menu {
      display: none;
    }

    .nav-menu > .close {
      display: none;
    }
  }

  @media (max-width: 1024px) {
    .nav-menu {
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      flex-direction: column;
      padding: 1em;

      background: var(--color-background-1);
    }

    .nav-menu.hidden {
      display: none;
    }
  }
</style>
