<template>
  <div class='container-fluid'>

    <product-form :product='product'> </product-form>
    
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

import ProductForm from './ProductForm.vue'

export default {
  name: 'EditProduct',

  components: {
    ProductForm
  },

  props: [],

  data() {
    return {
      productId: this.$route.params.id,
      product: null,
    }
  },

  created() {
    let getUrl = 'http://my-json-server.typicode.com/zstephenj/moore-market-fakejson2/products/'
        
        axios.get(getUrl)
        .then (res => this.$store.state.product.allProducts = res.data)
        .catch (error => console.log(error))
    console.log(productId)
    this.product = this.getProductById(productId)
  },

  methods: {
    ...mapGetters('product', ['getProductById']),
    ...mapActions('product', ['editProduct'])
  },

  
}
</script>

<style>

</style>
