-- ORDERING RESULTS

-- Populations of all countries in descending order
SELECT name, FORMAT(population, 'N0')
FROM country
ORDER BY population DESC


--Names of countries and continents in ascending order
SELECT name, continent
FROM country
ORDER BY continent, name



-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
SELECT TOP 10 name, lifeexpectancy
FROM country
ORDER BY lifeexpectancy DESC

-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
Select name + ', ' + district AS 'CityState'
FROM city
WHERE district in ('California', 'Oregon', 'Washington')
ORDER BY district, name


-- Can you do it another way?
Select CONCAT(UPPER(name), ', ', UPPER(district)) AS 'CityState'
FROM city
WHERE district in ('California', 'Oregon', 'Washington')
ORDER BY district, name


-- AGGREGATE FUNCTIONS

-- Total population in Asia
SELECT SUM(  CAST(population AS BigInt) ) As 'World Population' FROM country WHERE continent = 'Asia'
SELECT AVG(CAST(population AS BigInt)) As 'Average World Population' FROM country WHERE continent = 'Asia'

-- Average Life Expectancy in the World
SELECT AVG(lifeexpectancy) As 'Average Life Expectancy' FROM country

-- Total population of the major cities in Ohio
SELECT SUM(population) As 'Ohio population'
FROM city
WHERE district = 'Ohio'

-- The surface area of the smallest country in the world
Select MIN(surfaceArea) from country
SELECT TOP 1 name, surfacearea FROM country ORDER BY surfacearea

-- Surface area of the country with the smallest population
SELECT TOP 1 name, surfacearea
FROM country
ORDER BY population

-- The 10 largest countries in the world
SELECT TOP 10 name, LEN(name) As NameLength
FROM country
ORDER BY NameLength DESC

-- The number of countries who declared independence in 1991
Select COUNT(*) 
FROM Country
Where indepyear = 1991


-- GROUP BY
-- Count the number of countries where each language is spoken, ordered from most countries to least
SELECT language, COUNT(countrycode) AS CountryCount
FROM countrylanguage
GROUP BY language
ORDER BY CountryCount DESC 

Select * from countrylanguage


-- Average life expectancy of each continent ordered from highest to lowest
SELECT continent, AVG(lifeexpectancy) AS Life_Expectancy
FROM country
GROUP BY continent
ORDER BY Life_Expectancy DESC

-- Exclude Antarctica from consideration for average life expectancy
SELECT continent, AVG(lifeexpectancy) AS Life_Expectancy
FROM country
WHERE lifeexpectancy is not null
GROUP BY continent
ORDER BY Life_Expectancy DESC

-- Sum of the population of cities in each state in the USA ordered by state name
SELECT district, SUM(population) As StatePop
FROM city
WHERE countrycode = 'USA'
GROUP BY district
ORDER BY StatePop DESC

SELECT district, FORMAT(SUM(population), 'N0') As StatePop
FROM city
WHERE countrycode = 'USA'
GROUP BY district
ORDER BY SUM(population) DESC

-- The average population of cities in each state in the USA ordered by state name
SELECT district, AVG(population) As StatePop
FROM city
WHERE countrycode = 'USA'
GROUP BY district
ORDER BY district

-- SUBQUERIES
-- Find the names of cities under a given government leader

-- Don't do it this way!
SELECT *
FROM city
WHERE countrycode IN ('ASM', 'GUM', 'MNP', 'PRI', 'UMI', 'USA', 'VIR')

-- Do it this way!
SELECT *
FROM city
WHERE countrycode IN (SELECT code FROM country WHERE headofstate like '%Bush')


-- Find the names of cities whose country they belong to has not declared independence yet
SELECT name, countrycode
FROM city
WHERE countrycode in (SELECT code FROM country WHERE indepyear IS NULL)


-- Select those countries with lower than average life expectancy

SELECT *
FROM country
WHERE lifeexpectancy < (SELECT AVG(lifeexpectancy) FROM country)
ORDER BY lifeexpectancy


-- Additional samples
-- You may alias column and table names to be more descriptive

-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)
SELECT name, population
FROM city
WHERE countrycode = 'USA'
ORDER BY name, population



-- While you can use TOP to limit the number of results returned by a query,
-- in SQL Server it is recommended to use OFFSET and FETCH if you want to get
-- "pages" of results. For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)

-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.
-- Counts the number of rows in the city table

-- Also counts the number of rows in the city table

-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.
SELECT SUM(population) As TotalPop, AVG(population) AS AveragePop, Count(population)
FROM city

Select COUNT (*) from country
Select COUNT(indepyear) from country

Select * from city


-- Gets the MIN population and the MAX population from the city table.

-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to 
-- determine the MIN and MAX population for each countrycode in the city table.
Select countrycode, MIN(population), MAX(population)
FROM city
GROUP BY countrycode



