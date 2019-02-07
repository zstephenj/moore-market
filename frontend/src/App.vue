<template>
  <div id="app">
    <router-view></router-view>
    
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    
    <img alt="Vue logo" src="./assets/logo.png">
    <AddProduct v-bind:categories="addProductFormCategories" />
  </div>
</template>

<script>
import AddProduct from './components/AddProduct.vue'

export default {
  name: 'app',
  components: {
    AddProduct,
  },
  data() {
    return {
        addProductFormCategories: [{id:1, name:'Category 1'}, {id:2, name:'Category 2'}, {id:3, name:'Category 3'} ]
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
