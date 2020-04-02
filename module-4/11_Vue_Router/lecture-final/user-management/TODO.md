# Work to Create Our User Management Site
1. Create two new views (and the views folder)
    * Users.vue
    * User.vue
2. Build routes to the views (router.js):
    * /users - to go to the Users view
    * /users/:id - to got to the User view, passing in a user id
    * Also, add a re-direct from the home path /, to the users page
3. Build Users view:
    * Add a table for the user list (Id & Name columns)
    * Add a little bit of Style
        <style>
        td, th {
        padding:6px;
        margin:0;
        }
        tr:nth-child(even) {
        background-color: rgb(216, 216, 216);
        }
        a, a:hover, a:visited {
        color:blue;
        text-decoration:none;
        text-transform: uppercase;
        }
        </style>
    * Add Script:
        * import UserService
        * Data:
            * users - an empty array to hold all our users
        * Methods:
            * getUsers() - to get the list of users from an api
        * created() life-cycle hook - to call getUsers()
    * Go back to the HTML and write a loop over our users to fill in the table.
4. Build the User view:
    * Script
        * Data:
            * user - holds our selected user (null to start)
        * Methods:
            * getUser(id) - to get a single user from an api
        * created() life-cycle hook - call the get user method using the id from $route.params.
    * HTML
        * Display the user
        * Add a link to go back to the list
        
