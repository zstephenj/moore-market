import axios from 'axios';

const product = {
    namespaced: true,
    
    state: { 
        newProduct: null,
        allProducts: [],
        cart: [],
        searchResults: [],
    },

    mutations: {
        setNewProduct(state, product) {
            state.newProduct = product
            state.allProducts.push(product)
        },
        updateAllProducts(state, products) {
            state.allProducts = products
        },
        removeProductByIndex(state, idx) {
            state.allProducts.splice(idx, 1)
        },
        addEditedProduct(state, payload) {
            state.allProducts.splice(payload.idx, 1, payload.product)
        },
        addProductToCart(state, product) {
            state.cart.push(product)
        },
        updateSearchResults(state, products) {
          state.searchResults = products
        }
    },

    actions: { 
        async addNewProduct({ commit }, product) {
            let response
            try{
                // Comment next line if using backend database
                // response = await axios.post('http://my-json-server.typicode.com/zstephenj/moore-market-fakejson/products/', product)
                // Comment next line if using FakeJSON
                response = await axios.post('/api/products/add', product)
                commit('setNewProduct', response.data)
                return response
            } catch(error) {
                console.log(error)
            }
        },
        async getAllProductsFromApi({ commit }) {
            let response
            try{
                // Comment next line if using backend database
                // response = await axios.get('http://my-json-server.typicode.com/zstephenj/moore-market-fakejson/products/')
                // Comment next line if using FakeJSON
                response = await axios.get('/api/products')
                commit('updateAllProducts', response.data)
                return response
            } catch(error) {
                console.log(error)
            }
        },

        async removeProductById({ commit, getters }, id) {
            let response
            try{
                // Comment next line if using backend database
                // response = await axios.delete('http://my-json-server.typicode.com/zstephenj/moore-market-fakejson/products/' + id)
                // Comment next line if using FakeJSON
                response = await axios.delete('/api/products/remove/'+ id)
                let idx = getters.getProductIndex(id) 
                commit('removeProductByIndex', idx)
                return response
            } catch(error) {
                console.log(error)
            }
            
        },
        addProductToCart({ commit }, product) {
            return commit('addProductToCart', product)
        },
        async searchProducts({ commit }, searchTerm) {
            let response
            try {
                response = await axios.get('/api/products/search?searchTerm='+searchTerm)
                return commit('updateSearchResults', response.data)
            } catch(error) {
                console.error(error)
            }
        },
        async editProductById({ commit, getters }, product) {
            let response
            try{
                // Comment next line if using backend database
                // response = await axios.put('http://my-json-server.typicode.com/zstephenj/moore-market-fakejson/products/' + product.id, product)
                // Comment next line if using FakeJSON
                response = await axios.put('/api/products/edit/'+ product.id, product)
                let idx = getters.getProductIndex(response.data.id)
                let payload = {'idx':idx, 'product':response.data}
                commit('addEditedProduct', payload)
                return response
            } catch(error) {
                console.log(error)
            }
        },
    },

    getters: {
      //this syntax lets us call getters with a parameter
      
        getProductById: (state) => (id) => {
            return state.allProducts.find(p => p.id === id)
        },

        getProductIndex: (state) => (id) => {
            return state.allProducts.findIndex(p => p.id === id)
        }
    }

}

export default product