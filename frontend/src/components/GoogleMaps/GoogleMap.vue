<template>
    <div v-if='currentUser && allMarkets' class='container-fluid'>

        <!-- <div v-if='(currentUser.accountType === "user" && !currentUser.location) || (currentUser.accountType === "farmer" && currentUser.location.length < 10)'>
            <button type='button' class='btn btn-success'> Add Location </button>
        </div>

        <div v-if='currentUser.accountType === "farmer" && currentUser.location.length < 10'>
            <button type='button' class='btn btn-success'> Add Location </button>
        </div> -->
        <h2 class='my-2'> Markets Near Me </h2>

        <hr class='border-navy' />
        

        <div class='row justify-content-center'>
            <gmap-autocomplete @place_changed="setPlace" class='d-flex flex-grow-1'> </gmap-autocomplete>
        </div>

        <div class='row justify-content-center'>
            <gmap-map ref='mapRef' class='gmap mb-2' :zoom='3' :center='mapCenter' :options="{mapTypeControl: false}">

                <gmap-cluster @click='clickCluster'>
                    <gmap-marker v-for="(marker, index) in markers"
                        :key="index"
                        :position="markers[index].position"
                        @click='setMapMarket'/>
                </gmap-cluster>

                <gmap-marker
                    v-if="place && isAddingLocation"
                    label="★"
                    :position="{
                    lat: place.geometry.location.lat(),
                    lng: place.geometry.location.lng()}"
                    />

            </gmap-map>

        </div>
    </div>
</template>

<script>
import {mapState, mapActions, mapGetters} from 'vuex'


import GmapCluster from 'vue2-google-maps/src/components/cluster'
import {gmapApi} from 'vue2-google-maps'
export default {
    name: 'GoogleMap',
    props: ['isAddingLocation', 'filter'],
    components: {
        GmapCluster
    },
    data() {
        return {
            markets: [],
            place: null,
            mapCenter: {lat: 38.624691, lng: -90.184776},
        }
    },

    computed: {
        ...mapState('user', [
            'currentUser',
        ]),
        ...mapState('market', [
            'allMarkets',
        ]),
        google: gmapApi,
        markers() {
            let markers = []
            for (let idx in this.markets) {
                let gps = this.markets[idx].position.gps
                let title = this.markets[idx].name
                let marker = {position: gps, title: title}
                markers.push(marker)
            }
            return markers
        }
    },

    methods: {
        ...mapActions('user', [
            'addLocation'
        ]),
        ...mapActions('market', [
            'getAllMarketsFromApi'
        ]),

        // Async: since we get the Gmap from API, we must return a Promise
        async setCenter(gps, zoom) {
            let map = await this.$refs.mapRef.$mapPromise
            map.panTo({lat: gps.lat, lng: gps.lng})
            if (zoom != 0) {
                map.setZoom(zoom)
            }
        },

        setDescription(description) {
            this.description = description;
        },
        setPlace(place) {
            this.place = place
            let gps = {lat: this.place.geometry.location.lat(),
                       lng: this.place.geometry.location.lng()}
            
            this.setCenter(gps, 10)
            this.$emit('change-map-place', place)
        },
        usePlace(place) {
            if (this.place) {
                this.markers.push({
                    position: {
                    lat: this.place.geometry.location.lat(),
                    lng: this.place.geometry.location.lng(),
                    }
                })

            this.place = null;
            }
        },

        clickCluster(e) {
            let gps = {
                lat: e.center_.lat(),
                lng: e.center_.lng()
            }
            this.setCenter(gps, 0)
        },

        changeIsAddingLocation() {
            this.isAddingLocation = !this.isAddingLocation
        },
        async addNewLocation() {
            if (!this.place) {
                console.log('error')
                return false
            }
            else {
                let newLocation = this.getPlacePosition()
                await this.addLocation(newLocation)
                this.setCenter(gps, 10)
                this.changeIsAddingLocation()
                
            }
        },
        async addNewMarket() {
            if (this.place === 12345) {
                console.log('error')
                return false
            }

        },
        getPlacePosition(type) {
            let lat = this.place.geometry.location.lat()
            let lng = this.place.geometry.location.lng()
            let gps = {lat: lat, lng: lng}
            // Pull only relevant properties out of Google Place
            let position = {
                formatted_address: this.place.formatted_address,
                gps: gps,
                vicinity: this.place.vicinity
            }  
            if (type === 'market') {
                position.url = this.place.url
            }
            return position
        },

        setMapMarket(e) {
            console.log(e)
            let lat = e.latLng.lat()
            let lng = e.latLng.lng()
            let market = this.allMarkets.find(m => m.position.gps.lat === lat && m.position.gps.lng === lng)
            let gps = {
                lat: lat,
                lng: lng
            }
            this.setCenter(gps, 15)
            this.$emit('set-map-market', market)
        },
        filterMarketsByFavorite(market) {
            for(let idx in this.currentUser.favoriteMarkets) {
                let fm = this.currentUser.favoriteMarkets
                if (fm[idx] === market.id)
                    return true
            }
            return false
        },
        filterMarketsByDistance(distance) {
            for (idx in this.markets) {

            }
        },
        
    },
    watch: {
        filter: {
            handler: async function (filter, oldFilter) {
                let map = await this.$refs.mapRef.$mapPromise
                if (filter.byFavorite === true) {
                    let filteredMarkets = this.markets.filter(this.filterMarketsByFavorite)
                    this.markets = filteredMarkets
                    console.log(filteredMarkets)
                }
                if (filter.byDistance !=  oldFilter.byDistance) {
                    this.filterMarketsByDistance(filter.byDistance)
                }
                
            },
            deep: true
        }
    },
    async mounted() {
        let response = await this.getAllMarketsFromApi()

        for(let idx in response.data) {
            let market = response.data[idx]
            this.markets.push(market)
        }
        
        if (this.currentUser.location.length != 0) {
            this.location = this.currentUser.location[0]
            this.mapZoom = 10
        }
    }


}
</script>

<style scoped>

.gmap {
    width: 100%; height: 333px;
}

.border-navy {
    border-style:solid;
    border-color: #001f3f;
}
</style>
