<template>
  <div class ="shopping-list">
      <h1>My Shopping List</h1>
      <ul>
          <li>Coffee</li>
          <li>A Bit More Coffee</li>
          <li>Some Coffee</li>
          <li class="completed">Whole Bean Coffee</li>
          <li class="completed">Additional Coffee</li>
          <li>A Lot More Coffee</li>
          <li>A Pound of Coffee</li>
          <li>Coffee</li>        
      </ul>
  </div>
</template>

<script>
export default {
    name: "shopping-list",
    }
</script>

<style>
.shopping-list {
    width:450px;
    background: #fff;
    margin: 50px auto;
    font-family: 'Roboto Condensed', sans-serif;
    border-radius: 10px;
}
h1 {
    background:#f2f2f2;
    color:#5c8578;
    padding:10px;
    font-size:24px;
    text-transform: uppercase;
    text-align: center;
    margin-bottom: 0px;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
}
ul {
    list-style-type: none;
    margin:0px;
    padding:0px;
}
li {
    font-size: 24px;
    border-bottom:1px solid #f2f2f2;
    padding:10px 20px;
}
li:last-child{
    border:0px;
}
li.completed {
    text-decoration: line-through;
    color:darkgrey;
}
</style>