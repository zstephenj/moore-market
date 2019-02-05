<template>
  <div id="app">
    <router-view></router-view>
    
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
    
    <img alt="Vue logo" src="./assets/logo.png">
    <AddProduct v-bind:categories="addProductFormCategories" />
  </div>
</template>

<script>
import AddProduct from './components/AddProduct.vue'
import { ProductItem } from './components/ProductItem'

export default {
  name: 'app',
  components: {
    AddProduct, ProductItem
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
