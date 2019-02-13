import Vue from 'vue';

import App from './App.vue';
import VueRouter from 'vue-router'
import Routes from './routes/routes'

import store from './store/store';

import 'bootstrap/dist/css/bootstrap.min.css'


Vue.config.productionTip = false

Vue.use(VueRouter)

const router = new VueRouter({
  routes: Routes
});

new Vue({
  render: h => h(App),
  store,
  router
}).$mount('#app');
