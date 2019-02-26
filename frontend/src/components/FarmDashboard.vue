<template>
  <div id="dashboard">
      <div>
          <h1>Vendor-Mart</h1>
      </div>

      <div class="card-deck mx-2">
        <FeedBox :messages="messages"></FeedBox>

        <div class="card">
          <div class="card-body">
            <p><router-link to="/product/add"><button type="button" class="btn btn-success btn-lg">Add New Item</button></router-link></p>
            <button type="button" class="btn btn-success btn-lg" disabled>Add New Category</button>
          </div>
        </div>
        <SummaryBox :sumBoxMessages="sumBoxMessages"></SummaryBox>
        
      </div>

      <div class=farmerNav>
      </div>
      
      <farmer-product-dash></farmer-product-dash>

  </div>
</template>

<script>
import FeedBox from '../components/FeedBox.vue';
import SummaryBox from '../components/SummaryBox.vue';
import FarmerProductDash from '../components/Product/FarmerProductDash.vue'
import { mapActions, mapState } from 'vuex'

export default {
  name: 'FarmDashboard',
  components: {
      'FeedBox': FeedBox,
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

table.itemSummary {
  border: 2px solid #FFFFFF;
  width: 100%;
  text-align: center;
  border-collapse: collapse;
  padding: 10px;
}
table.itemSummary td, table.itemSummary th {
  border: 1px solid #FFFFFF;
  padding: 3px 4px;
}
table.itemSummary tbody td {
  font-size: 13px;
}
table.itemSummary td:nth-child(even) {
  background: #EBEBEB;
}
table.itemSummary thead {
  background: #FFFFFF;
  border-bottom: 4px solid #333333;
}
table.itemSummary thead th {
  font-size: 15px;
  font-weight: bold;
  color: #333333;
  text-align: center;
  border-left: 2px solid #333333;
}
table.itemSummary thead th:first-child {
  border-left: none;
}

table.itemSummary tfoot td {
  font-size: 14px;
}

.farmerNav {
    margin: 20px;
}
</style>
