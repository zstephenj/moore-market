const user = {
    namespaced: true,
    state: {
        currentUser: {
            username: "",
            accountType: "",
            isLoggedIn: false,
        }
    },
    mutations: {

        
    },
    actions: {
        
    },
    getters: {
        isLoggedIn(state) {
            return state.user.isLoggedIn
        }
    },
}

export default user