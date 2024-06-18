<script setup lang="ts">
import Breadcrumb from '../../components/Breadcrumb.vue'
import type { Invoice } from '../../models/invoice'

import { ref } from 'vue'

const invoice = ref<Invoice>({
    number: 1,
    date: '2021-10-01',
    amount: 1000,
    status: 'paid',
    invoiceLines: [
        { description: '', quantity: 0, price: 0 }
    ]
});

const breadCrumbs = ref([
    { name: 'Home', link: '/' },
    { name: 'Invoices', link: '/invoices' },
    { name: 'Create Invoice', link: '/invoices/create' }
]);

function addLine() {
    invoice.value.invoiceLines.push({ description: '', quantity: 0, price: 0 });
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
                    <label for="invoiceNumber" class="form-label">Invoice Number</label>
                    <input type="number" class="form-control" id="invoiceNumber" placeholder="Enter invoice number"
                        v-model="invoice.number">
                </div>
                <div class="w-100 d-none d-md-block"></div>
                <div class="col-6">
                    <label for="invoiceAmount" class="form-label">Amount</label>
                    <input type="number" class="form-control" id="invoiceAmount" v-model="invoice.amount"
                        placeholder="Enter invoice Amount ($0.00)">
                </div>
                <div class="w-100 d-none d-md-block"></div>
                <div class="col-6">
                    <label for="invoiceDate" class="form-label">Date</label>
                    <input type="date" class="form-control" id="invoiceDate" placeholder="Enter invoice date"
                        v-model="invoice.date">
                </div>
                <div class="w-100 d-none d-md-block"></div>
                <div class="col-6">
                    <label for="inputStatus" class="form-label">Status</label>
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
                    <div class="btn btn-primary float-end" @click="addLine">Add </div>

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
                            <tr v-for="invoiceLine in invoice.invoiceLines" v-bind:key="invoiceLine.description">
                                <td>
                                    <input type="text" class="form-control" id="item" placeholder="Enter item"
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
                                    <input type="number" class="form-control disabled" id="total"
                                        placeholder="Enter total" :value="invoiceLine.price * invoiceLine.quantity">
                                </td>
                                <td>
                                    <button class="btn btn-danger">Delete</button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="col-6">
                    <button type="submit" class="btn btn-primary">Save</button>
                </div>
            </form>
        </div>
    </div>
</template>