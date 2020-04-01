<template>
  <div class="users">
      <h1>User List</h1>

    <table>
        <tr v-for="user in users" :key="user.name">
            <td>{{user.id}}</td>
            <td><router-link :to="{name: 'user', params: {id: user.id}}">{{user.name}}</router-link>
                </td>
        </tr>
    </table>


  </div>
</template>

<script>
import userService from '@/service/UserService.js'
export default {
    name: 'users',
    data() {
        return {
            users: []
        }
    },
    methods: {
        getUsers() {
            userService.list().then( users =>  this.users = users);
        }
    },
    created() {
        this.getUsers();
    }
}
</script>

<style>

</style>