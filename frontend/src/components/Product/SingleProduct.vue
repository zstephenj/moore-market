<template>
    <div class='container-fluid'>
        <div class='row align-items-start justify-content-center'>
            
            <div class="card col-md-6" style='border-color: Green; background-color: #2ECC40; color: #001f3f;'>

                <div class='card-header' style='background-color: LightGreen'>
                    <h2 style=''> {{product.name}} </h2>
                </div>

                <div class='justify-content-center'>
                    <img class="card-img-top img-thumbnail" style='border-color: DarkGreen; max-width: 50%;' :src='product.image' alt="Card image cap">
                </div>

                <div class="card-body">
                    <h5 class="card-title d-flex justify-content-start" style='background-color: #3D9970; text-indent: 0.25em;border: solid; border-color: darkgreen;'> About this product </h5>
                    <p class="card-text d-flex justify-content-start" style='text-indent: 2em'>{{product.description}}</p>
                </div>

                <ul class="list-group list-group-flush" v-if='product.isPerishable === 1'>
                    <li class="list-group-item">Cras justo odio</li>
                    <li class="list-group-item">Dapibus ac facilisis in</li>
                    <li class="list-group-item">Vestibulum at eros</li>
                </ul>
                <div class="card-body">
                    <a href="#" class="card-link">Card link</a>
                    <a href="#" class="card-link">Another link</a>
                </div>
                <div>
                    <input type='checkbox' @change='test' >
                </div>
            </div>  

            <div class='card col-md-4' style='border-color: Green; background-color: LightGreen; color: DarkGreen;' >
                <div class='card-body'>
                    <p>sdfsadf</p>
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
        test() {
            console.log(this.product)
        }
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
.hide-form {
  display: none;
}

</style>
