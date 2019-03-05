import axios from 'axios'

const user = {
    namespaced: true,
    state: {
        currentUser: {
            id: 1,
            username: "user",
            accountType: "farmer",
            isLoggedIn: true,
            id: 2,
            products: []
        },
    },
    mutations: {
        setUserProducts(state, products) {
            state.currentUser.products = products
        },
    },
    actions: {
        async getUserProducts({ commit }, id) {
            let response
            try{
                // Comment next line if using backend database
                // response = await axios.get('http://my-json-server.typicode.com/zstephenj/moore-market-fakejson/products/')
                // Comment next line if using FakeJSON
                response = await axios.get('api/user/products/' + id)
                console.log(response)
                commit('setUserProducts', response.data)
                return response
            } catch(error) {
                console.log(error)
            }
        },
    },
    getters: {
    },
}

export default user