<template>
  <div class="city-update">
    <h1>Update City {{city.name}}</h1>
    <table class="form">
      <tr>
        <td>Name</td>
        <td>
          <input type="text" v-model="city.name" />
        </td>
      </tr>
      <tr>
        <td>District</td>
        <td>
          <input type="text" v-model="city.district" />
        </td>
      </tr>
      <tr>
        <td>Country Code</td>
        <td>
          <input type="text" v-model="city.countryCode" />
        </td>
      </tr>
      <tr>
        <td>Population</td>
        <td>
          <input type="number" v-model.number="city.population" />
        </td>
      </tr>
      <tr>
        <td></td>
        <td>
          <button v-on:click="saveCity">Save</button>
        </td>
      </tr>
    </table>
    <hr />
    <div>
      <router-link :to="{name: 'City', params: {id: city.cityId}}">Back to Details page</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "city-update",
  props: {
    id: Number
  },
  data() {
    return {
      city: {
        cityId: 0,
        name: "",
        district: "",
        countryCode: "",
        population: 0
      }
    };
  },
  methods: {
    getCity(id) {
      // TODO 04: use fetch to get the city given an id

      let url = `${process.env.VUE_APP_REMOTE_API}/cities/${id}`;

      // fetch here...
      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.city = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    },
    saveCity() {
      // TODO 05: use fetch to Update the city on the server (PUT)
      let url = `${process.env.VUE_APP_REMOTE_API}/cities/${this.city.cityId}`;

      // fetch here...
      fetch(url, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.city)
      }).then(response => {
        if (response.ok) {
          alert("City has been updated!");
        } else {
          alert(
            `There was an error updating: ${response.status}: ${response.statusText}`
          );
        }
      });
    }
  },
  created() {
    // TODO 04: Call getCity using the param id to populate the data
    this.getCity(this.$route.params.id);
  }
};
</script>

<style>
</style>