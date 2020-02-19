-- Delete all of the data
DELETE FROM countrylanguage;
UPDATE country SET capital = NULL;
DELETE FROM city;
DELETE FROM country;

-- Insert a fake country
INSERT INTO country
(code,name,continent,region,surfacearea,indepyear,population,lifeexpectancy,gnp,gnpold,localname,governmentform,headofstate,capital,code2)
VALUES
('USA', 'United States of America', 'North America', 'Region', 100, 1776, 100, null, null, null, 'United States of America', 'Government', 'Leader', null, 'US'),
('ZZZ', 'Z-Land', 'Europe', 'Region', 100, null, 100, null, null, null, 'ZZZ-Zaw', 'Government', 'Leader', null, 'ZZ');

-- Insert a fake city
INSERT INTO city
(name, countrycode, district, population)
VALUES
('Candyland', 'USA', 'Iowa', 10),
('Utopia', 'USA', 'Iowa', 5);

DECLARE @newCityId int = (SELECT @@IDENTITY);

-- Insert a fake country language
INSERT INTO countrylanguage VALUES ('USA', 'Test Language', 1, 100);

-- Assign the fake city to be the capital of the fake country
UPDATE country SET capital = @newCityId Where code = 'USA';

-- Return the id of the fake city
SELECT @newCityId as newCityId;