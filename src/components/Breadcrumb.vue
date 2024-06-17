<script setup lang="ts">
import { defineProps } from 'vue';

defineProps(['breadCrumbs']);

</script>


<template>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li v-for="breadcrumb in breadCrumbs" :class="['breadcrumb-item', breadcrumb.link==''?'active':'']">
                <RouterLink :to="breadcrumb.link">{{
                    breadcrumb.name }}</RouterLink>
            </li>
        </ol>
    </nav>
</template>