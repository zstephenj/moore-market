<template>
    <div class='container-fluid moore-gradient moore-navy'>
        <table class='table'>
            <thead>
                <tr>
                    <th scope='col'>ID</th>
                    <th scope='col'>Name</th>
                    <th scope='col'>Category</th>
                    <th scope='col'>Price</th>
                    <th scope='col'>Quantity</th>
                    <th scope='col'>Edit/Delete</th>    
                </tr>
            </thead>
            <tbody>
                <template v-if='productIds.some(getProductById)'>
                    <farmer-product-item v-for='id in productIds' :key='id' :product='getProductById(id)'> </farmer-product-item>
                </template>
            </tbody>
        </table>
    </div>
</template>

<script>
import {mapActions, mapGetters} from 'vuex'

import FarmerProductItem from './FarmerProductItem.vue'
export default {
    name: 'FarmerProductDash',
    components: {
        FarmerProductItem
    },
    
    data() {
        return {
            productIds: [1,2,3,4,5,66,77,88,99,111,222,333]
        }
    },

    computed: {
        ...mapGetters('product', [
            'getProductById'
        ])
    },

    methods: {
        ...mapActions('product', [
            'getAllProductsFromApi'
        ])
    },

    created() {
        this.getAllProductsFromApi()
        
    },
}
</script>

<style>

</style>
