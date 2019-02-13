<template>
  <div id="app">

    <router-view></router-view>

  </div>
</template>

<script>

export default {
  name: 'app',
  components: {
  },
  beforeCreate: function() {
    if(this.$store.state.user.currentUser.isLoggedIn === true)
      this.$router.push('/dashboard')
    else
      this.$router.push('/')
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
