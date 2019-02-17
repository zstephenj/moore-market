<<<<<<< HEAD
import HelloWorld from './components/HelloWorld';
import Dashboard from './components/Dashboard';
import UserLogin from './components/UserLogin'
=======
import HelloWorld from './components/HelloWorld.vue'
import Dashboard from './Dashboard.vue'
import AddProduct from './components/AddProduct'
>>>>>>> b35e003585dec65cc18c17085f8850c4866028d1

export default [
    { path: '/', component: HelloWorld},
    { path: '/dashboard', component: Dashboard},
<<<<<<< HEAD
    { path: '/login', component: UserLogin }
=======
    { path: '/addproduct', component: AddProduct}
>>>>>>> b35e003585dec65cc18c17085f8850c4866028d1
]