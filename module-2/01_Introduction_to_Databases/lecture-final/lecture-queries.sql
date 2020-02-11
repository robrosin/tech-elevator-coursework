/* This is a block comment
	It is the same as C#
*/

-- SELECT ... FROM
-- Selecting the names for all countries
SELECT name 
FROM country;

-- Selecting the name and population of all countries
select name, population FROM country

-- Selecting all columns from the city table
SELECT * FROM city


-- SELECT ... FROM ... WHERE
-- Selecting the cities in Ohio
SELECT *
FROM city
WHERE district = 'ohio'

-- Selecting countries that gained independence in the year 1776
SELECT * 
FROM country 
WHERE indepyear = 1776


-- Selecting countries not in Asia
SELECT *
FROM country
WHERE continent != 'asia'


-- Selecting countries that do not have an independence year
SELECT * 
FROM country
WHERE indepyear IS NULL


-- Selecting countries that do have an independence year
SELECT * 
FROM country
WHERE indepyear IS NOT NULL

-- Selecting countries that have a population greater than 5 million
SELECT * 
FROM country
WHERE population > 5000000


-- SELECT ... FROM ... WHERE ... AND/OR
-- Selecting cities in Ohio and Population greater than 400,000
SELECT * 
FROM city
WHERE district = 'Ohio' AND population > 400000

-- Selecting country names on the continent North America or South America
SELECT *
FROM country
WHERE continent = 'North america' OR continent = 'south america'

-- Same query with a wild-card search
SELECT * 
FROM country
WHERE continent LIKE '%america'

-- Same query with an IN clause
SELECT * 
FROM country
WHERE continent IN ('North America', 'South America')

-- Countries not in the americas
SELECT * 
FROM country
WHERE continent NOT IN ('North America', 'South America')

-- Cities in Ohio and Michigan
SELECT * 
FROM city
WHERE district in ('Ohio', 'Michigan')

-- SELECTING DATA w/arithmetic
-- Selecting the population, life expectancy, and population per area
--	note the use of the 'as' keyword
SELECT name AS 'Country name', population, lifeexpectancy AS 'Longevity', population / surfacearea AS 'Population Density'
FROM country


-- Select cities in the US ordered by name
SELECT * 
FROM city
WHERE countrycode = 'USA'
ORDER BY name

-- Select cities in the US ordered state, then by city name
SELECT * 
FROM city
WHERE countrycode = 'USA'
ORDER BY district, name

-- Select cities in the US ordered population, largest to smallest
SELECT TOP 10 *
FROM city
WHERE countrycode = 'USA'
ORDER BY population DESC

-- Select the 10 largest cities in the world
SELECT TOP 10 *
FROM city
ORDER BY population DESC

-- Get a list of US states
SELECT DISTINCT district
FROM city
WHERE countrycode = 'USA'
ORDER BY district



