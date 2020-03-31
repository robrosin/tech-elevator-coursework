<template>
  <div>
    <h2 v-if="title">{{title}}</h2>
    <div class="barchart">
      <div
        v-for="(item, index) in chartData"
        v-bind:key="index"
        class="barchart-bar"
        v-bind:style="{'width': percentage(item).toString()+'%', 'background-color' : item.color}"
      >{{displayText(item)}}</div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    title: String,
    // TODO 04: chartArray is a prop so that the parent component can bind to it.
    chartData: Array
    /***chartData is an array of objects, which represent bars on the chart.  Each bar object has these properties:
     *    color: background color of the bar
     *    value: Number represented by the bar
     *    label: Text to display
     */
  },
  computed: {
    totalValue() {
      return this.chartData.reduce((sum, dataPoint) => {
        return sum + dataPoint.value;
      }, 0);
    }
  },
  methods: {
    percentage(item) {
      if (this.totalValue === 0) return 0.0;
      return (item.value * 100.0) / this.totalValue;
    },
    displayText(item) {
      if (isNaN(item.value) || item.value == 0) {
        return "";
      }
      return `${item.label} ${Math.round(this.percentage(item))}%`;
    }
  }
};
</script>

<style scoped>
* {
  box-sizing: border-box;
}

.barchart {
  height: 40px;
  /* width: 80%; */
  display: flex;
  flex-direction: row;
  border: 1px solid darkgray;
  box-shadow: 5px 5px lightgray;
}
.barchart-bar {
  height: 100%;
  text-align: center;
  border-top: 1px solid darkgray;
  border-right: 1px solid darkgray;
  /* word-wrap: break-word; */
}
</style>
