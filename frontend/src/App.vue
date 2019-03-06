<template>
  <div id="app">
    <NavigationTwo></NavigationTwo>
    <router-view></router-view>
  </div>
</template>

<script>
import Navigation from "./components/Navigation.vue"
import NavigationTwo from "./components/NavigationTwo.vue"
import { mapActions } from 'vuex'

export default {
  name: 'app',
  components: {
    Navigation,
    NavigationTwo
  },
  methods: {
    ...mapActions('product', ['getAllProductsFromApi'])
  },
  mounted() {
    this.getAllProductsFromApi()
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  text-align: center;
}

.moore-gradient {
  background: linear-gradient(-90deg, #84CF6A, #16C080);
}

.moore-navy {
  color: #001f3f;
}
</style>
