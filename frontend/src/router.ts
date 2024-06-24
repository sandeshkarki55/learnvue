import { createRouter, createWebHistory } from 'vue-router'
import InvoicesPage from './pages/Invoice/InvoicesPage.vue'
import CreateInvoicePage from './pages/Invoice/CreateInvoicePage.vue'
import HomePage from './pages/HomePage.vue'

const routes = [
    { path: '/invoices', component: InvoicesPage },
    { path: '/', component: HomePage },
    { path: '/invoices/create', component: CreateInvoicePage }
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router