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
            state.allProducts.splice(idx, 1)
        },
    },
    actions: { 
        addNewProduct({ commit }, product) {
            return axios.post('/api/products/add', product).then(() => commit('setNewProduct', product))
        },
        getAllProductsFromApi({ commit }) {
            axios.get('/api/products').then(response => commit('updateProducts', response.data))
        },
        removeProductById({ commit, state }, id) {
            let idx = state.allProducts.findIndex(p => p.id === id)
            axios.delete('/api/products/remove/'+id).then(() => commit('removeProductByIndex', idx))   
        },
    },  
    getters: {
        getNewProduct (state) {
            return state.newProduct
        },
        getProductById(state, id) {
            return state.allProducts.find(p => p.id === id)
        },
        getAllProducts(state) {
            return state.allProducts
        },
    }
}

export default product