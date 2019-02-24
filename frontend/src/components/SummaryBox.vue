<template>
    <div class="card border-success mb-3">
      <h4 class="card-header">Summary</h4>
      <div class="card-body">
        <ul>
            <li :key='message.id' v-for="message in sumBoxMessages">{{ message }}</li>
        </ul>
      </div> 
    </div>
</template>

<script>
export default {
   name: 'SummaryBox',
   props: {
    sumBoxMessages: {
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

