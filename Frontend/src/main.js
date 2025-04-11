import './assets/main.css'

import { createApp } from 'vue'
import { createHead } from '@unhead/vue/client'
import vSelect from 'vue-select'
import App from './App.vue'
import router from './router.js'

createApp(App)
  .component('v-select', vSelect)
  .use(router)
  .use(createHead({
    init: [
      {
        titleTemplate: t => t ? `${t} - Lian` : 'Lian',
        htmlAttrs: { lang: 'sv-SE' }
      }
    ]
  }))
  .mount('#app')
