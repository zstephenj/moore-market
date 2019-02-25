<template>
    <div class="card my-3 moore-gradient moore-navy " style="border-color: #001f3f; ">

            <img v-if='product.image' @click='goToProduct(product.id)'  class="card-img-top mousePointer" :src='product.image' alt="Card image cap">
            <img v-if='!product.image' @click='goToProduct(product.id)'  class="card-img-top mousePointer" src='../../assets/no_image.png' alt="No image card cap">


        <hr style='border-color: #001f3f' />

        <div class="card-body">
            
            <div style='height: 3 em;'>

                    <h5 @click='goToProduct(product.id)' class="card-title moore-navy mousePointer">{{product.name}}</h5>

            </div>
            
            <div class='my-3 card-text'>

                    <h5> Price: 
                        <span style='font-size: 24px; font-weight: 588;'> ${{product.price}} </span>
                    </h5>
                        <span v-if='product.quantity > 10' class="badge badge-success">In Stock</span>
                        <span v-else-if='product.quantity === 0' class="badge badge-danger">Out of Stock</span>
                        <span v-else class="badge badge-warning">Only {{product.quantity}} left!</span>
    
                    
            </div>

            <div>
                <h6> Listed by:  

                        <span @click='goToFarmer(product.farmerid)' class='moore-navy mousePointer'> [FarmerName] </span>

                </h6>
            </div>
        </div>

    </div>
</template>

<script>

export default {
    name: "ProductSearchItem",

    props: ['product'],

    data() {
        return {
            productURL: '../product/' + this.product.id ,
            farmerURL: '../vendor/' //+ this.product.farmerid
        }
    },

    methods:{
        goToProduct(id) {
            this.$router.push({ name: 'SingleProduct', params:{id:id} })
        },
        goToFarmer(id) {
            this.$route.push({ name: 'Farmer', params:{id:id} })
        }
    }
}
</script>

<style>
.mousePointer {
    cursor: pointer;
}
.mousePointer:hover {
    text-decoration:underline;
}
</style>