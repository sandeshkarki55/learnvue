<script setup lang="ts">
import InvoiceTable from '../../components/InvoiceTable.vue'
import Breadcrumb from '../../components/Breadcrumb.vue'
import Invoice from '../../models/invoice'

import { ref, defineProps } from 'vue'

const invoice = ref({
    number: '001',
    date: '2021-10-01',
    amount: 1000,
    status: 'Paid',
    invoiceLines: [
    { description: 'Item 1', quantity: 1, price: 1000 },
    { description: 'Item 2', quantity: 2, price: 2000 },
    { description: 'Item 3', quantity: 3, price: 3000 }
]});

const breadCrumbs = ref([
    { name: 'Home', link: '/' },
    { name: 'Invoices', link: '/invoices' },
    { name: 'Create Invoice', link: '/invoices/create' }
]);

function addLine() {
    console.log('Add Line');
    invoice.value.invoiceLines.push({ description: '', quantity: 0, price: 0 });

    console.log(invoice.value.invoiceLines);
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
                        v-bind:value="invoice.number">
                </div>
                <div class="w-100 d-none d-md-block"></div>
                <div class="col-6">
                    <label for="invoiceAmount" class="form-label">Amount</label>
                    <input type="number" class="form-control" id="invoiceAmount" v-bind:value="invoice.amount"
                        placeholder="Enter invoice Amount ($0.00)">
                </div>
                <div class="w-100 d-none d-md-block"></div>
                <div class="col-6">
                    <label for="invoiceDate" class="form-label">Date</label>
                    <input type="date" class="form-control" id="invoiceDate" placeholder="Enter invoice date"
                        v-bind:value="invoice.date">
                </div>
                <div class="w-100 d-none d-md-block"></div>
                <div class="col-6">
                    <label for="inputStatus" class="form-label">Status</label>
                    <select id="inputStatus" class="form-select" v-bind:value="invoice.status">
                        <option selected>Choose...</option>
                        <option>New</option>
                        <option>Paid</option>
                        <option>Unpaid</option>
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
                            <tr v-for="invoiceLine in invoice.invoiceLines">
                                <td>
                                    <input type="text" class="form-control" id="item" placeholder="Enter item"
                                        v-bind:value="invoiceLine.description">
                                </td>
                                <td>
                                    <input type="number" class="form-control" id="quantity" placeholder="Enter quantity"
                                        v-bind:value="invoiceLine.quantity">
                                </td>
                                <td>
                                    <input type="number" class="form-control" id="unitPrice"
                                        placeholder="Enter unit price" v-bind:value="invoiceLine.price">
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