<template>
    <div class="container-fluid d-flex h-100">
        <div class='row h-100'>
            
            <div class="card sidebar-background h-100  d-flex flex-column flex-grow text-green">
                <div class="card-body ">
                    
                    
                    <h5 class="card-title"> Filter Markets </h5>
                    <div>
                        Distance (mi): 
                    </div>
                    <div class="form-check form-check-inline">
                        <input v-model='byDistance' class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" :value="8046.7" :disabled='!isUserLocation'>
                        <label  class="form-check-label" for="inlineRadio1">5</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input v-model='byDistance' class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" :value="24140.1" :disabled='!isUserLocation'>
                        <label class="form-check-label" for="inlineRadio2">15</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input v-model='byDistance' class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio3" :value="48280.2" :disabled='!isUserLocation'>
                        <label class="form-check-label" for="inlineRadio3">30</label>
                        
                    </div>
                     <div class="form-check form-check-inline">
                        <input v-model='byDistance' class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio3" :value="80467" :disabled='!isUserLocation'>
                        <label class="form-check-label" for="inlineRadio3">50</label>
                        
                    </div>
                    <div class="form-check">
                        <input v-model='byFavorite' class="form-check-input" type="checkbox" :value="true" id="defaultCheck1">
                        <label class="form-check-label" for="defaultCheck1">
                            My Favorite Markets
                        </label>
                    </div>
                    <a @click='resetMap()' class="badge badge-secondary">Reset Map</a>
                    
                    <div class='mt-3'>
                        <h6> Set Location by: </h6>
                        <button @click='getPosition' type="button" class="btn btn-moore-invert btn-sm"><img class='gps-img mr-2' src='../../assets/gps_target.png'>My Location</button>
                        <div class='my-2'>
                            <div v-if='!isSettingLocation'>
                                <button @click='emitChangeAdding(0)' type='button' class='btn btn-moore-invert btn-sm'> Map Search </button>
                            </div>

                            <div v-if='isSettingLocation' class='d-flex justify-content-around'>
                                <button @click='emitChangeAdding(1)' type='button' class='btn btn-success btn-sm'> Confirm </button>
                                <button @click='emitChangeAdding(0)' type='button' class='btn btn-secondary btn-sm'> Cancel </button>
                                
                        </div>
                    </div>
                    </div>
                </div>
                
            </div>
            
        </div>
    </div>
</template>

<script>
import {mapState, mapActions} from 'vuex'

export default {
    name: 'MapSidebar',
    props: ['isMapPlace'],
    data() {
        return {
            isSettingLocation: false,
            byDistance: null,
            byFavorite: false
        }
    },
    computed: {
        ...mapState('user', [
            'currentUser'
        ]),

        filter() {
            let newFilter = {}
            if (this.byDistance != undefined) {
                newFilter.byDistance = this.byDistance
            }
            else {
                newFilter.byDistance = null
            }
            newFilter.byFavorite = this.byFavorite
            console.log(newFilter)
            this.$emit('change-filter', newFilter)
            return newFilter
        },
        isUserLocation() {
            let location = Object.keys(this.currentUser.location)
            return (location.length != 0 ? true: false)
        }
    },
    methods: {
        ...mapActions('user', [
            'setLocation'
        ]),
        emitChangeAdding(confirmed) {
            if (confirmed === 0) {
                this.$emit('clicked-set-location')
            }
            if (confirmed === 1) {
                console.log(this.isMapPlace)
                if (this.isMapPlace === false) {
                    console.log('error')
                    return false
                }
                else {
                    this.$emit('clicked-confirm-location')    
                }
            }
            this.changeIsSettingLocation()
        },
        resetMap() {
            this.byDistance= null,
            this.byFavorite= false
        },
        changeFilterFavoriteMarkets() {
            this.filter.byFavorite = !this.filter.byFavorite
        },
        changeIsSettingLocation(e) {
            this.isSettingLocation = !this.isSettingLocation
        },
        getPosition() {
            if(navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(this.setPosition);
            } else {
                this.error = "Geolocation is not supported";
            }
        },
        async setPosition(navGeo) {
            let gps = {
                lat: navGeo.coords.latitude,
                lng: navGeo.coords.longitude
            }
            let position = {
                gps: gps
            }
            let response = await this.setLocation(position)
            this.$emit('nav-set-gps')
            console.log(response)
        }
    }
}
</script>

<style scoped>
.sidebar-background {
    background-color: rgb(0, 31, 63, 0.85);
    width: 100%;
}

.text-green {
    color: #84CF6A;
}

.gps-img {
    width: 15%;
    height: 15%;
}

.btn-moore-invert {
    background-color:#84CF6A ;
    color:#001f3f;
}
</style>
