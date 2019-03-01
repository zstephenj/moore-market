import Vue from 'vue'
import Router from 'vue-router'

import HelloWorld from '../components/HelloWorld.vue'
import Dashboard from '../components/Dashboard.vue'
import ProductHomePage from '../components/Product/ProductHomepage.vue'
import ManageCategories from '../components/Product/ManageCategories.vue'
import AddProduct from  '../components/Product/AddProduct.vue'
import EditProduct from '../components/Product/EditProduct.vue'
import SingleProduct from '../components/Product/SingleProduct.vue'
import ProductSearchResult from '../components/Product/ProductSearchResult.vue'
import BrowseFarmers from '../components/BrowseFarmers.vue'
import BrowseInventory from '../components/BrowseInventory.vue'

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
    name:'ProductHomePage',
    path: '/product',
    component: ProductHomePage,
  }, {
    name:'ManageCategories',
    path: '/categories',
    component: ManageCategories
  }, {
    path: '/product/add',
    name: 'AddProduct',
    component: AddProduct,
  }, {
    name: 'SingleProduct',
    path: '/product/:id',
    component: SingleProduct
  }, {
    name: 'ProductSearchResult',
    path: '/productsearchresult',
    component: ProductSearchResult
  }, {
    name: 'EditProduct',
    path: '/product/edit/:id',
    component: EditProduct
  }, {
    name: 'BrowseFarmers',
    path: '/farmers',
    component: BrowseFarmers,
  }, {
    name: 'BrowseInventory',
    path: '/farmers/:id',
    component: BrowseInventory,
    props: true,
  }],
})