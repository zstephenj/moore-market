<template>
    <div>
        <p>Current User's name: {{ getUsername }} | Account Type: {{ getAccountType }}</p>
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
        getAccountType() {
            return this.$store.state.user.currentUser.accountType
        },
        getUsername() {
            return this.$store.state.user.currentUser.username
        }
    }
}
</script>

