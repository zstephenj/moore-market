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
import {mapActions, mapGetters, mapState} from 'vuex'

import FarmerProductItem from './FarmerProductItem.vue'
export default {
    name: 'FarmerProductDash',
    components: {
        FarmerProductItem
    },
    
    data() {
        return {
        }
    },

    computed: {
        ...mapState('product', [
            'allProducts'
        ]),
        ...mapState('user', [
            'currentUser'
        ]),
        ...mapGetters('product', [
            'getProductById'
        ])
    },

    methods: {
        ...mapActions('product', [
            'getAllProductsFromApi'
        ])
    },

    async created() {
        await this.getAllProductsFromApi()
        
    },
}
</script>

<style>

</style>
