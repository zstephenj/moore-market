<template>
    <div v-if='currentUser' class='container-fluid'>

        <div v-if='(currentUser.accountType === "user" && !currentUser.location) || (currentUser.accountType === "farmer" && currentUser.location.length < 10)'>
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
    </label>

    <br/>

    <gmap-map style="width: 600px; height: 300px;" :zoom="1" :center="{lat: 0, lng: 0}">

      <gmap-marker v-for="(marker, index) in markers"
        :key="index"
        :position="marker.position"
        />

      <gmap-marker
        v-if="this.place"
        label="★"
        :position="{
          lat: this.place.geometry.location.lat(),
          lng: this.place.geometry.location.lng(),
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

</style>
