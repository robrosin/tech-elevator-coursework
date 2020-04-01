<template>
<div class="user">
  <h1>User {{user.id}} {{user.name}}</h1>
  <pre>{{user}}</pre>
  </div>
</template>

<script>
import userService from '@/service/UserService.js'
export default {
    name: 'user',
    data(){
        return {
            user: null
        }
    },
    methods:{
        getUser(id){
            userService.get(id).then(user => this.user=user);
        }
    },
    created(){
        this.getUser(this.$route.params.id)
    }
}
</script>

<style>

</style>