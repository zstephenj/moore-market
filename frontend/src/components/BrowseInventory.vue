<template>
  <div class="browse-farmer-products">
    <div class="farmer-details">
      <h3>{{ farmerProducts.username }}</h3>
    </div>
    <div class="farmer-products">
      <ul>
        <li v-for="product in farmerProducts.products" :key="product.id">
          {{ product.name }} | {{ product.description }}
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
import { mapActions, mapState } from 'vuex'

export default {
  name: 'BrowseInventory',
  props: {
    id: {
      type: [Number, String],
      required: true,
      validator(value) {
        return Number.isInteger(value)
      }
    },
  },
  computed: {
    ...mapState('farmer', ['farmerProducts']),
  },
  methods: {
    ...mapActions('farmer', ['getFarmerProducts']),
  },
  created() {
    this.getFarmerProducts(this.id)
  },
}
</script>

<style>

</style>
