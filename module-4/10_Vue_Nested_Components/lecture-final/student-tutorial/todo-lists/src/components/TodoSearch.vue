<template>
    <div class="search">
        <input type="text" id="search" name="search" 
        v-on:keyup="searchChanged" 
        v-model="searchString"
        placeholder="Search Todo's..."/>
    </div>
</template>

<script>
export default {
    data() {
        return {
            searchString : ''
        }
    },
    methods: {
        searchChanged() {
            this.$emit('search-change', this.searchString);
        }
    }
}
</script>

<style>
#search {
    width:100%;
    font-size:24px;
    font-family: 'Roboto Condensed', sans-serif;
    margin-top:50px;
    padding:10px;
}
</style>
