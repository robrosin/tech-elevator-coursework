-- World DB Joins

select city.name, country.name, headofstate
from city
join country on city.countrycode = country.code

-- Use table alias
select ci.name, co.name, headofstate
from city as ci
join country as co on ci.countrycode = co.code

-- List each country and its capital city
select co.name, ci.name
from country as co
join city as ci on co.capital = ci.id

use dvdstore

-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:
select *
from payment where payment_id = 16666

-- Ok, that gives us a customer_id, but not the name. We can use the customer_id to get the name FROM the customer table
select * from payment
join customer on payment.customer_id = customer.customer_id
where payment_id = 16666

-- We can see that the * pulls back everything from both tables. We just want everything from payment and then the first and last name of the customer:
select payment.*, first_name, last_name
from payment
join customer on payment.customer_id = customer.customer_id
where payment_id = 16666

-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.
select p.*, first_name, last_name, r.*
from payment as p
join customer as c on p.customer_id = c.customer_id
join rental as r on  p.rental_id = r.rental_id
where payment_id = 16666

-- What did they rent? Film id can be gotten through inventory.



-- What if we wanted to know who acted in that film?

-- What if we wanted a list of all the films and their categories ordered by film title
select title
from film
join film_category on film_category.film_id = film.film_id

select * from film
select * from film_category where film_id = 1
select * from category where category_id = 6

select film_id
from film

-- Show all the 'Comedy' films ordered by film title
select * from film 
join film_category on film.film_id = film_category.film_id
join category on category.category_id = film_category.category_id
where name = 'comedy' 
order by film.title

-- Finally, let's count the number of films under each category
select category.name, count(*)
from film_category
join category on film_category.category_id = category.category_id
group by category.name

-- ********* LEFT JOIN ***********

-- (There aren't any great examples of left joins in the "dvdstore" database, so the following queries are for the "world" database)

-- A Left join, selects all records from the "left" table and matches them with records from the "right" table if a matching record exists.

-- Let's display a list of all countries and their capitals, if they have some.

-- Only 232 rows
-- But we’re missing entries:

-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

-- *********** UNION *************

-- Back to the "dvdstore" database...

-- Gathers a list of all first names used by actors and customers
-- By default removes duplicates

-- Gather the list, but this time note the source table with 'A' for actor and 'C' for customer
