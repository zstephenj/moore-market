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
                        <input @input='changeFilterDistance($event)' class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value="5">
                        <label  class="form-check-label" for="inlineRadio1">5</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input @input='changeFilterDistance($event)' class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value="15">
                        <label class="form-check-label" for="inlineRadio2">15</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input @input='changeFilterDistance($event)' class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio3" value="30" >
                        <label class="form-check-label" for="inlineRadio3">30</label>
                        
                    </div>
                     <div class="form-check form-check-inline">
                        <input @input='changeFilterDistance($event)' class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio3" value="50"    >
                        <label class="form-check-label" for="inlineRadio3">50</label>
                        
                    </div>
                    <div class="form-check">
                        <input @change='changeFilterFavoriteMarkets($event)' class="form-check-input" type="checkbox" value="" id="defaultCheck1">
                        <label class="form-check-label" for="defaultCheck1">
                            My Favorite Markets
                        </label>
                    </div>
                    <a class="badge badge-secondary">Reset Map</a>
                    <div class='my-2'>
                        <div v-if='!isAddingLocation'>
                            <button @click='emitChangeAdding(0)' type='button' class='btn btn-warning'> Set My Location </button>
                        </div>

                        <div v-if='isAddingLocation' class='d-flex justify-content-around'>
                            <button @click='emitChangeAdding(1)' type='button' class='btn btn-success'> Confirm </button>
                            <button @click='emitChangeAdding(0)' type='button' class='btn btn-secondary'> Cancel </button>
                            
                        </div>
                    </div>
                </div>
                
            </div>
            
        </div>
    </div>
</template>

<script>
export default {
    name: 'MapSidebar',
    props: ['isMapPlace'],
    data() {
        return {
            isAddingLocation: false,
            filter:{
                byDistance: null,
                byFavorite: false
            }
        }
    },

    methods: {
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
            this.changeIsAddingLocation()
        },
        emitChangeFilter() {
            this.$emit('change-filter', this.filter)
        },
        changeFilterDistance(e) {
            this.filter.byDistance = this.milesToMeters(e.target.value)
            this.emitChangeFilter()
        },
        changeFilterFavoriteMarkets() {
            this.filter.byFavorite = !this.filter.byFavorite
            this.emitChangeFilter()
        },
        changeIsAddingLocation(e) {
            this.isAddingLocation = !this.isAddingLocation
        },
        milesToMeters(miles) {
            return miles * 1609.34
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
</style>
