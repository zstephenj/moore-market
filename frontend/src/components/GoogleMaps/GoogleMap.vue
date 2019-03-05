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
                    <gmap-marker v-for="(marker, index) of markers"
                        :key="index"
                        :position="marker.position"
                        @click='setMapMarket'/>
                </gmap-cluster>

                <gmap-marker
                    v-if="place && sidebar.isSettingLocation"
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
    props: ['sidebar'],
    components: {
        GmapCluster
    },
    data() {
        return {
            markets: [],
            place: null,
            mapCenter: {lat: 38.624691, lng: -90.184776},
            oldFilter: {},
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
        isConfirmingLocation() {
            return this.sidebar.isConfirmingLocation
        },
        filter () {
            return this.sidebar.filter
        },
        markers() {
            let markers = []
            for (let market of this.markets) {
                let gps = market.position.gps
                let title = market.name
                let marker = {position: gps, title: title}
                markers.push(marker)
            }
            return markers
        },
    },

    methods: {
        ...mapActions('user', [
            'setLocation'
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

        emitChangeIsConfirmingLocation() {
            this.$emit('change-is-confirming-location')
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
            for(let favoriteMarketId of this.currentUser.favoriteMarkets) {
                if (favoriteMarketId === market.id)
                    return true
            }
            return false
        },
        filterMarketsByDistance(market) {
            let lat = market.position.gps.lat
            let lng = market.position.gps.lng
            let point = new google.maps.LatLng(lat, lng)
            console.log(point)
            let userPoint = new google.maps.LatLng(this.currentUser.location.gps,lat, this.currentUser.location.gps.lng)
            let distanceBetween = google.maps.geometry.spherical.computeDistanceBetween(point, userPoint)
            console.log(distanceBetween)
            if (distanceBetween < this.sidebar.filter.byDistance) {
                return true
            }
            else {
                return false
            }
        },
        
    },
    watch: {
        filter: {
            handler: 
                function (filter) {
                
                    console.log('filtering')
                    this.markets = this.allMarkets
                    console.log(filter)
                    if (filter.byFavorite === true) {
                        console.log('filter favs')
                        let filteredMarkets = this.markets.filter(this.filterMarketsByFavorite)
                        this.markets = filteredMarkets
                        console.log(filteredMarkets)
                    }
                    if (filter.byDistance != null) {
                        if (Object.keys(this.currentUser.location).length != 0) {
                            console.log('filtering distance')
                            let filteredMarkets = this.markets.filter(this.filterMarketsByDistance)
                            console.log(filteredMarkets)
                            this.markets = filteredMarkets
                        }
                    }
                },
            deep: true
        },
        isConfirmingLocation: 
                async function (isConfirmingLocation) {
                    if (this.place) {
                    let newLocation = this.getPlacePosition()
                    let response = await this.setLocation(newLocation)
                    console.log(response)
                    //change to response.data
                    this.setCenter(response.gps, 10)
                    this.emitChangeIsConfirmingLocation()
                }
        }
    },
    async mounted() {
        let response = await this.getAllMarketsFromApi()

        for(let market of response.data) {
            this.markets.push(market)
        }
        
        if (this.currentUser.location.gps) {
            this.setCenter(this.currentUser.location.gps, 10)
        }
    }


}
</script>

<style scoped>
html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }

.gmap {
    width: 100%; height: 333px;
}

.border-navy {
    border-style:solid;
    border-color: #001f3f;
}
</style>
