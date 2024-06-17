<script setup lang="ts">
import NavBar from './components/NavBar.vue'
import Breadcrumb from './components/Breadcrumb.vue'

import { ref } from 'vue'

const breadCrumbs = ref([
	{ name: 'Home', link: '/Home' },
	{ name: 'Invoices', link: '' },
]);
</script>

<template>
	<div>
		<NavBar />
		<br>
		<Breadcrumb :breadCrumbs="breadCrumbs" />
		<br>		
		<RouterView />
	</div>
</template>

<style scoped></style>
