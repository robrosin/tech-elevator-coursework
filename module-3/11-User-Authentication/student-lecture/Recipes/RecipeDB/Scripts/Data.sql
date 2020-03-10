Use RecipeDB 
Delete from Ingredient;
Delete from Recipe;
Delete from [user];

Declare @user int = 1
Declare @recipe int
Set Identity_insert [user] On

Insert [user] (id, username, password, salt, role)
Values (@user, 'user01@te.com', 'pqnS6B26+p1ii3A6QJPrm6n9GaM=', '3MWN6h0nnUY=', 'User');

Insert [user] (id, username, password, salt, role)
Values (2, 'admin1@te.com', '0+tE26SG/P2A4F9iGH4CG1gx8ec=', 'GWieJBJgNvY=', 'Admin');

Set Identity_insert [user] Off



Insert Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine, ImageFile, PrepTime, CookTime, Serves)
    values ('Elvis Pancakes', @user, 
    'Tender and delicious pancakes featuring peanut butter, bananas, and chocolate chips! Inspired by the folklore surrounding Elvis and his fried peanut butter and banana sandwiches. Serve with butter and maple syrup and try not to think about the weight you''re about to gain! Enjoy!!',
    'Whisk flour, baking powder, salt, and brown sugar in bowl. Beat egg and milk together and stir in peanut butter until smooth in a second bowl. Whisk the milk mixture into the dry ingredients just until moistened, then whisk in melted butter and vanilla extract. Gently fold chocolate chips and diced banana into the batter.
     Place a large nonstick skillet over medium heat and pour 1/4 cup of batter per pancake into the middle of the skillet. Let the pancake cook until bottom is golden brown and there are many small pinholes in the top of the pancake before flipping, about 2 minutes. Cook other side until golden brown and the middle of the pancake is set, 2 to 3 minutes. Repeat with remaining batter.',
    'Breakfast', 'American', 'https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F874635.jpg&w=596&h=399.32000000000005&c=sc&poi=face&q=85', 15, 25, 4)
Select @recipe = @@IDENTITY
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'All-purpose flour', 1.25, 'cup')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Baking powder', 1, 'tbsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Salt', 0.5, 'tsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Brown sugar', 2, 'tbsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Milk', 1.5, 'cup')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Egg, beaten', 1, 'ea')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Butter, melted', 3, 'tbsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Vanilla extract', 1, 'tsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Peanut butter', .25, 'cup')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Chocolate chips', .25, 'cup')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Banana, ripe', 1, 'ea')


Insert Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine, ImageFile, PrepTime, CookTime, Serves)
    values ('Ultimate French Toast', @user, 
    'This is a good, old-fashioned way of making delicious French toast. To add a little pizzazz to it, sprinkle on some cinnamon after dipping the bread into the batter. Serve hot with butter and maple syrup.',
    'Combine eggs, milk and cinnamon; beat well. Dip bread into egg mixture until completely coated.
     Heat a lightly oiled griddle or frying pan over medium high heat. Cook bread slices until they are golden brown on both sides. Serve hot.',
    'Breakfast', 'American', 'https://images.media-allrecipes.com/userphotos/560x315/3314610.jpg', 10, 10, 4)
Select @recipe = @@IDENTITY
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Egg', 4, 'ea')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Milk', 2, 'tbsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ground cinnamon', 0.25, 'tsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Bread', 8, 'pc')



Insert Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine, ImageFile, PrepTime, CookTime, Serves)
    values ('Overnight Chia Oatmeal', @user, 
    'This tastes more like a dessert than breakfast! Top with almonds if you like.',
    'Combine oats, almond-coconut milk, chia seeds, coconut, cardamom, cinnamon, vanilla extract, ginger, and nutmeg in a bowl. Cover bowl with plastic wrap and refrigerate, 8 hours to overnight.',
    'Breakfast', 'American', 'https://images.media-allrecipes.com/userphotos/720x405/1122507.jpg', 10, 480, 1)
Select @recipe = @@IDENTITY
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Oats', 1, 'cup')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Almond-coconut milk', 1, 'cup')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Chia seeds', 2, 'tbsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Shredded coconut', 2, 'tbsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ground cardamom', 0.25, 'tsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Vanilla extract', 0.25, 'tsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Ground ginger', 0.25, 'tsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Nutmeg', 0.25, 'tsp')


Insert Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine, ImageFile, PrepTime, CookTime, Serves)
    values ('Spicy Thai Basil Chicken', @user, 
    'My version of this classic Thai dish (Pad Krapow Gai) has spectacular taste even with regular basil instead of Thai or holy basil. The sauce actually acts like a glaze as the chicken mixture cooks over high heat. The recipe works best if you chop or grind your own chicken and have all ingredients prepped before you start cooking.',
    'Whisk chicken broth, oyster sauce, soy sauce, fish sauce, white sugar, and brown sugar together in a bowl until well blended.
    Heat large skillet over high heat. Drizzle in oil. Add chicken and stir fry until it loses its raw color, 2 to 3 minutes. Stir in shallots, garlic, and sliced chilies. Continue cooking on high heat until some of the juices start to caramelize in the bottom of the pan, about 2 or 3 more minutes. Add about a tablespoon of the sauce mixture to the skillet; cook and stir until sauce begins to caramelize, about 1 minute.
    Pour in the rest of the sauce. Cook and stir until sauce has deglazed the bottom of the pan. Continue to cook until sauce glazes onto the meat, 1 or 2 more minutes. Remove from heat.
    Stir in basil. Cook and stir until basil is wilted, about 20 seconds. Serve with rice.',
    'Dinner', 'Thai', 'https://images.media-allrecipes.com/images/75366.jpg?width=420&height=237', 15, 10, 4)
Select @recipe = @@IDENTITY
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Chicken broth', .33, 'cup')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Oyster sauce', 1, 'tbsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Soy sauce', 1, 'tbsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Fish sauce', 2, 'tsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'White sugar', 1, 'tsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Brown sugar', 1, 'tsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Vegetable oil', 2, 'tbsp')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Skinless, boneless chicken thighs, coarsely chopped', 1, 'lb')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Sliced shallots', 0.25, 'cup')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Garlic clove', 4, 'ea')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Thai chiles, minced', 2, 'ea')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Basil leaves, thinly sliced', 1, 'cup')
Insert Ingredient (RecipeId, Name, Quantity, Unit) Values (@recipe, 'Rice, cooked', 2, 'cup')

