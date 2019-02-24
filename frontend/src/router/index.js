import Vue from 'vue'
import Router from 'vue-router'

import HelloWorld from '../components/HelloWorld.vue'
import Dashboard from '../components/Dashboard.vue'
import AddProduct from  '../components/AddProduct.vue'
import ProductForm from '../components/ProductForm.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [{
    name: 'Homepage',
    path: '/',
    component: HelloWorld,
  }, {
    name: 'Dashboard',
    path: '/dashboard',
    component: Dashboard,
  }, {
    path: '/addproduct',
    name: 'AddProduct',
    component: AddProduct,
  }, {
    path: '/productform',
    component: ProductForm,
  }],
})