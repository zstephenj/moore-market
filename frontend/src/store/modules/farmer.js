import axios from 'axios';

const farmer = {
  namespaced: true,
  state: {
    allFarmers: [],
    farmerProducts: [],
    currentFarmer: null,
  },
  mutations: {
    setFarmerProducts(state, data) {
      state.farmerProducts = data
      state.currentFarmer = data
    },
    setFarmers(state, farmers) {
      state.allFarmers = farmers
    },
  },
  actions: {
    getFarmerProducts({ commit }, id) {
      axios.get('/api/farmers/'+id)
        .then(response => commit('setFarmerProducts', response.data))
    },
    getFarmers({ commit }) {
      axios.get('/api/farmers')
        .then(response => commit('setFarmers', response.data))
    },
  },
  getters: {

  }
}

export default farmer
