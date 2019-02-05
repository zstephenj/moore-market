import vuex from 'vuex';
import vue from 'vue';

import state from './state.js'
import mutations from './mutations.js'
import actions from './actions.js'
import getters from './getters.js'

import product from  './modules/product'

vue.use(vuex)

const store = new vuex.Store({
    state,
    mutations,
    actions,
    getters,
    modules: {
        product: product
    }
})

export default {
    store
}

