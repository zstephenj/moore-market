<template>
    <div class='container-fluid'>

        <div v-for='num in numProductIds' :key='num'>

            <div v-if='((num + 2) % 3) === 0'>

                <div class='row'>

                    <div class='col-md-3'>
                        <product-search-item :product='getProduct(productIds[num-1])'> </product-search-item>
                    </div>
                    <div class='col-md-3'>
                        <product-search-item v-if='(num + 1) <= numProductIds' :product='getProduct(productIds[num])'> </product-search-item>
                    </div>
                    <div class='col-md-3'>
                        <product-search-item v-if='(num + 2) <= numProductIds' :product='getProduct(productIds[num+1])'> </product-search-item>
                    </div>

                </div>

            </div>

        </div>

    </div>
</template>

<script>
import axios from 'axios'
import {mapGetters} from 'vuex'
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
        let getUrl = 'http://my-json-server.typicode.com/zstephenj/moore-market-fakejson2/products/'
        
        axios.get(getUrl)
        .then (res => this.$store.state.product.allProducts = res.data)
        .catch (error => console.log(error))

        
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
        getProduct(id) {

            return this.getProductById(id)
        }
        
    }

}
</script>

<style>

</style>
