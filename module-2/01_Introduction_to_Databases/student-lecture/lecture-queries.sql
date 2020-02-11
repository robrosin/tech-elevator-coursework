-- SELECT ... FROM
-- Selecting the names for all countries
SELECT name FROM country

-- Selecting the name and population of all countries
select name, population from country

-- Selecting all columns from the city table
select * from city

-- SELECT ... FROM ... WHERE
-- Selecting the cities in Ohio
select * from city where district = 'Ohio'

-- Selecting countries that gained independence in the year 1776
select * from country where indepyear = 1776

-- Selecting countries not in Asia
select * from country where continent != 'Asia'

-- Selecting countries that do not have an independence year
select * from country where indepyear is null

-- Selecting countries that do have an independence year
select * from country where indepyear is not null

-- Selecting countries that have a population greater than 5 million
select * from country where population > 5000000

-- SELECT ... FROM ... WHERE ... AND/OR
-- Selecting cities in Ohio and Population greater than 400,000

select * from city where district = 'ohio' and population > 400000

-- Selecting country names on the continent North America or South America
select * from country where continent = 'north america' or continent = 'south america'

-- Same query with a wild-card search
select * from country where continent like '%america'

-- Same query withan IN clause
select * from country where continent in ('north america', 'south america')

-- Countries not in the Americas
select * from country where continent not in ('north america', 'south america')

-- Cities in Ohio and Michigan
select * from city where district in ('ohio', 'michigan')

-- SELECTING DATA w/arithmetic
-- Selecting the population, life expectancy, and population per area
--	note the use of the 'as' keyword
select name, population, lifeexpectancy, population/surfacearea as density from country

-- Select cities in the US ordered by name
select * from city where countrycode = 'USA' order by name desc

-- Select cities in the US ordered by state, then by city name
select * from city where countrycode = 'usa' order by district, name 

-- Select cities in the US ordered by population, largest to smallest
select * from city where countrycode = 'usa' order by population desc

-- Select the ten largest cities in the world
select top 10 * from city order by population desc

-- Get a list of US states
select distinct district from city where countrycode = 'usa'

