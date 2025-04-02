import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'

import { createMemoryHistory, createRouter } from 'vue-router'

import HomeView from './views/Home.vue'
import AboutView from './views/About.vue'

const routes = [
  { path: '/', component: HomeView },
  { path: '/om-lian', component: AboutView },
]

const router = createRouter({
  history: createMemoryHistory(),
  routes,
})

createApp(App)
  .use(router)
  .mount('#app')
