import HelloWorld from './components/HelloWorld.vue';
import Dashboard from './Dashboard.vue';
import UserLogin from './components/UserLogin'

export default [
    { path: '/', component: HelloWorld},
    { path: '/dashboard', component: Dashboard},
    { path: '/login', component: UserLogin }
]