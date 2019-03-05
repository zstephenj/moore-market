<template>
    <div class='container-fluid moore-gradient moore-navy'>
        <div class='row'>

            <div class='col d-flex flex-grow'>
                <map-market :market='market' class='m-2'> </map-market>
            </div>

            <div class='col-md-5 border-navy m-2'>

                <google-map class='align-items-end' 
                    :sidebar='sidebar'
                    @change-is-pan-to='changeIsPanToFalse'
                    @set-map-market='setMapMarket' 
                    @change-map-place='setMapPlace'
                    @change-is-confirming-location='changeIsConfirmingLocation'> 
                </google-map>

            </div>

            <div class='col-md-2 m-2 d-flex flex-column'>
                <map-sidebar 
                    :isMapPlace='isMapPlace' 
                    @nav-set-gps='changeIsPanToTrue'
                    @clicked-set-location='changeIsSettingLocation' 
                    @clicked-confirm-location='confirmLocation'
                    @change-filter='changeFilter'> 
                </map-sidebar>
            </div>
        </div>
    </div>
</template>

<script>
import GoogleMap from './GoogleMap.vue'
import MapMarket from './MapMarket.vue'
import MapSidebar from './MapSidebar.vue'
export default {
    name:'MapPage',
    components: {
        GoogleMap,
        MapMarket,
        MapSidebar
    },
    data() {
        return {
            // from GoogleMap
            market: {},
            mapPlace: {},
            // from MapSidebar to GoogleMap
            sidebar: {
                isSettingLocation: false,
                isConfirmingLocation: false,
                filter: {},
                isPanTo: false
            }

            
        }

    },

    computed: {
        // props to MapSidebar
        isMapPlace() {
            if (Object.keys(this.mapPlace).length != 0 ) {
                
                return true
            }
            else {
                return false
            }
        },

    },

    methods:{
        // emitted events from GoogleMap
        setMapMarket(market) {
            this.market= market
        },
        setMapPlace(place) {
            this.mapPlace = place
        },
        changeIsConfirmingLocation() {
            this.sidebar.isSettingLocation = false
            this.sidebar.isConfirmingLocation = false
        },

        // emitted events from MapSidebar
        changeIsSettingLocation() {
            this.sidebar.isSettingLocation = !this.sidebar.isSettingLocation
        },
        confirmLocation() {
            this.sidebar.isConfirmingLocation = !this.sidebar.isConfirmingLocation
        },
        changeFilter(filter) {
            this.sidebar.filter = filter
        },
        changeIsPanToTrue() {
            this.sidebar.isPanTo = true
        },
        changeIsPanToFalse() {
            this.sidebar.isPanTo = false
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
