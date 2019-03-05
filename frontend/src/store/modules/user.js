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
    },
    mutations: {
    },
    actions: {
      registerUser({ commit, state }, user) {

      }
    },
    getters: {
    },
}

export default user