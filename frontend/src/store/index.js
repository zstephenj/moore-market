import vuex from 'vuex';
import vue from 'vue';

vue.use(vuex);

export default new vuex.Store({
    state: {
        currentUser: {id:1, username: "John", AccountType: "user", isLoggedIn: true},
        
    }
})

