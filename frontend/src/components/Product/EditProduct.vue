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
      'getAllProductsFromApi'
    ]),

    
  },

  computed: {
      ...mapGetters('product', ['getProductById']),

      getProduct() {
            let gotProduct = this.getProductById(this.productId)
            return gotProduct
          }
    },

  async created() {
        await this.getAllProductsFromApi()
        
    },
  
  mounted(){

  }
  
  
}
</script>

<style>

</style>
