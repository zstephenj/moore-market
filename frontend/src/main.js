import Vue from 'vue';

import App from './App.vue';
import router from './router'
import store from './store';

import geo from './geo'

import 'jquery/dist/jquery.slim.js'
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap/dist/js/bootstrap.bundle.min.js'

Vue.config.productionTip = false


new Vue({
  render: h => h(App),
  router,
  store,
  geo,
}).$mount('#app');
