<template>
  <div id="dashboard">
      <div>
          <h1>Vendor-Mart</h1>
      </div>

      <div class='row justify-content-center m-3'>

        <div class="card">
          <div class="card-body">
            <router-link to="/product/add"><button type="button" class="btn btn-success btn-lg mx-3">Add New Item</button></router-link>
            <router-link to='/categories'> <button type="button" class="btn btn-success btn-lg" > Manage Categories </button> </router-link>
          </div>
        </div>
        
        
      </div>
      
      <SummaryBox :sumBoxMessages="sumBoxMessages" class='m-3'></SummaryBox>
      
      <div class=farmerNav>
      </div>
      
      <farmer-product-dash></farmer-product-dash>

  </div>
</template>

<script>
import SummaryBox from '../components/SummaryBox.vue';
import FarmerProductDash from '../components/Product/FarmerProductDash.vue'

export default {
  name: 'FarmDashboard',
  components: {
      'SummaryBox': SummaryBox,
      FarmerProductDash

  },
  created() {
  
  },
  computed: {
    
  },
  methods: {
    
  },
  data() {
      return {
          messages: [],
          sumBoxMessages: [],
          }
  }
}
</script>

<style>
#dashboard {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  text-align: center;
}


</style>
