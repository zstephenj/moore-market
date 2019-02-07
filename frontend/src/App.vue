<template>
  <div id="app">

    <AddProduct />

  </div>
</template>

<script>
import AddProduct from './components/AddProduct.vue'

export default {
  name: 'app',
  components: {
    AddProduct
  },
  data() {
    return {
        
        }
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
