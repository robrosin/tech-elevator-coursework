<template>
  <div class="cities">
    <h1>List Cities</h1>
    <table class="form">
      <tr>
        <td>Country Code:</td>
        <td>
          <input
            type="text"
            v-model="searchCountry"
            @change="searchDistrict = (searchCountry) ? searchDistrict : '' ;"
            placeholder="Country Code"
          />
        </td>
        <td>District:</td>
        <td>
          <input
            type="text"
            v-model="searchDistrict"
            :disabled="!searchCountry"
            placeholder="State"
          />
        </td>
        <td>
          <button @click="getData">Search</button>
        </td>
      </tr>
    </table>

    <city-list :cities="cities"></city-list>
  </div>
</template>

<script>
import CityList from "@/components/CityList.vue";
export default {
  name: "cities",
  components: {
    "city-list": CityList
  },
  data() {
    return {
      searchCountry: "",
      searchDistrict: "",
      cities: []
    };
  },
  methods: {
    getData() {
      // TODO 01: use fetch to get data from the server populate the cities array
      // TODO 02: add in the query string parameters

      // This is the url...
      let url = `${process.env.VUE_APP_REMOTE_API}/cities`;

      if (this.searchCountry){
        url += `?countryCode=${this.searchCountry}`;
        if(this.searchDistrict){
          url += `&district=${this.searchDistrict}`;
        }
      }

      // fetch here...
      fetch(url)
      .then(response => {
        response.json()
        .then(json => {
          this.cities = json;
        })
      }).catch(err => {
        console.log(err)
      });
    }
  },
  created() {
    // TODO 02: Get QS parameters from the route and populate them in data
    this.searchCountry = this.$route.query.countryCode;
    this.searchDistrict = this.$route.query.district;
    if (this.searchCountry){
      this.getData();
    }
  }
};
</script>

<style scoped>
</style>