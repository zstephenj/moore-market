<template>
  <div class="container">
    <ProductSearchResult :products="allProducts" />
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
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
