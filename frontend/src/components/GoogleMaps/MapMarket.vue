<template>
    <div class='container-fluid border-navy'>

        <div class='my-2'>
            <h2>{{market.name}}</h2>
        </div>

        <hr class='border-navy' />
        <div class='d-flex align-items-stretch'></div>
    </div>
</template>

<script>
export default {
    name: 'MapMarket',
    props: ['market'],

}
</script>

<style scoped>

.border-navy {
    border-style:solid;
    border-color: #001f3f;
}

</style>
