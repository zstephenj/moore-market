<template>
  <div class="container">
    <ProductSearchResult :products="searchResults" />
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import ProductSearchResult from './ProductSearchResult'

export default {
  name: 'SearchProducts',
  components: {
    ProductSearchResult
  },
  computed: {
    ...mapState('product', ['searchResults']),
    query() {
      console.log(this.$route.query.searchTerm)
      return this.$route.query.searchTerm
    },
  },
  methods: {
    ...mapActions('product', ['searchProducts']),
  },
  created() {
    this.searchProducts(this.query)
  }
}
</script>

<style>

</style>
