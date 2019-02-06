const product = {
    namespaced: true,
    state: { 
        newProduct: undefined
    },

    mutations: {
        setNewProduct (state, product) {
            console.log(product)
            state.newProduct = product
        }
    },

    actions: { 
        addNewProduct(context, product) {
            console.log(product)
            context.commit('setNewProduct', product)
        }
    },
    getters: {
        getNewProduct (state) {
            return state.newProduct
        }
    }
}

export default product