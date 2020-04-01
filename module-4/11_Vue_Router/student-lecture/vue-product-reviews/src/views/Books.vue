<template>
  <div class="books">
        <h1>Related Books</h1>
<books-list></books-list>
    </div>
</template>

<script>
import BooksList from '@/components/BooksList.vue'
export default {
    name: 'books',
    components: {
'books-list': BooksList
    }
};
</script>

<style>
</style>