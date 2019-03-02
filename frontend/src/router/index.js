import Vue from 'vue'
import Router from 'vue-router'

import HelloWorld from '../components/HelloWorld.vue'
import Dashboard from '../components/Dashboard.vue'
import AddProduct from  '../components/Product/AddProduct.vue'
import EditProduct from '../components/Product/EditProduct.vue'
import ProductForm from '../components/Product/ProductForm.vue'
import SingleProduct from '../components/Product/SingleProduct.vue'
import ProductSearchResult from '../components/Product/ProductSearchResult.vue'
import BrowseFarmers from '../components/BrowseFarmers.vue'
import BrowseInventory from '../components/BrowseInventory.vue'
import AllProducts from '../components/Product/AllProducts.vue'
import SearchProducts from '../components/Product/SearchProducts.vue'
import ShoppingCart from '../components/ShoppingCart.vue'

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
    path: '/product/add',
    name: 'AddProduct',
    component: AddProduct,
  }, {
    path: '/productform',
    component: ProductForm,
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
  }, {
    name: 'AllProducts',
    path: '/products/all',
    component: AllProducts,
  }, {
    name: 'SearchProducts',
    path: '/products/search',
    component: SearchProducts,
  }, {
    name: 'ShoppingCart',
    path: '/products/cart',
    component: ShoppingCart,
  }],
})