<template>
  <div class="about">
    <h1>About the Author</h1>
    <author-bio />
  </div>
</template>

<script>
import AuthorBio from '@/components/AuthorBio.vue'
export default {
  name: 'about',
  components: {
    'author-bio': AuthorBio
  }
}
</script>

<style>

</style>