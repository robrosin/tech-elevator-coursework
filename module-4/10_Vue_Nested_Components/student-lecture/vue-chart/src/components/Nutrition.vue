<template>
  <div class="nutrition-control">
    <h3>Nutrition Log: {{userName}} ({{logDate}})</h3>
    <table style="text-align: right;">
      <thead>
        <tr>
          <th>Meal</th>
          <th class="th-carbs">Carbs (g)</th>
          <th class="th-protein">Protein (g)</th>
          <th class="th-fat">Fat (g)</th>
          <th>Total Calories</th>
          <!-- TODO REVIEW: add a button to add a new meal -->
          <th>
            <input class="add" type="button" value="Add Meal" v-on:click="newMeal" />
          </th>
        </tr>
      </thead>
      <tbody>
        <!-- TODO REVIEW: add an index to the foreach so that we can pass it into Remove -->
        <tr v-for="(meal, index) in meals" v-bind:key="meal.id">
          <td>
            <input type="text" v-model="meal.meal" />
          </td>
          <td>
            <!-- TODO 02c: Call the method to emit the data-change event -->
            <input type="number" v-model.number="meal.carbs" />
          </td>
          <td>
            <!-- TODO 02c: Call the method to emit the data-change event -->
            <input type="number" v-model.number="meal.protein" />
          </td>
          <td>
            <!-- TODO 02c: Call the method to emit the data-change event -->
            <input type="number" v-model.number="meal.fat" />
          </td>
          <td>{{calories(meal)}}</td>
          <!-- TODO REVIEW: Add a link to remove the current meal -->
          <td>
            <a class="remove" v-on:click="removeMeal(index)">❌</a>
          </td>
        </tr>
        <tr>
          <td>Grams</td>
          <td>{{totalCarbs}}</td>
          <td>{{totalProtein}}</td>
          <td>{{totalFat}}</td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td>Calories</td>
          <td>{{totalCarbs * 4}}</td>
          <td>{{totalProtein * 4}}</td>
          <td>{{totalFat * 9}}</td>
          <td>{{totalCalories}}</td>
          <td></td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
// TODO 02: Add code in the Nutrition component to emit a data-change event whenever nutrition data changes. 
export default {
  props: {
    userName: {
      type: String,
      default: ""
    },
    logDate: {
      type: Date,
      default: new Date()
    }
  },

  data() {
    return {
      meals: [
        {
          id: 1,
          meal: "Breakfast",
          carbs: 0,
          protein: 0,
          fat: 0
        },
        {
          id: 2,
          meal: "Lunch",
          carbs: 0,
          protein: 0,
          fat: 0
        },
        {
          id: 3,
          meal: "Dinner",
          carbs: 0,
          protein: 0,
          fat: 0
        }
      ]
    };
  },

  computed: {
    totalCarbs() {
      return this.meals.reduce((sum, meal) => {
        return sum + meal.carbs;
      }, 0);
    },
    totalProtein() {
      return this.meals.reduce((sum, meal) => {
        return sum + meal.protein;
      }, 0);
    },
    totalFat() {
      return this.meals.reduce((sum, meal) => {
        return sum + meal.fat;
      }, 0);
    },
    totalCalories() {
      return this.meals.reduce((sum, meal) => {
        return sum + this.calories(meal);
      }, 0);
    },
    percentCarbs() {
      if (this.totalCalories == 0 || this.totalCarbs === 0) return "";
      return (
        (this.totalCalories === 0
          ? 0
          : (this.totalCarbs * 400) / this.totalCalories
        ).toFixed(0) + "%"
      );
    },
    percentProtein() {
      if (this.totalCalories == 0 || this.totalProtein === 0) return "";
      return (
        (this.totalCalories === 0
          ? 0
          : (this.totalProtein * 400) / this.totalCalories
        ).toFixed(0) + "%"
      );
    },
    percentFat() {
      if (this.totalCalories == 0 || this.totalFat === 0) return "";
      return (
        (this.totalCalories === 0
          ? 0
          : (this.totalFat * 900) / this.totalCalories
        ).toFixed(0) + "%"
      );
    },

    // TODO 02a: Add the chartData computed property (method) to return the array of data to be charted

    // TODO REVIEW: Add a computed property to calculate the next id for a meal
    nextMealId() {
      return (
        this.meals.reduce((maxId, meal) => {
          return meal.id > maxId ? meal.id : maxId;
        }, 0) + 1
      );
    }
  },

  methods: {
    // TODO 02b: Create a method (emitChangeEvent) to signify the change of nutrition data

    calories(meal) {
      return meal.carbs * 4 + meal.protein * 4 + meal.fat * 9;
    },

    /**
    TODO REVIEW: The newMeal() method adds a new, empty meal to the collection of meals
     */
    newMeal() {
      let meal = {
        id: this.nextMealId,
        meal: "",
        carbs: 0,
        protein: 0,
        fat: 0
      };
      this.meals.push(meal);
    },

    /**
    TODO REVIEW: The removeMeal(index) method removes the meal at the specified index
     */
    removeMeal(index) {
      this.meals.splice(index, 1);

      // TODO 02c: Call the method to emit the data-change event
    }
  }
};
</script>

<style scoped>
input {
  text-align: right;
}
.th-carbs {
  color: var(--carbs-fg);
  background-color: var(--carbs-bg);
}
.th-protein {
  color: var(--protein-fg);
  background-color: var(--protein-bg);
}
.th-fat {
  color: var(--fat-fg);
  background-color: var(--fat-bg);
}
.remove,
.add {
  cursor: pointer;
}
</style>
