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
            state.allProducts.push(product)
        },
        updateProducts(state, products) {
            state.allProducts = products
        },
        removeProductByIndex(state, idx) {
          delete state.allProducts[idx]
        },
    },
    actions: { 
        addNewProduct({ commit }, product) {
            // eslint-disable-next-line no-console
            // axios.post({
            //   url: 'https://localhost:5001/products/add', 
            //   method: 'get',
            //   headers: {'Access-Control-Allow-Origin': 'meeeee'},
            //   data: product,
            // })
            axios.post('/api/products/add', product)
            return commit('setNewProduct', product)
        },
        getAllProductsFromApi({ commit }) {
            axios.get('/api/products').then(response => commit('updateProducts', response.data))
        },
        removeProductById({ commit, state }, id) {
            axios.delete('/api/products/remove/'+id)
            let idx = state.allProducts.findIndex(p => p.id === id)
            return commit('removeProductByIndex', idx)            
        },
    },  
    getters: {
        getNewProduct (state) {
            return state.newProduct
        },
        getProductById(state, id) {
            return state.allProducts.find(p => p.id === id)
        }
        
    }
}

export default product