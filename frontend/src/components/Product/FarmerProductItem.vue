<template>
    <tr >
        <td class='align-middle' scope='row'> <router-link :to='productURL' class='moore-navy font-weight-bold' > {{product.id}} </router-link></td>

        <td class='align-middle'> <router-link :to='productURL' class='moore-navy'> {{product.name}} </router-link></td>

        <td class='align-middle'> {{product.category.name}} </td>

        <td>

            <div v-if='!isEditing.price' class='margin-left-5'>
                ${{Number(product.price).toFixed(2)}}
                <a @click='changeIsEditingPrice()' class='badge badge-success ml-3 mousePointer float-right' > Quick Edit </a>
            </div>

            <form v-if='isEditing.price' >
                <div class='form-row align-items-center justify-content-end margin-right-3'>
                    <div class='col-4'>
                        <input class='form-control form-control-sm' type='number' name='formPrice' v-model='newValue.price' step='0.01'>
                    </div>
                    <div class='col-2'>
                        <a @click='editProductPrice()' class='badge badge-warning ml-3 mousePointer'> Confirm </a>
                        <a @click='changeIsEditingPrice()' class='badge badge-danger ml-3 mousePointer'> Cancel </a>
                    </div>
                </div>

                <div v-if='error.price' class='row justify-content-center'>
                    <div class='alert alert-danger p-1 font-size-14' role='alert'>
                        {{error.priceMsg}}
                    </div>
                </div>

            </form>

        </td>

        <td>

            <div v-if='!isEditing.quantity'  class='margin-left-5'>

                {{Number(product.quantity).toFixed(0)}}

                <a @click='changeIsEditingQuantity()' class='badge badge-success ml-3 mousePointer float-right' > Quick Edit </a>
                
            </div>

            <form v-if='isEditing.quantity'>

                <div class='form-row align-items-center justify-content-end margin-right-3'>

                    <div class='col-4'>
                        <input class='form-control form-control-sm' name='formQuantity' type='number' v-model='newValue.quantity'>
                    </div>

                    <div class='col-2'>
                        <a @click='editProductQuantity()' class='badge badge-warning ml-3 mousePointer'> Confirm </a>
                        <a @click='changeIsEditingQuantity()' class='badge badge-danger ml-3 mousePointer'> Cancel </a>
                    </div>
                    
                </div>

                <div v-if='error.quantity' class='row justify-content-center'>

                    <div class='alert alert-danger p-1 font-size-14' role='alert' >
                        {{error.quantityMsg}}
                    </div>

                </div>

            </form>

        </td>

        <td> 
            
            <div class="btn-group" role="group">
                <router-link v-if='!isDeleting' :to='editProductURL'><button type="button" class="btn btn-success"> Edit </button></router-link>
                <button v-if='!isDeleting' @click='changeIsDeleting()' type="button" class="btn btn-danger"> Delete </button>
                
                <button v-if='isDeleting' @click='removeProductById(product.id)' type="button" class="btn btn-danger"> Confirm </button>
                <button v-if='isDeleting' @click='changeIsDeleting()' type="button" class="btn btn-secondary"> Cancel </button>
            </div>

         </td>

    </tr>
</template>

<script>
import {mapActions} from 'vuex'

export default {
    name: 'FarmerProductItem',
    props: ['product'],
    data(){
        return {
            productURL: '../product/' + this.product.id,
            editProductURL: '../product/edit/' + this.product.id,

            isEditing: {
                price: false,
                quantity: false
            },

            isDeleting: false,

            error: {
                price: false,
                priceMsg: '',
                quantity: false,
                quantityMsg: ''
            },

            newValue: {
                price: this.product.price,
                quantity: this.product.quantity
            }
        }
    },

    methods: {
        changeIsEditingPrice(){
            this.isEditing.price = !this.isEditing.price
        },

        changeIsEditingQuantity(){
            this.isEditing.quantity = !this.isEditing.quantity
        },
        changeIsDeleting(){
            this.isDeleting = !this.isDeleting
        },

        editProductPrice() {
            if (!this.checkErrorPrice()){
                let editedProduct = this.product
                editedProduct.price = this.newValue.price
                console.log(editedProduct)
                this.editProductById(editedProduct)
                this.isEditing.price = false
                return true
            }
            else {
                return false
            }
        },

        editProductQuantity() {
            if (!this.checkErrorQuantity()) {
                let editedProduct = this.product
                editedProduct.quantity = this.newValue.quantity
                console.log(editedProduct)
                this.editProductById(editedProduct)
                this.isEditing.quantity = false
                return true
            }
            else {
                return false
            }
        },

        checkErrorPrice() {
            this.error.price = true
            let price = this.newValue.price
            if (price == '') {
                this.error.priceMsg = 'Please enter a Price'
                return true
            }
            
            else if (price > 999999) {
                this.error.priceMsg  = "That's a little expensive for our taste!"
                return true
            }

            else if (price < 0) {
                this.error.priceMsg  = "Rather than pay people to take your product, why not donate it instead?"
                return true
            }

            else {
                this.error.price = false
                return false
            }
        },

        checkErrorQuantity() {
            this.error.quantity = true
            let quantity = this.newValue.quantity
            if (quantity == '') {
                this.error.quantityMsg = 'Please enter a Quantity'
                return true
            }

            else if (quantity > 999999) {
                this.error.quantityMsg = "You couldn't possibly have that many, could you?"
                return true
            }

            else if (quantity < 0) {
                this.error.quantityMsg = "Let's try something positive"
                return true
            }

            else {
                this.error.quantity = false
                return false
            }
        },

        ...mapActions('product', [
            'editProductById',
            'removeProductById'
        ])
    }
}
</script>

<style scoped>

.mousePointer {
    cursor: pointer;
}

.margin-left-5 {
    margin-left: 5em;
}

.margin-left-3 {
    margin-left: 3em;
}

.margin-right-3 {
    margin-right: 3em;
}

.font-size-14 {
    font-size:14px;
}
</style>
