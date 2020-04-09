<template>
  <div class="city-delete">
    <h1>Wanna DELETE City {{city.name}}?</h1>
    <table class="form"><tr><td><button v-on:click="deleteCity">Yes!</button></td></tr></table>
    
    <div>
      <hr/>
      <router-link :to="{name: 'City', params: {id: city.cityId}}">Cancel</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "city-delete",
  props: {
    id: Number
  },
  data() {
    return {
      city: null
    };
  },
  methods: {
    getCity(id) {
      // TODO 06: Use fetch to get data and populate the city data field
      // This is the url...
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
    deleteCity() {
      // TODO 07: use fetch to Delete the city on the server (DELETE)
      let url = `${process.env.VUE_APP_REMOTE_API}/cities/${this.city.cityId}`;
      console.log(url);

      // fetch here...
      fetch(url, {
        method: 'DELETE'
      })
        .then( response =>{
          if (response.ok){
            alert('City has been deleted!');
            // Redirect to the city search page, which cc and district passed in 
            this.$router.push( {name: 'Cities', query: {countryCode: this.city.countryCode, district: this.city.district} });
          }
          else {
            alert(`There was an error deleting: ${response.status}: ${response.statusText}`);
          }
        })
    }
  },
  created() {
    // TODO 06: Call getCity using the param id to populate the data
    this.getCity(this.$route.params.id);
    
  }
};
</script>

<style>
</style>