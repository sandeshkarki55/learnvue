<script setup lang="ts">
import InvoiceTable from '../../components/InvoiceTable.vue'
import Breadcrumb from '../../components/Breadcrumb.vue'
import ConfirmModal from '../../components/ConfirmModal.vue'
import { useRouter } from 'vue-router'
import { ref } from 'vue'
import type { Invoice } from '@/models/invoice';

const router = useRouter();

const breadCrumbs = ref([
    { name: 'Home', link: '/' },
    { name: 'Invoices', link: 'invoices' },
]);

const invoices = ref<Invoice[]>([
    { number: 1, date: '2021-10-01', amount: 1000, status: 'paid', invoiceLines: [] },
    { number: 2, date: '2021-10-02', amount: 2000, status: 'paid', invoiceLines: [] },
    { number: 3, date: '2021-10-03', amount: 3000, status: 'paid', invoiceLines: [] },
    { number: 4, date: '2021-10-04', amount: 4000, status: 'paid', invoiceLines: [] },
    { number: 5, date: '2021-10-05', amount: 5000, status: 'paid', invoiceLines: [] },
    { number: 6, date: '2021-10-06', amount: 6000, status: 'paid', invoiceLines: [] },
    { number: 7, date: '2021-10-07', amount: 7000, status: 'paid', invoiceLines: [] },
    { number: 8, date: '2021-10-08', amount: 8000, status: 'paid', invoiceLines: [] },
    { number: 9, date: '2021-10-09', amount: 9000, status: 'paid', invoiceLines: [] },
    { number: 10, date: '2021-10-10', amount: 10000, status: 'paid', invoiceLines: [] },
]);

function goToCreateInvoice() {
    router.push('invoices/create');
}

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