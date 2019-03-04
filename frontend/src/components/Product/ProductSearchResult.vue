<template>
    <div v-if='getProductById(productIds[0])' class='container-fluid'>


        <div class='row'>

            <div v-for='productId in productIds' :key='productId' class='col-md-4'>
                <product-search-item :product='getProductById(productId)'> </product-search-item>
            </div>

        </div>


    </div>
</template>

<script>
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

    async created() {
        await this.getAllProductsFromApi()
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
    }

}
</script>

<style>

</style>
