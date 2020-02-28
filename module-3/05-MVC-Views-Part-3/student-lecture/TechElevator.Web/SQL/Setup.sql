Use master 
Go

Drop Database if Exists SWDB
Go

Create Database SWDB
Go

Use SWDB
Go

Create table Film (
    Id varchar(10) Primary Key,
    Name varchar(100) not null,
    Description varchar(max),
    Series varchar(10) not null,
    Length int not null default 0,
    YearReleased int not null,
    ImageUrl varchar(200),
)
Go

Insert Film Values
(
'swi', 'Episode I - The Phantom Menace',
'After a millennia, an ancient evil returns seeking revenge. Meanwhile, Jedi Knight Qui-Gon Jinn discovers Anakin Skywalker: a young slave boy unusually strong with the Force.',
'Prequel', 136, 1999, 'https://lumiere-a.akamaihd.net/v1/images/open-uri20150608-27674-1u75352_74ad4fed.jpeg?region=0%2C0%2C1280%2C720'
),
(
'swii', 'Episode II - Attack of the Clones',
'Following an assassination attempt on Senator Padmé Amidala, Jedi Knights Anakin Skywalker and Obi-Wan Kenobi investigate a mysterious plot that could change the galaxy forever.',
'Prequel', 142, 2002, 'https://lumiere-a.akamaihd.net/v1/images/image_d347a76f.jpeg?height=877&width=1560&x=0&y=0'
),
(
'swiii', 'Episode III - Revenge of the Sith',
'The evil Darth Sidious enacts his final plan for unlimited power -- and the heroic Jedi Anakin Skywalker must choose a side.',
'Prequel', 140, 2005, 'https://lumiere-a.akamaihd.net/v1/images/open-uri20150608-27674-1ovrwx_ec2c9933.jpeg?region=0%2C0%2C1280%2C720'
),
(
'swiv', 'Episode IV - A New Hope',
'With the planet-destroying power of the Death Star, the Empire looks to cement its grip on the galaxy. Meanwhile, farm boy Luke Skywalker rises to face his destiny.',
'Original', 121, 1977, 'https://lumiere-a.akamaihd.net/v1/images/open-uri20150608-27674-19ndoh0_6b28a7c8.jpeg?region=0%2C0%2C1280%2C720'
),
(
'swv', 'Episode V - The Empire Strikes Back',
'While the Death Star has been destroyed, the battle between the Empire and the Rebel Alliance rages on...and the evil Darth Vader continues his relentless search for Luke Skywalker.',
'Original', 124, 1980, 'https://lumiere-a.akamaihd.net/v1/images/open-uri20150608-27674-uvp69q_01527055.jpeg?region=0%2C0%2C1280%2C720'
),
(
'swvi', 'Episode VI - Return of the Jedi',
'Luke Skywalker leads a mission to rescue his friend Han Solo from the clutches of Jabba the Hutt, while the Emperor seeks to destroy the Rebellion once and for all with a second dreaded Death Star.',
'Original', 131, 1983, 'https://lumiere-a.akamaihd.net/v1/images/open-uri20150608-27674-wpda3k_1932e9f5.jpeg?region=0%2C0%2C1280%2C720'
),
(
'swvii', 'Episode VII - The Force Awakens',
'Thirty years after the Battle of Endor, a new threat has risen in the form of the First Order and the villainous Kylo Ren. Meanwhile, Rey, a young scavenger, discovers powers that will change her life -- and possibly save the galaxy.',
'Sequel', 138, 2015, 'https://lumiere-a.akamaihd.net/v1/images/open-uri20150608-27674-wpda3k_1932e9f5.jpeg?region=0%2C0%2C1280%2C720'
),
(
'swviii', 'Episode VIII: The Last Jedi', 
'Rey has found the legendary Luke Skywalker, hoping to be trained in the ways of the Force. Meanwhile, the First Order seeks to destroy the remnants of the Resistance and rule the galaxy unopposed.',
'Sequel', 152, 2017, 'https://lumiere-a.akamaihd.net/v1/images/the-last-jedi-theatrical-poster-tall-a_6a776211.jpeg?region=0%2C53%2C1536%2C768&width=768'
),
(
'swix', 'Episode IX - The Rise of Skywalker',
'A powerful enemy returns and Rey must face her destiny. The final chapter of the Skywalker saga comes home beginning March 17.',
'Sequel', 142, 2019, 'https://i0.wp.com/culturedvultures.com/wp-content/uploads/2019/04/Star-Wars-Episode-9.jpg'
),
(
'solo', 'Solo: A Star Wars Story',
'Board the Millennium Falcon and journey to a galaxy far, far away in Solo: A Star Wars Story, an all-new adventure with the most beloved scoundrel in the galaxy. Through a series of daring escapades deep within a dark and dangerous criminal underworld, Han Solo meets his mighty future copilot Chewbacca and encounters the notorious gambler Lando Calrissian, in a journey that will set the course of one of the Star Wars saga''s most unlikely heroes.',
'Standalone', 135, 2018, 'https://lumiere-a.akamaihd.net/v1/images/solo-theatrical-poster-1000_27861ab7.jpeg?region=0%2C279%2C1000%2C503&width=768'
),
(
'rogue-one', 'Rogue One: A Star Wars Story', 
'From Lucasfilm comes the first of the Star Wars standalone films, ''Rogue One: A Star Wars Story,'' an all-new epic adventure. In a time of conflict, a group of unlikely heroes band together on a mission to steal the plans to the Death Star, the Empire''s ultimate weapon of destruction. This key event in the Star Wars timeline brings together ordinary people who choose to do extraordinary things, and in doing so, become part of something greater than themselves.',
'Standalone', 133, 2016, 'https://lumiere-a.akamaihd.net/v1/images/rogueone_onesheeta_8a255456.jpeg?region=0%2C77%2C1688%2C849&width=768'
)


