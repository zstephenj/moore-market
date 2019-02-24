<template>
    <div>
      <h1>This will be the User Dashboard</h1>
      <div>
        <h4>Product List</h4>
        <ul>
          <li v-for="product in allProducts" :key="product.id">{{ product.name }}</li>
        </ul>
      </div>
      <div> 
        <h4>Farmer List</h4>
        <ul>
          <li v-for="farmer in allFarmers" :key="farmer.id">{{ farmer.username }}</li>
        </ul>
      </div>
    </div>
</template>

<script>
import { mapActions, mapState } from 'vuex'

export default {
  name: 'userdashbaord',
  components: {
      
  },
  created() {
    this.getFarmers(),
    this.getAllProductsFromApi()
  },
  computed: {
    ...mapState('product', ['allProducts']),
    ...mapState('farmer', ['allFarmers'])
  },
  methods: {
    ...mapActions('product', ['getAllProductsFromApi']),
    ...mapActions('farmer', ['getFarmers'])
  }  

}  
</script>

