<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <router-view></router-view>
  </div>
</template>

<script>
import UserLogin from './components/UserLogin.vue'
import UserDashboard from './components/UserDashboard.vue'

export default {
  name: 'app',
  components: {
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
      this.$router.push('/dashboard')
    else
      this.$router.push('/login')
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
