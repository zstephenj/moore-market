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
    <gmap-autocomplete @place_changed="setPlace">
    </gmap-autocomplete>

    <br/>

    <gmap-map ref='mapRef' class='gmap'  :zoom="1" :center="{lat: 38.6270, lng: -90.1994}" :options="{mapTypeControl: false}">

      <gmap-marker v-for="(marker, index) in markers"
        :key="index"
        :position="marker.position"
        />

      <gmap-marker
        v-if="place && isEditing"
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
import {mapState} from 'vuex'

export default {
    name: 'GoogleMap',
    props: [],

    data() {
        return {
            markers: [],
            place: null,
        }
    },

    computed: {
        ...mapState('user', [
            'currentUser',
        ]),
        
    },

    methods: {
        
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
        }
  }


}
</script>

<style>
.gmap {
    width: 600px; height: 300px;
}
</style>
