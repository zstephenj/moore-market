import HelloWorld from './components/HelloWorld';
import Dashboard from './components/Dashboard';
import UserLogin from './components/UserLogin'
import AddProduct from './components/AddProduct'

export default [
    { path: '/', component: HelloWorld},
    { path: '/dashboard', component: Dashboard},
    { path: '/login', component: UserLogin },
    { path: '/addproduct', component: AddProduct}
]