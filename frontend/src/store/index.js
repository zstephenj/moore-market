import Vuex from 'vuex';
import Vue from 'vue';

import product from  './modules/product'
import category from './modules/category'
import user from './modules/user'
import vendor from './modules/vendor'
import market from './modules/market'
import api from './modules/api'

Vue.use(Vuex)

const store = new Vuex.Store({
    modules: {
        product,
        category,
        user,
        vendor,
        market,
        api
    }
})

export default store
