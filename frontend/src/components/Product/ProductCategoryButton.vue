<template>
    <div class='container-fluid'>

        <router-link :to='searchCategoryURL' class='pc-button'> {{category.name}} </router-link>

    </div>
</template>

<script>
export default {
    name: 'ProductCategoryButton',
    props: ['category'],
    data() {
        return {
            searchCategoryURL: '../search/category/' + this.category.id,
        }
    }
}
</script>

<style scoped>

.pc-button {
    border-style: solid;
    border-color: #001f3f;
    color: #001f3f;
    font-weight: 600;
    padding: 0.5em;
}

.pc-button:hover {
    background-color: #001f3f;
    color: #16C080;
    font-weight: 600;
    padding: 0.5em;
}
</style>
