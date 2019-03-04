<template>
    <div class='container-fluid'>

        <div>

            <product-category-form formType='edit'> </product-category-form>

        </div>

    </div>
</template>

<script>
import ProductCategoryForm from './ProductCategoryForm.vue'

export default {
    name: 'EditProductCategory',
    components: {
        ProductCategoryForm
    }
}
</script>

<style>

</style>