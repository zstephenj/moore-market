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
                <template v-if='this.currentUser.products.length > 0'>
                    <farmer-product-item v-for='product of this.currentUser.products' :key='product.id' :product='product'> </farmer-product-item>
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
        
        
    },

    methods: {
        ...mapActions('product', [
            'getAllProductsFromApi'
        ]),
        ...mapActions('user', [
            'getUserProducts'
        ]),
        

    },

    async created() {
        await this.getAllProductsFromApi()
        await this.getUserProducts(this.currentUser.id)
        
    },
}
</script>

<style>

</style>
