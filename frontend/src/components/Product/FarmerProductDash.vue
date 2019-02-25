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
                    <th scope='col'>Edit/Remove</th>    
                </tr>
            </thead>
            <tbody>
                <template v-if='getProduct(productIds[0])'>
                    <farmer-product-item v-for='id in productIds' :key='id' :product='getProduct(id)'> </farmer-product-item>
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
        getProduct(id) {
            return this.getProductById(id)
        }
    },

    created() {
        // Fills store state with data from fakeJSON API rather than calling store actions to fill state.Product.AllProducts
        let getUrl = 'http://my-json-server.typicode.com/zstephenj/moore-market-fakejson2/products/'
        
        axios.get(getUrl)
        .then (res => this.$store.state.product.allProducts = res.data)
        .catch (error => console.log(error))

        
    },
}
</script>

<style>

</style>
