-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
select *
from actor

insert into actor (first_name, last_name)
values ('Hampton', 'Avenue'),
	   ('Lisa', 'Byway')

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.
begin transaction
insert into film (title, description, release_year, language_id, length)
values ('Euclidean PI', 'The epic story of Euclid as a pizza delivery boy in ancient Greece', 2008, 1, 198)

select *
from film
where film.length = 198
commit transaction

-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.

select * from film_actor

begin transaction
insert into film_actor(actor_id, film_id)
values ((select actor_id from actor where first_name = 'hampton' and last_name = 'avenue'), -- hampton avenue
(select film_id from film where title = 'euclidian pi'))

insert into film_actor(actor_id, film_id)
values ((select actor_id from actor where first_name = 'lisa' and last_name = 'byway'), -- lisa byway
(select film_id from film where title = 'euclidian pi'))
rollback transaction

-- 4. Add Mathmagical to the category table.

insert into category(name)
values ('Mathemagical')

-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE" 

-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)

-- 7. Add a copy of "Euclidean PI" to all the stores.

-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>

-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>

-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>

-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)
-- <YOUR ANSWER HERE>

-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.
