<template>
    <div class='container-fluid'>
      <h1>This will be the User Dashboard</h1>

      <div class="row">
        <div class="col-5">
          <h4>Product List</h4>
          <ul class="list-unstyled">
            <li v-for="product in allProducts" :key="product.id" class="media text-left border border-success px-1 my-2">
              <img src="https://via.placeholder.com/64" class="pr-3">
              <div class="media-body">
                <h5 class="mt-0 mb-1"><router-link :to="{name: 'SingleProduct', params: { id: product.id },}">{{ product.name }}</router-link>  ${{Number(product.price).toFixed(2)}}</h5>
                {{ product.description }}
              </div>
            </li>
          </ul>
        </div> 
        <div class="col-7"> 
          <map-page> </map-page>
          
        </div>
      </div>  
    </div>
</template>

<script>
import { mapActions, mapState } from 'vuex'
import MapPage from '../components/GoogleMaps/MapPage.vue'
export default {
  name: 'userdashboard',
  components: {
      MapPage
  },
  data() {
    return {
      }
  },

  created() {
    this.getFarmers(),
    this.getAllProductsFromApi()
  },

  mounted(){
    this.getLocation()
  },

  computed: {
    ...mapState('product', ['allProducts']),
    ...mapState('farmer', ['allFarmers'])
  },

  methods: {
    ...mapActions('product', ['getAllProductsFromApi']),
    ...mapActions('farmer', ['getFarmers']),
  
  }  

}
</script>

