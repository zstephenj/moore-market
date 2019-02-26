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
                <template v-if='getProductById(productIds[0])'>
                    <farmer-product-item v-for='id in productIds' :key='id' :product='getProductById(id)'> </farmer-product-item>
                </template>
            </tbody>
        </table>
    </div>
</template>

<script>
import FarmerProductItem from './FarmerProductItem.vue'

import {mapActions, mapGetters} from 'vuex'
import axios from 'axios'

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
            'getAllProductsFromTest'
        ])
    },

    created() {
        // Fills store state with data from fakeJSON API rather than calling store actions to fill state.Product.AllProducts
        let db = '2'
        this.getAllProductsFromTest(db)
        
    },
}
</script>

<style>

</style>
