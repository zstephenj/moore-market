import Vuex from 'vuex';
import Vue from 'vue';

import product from  './modules/product'
import category from './modules/category'
import user from './modules/user'
import farmer from './modules/farmer'
import market from './modules/market'

Vue.use(Vuex)

const store = new Vuex.Store({
    modules: {
        product,
        category,
        user,
        farmer,
        market
    }
})

export default store

