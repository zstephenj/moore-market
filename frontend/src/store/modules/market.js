import axios from 'axios'

const market = {
    namespaced: true,

    state: {
        allMarkets: []
    },

    mutations: {

        setAllMarkets (state, payload) {
            state.allMarkets = payload
        },

        pushNewMarket (state, payload) {
            state.allMarkets.push(payload)
        },

        editMarketByIndex (state, payload) {
            state.allMarkets.splice(payload.idx, 1, payload.market)
        },

        removeMarketByIndex (state, payload) {
            state.allMarkets.splice(payload, 1)
        },

    },

    actions: {

        async getAllMarketsFromApi({ commit }) {
            let response
            try {
                // Comment next line if using backend database
                response = await axios.get('https://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON2/markets')
                // Comment next line if using FakeJSON
                // response = await axios.get('/api/markets')
                commit('setAllMarkets', response.data)
                return response
            } catch (error) {
                console.error(error)
            }
            
        },

        async addMarket({ commit }) {
            let response
            try {
                // Comment next line if using backend database
                response = await axios.post('http://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON2/markets/')
                // Comment next line if using FakeJSON
                // response = await axios.post('/api/markets/add')
                commit('pushNewMarket', response.data)
                return response
            } catch (error) {
                console.error(error)
            }
            
        },

        async editMarketById({ commit, getters }, market) {
            let response
            try {
                // Comment next line if using backend database
                response = await axios.put('http://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON2/markets/' + market.id, market)
                // Comment next line if using FakeJSON
                // response = await axios.put('/api/markets/edit/' + id)
                let idx = getters.getMarketIndex(market.id)
                let payload = {'idx':idx, 'market': market}
                commit('editMarketByIndex', payload)
                return response
            } catch (error) {
                console.error(error)
            }
            
        },

        async removeMarketById({ commit, getters }, id) {
            let response
            try {
                // Comment next line if using backend database
                response = await axios.delete('http://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON2/markets/' + id)
                // Comment next line if using FakeJSON
                // response = await axios.delete('/api/markets/remove/' + id)
                let idx = getters.getMarketIndex(id)
                commit('removeMarketByIndex', idx)
                return response
            } catch (error) {
                console.error(error)
            }
            
        },


    },

    getters: {

        getMarketIndex: (state) => (id) => {
            return state.allMarkets.findIndex(m => m.id === id)
        },

        
    }
}

export default market