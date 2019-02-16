import axios from 'axios';

const product = {

    namespaced: true,

    state: { 
        newProduct: undefined,
        allProducts: [],
    },

    mutations: {
        setNewProduct (state, product) {
            state.newProduct = product
        },
        updateProducts(state, products) {
          state.allProducts = products
        },
    },
    actions: { 
        addNewProduct({ commit }, product) {
            commit('setNewProduct', product)
        },
        getAllProducts({ commit }) {
          axios.get('https://localhost:5001/products').then(response => commit('updateProducts', response.data))
        },
    },  
    getters: {
        getNewProduct (state) {
            return state.newProduct
        }
    }
}

export default product