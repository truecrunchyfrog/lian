import { createWebHistory, createRouter } from 'vue-router'

import PageNotFoundView from './views/PageNotFound.vue'
import HomeView from './views/Home.vue'
import ResultsView from './views/Results.vue'
import AboutView from './views/About.vue'

const routes = [
  { path: '/', component: HomeView },
  { path: '/platser', component: ResultsView },
  { path: '/om-lian', component: AboutView },

  { path: '/:pathMatch(.*)*', component: PageNotFoundView }
]

export default createRouter({
  history: createWebHistory(),
  routes
})
