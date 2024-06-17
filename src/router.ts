import { createMemoryHistory, createRouter } from 'vue-router'
import InvoicesPage from './pages/InvoicesPage.vue'


const routes = [
  { path: '/', component: InvoicesPage },
]

const router = createRouter({
  history: createMemoryHistory(),
  routes,
})

export default router