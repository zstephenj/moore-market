import Vuex from 'vuex';
import Vue from 'vue';

import product from  './modules/product'
import user from './modules/user'
import farmer from './modules/farmer'

Vue.use(Vuex)

const store = new Vuex.Store({
    modules: {
        product,
        user,
        farmer,
    }
})

export default store

