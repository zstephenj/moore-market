<template>
    <div v-if='currentUser' class='container-fluid'>

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

    <gmap-map ref='mapRef' class='gmap'  :zoom="3" :center='location' :options="{mapTypeControl: false}">

      <gmap-marker v-for="(marker, index) in markers"
        :key="index"
        :position="marker.position"
        />

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
import {mapState, mapActions} from 'vuex'

export default {
    name: 'GoogleMap',
    props: [],

    data() {
        return {
            markers: [],
            place: null,
            isAddingLocation: false,
            location: {lat: 38.6270, lng: -90.1994}
        }
    },

    computed: {
        ...mapState('user', [
            'currentUser',
        ]),
        
    },

    methods: {
        ...mapActions('user', [
            'addLocation'
        ]),

        setDescription(description) {
            this.description = description;
        },
        setPlace(place) {
            this.place = place
            this.$refs.mapRef.$mapPromise.then((map) => {
                map.panTo({lat: place.geometry.location.lat(), lng: place.geometry.location.lng()})
            })
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
                await this.addLocation(this.place)
                this.changeIsAddingLocation()
                this.$refs.mapRef.$mapPromise.then((map) => {
                    map.panTo({lat: this.place.geometry.location.lat(), lng: this.place.geometry.location.lng()})
                })
            }
        }
    },

    mounted() {
        if (this.currentUser.location.length != 0) {
            this.location = this.currentUser.location[0]
        }
    }


}
</script>

<style>
.gmap {
    width: 600px; height: 300px;
}
</style>
