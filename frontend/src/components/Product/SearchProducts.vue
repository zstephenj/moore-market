<template>
  <div class="container">
    <h2>Showing results for: {{ query }}</h2>
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
