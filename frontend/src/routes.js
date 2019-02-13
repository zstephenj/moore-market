import HelloWorld from './components/HelloWorld.vue';
import Dashboard from './components/Dashboard.vue';
import ProductList from './components/ProductList.vue';

export default [
    { path: '/', component: HelloWorld },
    { path: '/dashboard', component: Dashboard },
    { path: '/productlist', component: ProductList },
]