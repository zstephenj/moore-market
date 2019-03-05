<template>
  <div class='register-user'>
    <div v-if="errorMsg">
      {{ errorMsg }}
    </div>
    <form @submit.prevent="handleSubmit()">
      <div class="form-group">
        <label for="username">Username</label>
        <input id="username" v-model.trim="user.username" />
      </div>
      <div class="form-group">
        <label for="password">Password</label>
        <input id="password" v-model="user.password" />
      </div>
      <div class="form-group">
        <label for="verify-pw">Verify Password</label>
        <input id="verify-pw" v-model="verify" />
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: 'RegisterUser',
  data() {
    return {
      user: {
        username: '',
        password: '',
      },
      verify: '',
      errorMsg: '',
    };
  },
  methods: {
    handleSubmit(e) {
      if(this.user.password !== this.verify) {
        this.errorMsg = 'Password and verify password fields must match';        
      } else if(this.user.username === '' || !this.user.username) {
        this.errorMsg = 'Username field is required'
      } else {
        //register new user
      }
    }
  }
}
</script>

<style>

</style>
