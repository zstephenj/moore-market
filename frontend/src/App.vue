<template>
  <div id="app">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <img alt="Vue logo" src="./assets/logo.png">
    
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
