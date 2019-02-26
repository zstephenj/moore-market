<template>

    <div v-if='productId' class='container-fluid moore-gradient moore-navy'>

        <div class='row align-items-start justify-content-center'>

            <div class='col-md-6'>

                <div class='my-4'>

                    <img :src='product.image' >
                    <hr style='border-color: #001f3f' />

                </div>

                <div>

                    <div>

                        <h5 align='left' style='font-weight: 588;'> About this item:  </h5>
                        <p style='text-align:left;'> {{product.description}} </p>

                        <div v-if='product.isPerishable === 1'>

                            <h6 align='left' style='text-indent: 1em; font-weight: 555;'> Food Storage Recommendations

                                <a v-if='!showStorage' @click='changeShowStorage()'  class="badge badge-pill badge-success ml-3">Show Info</a>
                                <a v-if='showStorage' @click='changeShowStorage()'  class="badge badge-pill badge-success ml-3">Hide Info</a>
                    
                            </h6>

                            <div v-show='showStorage'>

                                <h6 v-if='product.keepRoom === 1' align='left' style='text-indent: 2em; font-weight: 444;'> Room Temperature: 
                                    <span> {{product.shelfLifeRoom}} </span>
                                </h6>

                                <h6 v-if='product.keepFridge === 1' align='left' style='text-indent: 2em; font-weight: 444;'> Refrigerator: 
                                    <span> {{product.shelfLifeRoom}} </span>
                                </h6>

                                <h6 v-if='product.keepFreezer === 1' align='left' style='text-indent: 2em; font-weight: 444;'> Freezer: 
                                    <span> {{product.shelfLifeRoom}} </span>
                                </h6>

                            </div>

                        </div>

                        <hr style='border-color: #001f3f' />

                    </div>

                </div>

            </div>

            <div class='col-md-4' style='text-align:left;'>

                <div class='my-4'>

                    <h3 style='font-weight: 555; text-align:left;'> {{product.name}} </h3>

                </div>

                <div class='my-3'>

                    <h5> Price: 
                        <span style='font-size: 24px; font-weight: 588;'> ${{product.price}} </span>

                        <span v-if='product.quantity > 10' class="badge badge-success">In Stock</span>
                        <span v-else-if='product.quantity === 0' class="badge badge-danger">Out of Stock</span>
                        <span v-else class="badge badge-warning">Only {{product.quantity}} left!</span>
    
                    </h5>

                </div>


                <form>

                    <div class='form-group row my-4'>
                        <label for='addCartQuantity' class='col-md-2 col-form-label' style='font-size: 18px;'>Quantity: </label>
                        <div class='col-md-3'>
                            <input type='number' class='form-control' id='addCartQuantity' value='1'>
                        </div>
                    </div>

                    <!-- donate to pantry option? -->

                    <button type='button' class='btn btn-block btn-success'> Add to Cart </button>
                    
                </form>

                <hr style='border-color: #001f3f' />

                <!-- Add Farmer info div, pull in product.farmerID & product.farmer, href to farmer store etc. -->

            </div>

        </div>

        <div class='row justify-content-start'>

            <div class='col-md-6 '>

                <div class='ml-3'>
                    <h5 align='left' style='font-weight: 588;'> Other products in {{product.category.name}}: </h5>
                    <!-- Add ProductSearchResult cards? -->
                </div>

            </div>

        </div>

    </div>
</template>

<script>
import axios from 'axios'
import {mapActions, mapGetters} from 'vuex'

export default {
    name: "SingleProduct",

    props: [],

    data(){
            return {
                productId: parseInt(this.$route.params.id) ,
                product: [],
                showStorage: false
            }
    },

    computed: {
        ...mapGetters('product', [
            'getProductById'
        ]),

        getProduct(){
            return this.getProductById(this.productId)
        }
    },

    methods: {
        ...mapActions('product', [
            'getAllProductsFromTest'
        ]),

        changeShowStorage(){
            this.showStorage = !this.showStorage
        }
    },


    created() {
        
        let db = ''
        this.getAllProductsFromTest(db)
        console.log(this.productId)

        console.log(this.product)
    },

    mounted() {
        console.log(this.getProduct)
        this.product = this.getProduct

    }
}
</script>

<style>

</style>
