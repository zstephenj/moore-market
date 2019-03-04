import axios from 'axios'

const category = {
    namespaced: true,

    state: {
        allCategories: []
    },

    mutations: {

        setAllCategories (state, categories) {
            state.allCategories = categories
        },

        pushNewCategory (state, category) {
            state.allCategories.push(category)
        },

        editCategoryByIndex (state, payload) {
            state.allCategories.splice(payload.idx, 1, payload.category)
        },

        removeCategoryByIndex (state, idx) {
            state.allCategories.splice(idx, 1)
        },

    },

    actions: {

        async getAllCategoriesFromApi({ commit }) {
            let response
            try {
                // Comment next line if using backend database
                // response = await axios.get('https://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON-categories/categories')
                // Comment next line if using FakeJSON
                response = await axios.get('/api/categories')
                commit('setAllCategories', response.data)
                return response
            } catch (error) {
                console.error(error)
            }
            
        },

        async addNewCategory({ commit }, category) {
            let response
            try {
                // Comment next line if using backend database
                // response = await axios.post('http://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON-categories/categories')
                // Comment next line if using FakeJSON
                response = await axios.post('/api/categories/add', category)
                commit('pushNewCategory', response.data)
                return response
            } catch (error) {
                console.error(error)
            }
            
        },

        async editCategoryById({ commit, getters }, category) {
            let response
            try {
                // Comment next line if using backend database
                // response = await axios.put('http://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON-categories/categories/' + category.id, category)
                // Comment next line if using FakeJSON
                response = await axios.put('/api/categories/edit/' + category.id, category)
                let idx = getters.getCategoryIndex(response.data.id)
                let payload = {'idx':idx, 'category': response.data}
                commit('editCategoryByIndex', payload)
                return response
            } catch (error) {
                console.error(error)
            }
            
        },

        async removeCategoryById({ commit, getters }, id) {
            let response
            try {
                // Comment next line if using backend database
                // response = await axios.delete('http://my-json-server.typicode.com/zstephenj/moore-market-fakeJSON-categories/categories/' + id)
                // Comment next line if using FakeJSON
                response = await axios.delete('/api/categories/remove/' + id)
                let idx = getters.getCategoryIndex(id)
                commit('removeCategoryByIndex', idx)
                return response
            } catch (error) {
                console.error(error)
            }
            
        },


    },

    getters: {

        getCategoryIndex: (state) => (id) => {
            return state.allCategories.findIndex(c => c.id === id)
        },

    }
}

export default category
