import Vue from 'vue'
import * as VueGoogleMaps from 'vue2-google-maps'

const geo = 
    Vue.use(VueGoogleMaps, {
    load: {
        key: 'AIzaSyDzl33G5H6lBgUSxIJZDke0Qal0XN96Iug',
        libraries: 'places,geometry', 
    },

})


export default geo