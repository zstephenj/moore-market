<template>
  <div class="cart">
    <h2>Shopping Cart</h2>
    <table class="table">
      <thead>
        <tr>
          <th>Product Name</th>
          <th>Price</th>
          <th>Quantity</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="product in cart" :key="product.id">
          <td>{{ product.name }}</td>
          <td>{{ product.price }}</td>
          <td>{{ product.quantity }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { mapState } from 'vuex'

export default {
  name: 'ShoppingCart',
  computed: {
    ...mapState('product', ['cart']),
  },
}
</script>

<style>

</style>
