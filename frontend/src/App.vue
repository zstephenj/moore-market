<template>
  <div id="app">
<<<<<<< b7f80194ec4974c92188e44d20ed33759711afb5
=======
    <img alt="Vue logo" src="./assets/logo.png">
>>>>>>> added conditional routing based on user state
    <router-view></router-view>
  </div>
</template>

<script>
<<<<<<< b7f80194ec4974c92188e44d20ed33759711afb5
=======
import UserLogin from './components/UserLogin.vue'
import UserDashboard from './components/UserDashboard.vue'
import { mapState } from 'vuex'
>>>>>>> added conditional routing based on user state

export default {
  name: 'app',
  components: {
<<<<<<< b7f80194ec4974c92188e44d20ed33759711afb5
=======
    UserLogin,
    UserDashboard
  },
  data() {
    return {
      user: null
    }
  },
  beforeCreate: function () {
    if (this.$store.state.user.isLoggedIn === true)
      this.$router.push('/')
    else
      this.$router.push('/login')
>>>>>>> added conditional routing based on user state
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
