<template>
  <div>
    <h2>Forgot Password?</h2>
    <p>Please enter your email into the form below and click "Send Link" to reset your password.</p>
    <input v-model="email" type="email">
    <label v-if="linkSent">Sent! Please check your email. Link will expire in 30 mins.</label>
    <button @click="resetPassword">Reset Password</button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      linkSent: false
    }
  },
  methods: {
    resetPassword() {
      // Use store to send reset password link
      this.linkSent = true
    }
  }
}
</script>

<style scoped>
/* TODO (Ryan C.): Add in styles */
</style>
