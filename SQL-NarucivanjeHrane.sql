CREATE TABLE Restaurant
(
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	RestaurantName NVARCHAR(50) NOT NULL,
	Address nvarchar(100) not null,
	PhoneNumber INT not null,
	DeliveryPrice INT NOT NULL


);

CREATE TABLE Food
(
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	NameOfTheFood nvarchar(max) not null,
	Description nvarchar(max) null,
	Price INT not null,
	AverageScore FLOAT NULL,
	RestaurantID INT FOREIGN KEY REFERENCES Restaurant(ID),
	UserID int FOREIGN KEY REFERENCES Person(ID)
);

CREATE TABLE Score
(
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	ReviewScore INT NOT NULL,
	PersonID INT FOREIGN KEY REFERENCES Person(ID),
	FoodID INT FOREIGN KEY REFERENCES Food(ID)
);


CREATE TABLE Person
(
	ID INT PRIMARY KEY IDENTITY NOT NULL, 
	[First name] nvarchar(100) not null,
	[Last name] nvarchar(100) not null,
	UserID nvarchar(max),
	RestaurantVote INT FOREIGN KEY REFERENCES Restaurant(ID)

);



CREATE TABLE [Order]
(
	ID INT PRIMARY KEY IDENTITY NOT NULL, 
	FoodId INT FOREIGN KEY REFERENCES Food(ID),
	PersonID INT FOREIGN KEY REFERENCES Person(ID)

);

INSERT INTO Food
(NameOfTheFood, Description,Price,RestaurantID)
values
('PRIMAVERA','kečap,mozzarela,kukuruz, parmezan,crne i zelene masline (mala)',26,1),
('PRIMAVERA','kečap,mozzarela,kukuruz, parmezan,crne i zelene masline (velika)',35,1),
('VEGETARIJANA','kečap,kukuruz, feta sir,svježa paprika,svježa rajčica i cherry rajčica (mala)',26,1),
('VEGETARIJANA','kečap,kukuruz, feta sir,svježa paprika,svježa rajčica i cherry rajčica (velika)',35,1),
('SEBASTIAN','kečap, sir,gljive,artičoke,šparoge,paprika,masline (mala)',30,1),
('SEBASTIAN','kečap, sir,gljive,artičoke,šparoge,paprika,masline (velika)',38,1),
('FRUTTI DI MARE','kečap, sir,plodovi mora (mala)',30,1),
('FRUTTI DI MARE','kečap, sir,plodovi mora (velika)',38,1),
('POVRTNA','kečap, sir,svježa rajčica,svježa paprika,rikola,feta sir,cne i zelene masline (mala)',30,1),
('POVRTNA','kečap, sir,svježa rajčica,svježa paprika,rikola,feta sir,cne i zelene masline (velika)',38,1),
('MORNARSKA','kečap, sir,gljive,sardine,račići,školjke (mala)',30,1),
('MORNARSKA','kečap, sir,gljive,sardine,račići,školjke (velika)',38,1),
('BIJELA PIZZA','kečap,mozzarela,losos,rakovi (mala)',32,1),
('BIJELA PIZZA','kečap,mozzarela,losos,rakovi (velika)',42,1);


INSERT INTO Food
(NameOfTheFood, Description,Price,RestaurantID)
values
('Ćevapi u lepinji','veliki',29,2),
('Ćevapi u lepinji','mali',19,2),
('Pljeskavica u lepinji','velika',25,2),
('Piletina u lepinji','pileći batak i zabatak sa žara',25,2),
('Punjena pljeskavica','pommes, suhi vrat, gauda, lepinjice',34,2),
('Ražnjići ','svinjetina, pekarski krompir, luk, lepinjice',29,2),
('Ražnjići "Lipov hlad"','svinjetina, pekarski krompir, povrće, slanina, lepinjice',35,2),
('Pileće mješano meso','file - žar, ražnjić, panirani odrezak, zabatak, đuveđ - riža, limun, tartar, lepinjice',38,2),
('Pileći ražnjići','pommes, luk, lepinjice',29,2),
('Mješano meso','svinjski vrat, slanina, ražnjić, pljeskavica, roštilj kobasica, ćevapi, pekarski krompir, gljive, ajvar, lepinjice',48,2),
('Mesni uštipci','mljeveno meso, sir, suhi vrat, luk, lepinja',30,2),
('Plata za dvoje','ćevapi, punjena pljeskavica, ražnjić, panirani odrezak, pileći zabatak, pekarski krompir, đuveđ - riža, lepinjice',88,2),
('Zapečeni grah','slanina, lepinjice',26,2),
('Marinirani svinjski vrat','(pommes, luk, lepinjice',30,2),
('Škarpina na žaru','limun, maslinovo ulje, češnjak, pommes, tartar, lepinjice',35,2),
('Lignje na žaru','pommes, lepinjice, tartar',32,2),
('Panirani oslić','pommes, lepinjice, majoneza',32,2);




INSERT INTO Food
(NameOfTheFood, Description,Price,RestaurantID)
values
('Ćevapi','standardni',27,3),
('ĆEVAPI + POMMES FRITES','standardni',33,3),
('RAŽNJIĆI + POMMES FRITES','standardni',33,3),
('PLJESKAVICA','standardna',23,3),
('PLJESKAVICA + POMMES FRITES','standardna',33,3),
('PLJESKAVICA SA SIROM','standardna',33,3),
('PIKANTNA PUNJENA PLJESKAVICA + POMMES FRITES','pljeskavica punjena svježim sirom, svježom paprikom, crveni luk, kulen, lepinja',44,3),
('MJEŠANO MESO (malo) + POMMES FRITES','ražnjići, ćevapi, šnicla, roštilj, kobasica, lepinja',38,3),
('MJEŠANO MESO + POMMES FRITES','ražnjići, kotlet, punjena šnicla, pileći filet, ćevapi, roštilj kobasica, lepinja',52,3),
('VESELI SLAVONAC + POMMES FRITES','šnicla punjena šunkom i sirom pečena na roštilju',41,3),
('ŠUMSKI ODREZAK + KROKETI','šnicla punjena kulenom i sirom, lovački umak',49,3),
('CIGANSKI RAŽNJIĆI + POMMES FRITES','svinjski ražnjići, šampinjoni, povrće, slanina',41,3),
('PILEĆI MEDALJONI + KRUMPIR PIRE','pileći file omotan slaninom, umak od šampinjona',49,3),
('PUNJENA PILETINA + POMMES FRITES','pileći file punjen suhim vratom, kulenom i slaninom',49,3),
('PILEĆI RAŽNJIĆI','pileći filet, paprika, slanina, tagliatele u ajvar umaku',49,3),
('GLJIVE NA ŽARU + POMMES FRITES','standard',30,3),
('Palačinke s orasima','standard',15,3),
('Palačinke s čokoladom','standard',15,3),
('Palačinke s marmeladom','standard',15,3),
('Palačinke Saloon','standard',20,3);


INSERT INTO Food
(NameOfTheFood, Description,Price,RestaurantID)
values
('PANIRANI OSLIC','lepinjice,pommes,tartar,limun',30,4),
('PANIRANI SIR','lepinjice,pommes,tartar,limun',28,4),
('PANIRANI ŠAMPINJONI','lepinjice,pommes,tartar,limun',27,4),
('PUNJENA PILETINA','lepinjice,pommes,tartar,limun,sir,šunka',36,4),
('BECKI ODREZAK','lepinjice,pommes,tartar umak,svinjetina',33,4),
('OLIVA ODREZAK','lepinjice,pommes,ajvar,luk,svinjetina,svježi sir,kulen',37,4),
('ZAGREBACKI ODREZAK','lepinjice,pommes,tartar umak,svinjetina,sir,šunka',37,4),
('RISOTTO CON SCAMPI','standard',32,4),
('RIŽOTO OD GLJIVA','standard',32,4),
('RIŽOTO FRUTTI DI MARE','standard',32,4),
('RIŽOTO VEGETARIJANSKI','standard',32,4),
('RIŽOTO OD PILETINE','standard',32,4),
('TORTILJE S MLJEVENIM MESOM','umak od rajčice,paprika,kukuruz,sir,rikola,mex začini',31,4),
('TORTILJE S PILETINOM','umak od rajčice,paprika,kukuruz,sir,svježa rajčica,zelena salata,mex začini',31,4),
('PILECI RAŽNJIĆI S POVRCEM','lepinjice,luk,ajvar,pommes',33,4),
('PILECI RAŽNJIĆI SA SLANINOM I POVRCEM','lepinjice,luk,ajvar,pommes',37,4),
('PLJESKAVICA','lepinjice,pommes,luk,ajvar',30,4),
('PUNJENA PLJESKAVICA','šunka,sir,lepinjice,pommes,luk,ajvar',36,4),
('ROŠTILJ KOBASICE','lepinjice,pommes,luk,ajvar',28,4),
('ROLOVANA PILETINA','lepinjice, curry riža,suhi vrat,svježi sir,paprika,patliđan,tikvice,urnebes umak',36,4);



