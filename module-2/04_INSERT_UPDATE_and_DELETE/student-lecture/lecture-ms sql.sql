-- LEFT JOIN 

 -- Let's display a list of all countries and their capitals, if they have some.

 select country.name, city.name
 from country
 inner join city on country.capital = city.id

 -- Only 232 rows
-- But we’re missing entries:

-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

select country.name, city.name
from country
left join city on country.capital = city.id

select country.name, city.name
from city
right join country on country.capital = city.id

-- Find out if there are any countries which do not have any cities in the city table

select *
from country
left join city on country.code = city.countrycode
where city.id is null

-- Is there another way to do this?
select *
from country 
where code not in (select distinct countrycode from city)

-- INSERT

-- 1. Add Klingon as a spoken language in the USA
insert into countrylanguage (countrycode, language, isofficial, percentage)
values ('USA', 'Klingon', 0, .01)

-- 2. Add Klingon as a spoken language in Great Britain
insert into countrylanguage (countrycode, language, isofficial, percentage)
values ('GBR', 'Klingon', 1, 50)

select *
from countrylanguage where language = 'klingon'

-- UPDATE

-- 1. Update the capital of the USA to Houston
select * from city where name = 'Houston'

update country
set capital = 3796
where code = 'USA'

-- OR

update country
set capital = (select id from city where name = 'Houston')
where code = 'USA'

select * from country where code = 'USA'

-- 2. Update the capital of the USA to Washington DC and the head of state
select * from city where name = 'Washington'

update country
set capital = 3813, 
	headofstate = 'Donald J Trump'
where code = 'USA'

-- DELETE

-- 1. Delete English as a spoken language in the USA
select * from countrylanguage 
where countrycode = 'USA' and language = 'English'

delete from countrylanguage
where countrycode = 'USA' and language = 'English'

-- 2. Delete all occurrences of the Klingon language 
select * from countrylanguage
where language = 'Klingon'

delete from countrylanguage
where language = 'Klingon'

-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.
-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?
insert into countrylanguage
(countrycode, language, isofficial, percentage)
values
('zzz', 'English', 0, 110)

-- 3. Try deleting the country USA. What happens?
delete from country
where code = 'usa'


-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
insert into countrylanguage
(countrycode, language, isofficial, percentage)
values
('USA', 'English', 1, 89)

-- 2. Try again. What happens?
insert into countrylanguage
(countrycode, language, isofficial, percentage)
values
('USA', 'English', 1, 89

-- 3. Let's relocate the USA to the continent - 'Outer Space'
update country
set continent = 'Outer Space'
where code = 'USA'

-- How to view all of the constraints
SELECT * FROM INFORMATION_SCHEMA.TABLES
SELECT * FROM INFORMATION_SCHEMA. COLUMNS 
SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.
begin transaction
select * from countrylanguage
delete from countrylanguage
select * from countrylanguage
rollback transaction

select * from countrylanguage

-- 2. Try updating all of the cities to be in the USA and roll it back
begin transaction
update city set name = 'Mikeville'
select * from city
rollback transaction

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.