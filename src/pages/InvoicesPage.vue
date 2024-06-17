<script setup lang="ts">
import InvoiceTable from '../components/InvoiceTable.vue'

import { ref } from 'vue'

const invoices = ref([
    { number: 'INV-001', date: '2021-10-01', amount: 1000, status: 'Paid' },
    { number: 'INV-002', date: '2021-10-02', amount: 2000, status: 'Paid' },
    { number: 'INV-003', date: '2021-10-03', amount: 3000, status: 'Paid' },
    { number: 'INV-004', date: '2021-10-04', amount: 4000, status: 'Paid' },
    { number: 'INV-005', date: '2021-10-05', amount: 5000, status: 'Paid' },
    { number: 'INV-006', date: '2021-10-06', amount: 6000, status: 'Paid' },
    { number: 'INV-007', date: '2021-10-07', amount: 7000, status: 'Paid' },
    { number: 'INV-008', date: '2021-10-08', amount: 8000, status: 'Paid' },
    { number: 'INV-009', date: '2021-10-09', amount: 9000, status: 'Paid' },
    { number: 'INV-010', date: '2021-10-10', amount: 10000, status: 'Paid' },
]);

</script>
<template>
    <div class="card">
        <div class="card-header">
            Invoices
            <button class="btn btn-sm btn-outline-primary float-end">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-lg"
                    viewBox="0 0 16 16">
                    <path fill-rule="evenodd"
                        d="M8 2a.5.5 0 0 1 .5.5v5h5a.5.5 0 0 1 0 1h-5v5a.5.5 0 0 1-1 0v-5h-5a.5.5 0 0 1 0-1h5v-5A.5.5 0 0 1 8 2" />
                </svg>
                Add Invoice
            </button>
        </div>
        <div class="card-body">
            <InvoiceTable :invoices="invoices" @delete="(invoiceNumber) => { console.log(invoiceNumber) }" />
        </div>
    </div>
</template>