<template>
    <div class="card my-3 moore-gradient moore-navy " style="border-color: #001f3f; ">

        <a :href='productURL'>
            <img v-if='product.image'  class="card-img-top" :src='product.image' alt="Card image cap">
            <img v-if='!product.image'  class="card-img-top" src='../../assets/no_image.png' alt="No image card cap">
        </a>

        <hr style='border-color: #001f3f' />

        <div class="card-body">
            
            <div style='height: 3 em;'>
                <a :href='productURL'>
                    <h5 class="card-title moore-navy">{{product.name}}</h5>
                </a>
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
                    <a :href='farmerURL'>
                        <span class='moore-navy'> [FarmerName] </span>
                    </a>
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
    }
}
</script>

<style scoped>

</style>