import axios from 'axios';

const user = {
    namespaced: true,
    state: {
        currentUser: {
            id: 1,
            username: "user",
            accountType: "vendor",
            isLoggedIn: true,
            location: {},
            favoriteMarkets: [1,3,5],
        },
    },

    mutations: {

        setCurrentUser (state, user) {
            state.currentUser = user
        },

        setUserLocation (state, payload) {
            state.currentUser.location = payload
        },

        removeLocation (state) {
            state.currentUser.location = {}
        },

        setUserProducts(state, products) {
            state.currentUser.products = products
        },
        pushFavoriteMarket(state, marketId) {
            state.currentUser.favoriteMarkets.push(marketId)
        },
        spliceFavoriteMarket(state, idx) {
            state.currentUser.favoriteMarkets.splice(idx, 1)
        },
        pushVendorMarket(state, marketId) {
            state.currentUser.vendorMarkets.push(marketId)
        },
        spliceVendorMarket(state, idx) {
            state.currentUser.vendorMarkets.splice(idx, 1)
        }
    },

    actions: {

        async getUserFromApi({ commit }, login) {
            let response
            try {
                
                // response = await axios.get('/api/')
                // commit('setCurrentUser', response.data)
                return response
            } catch (error) {
                console.error(error)
            }

        },

        async setLocation({ commit }, location) {
            let response
            try {
                
                commit('setUserLocation', location)//response.data)
                return location//response
            } catch (error) {
                console.error(error)
            }

        },

        async removeLocation({ commit}) {
            let response
            try {
                
                // response = await axios.delete('/api/users/location/remove/')
                commit('removeLocation')
                return response
            } catch (error) {
                console.error(error)
            }

        },


        async getUserProducts({ commit }, id) {
            let response
            try{
               
                response = await axios.get('api/user/products/' + id)
                console.log(response)
                commit('setUserProducts', response.data)
                return response
            } catch(error) {
                console.log(error)
            }
        },

        async addFavoriteMarket ({commit}, id) {
            let response
            try {
                // response = await axios.post('api/user/favoriteMarkets', id)
                commit('pushFavoriteMarket', id)//response.data)
            }  catch(error) {
                console.log(error)
            }
            
        },
        async removeFavoriteMarket ({commit, getters}, id) {
            let response
            try {
                // response = await axios.delete('api/user/favoriteMarkets', id)
                console.log(id)
                let idx = getters.getFavoriteMarketIndex(id)
                commit('spliceFavoriteMarket', idx)//response.data)
            }  catch(error) {
                console.log(error)
            }
        },
        async addVendorMarket ({commit, dispatch, state}, id) {
            let response
            try {
                // response = await axios.put('api/user/vendorMarkets', id)
                commit('pushVendorMarket', id)//response.data)
                let dispatchObj = {
                    marketId: id,
                    userId: state.currentUser.id
                }
                dispatch('market/addUserToMarket',dispatchObj,{root:true})
            }  catch(error) {
                console.log(error)
            }
            
        },
        async removeVendorMarket ({commit, getters, dispatch, state}, id) {
            let response
            try {
                // response = await axios.delete('api/user/favoriteMarkets', id)
                let idx = getters.getVendorMarketIndex(id)
                commit('spliceVendorMarket', idx)//response.data)
                let dispatchObj = {
                    marketId: id,
                    userId: state.currentUser.id
                }
                dispatch('market/removeUserFromMarket',dispatchObj,{root:true})
            }  catch(error) {
                console.log(error)
            }
        },
      async registerUser({ commit, state }, user) {
      async login({commit}, userDto) {
        let response;
        try {
          response = await axios.post('api/user/login', userDto);
          if (response.status === 200) {
            let {id, username, accountType, token} = response.data;
            let user = {
              id: id,
              username: username,
              // Refactor if more than two accountTypes
              accountType: (accountType === 0 ? 'vendor': 'user'),
              isLoggedIn: true
            };
            sessionStorage.user = JSON.stringify({token:token});
            commit('setUser', user);
            return true;
          } else {
            // Wrong username or password
            return false;
          }
        } catch (error) {
          console.log(error);
        }
      },

      async registerUser({commit}, user) {
        let response;
        try {
          response = await axios.post('/api/user/register', user);
          commit('setUser', response.data);
          return response;
        } catch(error) {
          console.error(error);
        }
      },
    },

    getters: {
        getFavoriteMarketIndex: (state) => (marketId) => {
            return state.currentUser.favoriteMarkets.findIndex(m => m.id === marketId)
        },
        getVendorMarketIndex: (state) => (marketId) => {
            return state.currentUser.vendorMarkets.findIndex(m => m.id === marketId)
        },

    }

}

export default user
