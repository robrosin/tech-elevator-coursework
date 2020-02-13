--- ************* World DB Joins ******************
Use World 

SELECT city.name, country.name, headofstate
FROM city 
JOIN country ON city.countrycode = country.code
ORDER BY country.name, city.name

-- Use table aliases
SELECT ci.name, co.name, headofstate
FROM city AS ci
JOIN country AS co ON ci.countrycode = co.code
ORDER BY co.name, ci.name



-- List each country and its capital city
SELECT co.name Country, ci.name City
FROM country co 
JOIN city ci ON co.capital = ci.id
ORDER BY co.name


Use dvdstore
-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:
Select * 
From payment 
where payment_id = 16666

-- Ok, that gives us a customer_id, but not the name. We can use the customer_id to get the name FROM the customer table
Select *
From payment p
Join customer c on p.customer_id = c.customer_id
Where payment_id = 16666


-- We can see that the * pulls back everything from both tables. We just want everything from payment and then the first and last name of the customer:
Select p.*, first_name, last_name
From payment p
Join customer c on p.customer_id = c.customer_id
Where payment_id = 16666


-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.
Select p.*, first_name, last_name, r.*
From payment p
Join customer c on p.customer_id = c.customer_id
JOIN rental r ON p.rental_id = r.rental_id
Where payment_id = 16666

-- NOT THIS!!!  This shows all rental for the customer who made the payment...not what we wanted
Select p.*, first_name, last_name, r.*
From payment p
Join customer c on p.customer_id = c.customer_id
JOIN rental r ON c.customer_id = r.customer_id
Where payment_id = 16666



-- What did they rent? Film id can be gotten through inventory.

-- What if we wanted to know who acted in that film?



-- What if we wanted a list of all the films and their categories ordered by film title
select title 
from film f
join film_category fc ON fc.film_id = f.film_id

select * from film where film_id = 1
select * from film_category where film_id = 1
select * from category where category_id = 6

select f.title, c.name --f.title, c.name
from film f
join film_category fc ON f.film_id = fc.film_id
join category c ON fc.category_id = c.category_id
Where f.film_id = 1


-- Show all the 'Comedy' films ordered by film title
SELECT title, c.name
from film f
join film_category fc on f.film_id = fc.film_id
join category c ON c.category_id = fc.category_id
WHERE c.name = 'Comedy'
order by f.title


-- Finally, let's count the number of films under each category
SELECT c.name, count(*)
FROM film_category fc 
JOIN category c ON fc.category_id = c.category_id
GROUP BY c.name



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
