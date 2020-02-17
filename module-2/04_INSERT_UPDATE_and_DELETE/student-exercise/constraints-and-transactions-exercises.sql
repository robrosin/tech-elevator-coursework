-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
insert into actor (first_name, last_name)
values ('Hampton', 'Avenue'),
	   ('Lisa', 'Byway')

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.
insert into film (title, description, release_year, language_id, length)
values ('Euclidean PI', 'The epic story of Euclid as a pizza delivery boy in ancient Greece', 2008, 1, 198)

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

insert into film_category(category_id, film_id)
values ((select category_id from category where name = 'mathemagical'), (select film_id from film where title = 'euclidean pi')),
((select category_id from category where name = 'mathemagical'), (select film_id from film where title = 'egg igby')),
((select category_id from category where name = 'mathemagical'), (select film_id from film where title = 'karate moon')),
((select category_id from category where name = 'mathemagical'), (select film_id from film where title = 'random go')),
((select category_id from category where name = 'mathemagical'), (select film_id from film where title = 'young language'))

-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)

update film
set rating = 'G'
where film_id in (select film_id from film_category where category_id =
(select category_id from category where name = 'mathemagical'))

-- 7. Add a copy of "Euclidean PI" to all the stores.

insert into inventory (film_id, store_id)
values((select film_id from film where title = 'euclidean pi'), (select store_id from store where store_id = 1)),
((select film_id from film where title = 'euclidean pi'), (select store_id from store where store_id = 2))

-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>

It did not succeed because it still exists in film id and in inventory

-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>

delete category_id from category where name = 'mathemagical'

-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>

select name from category where name = 'mathemagical'

-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)
-- <YOUR ANSWER HERE>

-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.
