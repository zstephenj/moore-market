import axios from 'axios'

const user = {
    namespaced: true,
    state: {
        currentUser: {
            id: 1,
            username: "user",
            accountType: "farmer",
            isLoggedIn: true,
            location: {},
            favoriteMarkets: [1,3,5],
            products: []
        },
    },

    mutations: {

        setCurrentUser (state, payload) {
            state.currentUser = payload
        },

        setUserLocation (state, payload) {
            state.currentUser.location = payload
        },

        removeLocation (state, payload) {
            state.currentUser.splice(payload, 1)
        },

        setUserProducts(state, products) {
            state.currentUser.products = products
        },
    },

    actions: {

        async getUserFromApi({ commit }, login) {
            let response
            try {
                // Comment next line if using backend database
                // response = await axios.get('https://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON-categories/categories', login)
                // Comment next line if using FakeJSON
                // response = await axios.get('/api/categories')
                // commit('setCurrentUser', response.data)
                return response
            } catch (error) {
                console.error(error)
            }

        },

        async setLocation({ commit }, location) {
            let response
            try {
                // Comment next line if using backend database
                // response = await axios.post('http://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON-categories/categories', location)
                // Comment next line if using FakeJSON
                // response = await axios.post('/api/categories/add')
                commit('setUserLocation', location)//response.data)
                return location//response
            } catch (error) {
                console.error(error)
            }

        },

        async removeLocation({ commit, getters }, location) {
            let response
            try {
                // Comment next line if using backend database
                // response = await axios.delete('http://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON-categories/categories/' + id)
                // Comment next line if using FakeJSON
                // response = await axios.delete('/api/categories/remove/' + id)
                let idx = getters.getLocationIndex(location)
                commit('removeLocation', idx)
                return response
            } catch (error) {
                console.error(error)
            }

        },


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

        getLocationIndex: (state) => (location) => {
            console.log(state.location)
            return state.location.findIndex(location)
        },

    }

}

export default user