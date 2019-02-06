<template>
    <div class=feedBox>
      <h2>The Feed</h2>
      <hr/>
      <ul>
          <li v-for="message in messages">{{ message }}</li>
      </ul>
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
.feedBox {
    float: left;
    border: 3px solid seagreen;
    padding: 10px;
    width: 300px;
    margin: 15px;
    
}
.feedBox ul {
    text-align: left;
}
</style>

