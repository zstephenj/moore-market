<template>
    <div v-if='currentUser && allMarkets' class='container-fluid'>

        <!-- <div v-if='(currentUser.accountType === "user" && !currentUser.location) || (currentUser.accountType === "farmer" && currentUser.location.length < 10)'>
            <button type='button' class='btn btn-success'> Add Location </button>
        </div>

        <div v-if='currentUser.accountType === "farmer" && currentUser.location.length < 10'>
            <button type='button' class='btn btn-success'> Add Location </button>
        </div>

    <label>
      AutoComplete
      <gmap-autocomplete @place_changed="setPlace">
      </gmap-autocomplete>
      <button @click="usePlace">Add</button>
    </label> -->
    <div v-if='!isAddingLocation'>
        <button @click='changeIsAddingLocation()' type='button' class='btn btn-warning'> Set Location </button>
    </div>

    <div v-if='isAddingLocation' class='d-flex justify-content-around'>
        <button @click='changeIsAddingLocation()' type='button' class='btn btn-secondary'> Cancel </button>
        <button @click='addNewLocation()' type='button' class='btn btn-success'> Confirm </button>
    </div>
    <gmap-autocomplete @place_changed="setPlace">
    </gmap-autocomplete>

    <br/>

    <gmap-map ref='mapRef' class='gmap'  :zoom='mapZoom' :center='mapCenter' :options="{mapTypeControl: false}">

      <gmap-marker v-for="(marker, index) in markers"
        :key="index"
        :position="marker.position"
        @click='showMarketInfo'/>

      <gmap-marker
        v-if="place && isAddingLocation"
        label="★"
        :position="{
          lat: place.geometry.location.lat(),
          lng: place.geometry.location.lng(),
        }"
        />

    </gmap-map>

    </div>
</template>

<script>
import {mapState, mapActions, mapGetters} from 'vuex'

export default {
    name: 'GoogleMap',
    props: [],

    data() {
        return {
            markers: [],
            place: null,
            isAddingLocation: false,
            mapCenter: {lat: 38.624691, lng: -90.184776},
            mapZoom: 3

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

        setDescription(description) {
            this.description = description;
        },
        setPlace(place) {
            this.place = place
            this.$refs.mapRef.$mapPromise.then((map) => {
                map.panTo({lat: place.geometry.location.lat(), lng: place.geometry.location.lng()})
            })

            // if not at default position at STL Arch at zoom 3 (view of USA), there is a searched position. Zoom in
            if (this.mapCenter != {lat: 38.624691, lng: -90.184776}) {
                this.mapZoom = 10
            }
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
                console.log(newLocation)
                await this.addLocation(newLocation)
                this.changeIsAddingLocation()
                this.$refs.mapRef.$mapPromise.then((map) => {
                    map.panTo({lat: lat, lng: lng})
                })
            }
        },

        showMarketInfo(e) {
            console.log(e)
            let lat = e.latLng.lat()
            let lng = e.latLng.lng()
            let marketPlace = {lat: lat, lng: lng}
            console.log(this.allMarkets)
            let market = this.allMarkets.find(m => m.position.geometry.location.lat() === lat && m.position.geometry.location.lng())
            console.log(market)
        },

    },

    async mounted() {
        let response = await this.getAllMarketsFromApi()
        
        for(let idx in response.data) {
            console.log(this.allMarkets[1])
            let market = response.data[idx]
            let position = {lat: this.allMarkets[idx].position.gps.lat, lng: this.allMarkets[idx].position.gps.lng}
            console.log(position)
            this.markers.push({position})
        }
        console.log(this.markers)
        if (this.currentUser.location.length != 0) {
            this.location = this.currentUser.location[0]
            this.mapZoom = 10
        }
    }


}
</script>

<style>
.gmap {
    width: 600px; height: 300px;
}
</style>
