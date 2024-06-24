<script setup lang="ts">
import InvoiceTable from '../../components/InvoiceTable.vue'
import Breadcrumb from '../../components/Breadcrumb.vue'
import ConfirmModal from '../../components/ConfirmModal.vue'
import { useRouter } from 'vue-router'
import { ref } from 'vue'
import type { Invoice } from '@/models/invoice';
import axios from 'axios'

const router = useRouter();

const breadCrumbs = ref([
    { name: 'Home', link: '/' },
    { name: 'Invoices', link: 'invoices' },
]);

const invoices = ref<Invoice[]>([]);

async function fetchInvoices() {
    // Fetch invoices from the API
    await axios.get<Invoice[]>('http://localhost:5234/api/Invoice')
        .then((response) => {
            invoices.value = response.data;
        })
        .catch((error) => {
            console.error(error);
        });
}

function goToCreateInvoice() {
    router.push('invoices/create');
}

fetchInvoices();
</script>
<template>
    <Breadcrumb :breadCrumbs="breadCrumbs" />
    <br>
    <div class="card">
        <div class="card-header">
            Invoices
            <button class="btn btn-sm btn-outline-primary float-end" @click="goToCreateInvoice">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-lg"
                    viewBox="0 0 16 16">
                    <path fill-rule="evenodd"
                        d="M8 2a.5.5 0 0 1 .5.5v5h5a.5.5 0 0 1 0 1h-5v5a.5.5 0 0 1-1 0v-5h-5a.5.5 0 0 1 0-1h5v-5A.5.5 0 0 1 8 2" />
                </svg>
                Add Invoice
            </button>
        </div>
        <div class="card-body">
            <InvoiceTable :invoices="invoices" @delete="(invoiceNumber) => {

            }" />
        </div>
        <ConfirmModal header="Delete Invoice" body="Are you sure you want to delete this invoice?"
            primaryButtonText="Delete" secondaryButtonText="Cancel"
            @primaryClick="() => { console.log('Primary Click') }"
            @secondaryClick="() => { console.log('Secondary Click') }" />
    </div>
</template>