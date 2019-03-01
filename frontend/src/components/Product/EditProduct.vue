<template>
  <div class='container-fluid moore-gradient moore-navy'>

    <div class='p-3'>

      <h2> Edit Product </h2>

    </div>

    <product-form v-if='getProduct' :productToEdit='getProduct' :formType='formType'> </product-form>

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
      productId: parseInt(this.$route.params.id),
      formType: 'edit',
      product: []
    }
  },

  methods: {
    ...mapActions('product', [
      'getAllProductsFromTest'
    ]),

    
  },

  computed: {
      ...mapGetters('product', ['getProductById']),

      getProduct() {
            let gotProduct = this.getProductById(this.productId)
            return gotProduct
          }
    },

  created() {
        // Fills store state with data from fakeJSON API rather than calling store actions to fill state.Product.AllProducts
        let db = '2'
        this.getAllProductsFromTest(db)
        
    },
  
  mounted(){

  }
  
  
}
</script>

<style>

</style>
