import vuex from 'vuex';
import vue from 'vue';

vue.use(vuex);

export default new vuex.Store({
<<<<<<< HEAD
<<<<<<< b7f80194ec4974c92188e44d20ed33759711afb5
    state: {
        currentUser: {id:1, username: "John", AccountType: "farmer", isLoggedIn: true},
        
    }
})
=======
=======
>>>>>>> 456f2a92ae06194456b9bfcacc38b98604abaeec
  state: {
    user: {
      isLoggedIn: false,
    }
  }
});
>>>>>>> added conditional routing based on user state

