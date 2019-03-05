<template>
    <div class='container-fluid border-navy'>
        
        <div v-if='Object.keys(market).length === 0' class='my-2'>
            <h2>Please Select A Market To Display</h2>
            <hr class='border-navy' />
        </div>

        <div v-if='Object.keys(market).length != 0'>
            <div class='my-2'>
                <h2>{{market.name}}</h2>
            </div>
            <hr class='border-navy' />
            
            <div class=''>
                <h5> 
                    {{market.position.formatted_address}} 
                  
                </h5>
                <span class='ml-2'><a :href='market.position.url' class='badge badge-moore' target="_blank" rel="noopener noreferrer"> Get Directions </a></span>
                <span v-if='!isFavorite' @click='changeFavoriteMarket(1)' class='ml-2 badge badge-notfav mousePointer'>Favorite</span> 
                <span v-if='isFavorite' @click='changeFavoriteMarket(0)' class='ml-2 badge badge-fav mousePointer'>Favorited</span> 
                <span @click='addCurrentUserToMarket()' class='ml-2 badge badge-moore mousePointer'>Add My Store</span>     
                <span class='ml-2'><router-link class='badge badge-moore' :to='"../search/markets/"+market.id'>Search Market Products</router-link></span> 
            </div>

            <hr class='border-navy' />
            <h4 class='font-weight-bold'> Farmers at this Market </h4>
            <hr class='border-navy w-50' />
            <div v-if='numCarousels === 0'>
                <h6> No Farmers Yet </h6>
            </div>
            <div v-if='numCarousels > 0' id="carousel" class="carousel slide" data-ride="carousel">
                
                <div class="carousel-inner ">
                    <div v-for='num in Object.keys(carouselFarmersIds).length' :key='"car" + num' class="carousel-item" :class='{active: num === 1}'>
                        
                            <div class='row justify-content-center' v-for='farmer in carouselFarmersIds[num-1].length' :key='farmer'>

                                    <router-link-button type='farmer' :item='carouselFarmersIds[num-1][farmer-1]' :buttonText='carouselNames[num-1][farmer-1]' class='my-3'> </router-link-button>
                                
                            </div>
                        
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
            
        </div>

    </div>
</template>

<script>
import {mapState, mapActions} from 'vuex'
import RouterLinkButton from '../RouterLinkButton.vue'

export default {
    name: 'MapMarket',
    props: ['market'],
    components: {
        RouterLinkButton
    },
    data() {
        return {
            url: '../farmers/',
            carouselNames: {},
            carouselFarmersIds: {},
            isOverFavButton: false
        }
    },
    computed: {
        ...mapState('user', [
            'currentUser'
        ]),
        numCarousels() {
            let num
            if (Object.keys(this.market).length != 0) {
                num = Math.ceil(this.market.farmersIds.length / 4)
                for (let i = 0; i < num; i++) {
                    let farmersIds = []
                    farmersIds = this.market.farmersIds.slice(i*4, (i+1)*4)
                    this.carouselFarmersIds[i] = farmersIds
                }
                for (let i = 0; i < num; i++) {
                    
                    let farmersNames = this.market.farmersNames.slice(i*4, (i+1)*4)
                    this.carouselNames[i] = farmersNames
                    
                }
            } else {
                num = 0
            }
            
            return num
        },
        isFavorite(){
            let included
            if (Object.keys(this.market).length != 0) {
                included = this.currentUser.favoriteMarkets.includes(this.market.id)
            } else {
                included = false
            }
            return (included ? true: false)
        },
        favButtonText() {
            let buttonText
            if (this.isOverFavButton === true) {
                buttonText = 'Unfavorite'
            } else {
                buttonText = 'Favorited'
            }
            return buttonText
        }
    },
    methods: {
        ...mapActions('user', [
            'addFavoriteMarket',
            'removeFavoriteMarket',
            ''
        ]),
        addCurrentUserToMarket() {

        },
        async changeFavoriteMarket(num) {
            console.log('trying to change')
            if (num === 1) {
                
                await this.addFavoriteMarket(this.market.id)
            }
            if (num === 0) {
                await this.removeFavoriteMarket(this.market.id)
            }
        }
    },
    async mounted() {
         
    }
}
</script>

<style scoped>

.border-navy {
    border-style:solid;
    border-color: #001f3f;
}
.pc-button {
    border-style: solid;
    border-color: #001f3f;
    color: #001f3f;
    font-weight: 600;
    padding: 0.5em;
}

.pc-button:hover {
    background-color: #001f3f;
    color: #16C080;
    font-weight: 600;
    padding: 0.5em;
}

.badge-fav {
    background-color: gold;
}
.badge-fav:hover {
    background-color: gray;
}
.badge-notfav {
    background-color: gray;
}
.badge-notfav:hover {
    background-color: gold;
}

.badge-moore {
    background-color:#001f3f ;
    color:#84CF6A;
}
.badge-moore:hover {
    background-color:rgb(0, 31, 63, 0.85) ;
    color:#84CF6A;
}
.mousePointer {
    cursor: pointer;
}
</style>
