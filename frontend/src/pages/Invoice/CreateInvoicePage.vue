<script setup lang="ts">
import axios from 'axios';
import Breadcrumb from '../../components/Breadcrumb.vue'
import type { Invoice } from '../../models/invoice'

import { ref } from 'vue'
import { useRouter } from 'vue-router';

const router = useRouter();

const invoice = ref<Invoice>({
    number: 1,
    date: '2021-10-01',
    amount: 0,
    status: 'paid',
    invoiceLines: [
        { description: '', quantity: 1, price: 0 }
    ]
});

const breadCrumbs = ref([
    { name: 'Home', link: '/' },
    { name: 'Invoices', link: '/invoices' },
    { name: 'Create Invoice', link: '/invoices/create' }
]);

function addLine() {
    invoice.value.invoiceLines.push({ description: '', quantity: 1, price: 0 });
}

function getTotal() {
    let total = 0;
    invoice.value.invoiceLines.forEach((line) => {
        total += line.price * line.quantity;
    });
    return total;
}

async function createInvoice() {
    await axios.post('http://localhost:5234/api/Invoice', invoice.value)
        .then((response) => {
            router.push('/invoices');
        })
        .catch((error) => {
            console.error(error);
        });
}
</script>
<template>
    <Breadcrumb :breadCrumbs="breadCrumbs" />
    <br>
    <div class="card">
        <div class="card-header">
            Create Invoice
        </div>
        <div class="card-body">
            <form class="row g-3">
                <div class="col-6">
                    <label for="invoiceNumber" class="form-label fw-bold">Number</label>
                    <input type="number" class="form-control" id="invoiceNumber" placeholder="Enter invoice number"
                        v-model="invoice.number" required disabled readonly>
                </div>
                <div class="w-100 d-none d-md-block"></div>
                <div class="col-6">
                    <label for="invoiceAmount" class="form-label fw-bold">Amount</label>
                    <input type="number" class="form-control" id="invoiceAmount" :value="getTotal()"
                        placeholder="Enter invoice Amount ($0.00)" disabled readonly>
                </div>
                <div class="w-100 d-none d-md-block"></div>
                <div class="col-6">
                    <label for="invoiceDate" class="form-label fw-bold">Date</label>
                    <input type="date" class="form-control" id="invoiceDate" placeholder="Enter invoice date"
                        v-model="invoice.date">
                </div>
                <div class="w-100 d-none d-md-block"></div>
                <div class="col-6">
                    <label for="inputStatus" class="form-label fw-bold">Status</label>
                    <select id="inputStatus" class="form-select" v-model="invoice.status">
                        <option selected>Choose...</option>
                        <option value="new">New</option>
                        <option value="paid">Paid</option>
                        <option value="unpaid">Unpaid</option>
                    </select>
                </div>
                <div class="w-100 d-none d-md-block"></div>
                <div class="col-md-12">
                    <label for="invoiceLines" class="form-label fw-bold">Invoice Lines</label>
                    <div class="btn btn-primary float-end" @click="addLine"><i class="bi-plus-lg"></i></div>

                    <table class="table table-light table-striped table-bordered mt-4">
                        <thead>
                            <tr>
                                <th>Item</th>
                                <th>Quantity</th>
                                <th>Unit Price</th>
                                <th>Total</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="invoiceLine in invoice.invoiceLines" v-bind:key="invoiceLine.id">
                                <td>
                                    <input type="text" class="form-control" id="description" placeholder="Enter item"
                                        v-model="invoiceLine.description">
                                </td>
                                <td>
                                    <input type="number" class="form-control" id="quantity" placeholder="Enter quantity"
                                        v-model="invoiceLine.quantity">
                                </td>
                                <td>
                                    <input type="number" class="form-control" id="unitPrice"
                                        placeholder="Enter unit price" v-model="invoiceLine.price">
                                </td>
                                <td>
                                    <input type="number" class="form-control" readonly id="total"
                                        placeholder="Enter total" :value="invoiceLine.price * invoiceLine.quantity">
                                </td>
                                <td>
                                    <button class="btn btn-outline-danger"><i class="bi-trash"></i></button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="col-12">
                    <div class="float-end">
                        <button type="button" class="btn btn-success" @click="createInvoice"><i class="bi-floppy"></i>
                            Save</button>
                        <button type="button" class="btn btn-outline-secondary ms-3"
                            @click="router.push('/invoices')"><i class="bi-x-lg"></i>
                            Cancel</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>