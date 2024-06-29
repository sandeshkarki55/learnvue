<script setup lang="ts">
import { defineProps, defineEmits } from 'vue';

defineProps({
    header: { type: String, required: true },
    body: { type: String, required: true },
    primaryButtonText: { type: String, required: true },
    secondaryButtonText: { type: String, required: true },
});

const emit = defineEmits<{
    primaryClick: [];
    secondaryClick: [];
}>();

function primaryClick() {
    emit('primaryClick');
}

function secondaryClick() {
    emit('secondaryClick');
}


</script>

<template>
    <div class="modal fade" id="deleteModal" tabindex="-1" aria-labelledby="deleteModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="deleteModalLabel">{{ header }}</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    {{ body }}
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" @click="secondaryClick">
                        {{ secondaryButtonText }}
                    </button>
                    <button type="button" class="btn btn-primary" @click="primaryClick">
                        {{ primaryButtonText }}
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>