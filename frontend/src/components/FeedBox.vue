<template>
    <div class="card border-success mx-2 mb-3">
      <h4 class="card-header">The Feed</h4>
      <div class="card-body">
        <ul>
            <li :key='message.id' v-for="message in messages">{{ message }}</li>
        </ul>
      </div>  
    </div>
</template>

<script>
export default {
   name: 'FeedBox',
   props: {
    messages: {
        type: Array
    }
   },
   data() {
       return {
         

       }
       
       
   } 
}
</script>

<style scoped>

</style>

