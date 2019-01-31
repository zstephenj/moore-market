<template>
    <div class=summaryBox>
      <h2>{{ sumBoxTitle }}</h2>
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
    sumBoxTitle: {
        type: String
    },
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
ul {
    text-align: left;
}
</style>

