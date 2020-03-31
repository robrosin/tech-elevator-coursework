<template>
  <div id="app">
    <!-- TODO 03: Handle the data-change event and update the nutritionData data property -->
    <!-- TODO 05: Add a value for the userName property -->
    <nutrition></nutrition>
    <div class="charts">
      <!-- TODO 01: Add a stacked-bar-chart component to display the data graphically. Bind the chart to nutritionData -->
      <!-- TODO 05: Display the chart only if there is any nutritionData -->
      <!-- TODO 05: Add a title property to the chart -->


      <!-- TODO 01: Add a bar-chart component to display the data graphically. Bind the chart to nutritionData -->
      <!-- TODO 05: Display the chart only if there is any nutritionData -->
      <!-- TODO 05: Add a title property to the chart -->
      <!-- TODO 05: Pass in the scaleToLargest property -->

    </div>
  </div>
</template>

<script>
// TODO 01: Add components to the App (BarChart and StackedBarChart)
// TODO 03: Handle the data-change event in App.vue to pass the data on to other components
import Nutrition from "./components/Nutrition.vue";

export default {
  name: "app",
  components: {
    nutrition: Nutrition,
  },
  data() {
    return {
      /* TODO 03a: Add a nutritionData property to store the array of nutrition data in objects that have: label, value, color properties */

    };
  },
  methods: {
    // TODO 03b: Create an onDataChange method to update nutritionData when the table changes
    /**
     * Whenever the nutrition data changes in the nutrition component, we change it here.  This property is bound to the charts,
     * so they will automatically get updated.
     */

  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;
  width: 100%;
}

* {
  box-sizing: border-box;
}

.charts {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}

.chart {
  width: 48%;
  margin: 10px;
}

@media screen and (max-width: 1200px) {
  .chart {
    width: 100%;
  }
}
</style>
