<template>
    <div class="container-fluid d-flex h-100">
        <div class='row h-100'>
            
            <div class="card sidebar-background h-100  d-flex flex-column flex-grow">
                <div class="card-body ">
                    <h5 class="card-title">Card title</h5>
                    <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                    <div>
                        <div v-if='!isAddingLocation'>
                            <button @click='emitChangeAdding(0)' type='button' class='btn btn-warning'> Set My Location </button>
                        </div>

                        <div v-if='isAddingLocation' class='d-flex justify-content-around'>
                            <button @click='emitChangeAdding(1)' type='button' class='btn btn-success'> Confirm </button>
                            <button @click='emitChangeAdding(0)' type='button' class='btn btn-secondary'> Cancel </button>
                            
                        </div>
                    </div>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="#" class="card-link">Card link</a>
                    <a href="#" class="card-link">Another link</a>
                </div>
                <div class='accordion' id='sidebar'>
                    <div class="card">
                        <div class="card-header" id="headingOne">
                            <h5 class="mb-0">
                                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                                Filter Markets: 
                                </button>
                            </h5>
                        </div>
                        <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#sidebar">
                            <div class="card-body">
                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                            </div>
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
        changeIsAddingLocation() {
            this.isAddingLocation = !this.isAddingLocation
        }
    }
}
</script>

<style scoped>
.sidebar-background {
    background-color: rgb(0, 31, 63, 0.85);
    width: 100%;
}

</style>
