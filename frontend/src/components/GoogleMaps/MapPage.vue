<template>
    <div class='container-fluid moore-gradient moore-navy'>
        <div class='row'>

            <div class='col d-flex flex-grow'>
                <map-market :market='market' class='m-2'> </map-market>
            </div>

            <div class='col-md-5 border-navy m-2'>

                <google-map @setMapMarket='setMapMarket' class='align-items-end'> </google-map>

            </div>

        </div>
    </div>
</template>

<script>
import GoogleMap from './GoogleMap.vue'
import MapMarket from './MapMarket.vue'

export default {
    name:'MapPage',
    components: {
        GoogleMap,
        MapMarket
    },
    data() {
        return {
            market: {
                name: 'Please Select A Market To Display'
            }
        }

    },

    computed: {
        
    },

    methods:{
        setMapMarket(e) {
            this.market= e
        }
    }
}
</script>

<style scoped>

.border-navy {
    border-style:solid;
    border-color: #001f3f;
}

</style>
