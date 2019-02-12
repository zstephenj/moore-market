import Vuex from 'vuex';
import Vue from 'vue';

import product from  './modules/product'

Vue.use(Vuex)

const store = new Vuex.Store({
    modules: {
        product: product
    }
})

export default store

