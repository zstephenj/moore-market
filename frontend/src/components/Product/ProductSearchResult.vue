<template>
  <div>
      <div class="product-listing" v-for="(product, idx) in products" :key="idx">
        <product-search-item :product="product"></product-search-item>
      </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import ProductSearchItem from './ProductSearchItem.vue'

export default {
    name: 'ProductSearchResult',
    props: ['products'],
    components: {
        ProductSearchItem
    },

    data() {
        return {    
            // temp, to be replaced by prop
            productIds: [1,2,3,4,5,66,77,88,99,111,222,333]
        }
    },
    computed: {
        numProductIds(){
            return this.productIds.length
        },
        ...mapGetters('product', [
            'getProductById'
        ])
    },
}
</script>

<style scoped>
.product-listing {
  display: inline-block;
  width: 33%;
}

</style>
