<template>

    <div v-if='product' class='container-fluid moore-gradient moore-navy'>

        <div class='row align-items-start justify-content-center'>

            <div class='col-md-6'>

                <div class='my-4'>

                    <img :src='product.image' >
                    <hr class='border-color-navy' />

                </div>

                <div>

                    <div>

                        <h5 align='left' class='font-weight-bold'> About this item:  </h5>
                        <p class='text-left'> {{product.description}} </p>

                        <div v-if='product.isPerishable === 1'>

                            <h6 align='left' class='font-weight-bold indent-1'> Food Storage Recommendations

                                <a v-if='!showStorage' @click='changeShowStorage()'  class="badge badge-pill badge-success ml-3">Show Info</a>
                                <a v-if='showStorage' @click='changeShowStorage()'  class="badge badge-pill badge-success ml-3">Hide Info</a>
                    
                            </h6>

                            <div v-show='showStorage'>

                                <h6 v-if='product.keepRoom === 1' align='left' class='indent-2'> Room Temperature: 
                                    <span> {{product.shelfLifeRoom}} </span>
                                </h6>

                                <h6 v-if='product.keepFridge === 1' align='left' class='indent-2'> Refrigerator: 
                                    <span> {{product.shelfLifeRoom}} </span>
                                </h6>

                                <h6 v-if='product.keepFreezer === 1' align='left' class='indent-2'> Freezer: 
                                    <span> {{product.shelfLifeRoom}} </span>
                                </h6>

                            </div>

                        </div>

                        <hr class='border-color-navy' />

                    </div>

                </div>

            </div>

            <div class='col-md-4 text-left'>

                <div class='my-4'>

                    <h3 class='font-weight-bold'> {{product.name}} </h3>

                </div>

                <div class='my-3'>

                    <h5> Price: 
                        <span class='font-weight-bold font-size-24'> ${{product.price}} </span>

                        <span v-if='product.quantity > 10' class="badge badge-success">In Stock</span>
                        <span v-else-if='product.quantity === 0' class="badge badge-danger">Out of Stock</span>
                        <span v-else class="badge badge-warning">Only {{product.quantity}} left!</span>
    
                    </h5>

                </div>


                <form>

                    <div class='form-group row my-4'>
                        <label for='addCartQuantity' class='col-md-2 col-form-label font-size-18'>Quantity: </label>
                        <div class='col-md-3'>
                            <input type='number' class='form-control' id='addCartQuantity' value='1'>
                        </div>
                    </div>

                    <!-- donate to pantry option? -->

                    <button type='button' class='btn btn-block btn-success'> Add to Cart </button>
                    
                </form>

                <hr class='border-color-navy' />

                <!-- Add Farmer info div, pull in product.farmerID & product.farmer, href to farmer store etc. -->

            </div>

        </div>

        <div class='row justify-content-start'>

            <div class='col-md-6 '>

                <div class='ml-3'>
                    <h5 align='left' class='font-weight-bold'> Other products in {{product.category.name}}: </h5>
                    <!-- Add ProductSearchResult cards? -->
                </div>

            </div>

        </div>

    </div>
</template>

<script>
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
        
    },

    methods: {
        ...mapActions('product', [
            'getAllProductsFromApi'
        ]),

        changeShowStorage(){
            this.showStorage = !this.showStorage
        }
    },


    async created() {
        await this.getAllProductsFromApi()
        this.product = this.getProductById(this.productId)
    },
}
</script>

<style scoped>

.font-size-18 {
    font-size:18px;
}
.font-size-24 {
    font-size:24px;
}

.border-color-navy {
    border-color: #001f3f;
}

.indent-1 {
    text-indent: 1em;
}
.indent-2{
    text-indent: 1em;
}

</style>
