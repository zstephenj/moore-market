const product = {
    namespaced: true,
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
        getNewProduct (state) {
            return state.newProduct
        }
    }
}

export default {
    product
}