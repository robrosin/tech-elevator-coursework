<template>
  <div class="main">
        <h2> Product Reviews for {{ bookName }}</h2>
        <p class = "highlighted"> {{ description }} </p>
    </div>
</template>

<script>
export default {
    name: "product-review",
    data() {
        return {
            bookName: "Cigar Parties for Dummies",
            description: "Host and plan perfect cigar party for all your squirrelly friends",
        };
    } 
}

</script>

<style scoped>

.highlighted {
    background-color: yellow;
}

</style>