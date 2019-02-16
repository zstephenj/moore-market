<template>
    <div class="productList">
        {{ product.name }}
    </div>
</template>

<script>
import axios from 'axios'

export default {
    name: 'ProductList',
    data() {
        return {
            product: null
        }
    },
    mounted: function() {
        let products = axios.get('https://localhost:5001/products')
        this.product = products[0]
    }
}
</script>

<style>

</style>
