<template>
    <div class='container-fluid'>

        <router-link :to='url' class='pc-button'> {{buttonText}} </router-link>

    </div>
</template>

<script>
export default {
    name: 'RouterLinkButton',
    props: ['buttonText', 'item','type'],
    data() {
        return {
            url: '',
        }
    },
    created() {
        if (this.type === 'category') {
            let searchCategoryURL = '../search/category/' + this.item.id
            this.url = searchCategoryURL
        }
        if (this.type === 'farmer') {
            //later this.item.id
            let farmerUrl = '../farmers/' + this.item
            this.url = farmerUrl
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
