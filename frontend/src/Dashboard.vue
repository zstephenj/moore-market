<template>
    <div>
        <p>Current User's name: {{ currentUser.username }} | Account Type: {{ currentUser.AccountType }}</p>
        <farm-dashboard v-if="getAccountType === 'farmer'"></farm-dashboard>
        <user-dashboard v-else></user-dashboard>
    </div>
</template>

<script>
import UserDashboard from './UserDashboard.vue'
import FarmDashboard from './FarmDashboard.vue'
import { mapState } from 'vuex'

export default {
    components: {
        'farm-dashboard': FarmDashboard,
        'user-dashboard': UserDashboard,        
    },

    computed: {
        ...mapState([
            'currentUser'
        ]),
        getAccountType: function () {
            return this.currentUser.AccountType
        }
    }
}
</script>

