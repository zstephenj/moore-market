<template>
    <div v-if='getProductById(productIds[0])' class='container-fluid'>

        <div v-for='num in numProductIds' :key='num'>

            <div v-if='((num + 2) % 3) === 0'>

                <div class='row'>

                    <div class='col-md-3'>
                        <product-search-item :product='getProductById(productIds[num-1])'> </product-search-item>
                    </div>

                    <div class='col-md-3'>
                        <product-search-item v-if='(num + 1) <= numProductIds' :product='getProductById(productIds[num])'> </product-search-item>
                    </div>
                    
                    <div class='col-md-3'>
                        <product-search-item v-if='(num + 2) <= numProductIds' :product='getProductById(productIds[num+1])'> </product-search-item>
                    </div>

                </div>

            </div>

        </div>

    </div>
</template>

<script>
import axios from 'axios'
import {mapGetters, mapActions} from 'vuex'
import ProductSearchItem from './ProductSearchItem.vue'

export default {
    name: 'ProductSearchResult',
    props: [/* 'productIds' */],
    components: {
        ProductSearchItem
    },

    data() {
        return {    
            // temp, to be replaced by prop
            productIds: [1,2,3,4,5,66,77,88,99,111,222,333]
        }
    },

    created() {
        // Fills store state with data from fakeJSON API rather than calling store actions to fill state.Product.AllProducts
        let db = '2'
        this.getAllProductsFromTest(db)
    },
    computed: {
        numProductIds(){
            return this.productIds.length
        },
        ...mapGetters('product', [
            'getProductById'
        ])
    },

    methods: {
        ...mapActions('product', [
            'getAllProductsFromTest'
        ])
    }

}
</script>

<style>

</style>
