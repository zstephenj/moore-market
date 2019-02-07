import UserDashboard from '../components/UserDashboard'
import UserLogin from '../components/UserLogin'
import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  { path: '/dashboard', component: UserDashboard },
  { path: '/login', component: UserLogin }
]

export default new VueRouter ({
  routes: routes
})