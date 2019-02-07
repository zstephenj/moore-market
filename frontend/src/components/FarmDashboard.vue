<template>
  <div id="dashboard">
      <div>
          <h1>Vendor-Mart</h1>
      </div>

      <FeedBox :messages="messages"></FeedBox>
      <SummaryBox :sumBoxMessages="sumBoxMessages"></SummaryBox>


      <div class=farmerNav>
          <button>Add New Item</button>
          <button>Add New Category</button>
      </div>
      
      <table class=itemSummary>
          <thead>
            <tr>
              <th v-for="columnTitle in columnTitles">{{ columnTitle }}</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in items" :key="item.id">
              <td>{{item.name}}</td>
              <td>{{item.category}}</td>
              <td>{{item.price}}</td>
              <td>{{item.quantity}}</td>
              <td>{{item.code}}</td>
              <td><a v-bind:href="'/products/edit/?id='+item.id">Edit</a> | <a v-bind:href="'/products/remove/?id='+item.id">Remove</a></td>  
            </tr>
          </tbody>  
      </table>
  </div>
</template>

<script>
import FeedBox from '../components/FeedBox.vue';
import SummaryBox from '../components/SummaryBox.vue';

export default {
  name: 'app',
  components: {
      'FeedBox': FeedBox,
      'SummaryBox': SummaryBox
  },
  data() {
      return {
          columnTitles: ['Item', 'Category','Price', 'Quantity', 'Item Code', 'Edit/Remove'],
          items: [{
              id: 1,
              name: "Fuji",
              category: "apples",
              price: 2.00,
              quantity: 10,
              code: 5000,
          }, {
              id: 2,
              name: "Gala",
              category: "apples",
              price: 1.10,
              quantity: 25,
              code: 5001,
          }, {
              id: 3,
              name: "Green",
              category: "apples",
              price: 0.70,
              quantity: 30,
              code: 5002,
          }, {
              id: 4,
              name: "Honeycrisp",
              category: "apples",
              price: 0.40,
              quantity: 13,
              code: 5003,
          }],
          messages: [
              'Last item purchased: banana',
              'Customer 1 is looking for carrots',
              'Food bank 2 needs spinach'
          ],
          sumBoxMessages: [
              'Low Stock Alert(s): oranges',
              'Sales Totals: $550.00',
              'Best Selling Item: grapes'
          ],          
      }
  }
}
</script>

<style>
#dashboard {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  text-align: center;
}

table.itemSummary {
  border: 2px solid #FFFFFF;
  width: 100%;
  text-align: center;
  border-collapse: collapse;
  padding: 10px;
}
table.itemSummary td, table.itemSummary th {
  border: 1px solid #FFFFFF;
  padding: 3px 4px;
}
table.itemSummary tbody td {
  font-size: 13px;
}
table.itemSummary td:nth-child(even) {
  background: #EBEBEB;
}
table.itemSummary thead {
  background: #FFFFFF;
  border-bottom: 4px solid #333333;
}
table.itemSummary thead th {
  font-size: 15px;
  font-weight: bold;
  color: #333333;
  text-align: center;
  border-left: 2px solid #333333;
}
table.itemSummary thead th:first-child {
  border-left: none;
}

table.itemSummary tfoot td {
  font-size: 14px;
}

.farmerNav {
    margin: 20px;
}
</style>
