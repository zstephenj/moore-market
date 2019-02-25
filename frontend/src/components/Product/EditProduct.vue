<template>
  <div class='container-fluid moore-gradient moore-navy'>
    <p> {{productId}} </p>
    <p> {{}} </p>
    <product-form v-if='productId' :productToEdit='getProductById(productId)' :productId='productId' :formType='formType'> </product-form>

  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'

import ProductForm from './ProductForm.vue'

export default {
  name: 'EditProduct',

  components: {
    ProductForm
  },

  props: [],

  data() {
    return {
      productId: parseInt(this.$route.params.id),
      formType: 'edit',
      product: 'nochangeyet'
    }
  },

  methods: {

  },

  computed: {
      ...mapGetters('product', ['getProductById']),
      
    },

  created() {
        // Fills store state with data from fakeJSON API rather than calling store actions to fill state.Product.AllProducts
        let getUrl = 'http://my-json-server.typicode.com/zstephenj/moore-market-fakejson2/products/'
        
        axios.get(getUrl)
        .then (res => this.$store.state.product.allProducts = res.data)
        .catch (error => console.log(error))

        
    },
  
  mounted(){
    console.log (this.product)  
    this.product = this.getProductById(this.productId)
    console.log (this.product)
  }
  
  
}
</script>

<style>

</style>
