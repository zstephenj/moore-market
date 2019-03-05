<template>
    <div class='container-fluid moore-gradient moore-navy'>

        <div class='row justify-content-center py-3'>

            <h2>
                Browse Products By Category
            </h2>

        </div>

        <div class='row justify-content-start'>

            <div v-for='category in allCategories' :key='category.id' class='col-3 py-3'>
                <router-link-button type='category' :item='category' :buttonText='category.name'> </router-link-button>
            </div>

        </div>
    </div>
</template>

<script>
import {mapState, mapActions} from 'vuex'

import RouterLinkButton from '../RouterLinkButton.vue'

export default {
    name: 'ProductHomePage',
    components: {
        RouterLinkButton
    },
    data() {
        return{

        }
    },

    computed: {
        ...mapState('category', [(
            'allCategories'
        )]),

        
    },

    methods: {
        ...mapActions('category', [
            'getAllCategoriesFromApi'
        ])
    },

    created() {
        this.getAllCategoriesFromApi()
    }
}
</script>

<style scoped>

</style>
