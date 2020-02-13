-- The following queries utilize the "dvdstore" database.

-- 1. All of the films that Nick Stallone has appeared in
-- (30 rows)
select film.title
from film
join film_actor on film.film_id = film_actor.film_id
join actor on actor.actor_id = film_actor.actor_id
where actor.first_name = 'nick' and actor.last_name = 'stallone'

-- 2. All of the films that Rita Reynolds has appeared in
-- (20 rows)
select film.title
from film
join film_actor on film.film_id = film_actor.film_id
join actor on actor.actor_id = film_actor.actor_id
where actor.first_name = 'rita' and actor.last_name = 'reynolds'

-- 3. All of the films that Judy Dean or River Dean have appeared in
-- (46 rows)
select film.title
from film
join film_actor on film.film_id = film_actor.film_id
join actor on actor.actor_id = film_actor.actor_id
where (actor.first_name = 'judy' and actor.last_name = 'dean') or (actor.first_name = 'river' and actor.last_name = 'dean')

-- 4. All of the the ‘Documentary’ films
-- (68 rows)
select film.title
from film
join film_category on film_category.film_id = film.film_id
join category on film_category.category_id = category.category_id
where category.name = 'documentary'

-- 5. All of the ‘Comedy’ films
-- (58 rows)
select film.title
from film
join film_category on film_category.film_id = film.film_id
join category on film_category.category_id = category.category_id
where category.name = 'comedy'

-- 6. All of the ‘Children’ films that are rated ‘G’
-- (10 rows)
select film.title
from film
join film_category on film_category.film_id = film.film_id
join category on film_category.category_id = category.category_id
where category.name = 'children' and film.rating = 'g'

-- 7. All of the ‘Family’ films that are rated ‘G’ and are less than 2 hours in length
-- (3 rows)
select film.title
from film
join film_category on film_category.film_id = film.film_id
join category on film_category.category_id = category.category_id
where category.name = 'family' and film.rating = 'g' and length < 120

-- 8. All of the films featuring actor Matthew Leigh that are rated ‘G’
-- (9 rows)
select film.title
from film
join film_actor on film.film_id = film_actor.film_id
join actor on actor.actor_id = film_actor.actor_id
where (actor.first_name = 'matthew' and actor.last_name = 'leigh') and film.rating = 'g'

-- 9. All of the ‘Sci-Fi’ films released in 2006
-- (61 rows)
select film.title
from film
join film_category on film_category.film_id = film.film_id
join category on film_category.category_id = category.category_id
where category.name = 'sci-fi' and film.release_year = 2006

-- 10. All of the ‘Action’ films starring Nick Stallone
-- (2 rows)

select film.title
from film
join film_category on film_category.film_id = film.film_id
join category on film_category.category_id = category.category_id
join film_actor on film.film_id = film_actor.film_id
join actor on actor.actor_id = film_actor.actor_id
where (actor.first_name = 'nick' and actor.last_name = 'stallone') and category.name = 'action'

-- 11. The address of all stores, including street address, city, district, and country
-- (2 rows)
select address
from store
join address on store.store_id = address.address_id
join city on city.city_id = address.city_id
join country on city.country_id = country.country_id

-- 12. A list of all stores by ID, the store’s street address, and the name of the store’s manager
-- (2 rows)
select *
from staff

select *
from store

select store_id, address, manager_staff_id
from store
join address on store.store_id = address.address_id
join store on store_id = 

-- 13. The first and last name of the top ten customers ranked by number of rentals 
-- (#1 should be “ELEANOR HUNT” with 46 rentals, #10 should have 39 rentals)

-- 14. The first and last name of the top ten customers ranked by dollars spent 
-- (#1 should be “KARL SEAL” with 221.55 spent, #10 should be “ANA BRADLEY” with 174.66 spent)

-- 15. The store ID, street address, total number of rentals, total amount of sales (i.e. payments), and average sale of each store.
-- (NOTE: Keep in mind that an employee may work at multiple stores.)
-- (Store 1 has 7928 total rentals and Store 2 has 8121 total rentals)

-- 16. The top ten film titles by number of rentals
-- (#1 should be “BUCKET BROTHERHOOD” with 34 rentals and #10 should have 31 rentals


select top 10 film.title
from film
join film_category on film_category.film_id = film.film_id
join category on film_category.category_id = category.category_id
join film_actor on film.film_id = film_actor.film_id
join actor on actor.actor_id = film_actor.actor_id
where (actor.first_name = 'nick' and actor.last_name = 'stallone') and category.name = 'action'

-- 17. The top five film categories by number of rentals 
-- (#1 should be “Sports” with 1179 rentals and #5 should be “Family” with 1096 rentals)

-- 18. The top five Action film titles by number of rentals 
-- (#1 should have 30 rentals and #5 should have 28 rentals)

-- 19. The top 10 actors ranked by number of rentals of films starring that actor 
-- (#1 should be “GINA DEGENERES” with 753 rentals and #10 should be “SEAN GUINESS” with 599 rentals)

-- 20. The top 5 “Comedy” actors ranked by number of rentals of films in the “Comedy” category starring that actor 
-- (#1 should have 87 rentals and #5 should have 72 rentals)
