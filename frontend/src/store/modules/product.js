const product = {
    namespaced: false,
    state: { 
        newProduct: undefined
    },

    mutations: {
        addNewProduct (state, product) {
            state.newProduct = product
        }
    },

    actions: { 
        addProduct: ({ commit }, delay, product) => {
            setTimeout(() => {
              commit('addNewProduct', product)
            }, delay)
    },
    },
    getters: {
        newProduct (state) {
            return state.newProduct
        }
    }
}

export default {
    product
}