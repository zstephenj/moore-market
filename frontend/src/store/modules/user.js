import axios from 'axios';

function authHeader() {
  let user = JSON.parse(sessionStorage.getItem('user'));

  if(user && user.token) {
    return { 'Authorization': 'Bearer ' + user.token };
  } else {
    return {};
  }
}

const user = {
    namespaced: true,
    state: {
      // currentUser: {
      //   username: "user",
      //   accountType: "farmer",
      //   isLoggedIn: true,
      //   id: 2,
      // },
      user: null,
    },
    mutations: {
      setUser(state, user) {
        state.user = user;
      },
    },
    actions: {
      async registerUser({ commit, state }, user) {
        let response;
        try {
          response = axios.post('/api/user/register', user);
          commit('setUser', response.data);
          return response;
        } catch(error) {
          console.error(error);
        }
      },
    },
    getters: {
    },
}

export default user