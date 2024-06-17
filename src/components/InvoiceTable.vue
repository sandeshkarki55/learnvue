<script setup lang="ts">
import { ref, defineProps, defineEmits } from 'vue';

defineProps(['invoices']);
defineEmits(['delete']);


function currency(amount: number) {
    return new Intl.NumberFormat('en-AU', {
        style: 'currency',
        currency: 'AUD'
    }).format(amount);
}

</script>

<template>
    <table class="table table-light table-striped  table-bordered">
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
            <tr v-for="invoice in invoices">
                <td>{{ invoice.number }}</td>
                <td>{{ invoice.date }}</td>
                <td>{{ currency(invoice.amount) }}</td>
                <td>{{ invoice.status }}</td>
                <td>
                    <button class="btn btn-primary">Print</button>
                    <button class="btn btn-success mx-3">Edit</button>
                    <button class="btn btn-danger" @click="$emit('delete', invoice.number)">Delete</button>
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