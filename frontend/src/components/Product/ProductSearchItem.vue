<template>
    <div class="card my-3 moore-gradient moore-navy " style="border-color: #001f3f; ">

            <router-link v-if='product.image' :to='productURL'> <img class='card-img-top' :src='product.image' alt='Card image cap'> </router-link>
            <router-link v-if='!product.image' :to='productURL'> <img class='card-img-top' src='../../assets/no_image.png' alt='No image card cap'> </router-link>


        <hr style='border-color: #001f3f' />

        <div class="card-body">
            
            <div style='height: 3em;'>
                    <router-link :to='productURL' class='moore-navy' style='font-size:18px;'> {{product.name}} </router-link>
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

                        <span><router-link :to='productURL' class='moore-navy' style='font-size:16px;'>  [FarmerName] </router-link></span>

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

    }
}
</script>

<style scoped>
.mousePointer {
    cursor: pointer;
}
.mousePointer:hover {
    text-decoration:underline;
}
</style>