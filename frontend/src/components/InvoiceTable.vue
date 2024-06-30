<script setup lang="ts">
import type { Invoice } from '@/models/invoice';
import { defineProps, defineEmits } from 'vue';

defineProps({
    invoices: { type: Array as () => Invoice[], required: true }
});

defineEmits<{
    delete: [string | undefined];
    submit: [string | undefined];
    markAsPaid: [string | undefined];
}>();

function currency(amount: number) {
    return new Intl.NumberFormat('en-AU', {
        style: 'currency',
        currency: 'AUD'
    }).format(amount);
}

</script>

<template>
    <table class="table table-light table-striped table-bordered">
        <thead>
            <tr>
                <th>Number</th>
                <th>Invoice Date</th>
                <th>Amount</th>
                <th>Status</th>
                <th>Action</th>
            </tr>
        </thead>

        <tbody>
            <tr v-for="invoice in invoices" v-bind:key="invoice.id">
                <td>{{ invoice.number }}</td>
                <td>{{ invoice.date }}</td>
                <td>{{ currency(invoice.amount) }}</td>
                <td>{{ invoice.status }}</td>
                <td>
                    <button v-if="invoice.status == 'Draft'" class="btn btn-info me-3 text-white"
                        @click="$emit('submit', invoice.id)"><i class="bi bi-send"></i> Submit</button>
                    <button v-if="invoice.status == 'Pending'" class="btn btn-info me-3 text-white"
                        @click="$emit('markAsPaid', invoice.id)"><i class="bi bi-send"></i> Mark as Paid</button>
                    <button class="btn btn-outline-primary"> <i class="bi bi-printer"></i> Print</button>
                    <button class="btn btn-outline-success mx-3"><i class="bi bi-pencil-square"></i> Edit</button>
                    <button class="btn btn-outline-danger" @click="$emit('submit', invoice.id)"><i
                            class="bi bi-trash"></i> Delete</button>
                </td>
            </tr>
        </tbody>
    </table>

    <nav aria-label="Page navigation example ">
        <ul class="pagination justify-content-center">
            <li class="page-item"><a class="page-link" href="#">Previous</a></li>
            <li class="page-item"><a class="page-link" href="#">1</a></li>
            <li class="page-item"><a class="page-link" href="#">2</a></li>
            <li class="page-item"><a class="page-link" href="#">3</a></li>
            <li class="page-item"><a class="page-link" href="#">Next</a></li>
        </ul>
    </nav>
</template>