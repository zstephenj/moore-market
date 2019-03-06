<template>
  <div class="flex-container">
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
    computed: {
        ...mapGetters('product', [
            'getProductById'
        ])
    },
}
</script>

<style>
.product-listing {
  width: 33%;
}

</style>

<style scoped>
.flex-container {
  display: flex;
  flex-wrap: wrap;
}
</style>
