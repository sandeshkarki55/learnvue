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
const toSubmitId = ref('');
const toMarkAsPaidId = ref('');

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

function getModal(id: 'deleteModal' | 'submitModal' | 'markAsPaidModal') {
    if (!modal) {
        modal = new Modal(`#${id}`);
    }

    return modal;
}

function showDeleteModal(id: string | undefined) {
    if (!id) {
        return;
    }

    toDeleteId.value = id;
    getModal('deleteModal').show();
}

async function deleteInvoice() {
    await axios.delete(`http://localhost:5234/api/Invoice/${toDeleteId.value}`)
        .then(() => {
            getModal('deleteModal').hide();
            fetchInvoices();
        })
        .catch((error) => {
            console.error(error);
        });
}


function showSubmitModal(id: string | undefined) {
    if (!id) {
        return;
    }

    toSubmitId.value = id;
    getModal('submitModal').show();
}

async function submitInvoice() {
    if (!toSubmitId.value) {
        return;
    }

    await axios.put(`http://localhost:5234/api/Invoice/${toSubmitId.value}/submit`)
        .then(() => {
            getModal('submitModal').hide();
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
            <InvoiceTable :invoices="invoices" @delete="showDeleteModal" @submit="showSubmitModal"
                @mark-as-paid="markAsPaid" />
        </div>

        <ConfirmModal id="deleteModal" header="Delete Invoice" body="Are you sure you want to delete this invoice?"
            primaryButtonText="Delete" secondaryButtonText="Cancel" @primaryClick="deleteInvoice"
            @secondaryClick="() => toDeleteId = ''" />


        <ConfirmModal id="submitModal" header="Submit Invoice" body="Are you sure you want to submit this invoice?"
            primaryButtonText="Submit" secondaryButtonText="Cancel" @primaryClick="submitInvoice"
            @secondaryClick="() => toSubmitId = ''" />
    </div>
</template>