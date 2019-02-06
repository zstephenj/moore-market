import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router'
import UserDashboard from './components/UserDashboard'
import UserLogin from './components/UserLogin'

import store from './store';

Vue.config.productionTip = false
Vue.use(VueRouter)

const routes = [
  { path: '/', component: UserDashboard },
  { path: '/login', component: UserLogin }
]

const router = new VueRouter ({
  routes: routes
})

new Vue({
  render: h => h(App),
  router,
  store,
}).$mount('#app');
