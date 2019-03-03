<template>
    <div class='container-fluid border-navy'>
        
        <div v-if='Object.keys(market).length === 0' class='my-2'>
            <h2>Please Select A Market To Display</h2>
            <hr class='border-navy' />
        </div>

        <div v-if='Object.keys(market).length != 0'>
            <div class='my-2'>
                <h2>{{market.name}}</h2>
            </div>
            <hr class='border-navy' />
            
            <div class=''>
                <h5> 
                    {{market.position.formatted_address}} 
                  
                </h5>
                <span class='ml-2'><a :href='market.position.url' class='badge badge-info' target="_blank" rel="noopener noreferrer"> Get Directions </a></span>
                <span class='ml-2'><a class='badge badge-info'>Favorite</a></span> 
                <span class='ml-2'><a class='badge badge-warning'>Favorited</a></span> 
                <span class='ml-2'><a class='badge badge-warning'>Add to My Markets</a></span>     
                <span class='ml-2'><a class='badge badge-warning'>Add to Favorite Market</a></span> 
            </div>

        </div>

    </div>
</template>

<script>
export default {
    name: 'MapMarket',
    props: ['market'],

}
</script>

<style scoped>

.border-navy {
    border-style:solid;
    border-color: #001f3f;
}

</style>
