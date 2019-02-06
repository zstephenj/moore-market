<template>
    <div>
        <h1> Add Product</h1>
        <form id='addProductForm'>
            
            <div>
                <label for='addProductFormName'> Name: </label>
                <input type='text' v-model='name' name='name' id='addProductFormName'>
            </div>
            <div id='errorName'></div>
            
            <div>
                <label for='addProductFormDescription'> Description: </label>
                <textarea v-model='description' name='description' id='addProductFormDescription' form='addProductForm'> </textarea> 
            </div>
            <div id='errorDescription'></div>
            <div>
                <label for='addProductFormCategory'>Category: </label>
                <select v-model='category' name='category' id='addProductFormCategory' form='addProductForm' @change='changeCategory()'>
                <option :key='productCategory.id' v-for='productCategory in categories' value='${productCategory.id}''> {{productCategory.name}} </option>
                </select>
            </div>
            <div id='errorCategory'></div>  
            
            <div>
                <label for='addProductFormQuantity'>Quantity: </label>
                <input type='number' v-model="quantity" name='quantity' id='addProductFormQuantity'>
            </div>  
            <div id='errorQuantity'></div>

            <div>
                <label for='addProductFormQuantity'>Price: </label>
                <input type='number' step='0.01' v-model="price" name='price' id='addProductFormPrice'>
            </div>  
            <div id='errorPrice'></div>
            
            <div>
                <label for='addProductFormIsPerishable'>Is this item perishable? </label>
                <input type='checkbox' name='isPerishable' @change="toggleHidePerishables" id='addProductFormIsPerishable'>
            </div>  
            
            <div :class="{'hide-form':!isPerishable}">
                <div>
                    <label for='addProductFormKeepRoom'>Can this item be stored at room temperature? </label>
                    <input type='checkbox' name='keepRoom' @change="toggleHideRoom" id='addProductFormKeepRoom'>
                </div>
                
                <div :class="{'hide-form':!keepRoom}">  
                    <div>
                        <label for="addProductFormRoomShelfLife">How long can this item be stored at room temperature? </label>
                        <input type='text' v-model="roomShelfLife" name='roomShelfLife' id='addProductFormRoomShelfLife'>
                    </div>  
                </div>
                
                <div>
                    <label for="addProductFormKeepFridge">Can this item be stored in a refrigerator? </label>
                    <input type='checkbox' name='keepFridge' @change='toggleHideFridge' id='addProductFormKeepFridge'>
                </div>
                
                <div :class="{'hide-form':!keepFridge}">  
                    <div>
                        <label for="addProductFormFridgeShelfLife">How long can this item be stored in the refrigerator? </label>
                        <input type='text' v-model="fridgeShelfLife" name='fridgeShelfLife' id='addProductFormFridgeShelfLife'>
                    </div> 
                </div> 

                <div>
                    <label for="addProductFormKeepFrozen">Can this item be stored at room temperature? </label>
                    <input type='checkbox' name='keepFrozen' @change="toggleHideFreezer" id='addProductFormKeepFrozen'>
                </div> 

                <div :class="{'hide-form':!keepFrozen}"> 
                    <div>
                        <label for="addProductFormFrozenShelfLife">How long can this item be stored in the freezer? </label>
                        <input type='text' v-model="frozenShelfLife" name='frozenShelfLife' id='addProductFormFrozenShelfLife'>
                    </div>
                </div> 
            </div> 

            <div>
                <label>Upload a Picture: </label>
                <input type='file' name='pic' accept='image/*' id='addProductForm'>
            </div>  

            <div><input type='checkbox' @click='test'></div>

            <button type='button' @click="validateForm"> Add Product </button>
            
        </form>
    </div>
</template>

<script>
import {mapActions} from 'vuex'

export default {
    name: "AddProduct",

    props: ["categories"],

    components: {
        
    },

    computed: { 
        
    },
    methods: {
        toggleHidePerishables() {
            this.isPerishable = !this.isPerishable
        },
        toggleHideRoom() {
            this.keepRoom = !this.keepRoom
        },
        toggleHideFridge() {
            this.keepFridge = !this.keepFridge
        },
        toggleHideFreezer() {
            this.keepFrozen = !this.keepFrozen
        },
        validateForm() {
            /* document.getElementById('errorName').innerHTML=""
            document.getElementById('errorDescription').innerHTML=""
            document.getElementById('errorCategory').innerHTML=""
            document.getElementById('errorQuantity').innerHTML=""
            document.getElementById('errorPrice').innerHTML=""
            if (this.$data.name.length < 3 || this.$data.name.length > 56) {
                document.getElementById('errorName').innerHTML="Please adjust Product Name to be 3 to 56 characters long"
                return false
            }
            else if (this.$data.description.length > 512) {
                document.getElementById('errorDescription').innerHTML="Please shorten Product Description to 512 characters or less"
                return false
            }
            else if (this.$data.category == '') {
                
                document.getElementById('errorCategory').innerHTML="Please select a valid Category"
                return false
            }
            else if (this.$data.quantity == '') {
                document.getElementById('errorQuantity').innerHTML="Please enter a Quantity"
                return false
                }
            else if (this.$data.price == '') {
                document.getElementById('errorPrice').innerHTML="Please enter a Price"
                return false
                }
            else { */
                let newProduct = new Object()
                newProduct.name = this.name
                newProduct.description = this.description
                newProduct.category = this.category
                newProduct.quantity = this.quantity
                newProduct.price = this.price
                newProduct.isPerishable = this.isPerishable
                newProduct.keepRoom = this.keepRoom
                newProduct.roomShelfLife = this.roomShelfLife
                newProduct.keepFridge = this.keepFridge
                newProduct.fridgeShelfLife = this.fridgeShelfLife
                newProduct.keepFrozen = this.keepFrozen
                newProduct.frozenShelfLife = this.frozenShelfLife
                newProduct.image = this.image
                console.log(newProduct)
                this.addNewProduct(newProduct)
        },
        test() {
            console.log(this.$store.getters['product/getNewProduct'])
        },
        changeCategory() {
            let s = document.getElementById('addProductFormCategory')
            let valsearch = s.options[s.selectedIndex]
            this.selectedCategory = s.selectedIndex
            valsearch.selected = true
        },

        ...mapActions('product', [
            'addNewProduct'
        ])

},
    data() {
        return {
            name:'',
            description: '',
            category: '',
            quantity: '',
            price: '',
            isPerishable: false,
            keepRoom: false,
            roomShelfLife: '',
            keepFridge: false,
            fridgeShelfLife: '',
            keepFrozen: false,
            frozenShelfLife: '',
            image: '',
            selectedCategory: ''
        }
    }
}

</script>

<style scoped>
.hide-form {
  display: none;
}
</style>

