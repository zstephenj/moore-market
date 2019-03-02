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
                        :position="marker.position"
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
export default {
    name: 'GoogleMap',
    props: ['isAddingLocation'],
    components: {
        GmapCluster
    },
    data() {
        return {
            markers: [],
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
            }
            else {
                let lat = this.place.geometry.location.lat()
                let lng = this.place.geometry.location.lng()
                // Pull only relevant properties out of Google Place
                let newLocation = {
                    address_components: this.place.address_components, 
                    adr_address: this.place.adr_address,
                    formatted_address: this.place.formatted_address,
                    gps: {lat: lat, lng: lng},
                    name: this.place.name,
                    place_id: this.place.place_id,
                    url: this.place.url,
                    vicinity: this.place.vicinity
                }
                await this.addLocation(newLocation)
                this.changeIsAddingLocation()
                this.$refs.mapRef.$mapPromise.then((map) => {
                    map.panTo({lat: lat, lng: lng})
                })
            }
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

    },

    async mounted() {
        let response = await this.getAllMarketsFromApi()

        for(let idx in response.data) {
            let market = response.data[idx]
            let position = {lat: this.allMarkets[idx].position.gps.lat, lng: this.allMarkets[idx].position.gps.lng}
            this.markers.push({position})
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
