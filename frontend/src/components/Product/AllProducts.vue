<template>
  <div class="container">
    <h2 class="header">Viewing all products</h2>
    <ProductSearchResult :products="allProducts" />
  </div>
</template>

<script>
import { mapState } from 'vuex'
import ProductSearchResult from './ProductSearchResult'

export default {
  name: 'AllProducts',
  components: {
    ProductSearchResult
  },
  computed: {
    ...mapState('product', ['allProducts']),
  },
}
</script>

<style>

</style>
