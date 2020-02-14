-- LEFT JOIN 

 -- Let's display a list of all countries and their capitals, if they have some.

 SELECT co.name Country, ci.name City
 FROM country co 
 INNER JOIN city ci ON co.capital = ci.id

 Select * from country where capital is null

-- Only 232 rows
-- But we’re missing entries:

-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

 SELECT co.name Country, ci.name City
 FROM country co 
 LEFT OUTER JOIN city ci ON co.capital = ci.id


 SELECT co.name Country, ci.name City
 FROM city ci 
 RIGHT OUTER JOIN country co ON co.capital = ci.id



-- Find out if there are any countries which do not have any cities in the city table
SELECT *
FROM country co 
LEFT JOIN city ci ON co.code = ci.countrycode
WHERE ci.id IS NULL

-- Is there another way to do this?
SELECT * from country
WHERE code NOT IN (SELECT DISTINCT countrycode FROM city)



-- INSERT

-- 1. Add Klingon as a spoken language in the USA
-- 2. Add Klingon as a spoken language in Great Britain
INSERT INTO countrylanguage
           (countrycode, language, isofficial, percentage)
     VALUES ('USA', 'Klingon', 0, .01)

INSERT INTO countrylanguage
           (countrycode, language, isofficial, percentage)
     VALUES ('GBR', 'Klingon', 1, 50)

Select * from countrylanguage WHERE language = 'Klingon'


-- UPDATE

-- 1. Update the capital of the USA to Houston
Select * from city where name = 'Houston'
Update country
SET capital = 3796
WHERE code = 'USA'

-- OR, we could use a subquery
Update country
SET capital = (Select id from city where name = 'Houston')
WHERE code = 'USA'


Select * from country where code = 'USA'

-- 2. Update the capital of the USA to Washington DC and the head of state
Select * from city where name = 'Washington'
Update country
SET capital = 3813,
	headofstate = 'Donald J Trump'
WHERE code = 'USA'


-- DELETE



-- 1. Delete English as a spoken language in the USA
DELETE FROM countrylanguage WHERE
countrycode = 'USA' AND language = 'English'

-- 2. Delete all occurrences of the Klingon language 
DELETE FROM countrylanguage WHERE language = 'Klingon'

-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.


-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?
insert into countrylanguage 
([countrycode], language, isofficial, percentage)
VALUES
('ZZZ', 'English', 0, 110)


-- 3. Try deleting the country USA. What happens?
Delete from country where code = 'USA'


-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
insert into countrylanguage
([countrycode], language, isofficial, percentage)
VALUES
('USA', 'English', 1, 89)


-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'
Update country
Set continent = 'Outer Space'
Where code = 'USA'


-- How to view all of the constraints
SELECT * FROM INFORMATION_SCHEMA.TABLES
SELECT * FROM INFORMATION_SCHEMA. COLUMNS

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.
BEGIN TRANSACTION
	SELECT * from countrylanguage
	DELETE FROM countrylanguage
	SELECT * from countrylanguage
COMMIT TRAN

SELECT * from countrylanguage

-- 2. Try updating all of the cities to be in the USA and roll it back
BEGIN TRAN
	Update city SET name = 'Mikeville'
	Select * from city
Rollback tran
select * from city

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.