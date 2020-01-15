using System;

namespace VariableNaming
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1. 4 birds are sitting on a branch. 1 flies away. How many birds are left on
            the branch?
            */

            // ### EXAMPLE:
            int initialNumberOfBirds = 4;
            int birdsThatFlewAway = 1;
            int remainingNumberOfBirds = initialNumberOfBirds - birdsThatFlewAway;

            /*
            2. There are 6 birds and 3 nests. How many more birds are there than
            nests?
            */

            // ### EXAMPLE:
            int numberOfBirds = 6;
            int numberOfNests = 3;
            int numberOfExtraBirds = numberOfBirds - numberOfNests;



            /*
            3. 3 raccoons are playing in the woods. 2 go home to eat dinner. How
            many raccoons are left in the woods?
            */
            int numberOfRaccoons = 3;
            int raccoonsGoingHome = 2;
            int remainingRaccoons = numberOfRaccoons - raccoonsGoingHome;
            Console.WriteLine(remainingRaccoons);

            /*
            4. There are 5 flowers and 3 bees. How many less bees than flowers?
            */
            int flowers = 5;
            int bees = 3;
            int flowerBeeGap = flowers - bees;
            Console.WriteLine(flowerBeeGap);

            /*
            5. 1 lonely pigeon was eating breadcrumbs. Another pigeon came to eat
            breadcrumbs, too. How many pigeons are eating breadcrumbs now?
            */
            int lonelyPigeon = 1;
            lonelyPigeon = lonelyPigeon + 1;
            Console.WriteLine(lonelyPigeon);

            /*
             * 6. 3 owls were sitting on the fence. 2 more owls joined them. How many
             * owls are on the fence now?
             */
            int fenceOwls = 3;
            fenceOwls = fenceOwls + 2;
            Console.WriteLine(fenceOwls);


            /*
            7. 2 beavers were working on their home. 1 went for a swim. How many
            beavers are still working on their home?
            */
            int beavers = 2;
            beavers = beavers - 1;
            Console.WriteLine(beavers);

            /*
            8. 2 toucans are sitting on a tree limb. 1 more toucan joins them. How
            many toucans in all?
            */
            int toucans = 2;
            toucans = toucans + 1;
            Console.WriteLine(toucans);


            /*
            9. There are 4 squirrels in a tree with 2 nuts. How many more squirrels
            are there than nuts?
            */
            int squirrels = 4;
            int nuts = 2;
            int squirrelNutGap = squirrels - nuts;
            Console.WriteLine(squirrelNutGap);

            /*
            10. Mrs. Hilt found a quarter, 1 dime, and 2 nickels. How much money did
            she find?
            */
            int quarters = 25;
            int dimes = 10;
            int nickels = 5;
            int totalMoney = quarters + dimes + (2 * nickels);
            Console.WriteLine(totalMoney);

            /*
            11. Mrs. Hilt's favorite first grade classes are baking muffins. Mrs. Brier's
            class bakes 18 muffins, Mrs. MacAdams's class bakes 20 muffins, and
            Mrs. Flannery's class bakes 17 muffins. How many muffins does first
            grade bake in all?
            */
            int muffinBrier = 18;
            int muffinMacAdams = 20;
            int muffinFlannery = 17;
            int muffinTotal = muffinBrier + muffinMacAdams + muffinFlannery;
            Console.WriteLine(muffinTotal);

            /*
            12. Mrs. Hilt bought a yoyo for 24 cents and a whistle for 14 cents. How
            much did she spend in all for the two toys?
            */
            int hiltYoyo = 24;
            int hiltWhistle = 14;
            int hiltTotal = hiltYoyo + hiltWhistle;
            Console.WriteLine(hiltTotal);

            /*
            13. Mrs. Hilt made 5 Rice Krispie Treats. She used 8 large marshmallows
            and 10 mini marshmallows.How many marshmallows did she use
            altogether?
            */

            int lgMarshmallow = 8;
            int smMarshmallow = 10;
            int totalMarshmallow = lgMarshmallow + smMarshmallow;
            Console.WriteLine(totalMarshmallow);

            /*
            14. At Mrs. Hilt's house, there was 29 inches of snow, and Brecknock
            Elementary School received 17 inches of snow. How much more snow
            did Mrs. Hilt's house have?
            */

            int snowHilt = 29;
            int snowBrecknock = 17;
            int snowDiff = snowHilt - snowBrecknock;
            Console.WriteLine(snowDiff);

            /*
            15. Mrs. Hilt has $10. She spends $3 on a toy truck and $2 on a pencil
            case. How much money does she have left?
            */
            int walletHilt = 10;
            int costTruck = 3;
            int costPencil = 2;
            walletHilt = walletHilt - costTruck - costPencil;
            Console.WriteLine(walletHilt);

            /*
            16. Josh had 16 marbles in his collection. He lost 7 marbles. How many
            marbles does he have now?
            */

            int marblesJosh = 16;
            int marblesLost = 7;
            int marblesLeft = marblesJosh - marblesLost;
            Console.WriteLine(marblesLost);

            /*
            17. Megan has 19 seashells. How many more seashells does she need to
            find to have 25 seashells in her collection?
            */
            int shellsMegan = 19;
            int shellsNeeded = 25 - shellsMegan;
            Console.WriteLine(shellsNeeded);

            /*
            18. Brad has 17 balloons. 8 balloons are red and the rest are green. How
            many green balloons does Brad have?
            */
            int balloonsBrad = 17;
            int balloonsRed = 8;
            int balloonsGreen = balloonsBrad - balloonsRed;
            Console.WriteLine(balloonsGreen);

            /*
            19. There are 38 books on the shelf. Marta put 10 more books on the shelf.
            How many books are on the shelf now?
            */
            int booksShelf = 38;
            int booksAdded = 10;
            int booksTotal = booksShelf + booksAdded;
            Console.WriteLine(booksTotal);


            /*
            20. A bee has 6 legs. How many legs do 8 bees have?
            */
            int legsBee = 6;
            int totalLegs = legsBee * 6;
            Console.WriteLine(totalLegs);

            /*
            21. Mrs. Hilt bought an ice cream cone for 99 cents. How much would 2 ice
            cream cones cost?
            */
            int coneCost = 99;
            int coneHilt = coneCost * 2;
            Console.WriteLine(coneHilt);

            /*
            22. Mrs. Hilt wants to make a border around her garden. She needs 125
            rocks to complete the border. She has 64 rocks. How many more rocks
            does she need to complete the border?
            */
            int rocksTotal = 125;
            int rocksHas = 64;
            int rocksNeeded = rocksTotal - rocksHas;
            Console.WriteLine(rocksNeeded);

            /*
            23. Mrs. Hilt had 38 marbles. She lost 15 of them. How many marbles does
            she have left?
            */
            int marblesHilt = 38;
            int marblesHiltLost = 15;
            int marblesHiltLeft = marblesHilt - marblesHiltLost;
            Console.WriteLine(marblesHiltLeft);

            /*
            24. Mrs. Hilt and her sister drove to a concert 78 miles away. They drove 32
            miles and then stopped for gas. How many miles did they have left to drive?
            */
            int distanceTotal = 78;
            int distanceDriven = 32;
            int distanceRemaining = distanceTotal - distanceDriven;
            Console.WriteLine(distanceRemaining);

            /*
            25. Mrs. Hilt spent 1 hour and 30 minutes shoveling snow on Saturday
            morning and 45 minutes shoveling snow on Saturday afternoon. How
            much total time did she spend shoveling snow?
            */
            int snowSatMorn = 90;
            int snowSatAft = 45;
            int snowSatTot = snowSatMorn + snowSatAft;
            Console.WriteLine(snowSatTot);

            /*
            26. Mrs. Hilt bought 6 hot dogs. Each hot dog cost 50 cents. How much
            money did she pay for all of the hot dogs?
            */
            double hotdogCost = 0.5;
            double totalCost = hotdogCost * 6;
            Console.WriteLine(totalCost);

            /*
            27. Mrs. Hilt has 50 cents. A pencil costs 7 cents. How many pencils can
            she buy with the money she has?
            */
            int pencilCost = 7;
            int totalPencils = 50 / pencilCost;
            Console.WriteLine(totalPencils);


            /*
            28. Mrs. Hilt saw 33 butterflies. Some of the butterflies were red and others
            were orange. If 20 of the butterflies were orange, how many of them
            were red?
            */
            int butterfliesTotal = 33;
            int butterfliesOrange = 20;
            int butterfliesRed = butterfliesTotal - butterfliesOrange;
            Console.WriteLine(butterfliesRed);

            /*
            29. Kate gave the clerk $1.00. Her candy cost 54 cents. How much change
            should Kate get back?
            */
            double kateDollar = 1.00;
            double kateCost = 0.54;
            double kateChange = kateDollar - kateCost;
            Console.WriteLine(kateChange);

            /*
            30. Mark has 13 trees in his backyard. If he plants 12 more, how many trees
            will he have?
            */
            int treesMark = 13;
            int treesPlanted = 12;
            int treesTotal = treesMark + treesPlanted;
            Console.WriteLine(treesTotal);

            /*
            31. Joy will see her grandma in two days. How many hours until she sees
            her?
            */
            int hoursDay = 24;
            int numberOfDays = 2;
            int hoursUntilGrandma = hoursDay * numberOfDays;
            Console.WriteLine(hoursUntilGrandma);

            /*
            32. Kim has 4 cousins. She wants to give each one 5 pieces of gum. How
            much gum will she need?
            */
            int kimCousins = 4;
            int gumEach = 5;
            int gumNeeded = kimCousins * gumEach;
            Console.WriteLine(gumNeeded);

            /*
            33. Dan has $3.00. He bought a candy bar for $1.00. How much money is
            left?
            */
            int danDollars = 3;
            int candyBarCost = 1;
            int danChange = danDollars - candyBarCost;
            Console.WriteLine(danChange);

            /*
            34. 5 boats are in the lake. Each boat has 3 people. How many people are
            on boats in the lake?
            */
            int boatsTotal = 5;
            int boatsEach = 3;
            int peopleTotal = boatsTotal * boatsEach;
            Console.WriteLine(peopleTotal);

            /*
            35. Ellen had 380 legos, but she lost 57 of them. How many legos does she
            have now?
            */
            int legosTotal = 380;
            int legosLost = 57;
            int legosRemaining = legosTotal - legosLost;
            Console.WriteLine(legosRemaining);

            /*
            36. Arthur baked 35 muffins. How many more muffins does Arthur have to
            bake to have 83 muffins?
            */

            int muffinsBaked = 35;
            int muffinsNeeded = 83;
            int muffinsLeft = muffinsNeeded - muffinsBaked;
            Console.WriteLine(muffinsLeft);

            /*
            37. Willy has 1400 crayons. Lucy has 290 crayons. How many more
            crayons does Willy have then Lucy?
            */
            int crayonsWilly = 1400;
            int crayonsLucy = 290;
            int crayonsDeficiency = crayonsWilly - crayonsLucy;
            Console.WriteLine(crayonsDeficiency);


            /*
            38. There are 10 stickers on a page. If you have 22 pages of stickers, how
            many stickers do you have?
            */
            int stickersPerPage = 22;
            int numberOfPages = 10;
            int stickersTotal = numberOfPages * stickersPerPage;
            Console.WriteLine(stickersTotal);

            /*
            39. There are 96 cupcakes for 8 children to share. How much will each
            person get if they share the cupcakes equally?
            */
            int cupcakesTotal = 96;
            int numberOfChildren = 8;
            int cupcakesEach = cupcakesTotal / numberOfChildren;
            Console.WriteLine(cupcakesEach);

            /*
            40. She made 47 gingerbread cookies which she will distribute equally in
            tiny glass jars. If each jar is to contain six cookies each, how many
            cookies will not be placed in a jar?
            */
            int cookiesTotal = 47;
            int cookiesPerJar = 6;
            int cookiesRemainder = cookiesTotal % cookiesPerJar;
            Console.WriteLine(cookiesRemainder);

            /*
            41. She also prepared 59 croissants which she plans to give to her 8
            neighbors. If each neighbor received and equal number of croissants,
            how many will be left with Marian?
            */
            int crossaintsTotal = 59;
            int crossaintsNeighbors = 8;
            int crossaintsLeft = crossaintsTotal % crossaintsNeighbors;
            Console.WriteLine(crossaintsLeft);

            /*
            42. Marian also baked oatmeal cookies for her classmates. If she can
            place 12 cookies on a tray at a time, how many trays will she need to
            prepare 276 oatmeal cookies at a time?
            */
            int oatmealTotal = 276;
            int oatmealPerTray = 12;
            int traysNeeded = oatmealTotal / oatmealPerTray;
            Console.WriteLine(traysNeeded);

            /*
            43. Marian’s friends were coming over that afternoon so she made 480
            bite-sized pretzels. If one serving is equal to 12 pretzels, how many
            servings of bite-sized pretzels was Marian able to prepare?
            */
            int pretzelTotal = 480;
            int pretzelServing = 12;
            int totalServings = pretzelTotal / pretzelServing;
            Console.WriteLine(totalServings);

            /*
            44. Lastly, she baked 53 lemon cupcakes for the children living in the city
            orphanage. If two lemon cupcakes were left at home, how many
            boxes with 3 lemon cupcakes each were given away?
            */
            int lemonTotal = 53;
            int lemonLeftAtHome = 2;
            int lemonPerBox = 3;
            int lemonBoxes = (lemonTotal - lemonLeftAtHome) / lemonPerBox;
            Console.WriteLine(lemonBoxes);

            /*
            45. Susie's mom prepared 74 carrot sticks for breakfast. If the carrots
            were served equally to 12 people, how many carrot sticks were left
            uneaten?
            */
            int carrotTotal = 74;
            int peopleCarrotTotal = 12;
            int carrotRemaining = carrotTotal % peopleCarrotTotal;
            Console.WriteLine(carrotRemaining);

            /*
            46. Susie and her sister gathered all 98 of their teddy bears and placed
            them on the shelves in their bedroom. If every shelf can carry a
            maximum of 7 teddy bears, how many shelves will be filled?
            */
            int teddyTotal = 98;
            int teddyShelfMax = 7;
            int shelvesNeeded = teddyTotal / teddyShelfMax;
            Console.WriteLine(shelvesNeeded);

            /*
            47. Susie’s mother collected all family pictures and wanted to place all of
            them in an album. If an album can contain 20 pictures, how many
            albums will she need if there are 480 pictures?
            */
            int picsTotal = 480;
            int albumCapacity = 20;
            int albumsNeeded = picsTotal / albumCapacity;
            Console.WriteLine(albumsNeeded);

            /*
            48. Joe, Susie’s brother, collected all 94 trading cards scattered in his
            room and placed them in boxes. If a full box can hold a maximum of 8
            cards, how many boxes were filled and how many cards are there in
            the unfilled box?
            */
            int cardsTotal = 94;
            int cardsPerBox = 8;
            int boxesFilled = cardsTotal / cardsPerBox;
            int cardsRemaining = cardsTotal % cardsPerBox;
            Console.WriteLine(boxesFilled);
            Console.WriteLine(cardsRemaining);

            /*
            49. Susie’s father repaired the bookshelves in the reading room. If he has
            210 books to be distributed equally on the 10 shelves he repaired,
            how many books will each shelf contain?
            */
            int booksInTotal = 210;
            int shelvesTotal = 10;
            int shelvesEach = booksInTotal / shelvesTotal;
            Console.WriteLine(shelvesEach);

            /*
            50. Cristina baked 17 croissants. If she planned to serve this equally to
            her seven guests, how many will each have?
            */
            int crossaintCrisTotal = 17;
            int guestsTotal = 7;
            int crossaintPerGuest = crossaintCrisTotal / guestsTotal;
            Console.WriteLine(crossaintPerGuest);

            /*
                CHALLENGE PROBLEMS
            */

            /*
            Bill and Jill are house painters. Bill can paint a 12 x 14 room in 2.15 hours, while Jill averages
            1.90 hours. How long will it take the two painter working together to paint 5 12 x 14 rooms?
            Hint: Calculate the hourly rate for each painter, combine them, and then divide the total walls in feet by the combined hourly rate of the painters.
            Challenge: How many days will it take the pair to paint 623 rooms assuming they work 8 hours a day?.
            */

            int feetPerRoom = (12 + 14) * 2;
            double feetPerHourBill = feetPerRoom / 2.15;
            double feetPerHourJill = feetPerRoom / 1.90;
            double combinedFeetPerHour = feetPerHourBill + feetPerHourJill;
            int rooms = 5;
            int totalFeet = feetPerRoom * rooms;
            double fiveRoomTime = feetPerRoom / combinedFeetPerHour;
            Console.WriteLine("Days to paint 5 rooms");
            Console.WriteLine(fiveRoomTime);

            rooms = 623;
            totalFeet = feetPerRoom * rooms;
            double timeToPaintAll = totalFeet / combinedFeetPerHour;
            double daysToPaint623 = timeToPaintAll / 8;
            Console.WriteLine("Days to paint 623 rooms");
            Console.WriteLine(daysToPaint623);


            
                       
            /*
            Create and assign variables to hold your first name, last name, and middle initial. Using concatenation,
            build an additional variable to hold your full name in the order of last name, first name, middle initial. The
            last and first names should be separated by a comma followed by a space, and the middle initial must end
            with a period.
            Example: "Hopper, Grace B."
            */
            string firstName = "Rob ";
            string middleInitial = "G.";
            string lastName = "Rosin, ";
            string lastFirstMiddle = lastName + firstName + middleInitial;
            Console.WriteLine(lastFirstMiddle);

            /*
            The distance between New York and Chicago is 800 miles, and the train has already travelled 537 miles.
            What percentage of the trip has been completed?
            Hint: The percent completed is the miles already travelled divided by the total miles.
            Challenge: Display as an integer value between 0 and 100 using casts.
            */

            int tripTotal = 800;
            int tripTravelled = 537;
            double tripLeft = tripTotal - tripTravelled;
            double tripPercent = tripLeft / tripTotal;
            int tripPercentInt = (int)(tripPercent * 100);
            Console.WriteLine(tripPercentInt);



        }
    }
}
