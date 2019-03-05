<template>
    <div v-if='allCategories' class='container-fluid moore-gradient moore-navy'>

        <div class='row justify-content-center py-2'>
            <h2> Manage Categories </h2>
        </div>

        <div class='row justify-content-around my-1'>

            <div v-if='!isAdding' class='col-md-4'>
                <button @click='changeIsAdding()' type='button' class='btn btn-success col-md-4 my-2'> Add New Category </button>
            </div>

            <div v-if='isAdding' class='col-md-12'>

                <div class='row justify-content-center mb-2'>
                    <button @click='changeIsAdding()' type='button' class='btn btn-secondary col-2 m-2 mr-5' > Cancel </button>
                    <button @click='addCategory()' type='button' class='btn btn-warning col-2 m-2 ml-5'> Add </button>
                </div>

                <div class='row justify-content-center my-2'>
                    <product-category-form formType='add' @category-input='changeFormCategoryNew' class='col-md-3'> </product-category-form>
                </div>  

                <div class='row justify-content-center mt-2'>  
                    <div v-if='error.isError' class='alert alert-danger col-4 p-1' role='alert'>
                        {{error.msg}}
                    </div>
                </div>

            </div>

        </div>

        <div class='row justify-content-center'>

            <table v-if='allCategories' class='table col-5'>
                <tbody>
                    <tr v-for='category in firstHalfCategories' :key='category.id'>
                        <td class='row align-middle justify-content-around'>
                            <manage-category-item :category='category'> </manage-category-item>
                        </td>
                    </tr>
                </tbody>
            </table>

            <table class='table col-5'>
                <tbody class=''>
                    <tr v-for='category in secondHalfCategories' :key='category.id'>
                        <td class='row align-items-center justify-content-around'>
                            <manage-category-item :category='category'> </manage-category-item>
                        </td>
                    </tr>
                </tbody>
            </table>
            
        </div>
        
    </div>
</template>

<script>
import {mapState, mapActions} from 'vuex'

import ProductCategoryForm from './ProductCategoryForm.vue'
import ManageCategoryItem from './ManageCategoryItem.vue'

export default {
    name: 'ManageCategories',
    components: {
        ProductCategoryForm,
        ManageCategoryItem
    },

    data() {
        return{
            isAdding: false,
            formCategoryNew: '',
            error: {
                isError: false,
                msg: ''
            }
        }
    },

    computed: {
        ...mapState('category', [(
            'allCategories'
        )]),

        numHalfCategories() {
            return Math.ceil(this.allCategories.length / 2)
        },

        firstHalfCategories() {
            return this.allCategories.slice(0, this.numHalfCategories)
        },

        secondHalfCategories() {
            return this.allCategories.slice(this.numHalfCategories, this.numHalfCategories*2)
        }
    },

    methods: {
        ...mapActions('category', [
            'getAllCategoriesFromApi',
            'addNewCategory'
        ]),

        changeIsAdding() {
            this.isAdding = !this.isAdding
        },

        changeFormCategoryNew(e) {
            this.formCategoryNew = e
        },

        async addCategory() {
            this.error.isError = false
            if (this.formCategoryNew.length === 0) {
                this.error.isError = true
                this.error.msg = 'Please enter a category name'
                return false
            }

            else if (this.formCategoryNew.length < 3 || this.formCategoryNew.length > 26) {
                this.error.isError = true
                this.error.msg = 'Category name must be between 3 and 26 characters long'
                return false
            }

            else {
                let newCategory = {name: this.formCategoryNew}
                console.log(this.allCategories)
                console.log(newCategory)
                let response = await this.addNewCategory(newCategory)
                if (response.status === 201) {
                    this.isAdding = false
                }
                else {
                    //backend validation failed, display error?
                    console.log('backend rejected')
                }
            }
        }
    },

    async created() {
        await this.getAllCategoriesFromApi()
    }
}
</script>

<style>

</style>
