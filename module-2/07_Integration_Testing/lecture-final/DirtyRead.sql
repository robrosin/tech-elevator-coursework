-- This allows us to do a dirty read and see what the db looks like "in the middle of" the transaction.
select * from city with(nolock)
select * from country with(nolock)
select * from countrylanguage with(nolock)
