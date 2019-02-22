import axios from 'axios';

const user = {
    namespaced: true,
    state: {
        currentUser: {
            username: "user",
            accountType: "farmer",
            isLoggedIn: true,
        },
        allFarmers: [],
    },
    mutations: {
        setFarmers(state, farmers) {
          state.allFarmers = farmers
        },
    },
    actions: {
        getFarmers({ commit }) {
          axios.get('/api/farmers')
            .then(response => commit('setFarmers', response.data))
        },
    },
    getters: {
    },
}

export default user