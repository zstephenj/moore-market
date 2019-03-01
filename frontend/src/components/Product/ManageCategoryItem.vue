<template>
    <div v-if='category' class='container-fluid' >
        <div class='moore-border'>
            <div class='row align-items-center justify-content-around m-2 py-1'>

                <div v-if='!isEditing' class='col-6 pt-1'>
                    <h4>
                    {{category.name}}
                    </h4>
                </div>

                <div v-if='isEditing' class='col-6 pl-5 py-1 margin-top-tiny'>
                    <product-category-form formType='edit' @category-input='updateFormCategoryEdited' :oldCategoryName='category.name'> </product-category-form>
                </div>

                <div class='col-4'>
                    <div class="btn-group mx-2" role="group">
                        <button v-if='!isEditing && !isDeleting' @click='changeIsEditing()' type="button" class="btn btn-success"> Edit </button>
                        
                        <button v-if='isEditing' @click='changeIsEditing()' type="button" class="btn btn-secondary"> Cancel </button>
                        <button v-if='isEditing' @click='editCategory()' type="button" class="btn btn-warning"> Confirm </button>
                        
                        <button v-if='!isDeleting && !isEditing' @click='changeIsDeleting()' type="button" class="btn btn-danger"> Delete </button>
                        
                        <button v-if='isDeleting' @click='removeCategoryById(category.id)' type="button" class="btn btn-danger"> Confirm </button>
                        <button v-if='isDeleting' @click='changeIsDeleting()' type="button" class="btn btn-secondary"> Cancel </button>
                    </div>
                </div>

            </div>

            <div v-if='error.isError' class='row justify-content-center'>  
                <div v-if='error.isError' class='alert alert-danger p-1' role='alert'>
                    {{error.msg}}
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {mapActions} from 'vuex'
import ProductCategoryForm from './ProductCategoryForm.vue'

export default {
    name: 'ManageCategoryItem',
    components: {
        ProductCategoryForm
    },
    props:['category'],
    data() {
        return {
            isEditing: false,
            isDeleting: false,
            formCategoryEdited: this.category.name,
            error: {
                isError: false,
                msg: ''
            }
        }
    },

    methods: {
        ...mapActions('category', [
            'editCategoryById',
            'removeCategoryById'
        ]),

        changeIsEditing(){
            this.isEditing = !this.isEditing
        },
        changeIsDeleting(){
            this.isDeleting = !this.isDeleting
        },
        updateFormCategoryEdited(e) {
            this.formCategoryEdited = e
        },

        async editCategory() {
            this.error.isError = false
            if (this.formCategoryEdited.length === 0) {
                this.error.isError = true
                this.error.msg = 'Please enter a category name'
                return false
            }

            else if (this.formCategoryEdited.length < 3 || this.formCategoryEdited.length > 26) {
                this.error.isError = true
                this.error.msg = 'Category name must be between 3 and 26 characters long'
                return false
            }

            else {
                let newCategory = Object.assign(this.category)
                newCategory.name = this.formCategoryEdited
                let response = await this.editCategoryById(newCategory)
                if (response.status === 200) {
                    this.isEditing = false
                }
                else {
                    //backend validation failed, display error?
                }
            }
        }
    }
}
</script>

<style scoped>

.moore-border {
    border-style:solid;
    border-color:#001f3f;
}

.margin-top-tiny {
    margin-top:0.1em;
}

</style>
