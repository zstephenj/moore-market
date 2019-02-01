<template>
    <div class=summaryBox>
      <h2>Summary</h2>
      <hr/>
      <ul>
          <li v-for="message in sumBoxMessages">{{ message }}</li>
      </ul>
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
.summaryBox {
    float: right;
    border: 3px solid seagreen;
    padding: 10px;
    width: 300px;
    margin: 15px;
}
.summaryBox ul {
    text-align: left;
}
</style>

