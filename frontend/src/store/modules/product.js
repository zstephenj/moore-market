import axios from 'axios';

const product = {
    namespaced: true,
    state: { 
        newProduct: null,
        allProducts: [],
    },

    mutations: {
        setNewProduct (state, product) {
            state.newProduct = product
            state.allProducts.push(product)
        },

        updateProducts(state, products) {
            state.allProducts = products
        },

        removeProductByIndex(state, idx) {
          delete state.allProducts[idx]
        },

        setEditProduct (state, product) {
            let idx = state.allProducts.findIndex(p => p.id === product.id)
            state.allProducts[idx] = product
        }
    },
    actions: { 
        addNewProduct({ commit }, product) {
            axios.post('/api/products/add', product)
            return commit('setNewProduct', product)
        },

        getAllProductsFromApi({ commit }) {
            axios.get('/api/products').then(response => commit('updateProducts', response.data))
        },

        removeProductById({ commit, state }, id) {
            axios.delete('/api/products/remove/'+ id)
            let idx = state.allProducts.findIndex(p => p.id === id)
            return commit('removeProductByIndex', idx)            
        },

        editProduct( {commit}, product ) {
            axios.put('/api/products/edit/' + product.id)
            .then(res => commit('setEditProduct', res.data))
            
        }
    },  
    getters: {
        getNewProduct (state) {
            return state.newProduct
        },
        getProductById: (state) => (id) => {
            return state.allProducts.find(p => p.id === id)
        }
    }
}

export default product