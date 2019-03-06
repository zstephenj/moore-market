<template>
    <div class='container-fluid moore-gradient moore-navy'>

        <div class='p-3'>
            <h2> Add Product </h2>
        </div>

        <product-form formType='add'> </product-form>

    </div>
</template>

<script>
import ProductForm from './ProductForm.vue'

export default {
    name: 'AddProduct',

    components: {
        ProductForm
    },
}
</script>

<style>

</style>
