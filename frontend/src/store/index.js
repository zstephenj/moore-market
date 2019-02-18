import Vuex from 'vuex';
import Vue from 'vue';

import product from  './modules/product'
import user from './modules/user'

Vue.use(Vuex)

const store = new Vuex.Store({
    modules: {
        product: product,
        user: user
    }
})

export default store

