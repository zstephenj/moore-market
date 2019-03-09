import axios from 'axios';

const user = {
    namespaced: true,
    state: {
        currentUser: {
            id: 1,
            username: "user",
            accountType: "vendor",
            isLoggedIn: true,
            favMarketIds: [],
            lat: null,
            lng: null
        },
    },

    mutations: {

        setCurrentUser(state, user) {
            state.currentUser = user;
        },

        setUserLocation(state, payload) {
            let {lat, lng} = payload;
            state.currentUser.lat = lat;
            state.currentUser.lng = lng;
        },

        removeLocation(state) {
            state.currentUser.lat = null;
            state.currentUser.lng = null;
        },

        pushFavoriteMarket(state, marketId) {
            state.currentUser.favMarketIds.push(marketId);
        },
        spliceFavoriteMarket(state, idx) {
            state.currentUser.favMarketIds.splice(idx, 1);
        }
    },

    actions: {

        async setLocation({commit}, userLocation) {
            let response;
            try {
                response = axios.post('/user/location/', userLocation);
                commit('setUserLocation', response.data);
                return response;
            } catch (error) {
                console.error(error);
            }

        },

        async addFavoriteMarket({commit}, ids) {
            let response;
            let {marketId, userId} = ids;
            try {
                response = await axios.post('api/user/favoriteMarkets/' + userId, marketId);
                commit('pushFavoriteMarket', response.data);
                return response;
            } catch (error) {
                console.log(error);
            }

        },
        async removeFavoriteMarket({commit, getters}, ids) {
            let response;
            let {marketId, userId} = ids;
            try {
                response = await axios.delete('api/user/favoriteMarkets/' + userId, marketId);
                let idx = getters.getFavoriteMarketIndex(marketId)
                if (response.status === 200) {
                    commit('spliceFavoriteMarket', idx)
                }
                return response;
            } catch (error) {
                console.log(error)
            }
        },
        async addVendorMarket({ commit, dispatch, state }, id) {
            let response
            try {
                // response = await axios.put('api/user/vendorMarkets', id)
                commit('pushVendorMarket', id)//response.data)
                let dispatchObj = {
                    marketId: id,
                    userId: state.currentUser.id
                }
                dispatch('market/addUserToMarket', dispatchObj, { root: true })
            } catch (error) {
                console.log(error)
            }

        },
        async removeVendorMarket({ commit, getters, dispatch, state }, id) {
            let response
            try {
                // response = await axios.delete('api/user/favoriteMarkets', id)
                let idx = getters.getVendorMarketIndex(id)
                commit('spliceVendorMarket', idx)//response.data)
                let dispatchObj = {
                    marketId: id,
                    userId: state.currentUser.id
                }
                dispatch('market/removeUserFromMarket', dispatchObj, { root: true })
            } catch (error) {
                console.log(error)
            }
        },
        async login({ commit }, userDto) {
                let response;
                try {
                    response = await axios.post('api/user/login', userDto);
                    if (response.status === 200) {
                        let { id, username, accountType, token } = response.data;
                        let user = {
                            id: id,
                            username: username,
                            // Refactor if more than two accountTypes
                            accountType: (accountType === 0 ? 'vendor' : 'user'),
                            isLoggedIn: true
                        };
                        sessionStorage.user = JSON.stringify({ token: token });
                        commit('setCurrentUser', user);
                        return true;
                    } else {
                        // Wrong username or password
                        return false;
                    }
                } catch (error) {
                    console.log(error);
                }
            },

            async registerUser({ commit }, user) {
                let response;
                try {
                    response = await axios.post('/api/user/register', user);
                    commit('setCurrentUser', response.data);
                    return response;
                } catch (error) {
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
}
export default user
