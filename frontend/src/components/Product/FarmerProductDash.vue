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
                <farmer-product-item v-for='product in farmerProducts' :key='product.id' :product='product'> </farmer-product-item>
            </tbody>
        </table>
    </div>
</template>

<script>
import FarmerProductItem from './FarmerProductItem.vue'
import { mapActions, mapState } from 'vuex'


export default {
    name: 'FarmerProductDash',
    components: {
        FarmerProductItem
    },
    
    data() {
        return {
            //temporary
            id: 2
        }
    },

    computed: {
        ...mapState('farmer', [
          'farmerProducts'
        ]),
    },

    methods: {
        ...mapActions('farmer', [
            'getFarmerProducts'
        ])
    },

    created() {
        // Fills store state with data from fakeJSON API rather than calling store actions to fill state.Product.AllProducts
        this.getFarmerProducts(this.id)       
    },
}
</script>

<style>

</style>
