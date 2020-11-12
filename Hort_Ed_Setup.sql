CREATE DATABASE HORT_ED;
GO



USE HORT_ED;
CREATE TABLE Kits (

	KitID			INT PRIMARY KEY,
	KitName			NVARCHAR(50) NOT NULL,
	Cost			NVARCHAR(50) NOT NULL,
	Details			NVARCHAR(500) NOT NULL
	)
GO

USE HORT_ED;
CREATE TABLE Seminars (

	SeminarID		NVARCHAR(10) PRIMARY KEY,
	SeminarTitle	NVARCHAR(50) NOT NULL,
	Seasonal		NVARCHAR(50) NOT NULL,
	DeliveryType	NVARCHAR(50) NOT NULL,
	MaterialKit1	INT FOREIGN KEY		REFERENCES Kits(KitID),
	MaterialKit2	INT FOREIGN KEY		REFERENCES Kits(KitID),
	MaterialKit3	INT FOREIGN KEY		REFERENCES Kits(KitID),
	Details			NVARCHAR(500) NOT NULL,
	EventDate		NVARCHAR(15) NOT NULL
	)
GO

USE HORT_ED;
CREATE TABLE Customers (

	CustomerID		INT PRIMARY KEY IDENTITY,
	FirstName		NVARCHAR(50) NOT NULL,
	LastName		NVARCHAR(50) NOT NULL,
	Address1		NVARCHAR(50) NOT NULL,
	Address2		NVARCHAR(50),
	City			NVARCHAR(50) NOT NULL,
	State			NVARCHAR(50) NOT NULL,
	ZipCode			NVARCHAR(20) NOT NULL,
	Phone			NVARCHAR(20),
	EmailAddress	NVARCHAR(50) NOT NULL,
	UserAccountId   NVARCHAR(450) FOREIGN KEY REFERENCES AspNetUsers(Id)
	)
GO

USE HORT_ED;
CREATE TABLE Transactions (

	TransactionID		INT				PRIMARY KEY,
	CustomerID			INT				FOREIGN KEY REFERENCES Customers(CustomerID),
	SeminarID			NVARCHAR(10)	FOREIGN KEY REFERENCES Seminars(SeminarID),
	KitSelection		INT				FOREIGN KEY REFERENCES Kits(KitID),
	ChangeDate			DATETIME,
	ChangeAction		NVARCHAR(100) NOT NULL,
	)
GO

USE HORT_ED;
CREATE TABLE Enrollments (

	EnrollmentID		INT				PRIMARY KEY IDENTITY,
	CustomerID			INT				FOREIGN KEY REFERENCES Customers(CustomerID),
	SeminarID			NVARCHAR(10)	FOREIGN KEY REFERENCES Seminars(SeminarID),
	KitSelection		INT				FOREIGN KEY REFERENCES Kits(KitID),
	EnrollmentDate		DATETIME,
	Notes				NVARCHAR(100)
	)
GO


USE HORT_ED;
INSERT INTO Kits VALUES (0,'Kit Provided','Free','-');
INSERT INTO Kits VALUES (-1,'No Kit Required','-','-');
INSERT INTO Kits VALUES (1,'Fairy Garden #1','$1.00','-');
INSERT INTO Kits VALUES (2,'Fairy Garden #2','$1.00','-');
INSERT INTO Kits VALUES (3,'Fairy Garden #3','$1.00','-');
INSERT INTO Kits VALUES (4,'Container Garden #1','$2.00','-');
INSERT INTO Kits VALUES (5,'Container Garden #2','$2.00','-');
INSERT INTO Kits VALUES (6,'Container Garden #3','$2.00','-');
INSERT INTO Kits VALUES (7,'Planter #1','$3.00','-');
INSERT INTO Kits VALUES (8,'Planter #2','$4.00','-');
INSERT INTO Seminars VALUES ('ES01','Best New Plants for 2021','Early Spring (January-March)','Zoom',-1,-1,-1,'We will highlight the best new annuals, perennials, roses, vegetables, shrubs and trees for 2021. Only those plants with unique new features that are successful in our region make the list. Come see what''s new! ','01/01/2021');
INSERT INTO Seminars VALUES ('ES02','Starting Your Garden from Seed','Early Spring (January-March)','Google Chat',-1,-1,-1,'We will help you plan for the vegetables, herbs, annuals and perennials to start from seed. We will introduce you to new seed varieties, as well as ''tried and true'' and heirloom varieties for your garden! We will share tips for making your seed starting a success.','01/01/2021');
INSERT INTO Seminars VALUES ('ES03','Pruning Trees and Shrubs','Early Spring (January-March)','Zoom',-1,-1,-1,'Pruning is essential to the optimal health of trees and shrubs, but it is feared even by experienced gardeners. Learn how and when to prune your trees, shrubs, and evergreens to get them off to a beautiful start this year.','01/01/2021');
INSERT INTO Seminars VALUES ('ES04','The Joy of Flowers','Early Spring (January-March)','Countryside',0,0,0,'We will cover the joy of having fresh cut flowers in your home.  During this demonstration you will see 4 different floral designs created before your eyes.','01/01/2021');
INSERT INTO Seminars VALUES ('ES05','Creating Your Own Fairy Garden','Early Spring (January-March)','Hands-On Workshop / Grayslake Library',1,2,3,'Time to get creative and have fun! We''ll show you how to combine miniature plants, whimsical creatures, and accessories to create a potted fairy garden.  ','01/01/2021');
INSERT INTO Seminars VALUES ('ES06','Create an Early Spring Container Garden','Early Spring (January-March)','Zoom',4,5,0,'Why wait until summer when you can fill your containers with cool season annuals in March and April? We’ll show you some great combinations to brighten up your pots.','01/01/2021');
INSERT INTO Seminars VALUES ('ES07','Get Your Garden Ready for Spring','Early Spring (January-March)','Google Chat',-1,-1,-1,'Come learn the best ways to prepare your garden for the season. We’ll share valuable time-saving tips and sustainable techniques to start your garden on the right path this year.','01/01/2021');
INSERT INTO Seminars VALUES ('LS01','Great Combinations for Container Gardens ','Late Spring (April/May)','Zoom',-1,-1,-1,'Find out what’s hot in pots. We combine unusual plants for fresh looks for both sun and shade. Annuals, perennials, tropicals, edibles - even trees and shrubs - you won''t look at plant combinations the same again. ','01/01/2021');
INSERT INTO Seminars VALUES ('LS02','Growing Vegetables','Late Spring (April/May)','Countryside',0,0,0,'From planning to planting, get tips for crop rotation, planting schedules and succession planting for maximum production. We will also share our favorite vegetable varieties that are best suited for our climate.','01/01/2021');
INSERT INTO Seminars VALUES ('LS03','Attracting Birds and Butterflies to Your Garden','Late Spring (April/May)','Grayslake Library',-1,-1,-1,'Want to create a natural habitat to attract birds and butterflies to your garden? We’ll share advice for designing the garden and the best plants to use.  Good nectar sources for butterflies and food plants for their caterpillars will be covered. Preferred habitats for local birds will also be included.','01/01/2021');
INSERT INTO Seminars VALUES ('LS04','Creating an Blooming Garden in a Basket','Late Spring (April/May)','Hand-On Workshop / Zoom',5,6,0,'We will show you how to combine potted blooming and foliage plants to create a variety of indoor English gardens. Perfect as a gift or for yourself! ','01/01/2021');
INSERT INTO Seminars VALUES ('LS05','Growing Fantastic Fruits ','Late Spring (April/May)','Google Chat',-1,-1,-1,'You don’t need an orchard-sized property to grow your own fruit. Find out which fruits and berries are best suited to our area and learn the secrets to growing fresh fruit in your backyard.','01/01/2021');
INSERT INTO Seminars VALUES ('LS06','Landscape Design 101: From Planning to Planting','Late Spring (April/May)','Zoom',-1,-1,-1,'Does your yard need an update? Wondering how to put together a plan? We’ll share the key principles for creating a landscape that fits your needs.','01/01/2021');
INSERT INTO Seminars VALUES ('SU01','Edible Landscaping','Summer (June-August)','Countryside',0,0,0,'Growing our own food has become more popular and we are all anxious to grow tasty fruits, vegetables and herbs. This program shares how to take edible gardening to the next level by incorporating edible plants into your landscape and containers for the beauty of the plants and the bounty of the harvest.','01/01/2021');
INSERT INTO Seminars VALUES ('SU02','Growing Beautiful Roses Easily','Summer (June-August)','Grayslake Library',-1,-1,-1,'You will learn the about selecting, growing, and maintaining the most hardy, disease-resistant, pest-free roses that are easily grown in our area. We will discuss types of roses, and the best varieties for our area.','01/01/2021');
INSERT INTO Seminars VALUES ('SU03','Gardening in the Shade','Summer (June-August)','Zoom',-1,-1,-1,'We will highlight shade-loving plants that work well and look great in your home garden. We will go beyond the most common shade plants and give you new options for those shady places in your landscape. Learn to grow your own garden of ''shady characters.''','01/01/2021');
INSERT INTO Seminars VALUES ('SU04','Growing and Using Herbs','Summer (June-August)','Google Chat',-1,-1,-1,'Ready to grow your own herbs? Come see, touch, smell, and taste the top culinary herbs. You will learn how to grow, harvest, and cook with the herbs that great cooks use the most.','01/01/2021');
INSERT INTO Seminars VALUES ('SU05','Tropical Plants ','Summer (June-August)','Zoom',-1,-1,-1,'Give your garden that tropical look and feel. Tropical plants with their bold colors and unique forms create impact, add style, and brighten the mood of any garden.','01/01/2021');
INSERT INTO Seminars VALUES ('SU06','Sensational Shrubs ','Summer (June-August)','Countryside',0,0,0,'We will help you discover a wide range of shrubs to choose from for your landscape. We will highlight features such as flowers, foliage, texture, form, wildlife interest, fall color, bark, and showy fruits. ','01/01/2021');
INSERT INTO Seminars VALUES ('SU07','Ornamental Grasses','Summer (June-August)','Grayslake Library',-1,-1,-1,'Grasses can offer color, form, and texture in any garden or container. We will show you some of the most interesting grasses and share how they have been successfully used in the landscape. ','01/01/2021');
INSERT INTO Seminars VALUES ('SU08','Long-Blooming Perennials','Summer (June-August)','Zoom',-1,-1,-1,'You will learn how to select plants that have a long-bloom time and partner well together. Create a visually striking and harmonious look for your garden using color, texture, height, and bloom!','01/01/2021');
INSERT INTO Seminars VALUES ('SU09','Going Vertical; Using Vines in the Garden','Summer (June-August)','Google Chat',-1,-1,-1,'There are many different climbing plants. How do you choose the best vine for your situation? What makes them unique? How to care for them? We will highlight the characteristics and culture of various perennial vines from clematis to trumpet vines. Vine varieties for sun and part shade will be showcased for their foliage and blooms. ','01/01/2021');
INSERT INTO Seminars VALUES ('FA01','Using Native Plants in the Landscape','Fall (September/October)','Zoom',-1,-1,-1,'If you are interested in using Illinois native plants in your landscape but aren''t sure where to start, we’ll show you how. We will talk about plants that work well in our soils and weather, while providing natural beauty unique to our region.','01/01/2021');
INSERT INTO Seminars VALUES ('FA02','Adding Fall Color to Your Garden ','Fall (September/October)','Countryside',0,0,0,'Autumn can bring a wide range of colors to your landscape, and not just from shade trees. Learn about shrubs, perennials, and annuals that can spice up your garden with their fall color. ','01/01/2021');
INSERT INTO Seminars VALUES ('FA03','Updating Your Containers for Fall','Fall (September/October)','Grayslake Library',-1,-1,-1,'Do your containers need some freshening up for fall? We’ll show some new combinations of warm colors and unique textures for fall. Come see how to fill your containers with overflowing fall beauty.','01/01/2021');
INSERT INTO Seminars VALUES ('FA04','Spring-Blooming Bulbs','Fall (September/October)','Zoom',-1,-1,-1,'Be inspired by wide array of colors, forms, and fragrances of spring bulbs. Learn how you can create a stunning bulb display in your home landscape, along with selection and maintenance tips.','01/01/2021');
INSERT INTO Seminars VALUES ('FA05','It’s Not Too Late to Plant Perennials!','Fall (September/October)','Google Chat',-1,-1,-1,'As the nights get cooler and  Indian Summer sets in , we will share tips for selecting and establishing perennials to be planted in the fall. Many varieties of fall-blooming perennials will also be highlighted for both sun and shade. ','01/01/2021');
INSERT INTO Seminars VALUES ('FA06','Dress up your Home for Autumn ','Fall (September/October)','Zoom',-1,-1,-1,'Just in time for Halloween and fall entertaining, we will share ideas for decorating your home inside and out  with live plants. Fall annuals and unique indoor plants will be shown in seasonal containers with whimsical touches for the fall holidays.','01/01/2021');
INSERT INTO Seminars VALUES ('FA07','Creating Focal Points in Your Garden','Fall (September/October)','Countryside',0,0,0,'Basic design principles for incorporating furniture, structures, statuary and fountains into the garden will be shared. Sample designs for creating plantings around these features will be shared to enhance outdoor living.','01/01/2021');
INSERT INTO Seminars VALUES ('HO01','Make Your Own Holiday Planter','Holiday (November/December)','Hands-On Workshop / Grayslake Library',7,8,0,'We’ll show everything you need to know to create long-lasting planters with greens, berries and twigs for the winter season.','01/01/2021');
INSERT INTO Seminars VALUES ('HO02','Decorating Wreathes','Holiday (November/December)','Zoom',-1,-1,-1,'We will demonstrate how to embellish your live or artificial wreathes with berries, cones, greens, ornaments and ribbons to create unique decorations for your home indoors or out.','01/01/2021');
INSERT INTO Seminars VALUES ('HO03','Landscape Design 101: From Planning to Planting','Holiday (November/December)','Google Chat',-1,-1,-1,'Does your yard need an update? Wondering how to put together a plan? We’ll share the key principles for creating a landscape that fits your needs.','01/01/2021');
INSERT INTO Seminars VALUES ('HO04','Creating Gardens with Winter Interest','Holiday (November/December)','Zoom',-1,-1,-1,'Want a landscape with four-season interest? We will highlight outstanding plants and garden features for winter interest in the home garden. ','01/01/2021');
INSERT INTO Seminars VALUES ('HO05','Preparing Your Garden for Fall and Winter','Holiday (November/December)','Countryside',0,0,0,'Various techniques for pruning, mulching,  and cleaning up the fall garden will be shared This session will help boost the gardener’s success in over wintering their plants while still have an attractive garden space over the winter.','01/01/2021');
INSERT INTO Seminars VALUES ('HO06','Festive Holiday Plants','Holiday (November/December)','Grayslake Library',-1,-1,-1,'Want to fill your home with blooming plants for the holidays? How about filling your containers outdoors with cut evergreens, berries, and branches? We will highlight a wide variety of ways to add color, texture and fragrance to your home in winter. ','01/01/2021');
GO


