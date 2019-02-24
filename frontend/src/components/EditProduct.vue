<template>
  <div class="edit">

  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  name: 'EditProduct',
  props: {
    productId: {
      type: Number,
      required: true,
    },
  },
  created() {
    this.product = this.getProductById(productId)
  },
  methods: {
    ...mapGetters('product', ['getProductById']),
    ...mapActions('product', )
  },
  data() {
    return {
      product: null,
    }
  }
}
</script>

<style>

</style>
