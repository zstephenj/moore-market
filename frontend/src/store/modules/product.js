const product = {

    namespaced: true,

    state: { 
        newProduct: undefined
    },

    mutations: {
        setNewProduct (state, product) {
            state.newProduct = product
        }
    },

    actions: { 
        addNewProduct(context, product) {
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