<template>
  <div id="app">
    <nutrition-chart class="nutrition"></nutrition-chart>
  </div>
</template>

<script>
import Nutrition  from './components/Nutrition.vue'

export default {
  name: 'App',
  components: {
    'nutrition-chart' : Nutrition
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
