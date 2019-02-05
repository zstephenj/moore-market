const product = {
    namespaced: false,
    state: { 
        newProduct: undefined
    },

    mutations: {
        setNewProduct (state, product) {
            state.newProduct = product
        }
    },

    actions: { 
        addNewProduct: ({ commit }, delay, product) => {
            setTimeout(() => {
              commit('setNewProduct', product)
            }, delay)
    },
    },
    getters: {
        getNewProduct (state) {
            return state.newProduct
        }
    }
}

export default {
    product
}