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

        updateAllProducts(state, products) {
            state.allProducts = products
        },

        removeProductByIndex(state, idx) {
          delete state.allProducts[idx]
        },

        updateProduct (state, product) {
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
            axios.get('/api/products').then(response => commit('updateAllProducts', response.data))
        },

        removeProductById({ commit, state }, id) {
            axios.delete('/api/products/remove/'+ id)
            let idx = state.allProducts.findIndex(p => p.id === id)
            return commit('removeProductByIndex', idx)            
        },

        editProduct( {commit}, product ) {
            return axios.put('/api/products/edit/' + product.id, product)
            .then (res => commit('updateProduct', res.data))

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