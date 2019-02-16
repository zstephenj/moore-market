const user = {
    namespaced: true,
    state: {
        currentUser: {
            username: "user",
            accountType: "farmer",
            isLoggedIn: true,
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