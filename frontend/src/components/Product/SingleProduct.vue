<template>

    <div class='container-fluid' style="background: linear-gradient(-90deg, #84CF6A, #16C080); color: #001f3f;">

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

export default {
    name: "SingleProduct",

    props: [],

    data(){
            return {
                product: []
            }
    },

    methods: {

    },


    created() {
        
        let getUrl = 'http://my-json-server.typicode.com/zstephenj/moore-market-fakejson/products/' + this.$route.params.id
        
        axios.get(getUrl)
        .then (res => this.product = res.data)
        .catch (error => console.log(error))
        
    }

}
</script>

<style>

</style>
