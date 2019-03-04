<template>
    <div class="card my-3 moore-gradient moore-navy border-color-navy">

            <router-link v-if='product.image' :to='productURL'> <img class='card-img-top' :src='product.image' alt='Card image cap'> </router-link>
            <router-link v-if='!product.image' :to='productURL'> <img class='card-img-top' src='../../assets/no_image.png' alt='No image card cap'> </router-link>


        <hr class='border-color-navy' />

        <div class="card-body">
            
            <div class='height-3'>
                    <router-link :to='productURL' class='moore-navy font-size-18'> {{product.name}} </router-link>
            </div>
            
            <div class='my-3 card-text'>

                    <h5> Price: 
                        <span class='font-size-24 font-weight-bold'> ${{product.price}} </span>
                    </h5>
                    
                    <span v-if='product.quantity > 10' class="badge badge-success">In Stock</span>
                    <span v-else-if='product.quantity === 0' class="badge badge-danger">Out of Stock</span>
                    <span v-else class="badge badge-warning">Only {{product.quantity}} left!</span>
    
                    
            </div>

            <div>
                <h6> Listed by:  

                        <span><router-link :to='productURL' class='moore-navy font-size-16'>  [FarmerName] </router-link></span>

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

.font-size-16 {
    font-size:16px;
}
.font-size-18 {
    font-size:18px;
}
.font-size-24 {
    font-size:24px;
}

.border-color-navy {
    border-color: #001f3f;
}

.height-3 {
    height: 3em;
}
</style>