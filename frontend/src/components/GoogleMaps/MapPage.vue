<template>
    <div class='container-fluid moore-gradient moore-navy'>
        <div class='row'>

            <div class='col'>

            </div>

            <div class='d-flex flex-column'>

                <div class='p-3 flex-row'>
                    <h2> Markets Near Me </h2>
                    
                </div>

                <google-map class='pb-3 align-items-end flex-row'> </google-map>

            </div>

        </div>
    </div>
</template>

<script>
import GoogleMap from './GoogleMap.vue'

export default {
    name:'MapPage',
    components: {
        GoogleMap
    }

}
</script>

<style>

</style>
