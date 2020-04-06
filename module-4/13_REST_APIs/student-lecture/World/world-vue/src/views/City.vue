<template>
  <div class="city">
    <h1>{{city.name}}</h1>
    <h2>Details</h2>
    <table class="form">
      <tr>
        <td>Name</td>
        <td>
          {{city.name}}
        </td>
      </tr>
      <tr>
        <td>District</td>
        <td>
          {{city.district}}
        </td>
      </tr>
      <tr>
        <td>Country Code</td>
        <td>
          {{city.countryCode}}
        </td>
      </tr>
      <tr>
        <td>Population</td>
        <td>
          {{city.population}}
        </td>
      </tr>
    </table>
    <hr />
    <table class="form">
      <tr>
        <td><router-link tag="button" :to="{name: 'CityUpdate', params: {id: city.cityId}}">Modify city</router-link></td>
        <td><router-link tag="button" :to="{name: 'CityDelete', params: {id: city.cityId}}">Delete city</router-link></td>
      </tr>
    </table>

  </div>
</template>

<script>
export default {
  name: "city",
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
      // TODO 03: Use fetch to get data and populate the city data field
      // This is the url...
      let url = `${process.env.VUE_APP_REMOTE_API}/cities/${id}`;
      
            // fetch here...
            fetch(url)
            .then(response => {
              response.json()
              .then(json => {
                this.city=json;
              })
            }).catch(err => {
            console.log(err)});
    }
  },
  created() {
    // TODO 03: call getCity passing in the id from params
this.getCity(this.$route.params.id);
  }
};
</script>

<style>
</style>