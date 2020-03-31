<template>
  <div>
    <h2 v-if="title">{{title}}</h2>
    <div class="barchart">
      <div class="chart-row" v-for="(item, index) in chartData" v-bind:key="index">
        <div class="chart-row-title">{{item.label}}</div>
        <div class="chart-bar-container">
          <div
            class="chart-bar"
            v-bind:style="{'width': percentage(item).toString()+'%', 'background-color' : item.color}"
          >{{displayText(item)}}</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    title: String,
    displayPercentage: {
      /** If false will display item.value, if true will display percentage of total */
      type: Boolean,
      default: false
    },
    scaleToLargest: {
      /* If scaleToLargest, the largest value will be 100% chart width. If not, scale is 100% (totalValue). */
      type: Boolean,
      default: true
    },
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
    },
    scale() {
      /* If scaleToLargest, the largest value will be 100% chart width. If not, scale is 100% (totalValue). */
      if (!this.scaleToLargest) return this.totalValue;
      return this.chartData.reduce((max, item) => {
        return Math.max(max, item.value) * 1.0;
      }, Number.NEGATIVE_INFINITY);
    }
  },
  methods: {
    percentage(item) {
      if (this.totalValue === 0) return 0.0;
      return (item.value * 100.0) / this.scale;
    },
    displayText(item) {
      if (isNaN(item.value) || item.value == 0) {
        return "";
      }
      //return `${item.label} ${Math.round(this.percentage(item))}%`;
      return this.displayPercentage
        ? `${Math.round((item.value * 100.0) / this.totalValue)}%`
        : `${item.value}`;
    }
  }
};
</script>

<style scoped>
* {
  box-sizing: border-box;
}
.barchart {
  /* width: 100%; */
  border: 1px solid darkgray;
  box-shadow: 5px 5px lightgray;
}

.chart-row {
  height: 40px;
  width: 100%;
  /* display: flex;
  flex-direction: row; */
}

.chart-row-title {
  display: inline-block;
  width: 20%;
  height: 100%;
  padding: 0 5px;
}
.chart-bar-container {
  display: inline-block;
  border: 1px solid lightgray;
  width: 80%;
  height: 100%;
  padding: 1px 0;
}

.chart-bar {
  /* display: inline-block; */
  height: 100%;
  text-align: center;
  border-top: 1px solid darkgray;
  border-right: 1px solid darkgray;
}
</style>
