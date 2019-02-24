<template>
  <div class="vendor-list">
    <ul>
      <li 
      class="vendor-card"
      v-for="farmer in allFarmers" :key="farmer.id"
      ><router-link
      :to="{
        name: 'BrowseInventory',
        params: { id: farmer.id },
      }">
      {{ farmer.username }}'s items
      </router-link>
      </li>
    </ul>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
  name: 'BrowseFarmers',
  methods: {
    ...mapActions('farmer', ['getFarmers']),
  },
  created() {
    this.getFarmers()
  },
  computed: {
    ...mapState('farmer', ['allFarmers']),
  }
}
</script>

<style scoped>
ul {
  list-style-type: none;
}
</style>
