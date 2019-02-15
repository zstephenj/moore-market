import HelloWorld from './components/HelloWorld.vue'
import Dashboard from './Dashboard.vue'
import AddProduct from './components/Product/AddProduct'

export default [
    { path: '/', component: HelloWorld},
    { path: '/dashboard', component: Dashboard},
    { path: '/addproduct', component: AddProduct}
]