import Vue from 'vue';
import App from './App.vue';
<<<<<<< f3c2e149e7f9cbff605ef54d1d321e8e8fd36a84
import VueRouter from 'vue-router'
import Routes from './routes'
=======
import router from './router/router'
>>>>>>> cleaned up file directory moved router to seperate file

import store from './store';

Vue.config.productionTip = false
<<<<<<< f3c2e149e7f9cbff605ef54d1d321e8e8fd36a84

Vue.use(VueRouter);

const router = new VueRouter({
  routes: Routes
});
=======
>>>>>>> cleaned up file directory moved router to seperate file

new Vue({
  render: h => h(App),
  router,
  store,
}).$mount('#app');
