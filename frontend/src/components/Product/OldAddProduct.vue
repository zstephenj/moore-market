<template>

    <div class='container-fluid'>

        <div class='row'>

            <div class='col text-center'>
                <h1> Add Product</h1>
            </div>

        </div>

        <form id='addProductForm'>
            
            <div class="form-group">

                <div class="form-row align-items-center justify-content-center">
                    <label for='addProductFormName' class="col-md-2 col-form-label alert alert-success"> Name: </label>
                    <div class="col-md-4">
                        <input class="form-control" type='text' v-model='product.name' name='name' ref='addProductFormName' id='addProductFormName' >
                    </div>
                </div>

                <div class="form-row align-items-center justify-content-center">
                    <div class="col-md-6" :class="{'alert alert-danger':hasErrorName}" role="alert" ref='errorName' id='errorName'>  </div>
                </div>

            </div>

            <div class="form-group">

                <div class="form-row align-items-center justify-content-center">
                    <label for='addProductFormDescription' class="col-md-2 col-form-label alert alert-success"> Description: </label>
                    <div class="col-md-4">
                        <textarea class="form-control" v-model='product.description' name='description' ref='addProductFormDescription' id='addProductFormDescription' form='addProductForm'> </textarea> 
                    </div>
                </div>

                <div class="form-row align-items-center justify-content-center">
                    <div class="col-md-6" :class="{'alert alert-danger':hasErrorDescription}" role="alert" ref='errorDescription' id='errorDescription'></div>
                </div>

            </div>

            <div class="form-group">

                <div class="form-row align-items-center justify-content-center">
                    <label for='addProductFormCategory' class="col-md-2 col-form-label alert alert-success">Category: </label>
                    <div class="col-md-4">
                        <select class="custom-select" v-model='product.categoryId' name='categoryId' ref='addProductFormCategory' id='addProductFormCategory' form='addProductForm'>
                        <option :key='productCategory.id' v-for='productCategory in addProductFormCategories' :value='productCategory.id'> {{productCategory.name}} </option>
                        </select>
                    </div>
                </div>

                <div class="form-row align-items-center justify-content-center">
                    <div class="col-md-6" :class="{'alert alert-danger':hasErrorCategory}" role="alert" ref='errorCategory' id='errorCategory'></div> 
                </div> 

            </div>

            <div class="form-group">
                
                <div class="form-row align-items-center justify-content-center">
                    <label for='addProductFormQuantity' class="col-md-2 col-form-label alert alert-success">Quantity: </label>
                    <div class="col-md-4">
                        <input class="form-control" type='number' v-model="product.quantity" name='quantity' ref='addProductFormQuantity' id='addProductFormQuantity'>
                    </div>
                </div>

                <div class="form-row align-items-center justify-content-center">
                    <div class="col-md-6" :class="{'alert alert-danger':hasErrorQuantity}" role="alert" ref='errorQuantity' id='errorQuantity'></div>
                </div>

            </div>

            <div class="form-group">
                
                <div class="form-row align-items-center justify-content-center">
                    <label for='addProductFormPrice' class="col-md-2 col-form-label alert alert-success">Price: </label>
                    <div class="col-md-4">
                        <input class="form-control" type='number' step='0.01' v-model="product.price" name='price' ref='addProductFormPrice' id='addProductFormPrice'>
                    </div>
                </div>
                
                <div class="form-row align-items-center justify-content-center">
                    <div class="col-md-6" :class="{'alert alert-danger':hasErrorPrice}" role="alert" ref='errorPrice' id='errorPrice'></div>
                </div>

            </div>

            <fieldset class="form-group" id='isPerishable' >
                <div class="form-row align-items-center justify-content-center">
                    <legend class="col-form-label col-md-2 alert alert-success">Item is perishable: </legend>
                    <div class="custom-control custom-radio col-md-2">
                        <input class="custom-control-input" type='radio' ref='isPerishableYes' id='isPerishableYes' name='isPerishable' @click="product.isPerishable = true" value=true >
                        <label class="custom-control-label" for="isPerishableYes">Yes</label>
                    </div>
                    <div class="custom-control custom-radio col-md-2">
                        <input class="custom-control-input" type='radio' id='isPerishableNo' name='isPerishable' @click="product.isPerishable = false" value=false checked>
                        <label class="custom-control-label" for="isPerishableNo">No</label>
                    </div>
                </div>
            </fieldset>
            
                <div :class="{'hide-form':!product.isPerishable}">
                    
                    <fieldset class="form-group" id='keepRoom'>
                        <div class="form-row align-items-center justify-content-center">
                            <legend class="col-form-label col-md-2 alert alert-success">Item can be stored at room temperature: </legend>
                            <div class="custom-control custom-radio col-md-2">
                                <input class="custom-control-input" ref='keepRoomYes' id='keepRoomYes' type='radio' value=true name='keepRoom' @click="product.keepRoom = true">
                                <label class="custom-control-label" for="keepRoomYes">Yes</label>
                            </div>
                            <div class="custom-control custom-radio col-md-2">
                                <input class="custom-control-input" id='keepRoomNo' type='radio' value=false name='keepRoom' @click="product.keepRoom = false" checked>
                                <label class="custom-control-label" for="keepRoomNo">No</label>                            
                            </div>
                        </div>
                    </fieldset>
                    
                    
                        <div :class="{'hide-form':!product.keepRoom}">
                            <div class="form-group">
                                
                                <div class="form-row align-items-center justify-content-center">
                                    <label class="col-md-2 col-form-label alert alert-success" for="addProductFormShelfLifeRoom">Shelf life in room: </label>
                                    <div class="col-md-4">
                                        <input class="form-control" type='text' v-model="product.shelfLifeRoom" ref='addProductFormShelfLifeRoom' name='shelfLifeRoom' id='addProductFormShelfLifeRoom'>
                                    </div>
                                </div>

                                <div class="form-row align-items-center justify-content-center">
                                    <div class="col-md-6" :class="{'alert alert-danger':hasErrorShelfLifeRoom}" role="alert" ref='errorShelfLifeRoom' id='errorShelfLifeRoom'>  </div>
                                </div>

                            </div>    
                        </div>
                    
                    <fieldset class="form-group" id='keepFridge'>
                        <div class="form-row align-items-center justify-content-center">
                            <legend class="col-form-label col-md-2 alert alert-success">Item can be stored in refrigerator: </legend>
                            <div class="custom-control custom-radio col-md-2">
                                <input class="custom-control-input" ref='keepFridgeYes' id='keepFridgeYes' type='radio' value=true name='keepFridge' @click="product.keepFridge = true">
                                <label class="custom-control-label" for="keepFridgeYes">Yes</label>
                            </div>
                            <div class="custom-control custom-radio col-md-2">
                                <input class="custom-control-input" id='keepFridgeNo' type='radio' value=false name='keepFridge' @click="product.keepFridge = false" checked>
                                <label class="custom-control-label" for="keepFridgeNo">No</label>
                            </div>
                        </div>
                    </fieldset>
                    
                    
                        <div :class="{'hide-form':!product.keepFridge}">

                            <div class="form-group">

                                <div class="form-row align-items-center justify-content-center">
                                    <label class="col-md-2 col-form-label alert alert-success" for="addProductFormShelfLifeFridge">Shelf life in refrigerator:  </label>
                                    <div class="col-md-4">
                                        <input class="form-control" type='text' v-model="product.shelfLifeFridge" name='shelfLifeFridge' ref='addProductFormShelfLifeFridge' id='addProductFormShelfLifeFridge'>
                                    </div>
                                </div> 

                                <div class="form-row align-items-center justify-content-center">
                                    <div class="col-md-6" :class="{'alert alert-danger':hasErrorShelfLifeFridge}" role="alert" ref='errorShelfLifeFridge' id='errorShelfLifeFridge'>  </div>
                                </div>

                            </div>

                        </div> 

                    <fieldset class="form-group" id='keepFreezer'>
                        <div class="form-row align-items-center justify-content-center">
                            <legend class="col-form-label col-md-2 alert alert-success">Item can be stored in freezer: </legend>
                            <div class="custom-control custom-radio col-md-2">
                                <input class="custom-control-input" ref='keepFreezerYes' id='keepFreezerYes' type='radio' value=true name='keepFreezer' @click="product.keepFreezer = true">
                                <label class="custom-control-label" for="keepFreezerYes">Yes</label>
                            </div>
                            <div class="custom-control custom-radio col-md-2">
                                <input class="custom-control-input" id='keepFreezerNo' type='radio' value=false name='keepFreezer' @click="product.keepFreezer = false" checked>
                                <label class="custom-control-label" for="keepFreezerNo">No</label>
                            </div>
                        </div> 
                    </fieldset>
                    
                        <div :class="{'hide-form':!product.keepFreezer}"> 
                            
                            <div class="form-group">

                                <div class="form-row align-items-center justify-content-center">
                                    <label class="col-md-2 col-form-label alert alert-success" for="addProductFormShelfLifeFreezer">Shelf life in freezer:  </label>
                                    <div class="col-md-4">
                                        <input class="form-control" type='text' v-model="product.shelfLifeFreezer" ref='addProductFormShelfLifeFreezer' name='shelfLifeFreezer' id='addProductFormShelfLifeFreezer'>
                                    </div>
                                </div>

                                <div class="form-row align-items-center justify-content-center">
                                    <div class="col-md-6" :class="{'alert alert-danger':hasErrorShelfLifeFreezer}" role="alert" ref='errorShelfLifeFreezer' id='errorShelfLifeFreezer'>  </div>
                                </div>
                            
                            </div>
                        </div>                     
                </div> 

            <div class="form-group">
                <div class='form-row align-items-center justify-content-center'>
                    <label class="col-md-2 col-form-label alert alert-success">Upload a Picture: </label>
                    <div class="col-md-4">
                        <input class="form-control-file" type='file' ref='addProductFormPic' name='pic' accept='image/*' id='addProductFormPic' @change='generateBase64()'>
                    </div>
                </div>

                <div :class="{'hide-form':!hasImage}"> 
                    <div class='form-row align-items-center justify-content-center'>
                        <label class="col-md-2 col-form-label alert alert-success">Uploaded Picture: </label>
                        <div class="col-md-4">
                            <img class='image-responsive img-thumbnail' id='displayedImage' ref='displayedImage'>
                        </div>
                    </div>
                </div>
            </div>  

            <div class="form-group form-row align-items-center justify-content-center">

            <button class="btn btn-success" type='button' @click="addProduct()"> Add Product </button>
            
            </div>
        </form>
    </div>
</template>

<script>
import {mapActions} from 'vuex'

export default {
    name: "OldAddProduct",

    props: ["categories"],

    components: {
        
    },

    computed: { 
    },

    methods: {

        // Helper function
        isAlphaNumeric(str) {
            let code, i, len
            for (i = 0, len = str.length; i < len; i++) {
                code = str.charCodeAt(i);
                if (!(code > 47 && code < 58) && // numeric (0-9)
                    !(code > 64 && code < 91) && // upper alpha (A-Z)
                    !(code > 96 && code < 123)) { // lower alpha (a-z)
                    return false;
                    }
            }
            return true
        },
        
        
        generateBase64() {

            let reader = new FileReader()
            reader.readAsDataURL(this.$refs.addProductFormPic.files[0])
            
            reader.onload = () => {
                    this.$refs.displayedImage.src = reader.result
                    this.image = this.$refs.displayedImage.src
                    this.hasImage = true
                    }
        },

        //Check form errors
        checkErrorName() {
            this.hasErrorName = true
            let formName = this.$refs.addProductFormName.value

            if (formName == '') {
                this.$refs.errorName.innerHTML = 'Please provide a Name for the new product'
                return true
            }

            if (!this.isAlphaNumeric(formName)) {
                this.$refs.errorName.innerHTML = 'Please use letters and numbers only'
                return true
            }

            if (formName.length < 3 || formName.length > 56) {
                this.$refs.errorName.innerHTML = 'Name must be 3 to 56 characters in length'
                return true
            }
            
            else {
                this.hasErrorName = false
                return false
            }
        },
        
        checkErrorDescription() {
            this.hasErrorDescription = true
            let formDescription = this.$refs.addProductFormDescription.value

            if (formDescription.length > 512) {
                this.$refs.errorDescription.innerHTML = 'Please shorten the Description to 512 characters or less'
                return true
            }
            
            else {
                this.hasErrorDescription = false
                return false                
            }
        },
        
        checkErrorCategory() {
            this.hasErrorCategory = true
            let formCategory = this.$refs.addProductFormCategory.value
        
            if (formCategory == '') {
                this.$refs.errorCategory.innerHTML = 'Please select a Category'
                return true
            }

            else {
                this.hasErrorCategory = false
                return false
            }
        },

        checkErrorQuantity() {
            this.hasErrorQuantity = true
            let formQuantity = this.$refs.addProductFormQuantity.value

            if (formQuantity == '') {
                this.$refs.errorQuantity.innerHTML = 'Please enter a Quantity'
                return true
            }

            else if (formQuantity > 999999) {
                this.$refs.errorQuantity.innerHTML = "You couldn't possibly have that many, could you?"
                return true
            }

            else if (formQuantity < 0) {
                this.$refs.errorQuantity.innerHTML = "Let's try something positive"
                return true
            }

            else {
                this.hasErrorQuantity = false
                return false
            }
        },
        
        checkErrorPrice() {
            this.hasErrorPrice = true
            let formPrice = this.$refs.addProductFormPrice.value

            if (formPrice == '') {
                this.$refs.errorPrice.innerHTML = 'Please enter a Price'
                return true
            }
            
            else if (formPrice > 999999) {
                this.$refs.errorPrice.innerHTML = "That's a little expensive for our taste!"
                return true
            }

            else if (formPrice < 0) {
                this.$refs.errorPrice.innerHTML = "Rather than pay people to take your product, why not donate it instead?"
                return true
            }

            else {
                this.hasErrorPrice = false
                return false
            }
        },

        checkErrorShelfLife(formShelfLife) {
            let msgError = ''

            if (formShelfLife == '') {
                msgError = 'Please provide a Shelf Life for the new product'
                return msgError
            }

            else if (!this.isAlphaNumeric(formShelfLife)) {
                msgError = 'Please use letters and numbers only'
                return msgError
            }

            else if (formShelfLife.length < 3 || formShelfLife.length > 128) {
                msgError = 'Shelf Life must be 3 to 128 characters in length'
                return msgError
            }

            else {
                return false
            }
        },
        //Validate
        anyErrors() {
            if(this.hasErrorName == true ||
            this.hasErrorDescription == true ||
            this.hasErrorCategory == true ||
            this.hasErrorQuantity == true ||
            this.hasErrorPrice == true ||
            this.hasErrorShelfLifeRoom == true ||
            this.hasErrorShelfLifeFridge == true ||
            this.hasErrorShelfLifeFreezer == true) {
                return true
            }
            else {
                return false
            }
        },

        validateForm() {
            this.checkErrorName()
            this.checkErrorDescription()
            this.checkErrorCategory()
            this.checkErrorQuantity()
            this.checkErrorPrice()

            if (this.product.isPerishable) {

                if (this.product.keepRoom) {

                    //this.hasErrorShelfLifeRoom = false
                    this.$refs.errorShelfLifeRoom.innerHTML = ''
                    let formShelfLife = this.$refs.addProductFormShelfLifeRoom.value
                    if (this.checkErrorShelfLife(formShelfLife)) {
                        this.hasErrorShelfLifeRoom = true
                        this.$refs.errorShelfLifeRoom.innerHTML = this.checkErrorShelfLife(formShelfLife)
                    }
                }

                if (this.product.keepFridge) {

                    this.hasErrorShelfLifeFridge = false
                    this.$refs.errorShelfLifeFridge.innerHTML = ''
                    let formShelfLife = this.$refs.addProductFormShelfLifeFridge.value
                    if (this.checkErrorShelfLife(formShelfLife)) {
                        this.hasErrorShelfLifeFridge = true
                        this.$refs.errorShelfLifeFridge.innerHTML = this.checkErrorShelfLife(formShelfLife)
                    }
                }

                if (this.product.keepFreezer) {

                    this.hasErrorShelfLifeFreezer = false
                    this.$refs.errorShelfLifeFreezer.innerHTML = ''
                    let formShelfLife = this.$refs.addProductFormShelfLifeFreezer.value
                    if (this.checkErrorShelfLife(formShelfLife)) {
                        this.hasErrorShelfLifeFreezer = true
                        this.$refs.errorShelfLifeFreezer.innerHTML = this.checkErrorShelfLife(formShelfLife)
                    }
                }
            }

            if (!this.anyErrors()) {

                if (this.$refs.addProductFormPic.files.length == 1) {
                   newProduct.image = this.image
                }
                console.log(newProduct.image)
                this.addNewProduct(newProduct)
                return true
            }

            else{
                return false
            }
        },
        addProduct() {
          let product = this.product
          if(this.validateForm()) {
            this.addNewProduct(product).then(() => this.$router.push('/dashboard'))
          }
        },
        ...mapActions('product', [
            'addNewProduct'
        ])
    
    },
    data() {
        return {
            product: {
                name:'',
                description: '',
                categoryId: '',
                quantity: '',
                price: '',
                isPerishable: false,
                keepRoom: false,
                shelfLifeRoom: '',
                keepFridge: false,
                shelfLifeFridge: '',
                keepFreezer: false,
                shelfLifeFreezer: '',
                image: '',
            },
            hasErrorName: false ,
            hasErrorDescription: false ,
            hasErrorCategory: false ,
            hasErrorQuantity: false ,
            hasErrorPrice: false,
            hasErrorShelfLifeRoom: false,
            hasErrorShelfLifeFridge: false,
            hasErrorShelfLifeFreezer: false,
            addProductFormCategories: [{id:1, name:'Category 1'}, {id:2, name:'Category 2'}, {id:3, name:'Category 3'} ]
        }
    }
}

</script>

<style scoped>
.hide-form {
  display: none;
}
</style>

