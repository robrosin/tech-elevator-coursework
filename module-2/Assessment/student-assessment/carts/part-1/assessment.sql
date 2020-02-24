USE assessment;
GO

-- Select all the columns in cart where the username is kmilner1j

select * from carts where username = 'kmilner1j'

-- Select the id and name columns from items where the item was added on or after Jan. 15, 2019 and the weight is null

select id, name from items where (added > '2019-01-15') and weight is null

-- Select username and the cookie_value from carts where the username isn't null, ordered by the created date, latest first

select username, cookie_value from carts where username is not null
order by created desc

-- Select the added date and the count of all the items added on that date

select added, count(*) from items 
group by added

-- Select the cart's username and created date and the item's name for all carts created in the month of Sept. 2019

select username, created, name from carts
join items on carts.id = items.cart_id
where created >= '2019-09-01' and created <= '2019-09-30'