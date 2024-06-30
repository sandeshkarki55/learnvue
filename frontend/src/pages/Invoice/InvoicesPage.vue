<script setup lang="ts">
import InvoiceTable from '../../components/InvoiceTable.vue'
import Breadcrumb from '../../components/Breadcrumb.vue'
import ConfirmModal from '../../components/ConfirmModal.vue'
import { useRouter } from 'vue-router'
import { ref } from 'vue'
import type { Invoice } from '@/models/invoice';
import axios from 'axios'
import { Modal } from 'bootstrap'

const router = useRouter();

const breadCrumbs = ref([
    { name: 'Home', link: '/' },
    { name: 'Invoices', link: 'invoices' },
]);

const invoices = ref<Invoice[]>([]);
const toDeleteId = ref('');

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

let modal: Modal | null = null;

function getModal() {
    if (!modal) {
        modal = new Modal('#deleteModal');
    }

    return modal;
}


function showDeleteModal(id: string | undefined) {
    if (!id) {
        return;
    }

    toDeleteId.value = id;
    getModal().show();
}

async function deleteInvoice() {
    await axios.delete(`http://localhost:5234/api/Invoice/${toDeleteId.value}`)
        .then(() => {
            getModal().hide();
            fetchInvoices();
        })
        .catch((error) => {
            console.error(error);
        });
}

async function submitInvoice(id: string | undefined) {
    if (!id) {
        return;
    }

    await axios.put(`http://localhost:5234/api/Invoice/${id}/submit`)
        .then(() => {
            fetchInvoices();
        })
        .catch((error) => {
            console.error(error);
        });
}

async function markAsPaid(id: string | undefined) {
    if (!id) {
        return;
    }

    await axios.put(`http://localhost:5234/api/Invoice/${id}/mark-as-paid`)
        .then(() => {
            fetchInvoices();
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
                <i class="bi bi-plus"></i>
                Add Invoice
            </button>
        </div>
        <div class="card-body">
            <InvoiceTable :invoices="invoices" @delete="showDeleteModal" @submit="submitInvoice" @mark-as-paid="markAsPaid" />
        </div>

        <ConfirmModal header="Delete Invoice" body="Are you sure you want to delete this invoice?"
            primaryButtonText="Delete" secondaryButtonText="Cancel" @primaryClick="deleteInvoice"
            @secondaryClick="() => toDeleteId = ''" />
    </div>
</template>