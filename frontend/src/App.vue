<template>
  <div id="app">

    <router-view></router-view>

  </div>
</template>

<script>
import UserLogin from './components/UserLogin.vue'
import Dashboard from './components/Dashboard'

export default {
  name: 'app',
  components: {
    UserLogin,
    Dashboard
  },
  data() {
    return {
      user: null
    }
  },
  beforeCreate: function () {
    if (this.$store.state.currentUser.isLoggedIn === true)
      this.$router.push('/dasboard')
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
