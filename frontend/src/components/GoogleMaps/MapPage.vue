<template>
    <div class='container-fluid'>
        
        <div>
            <h2> Markets Near Me </h2>
        </div>

        <google-map> </google-map>

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
