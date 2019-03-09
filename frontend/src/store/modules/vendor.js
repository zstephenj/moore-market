import axios from 'axios';

const vendor = {
  namespaced: true,
  state: {
    allVendors: [],
    vendorProducts: [],
    currentVendor: null,
  },

  mutations: {
    setVendorProducts(state, data) {
      state.vendorProducts = data
      state.currentVendor = data
    },
    setVendors(state, vendors) {
      state.allVendors = vendors
    },
  },
  
  actions: {
    async getVendorProducts({ commit }, id) {
      let response
      try {
        response = await axios.get('/api/vendors/'+ id)
        console.log(response)
        commit('setVendorProducts', response.data)
      } catch(error) {
        console.log(error)
      }
      
    },
    getVendors({ commit }) {
      axios.get('/api/vendors')
        .then(response => commit('setVendors', response.data))
    },
  },

  getters: {

  }
}

export default vendor
