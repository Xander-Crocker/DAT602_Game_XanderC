DROP DATABASE IF EXISTS DAT602_A1_XanderC_2024;
CREATE DATABASE DAT602_A1_XanderC_2024;
USE DAT602_A1_XanderC_2024;

DROP PROCEDURE IF EXISTS create_insert_tables;
DELIMITER // 
CREATE PROCEDURE create_insert_tables()
BEGIN

	DROP TABLE IF EXISTS `playerTable`;
    DROP TABLE IF EXISTS `gameTable`;
	DROP TABLE IF EXISTS `boardTable`;
	DROP TABLE IF EXISTS `sessionTable`;
    DROP TABLE IF EXISTS `itemTypeTable`;
    DROP TABLE IF EXISTS `boardTileTable`;
    
	CREATE TABLE `playerTable` (
		`playerID` INT NOT NULL AUTO_INCREMENT,
        `email` VARCHAR(50) DEFAULT NULL,
		`username` VARCHAR(50) DEFAULT NULL,
		`password` VARCHAR(50) DEFAULT NULL,
		`lockedUser` BOOLEAN DEFAULT FALSE,
		`adminUser` BOOLEAN DEFAULT FALSE,
        `onlineStatus` BOOLEAN DEFAULT FALSE,
		PRIMARY KEY (`playerID`)
	);
    
    CREATE TABLE `gameTable` (
		`gameID` INT NOT NULL AUTO_INCREMENT,
        `gameStatus` BOOLEAN DEFAULT FALSE,
        PRIMARY KEY (`gameID`)
    );
    
    CREATE TABLE `boardTable` (
		`boardID` INT NOT NULL AUTO_INCREMENT,
        `gameID` INT NOT NULL,
        `boardNumber` INT,
        PRIMARY KEY (`boardID`),
        FOREIGN KEY (`gameID`) REFERENCES `gameTable`(`gameID`)
    );
    
    CREATE TABLE `sessionTable` (
		`sessionID` INT NOT NULL AUTO_INCREMENT,
        `playerID` INT NOT NULL,
        `gameID` INT NOT NULL,
        `sessionActive` BOOLEAN DEFAULT FALSE,
        `score` INT DEFAULT FALSE,
        PRIMARY KEY (`sessionID`, `playerID`),
        FOREIGN KEY (`playerID`) REFERENCES `playerTable`(`playerID`),
        FOREIGN KEY (`gameID`) REFERENCES `gameTable`(`gameID`)
    );
    
	CREATE TABLE `itemTypeTable` (
		`itemID` INT NOT NULL AUTO_INCREMENT,
        `itemName` VARCHAR(50) NOT NULL,
        PRIMARY KEY (`itemID`)
    );
    
    CREATE TABLE `boardTileTable` (
		`tileID` INT NOT NULL AUTO_INCREMENT,
        `boardID` INT,
        `tileRow` INT NOT NULL,
        `tileColumn` INT NOT NULL,
        `tileStatus` BOOLEAN DEFAULT FALSE,
        PRIMARY KEY (`tileID`),
		FOREIGN KEY (`boardID`) REFERENCES `boardTable`(`boardID`)
    );
    
    -- JOINING TABLES
    
    -- Player / Board Table
    SELECT
	  `playerTable`.`playerID`,
      `boardTable`.`boardID`
	FROM `playerTable`
	INNER JOIN `boardTable` ON `boardTable`.`boardID` = `playerTable`.`playerID`;
    
    -- Game / Board Table
    SELECT
	  `gameTable`.`gameID`,
      `boardTable`.`boardID`
	FROM `gameTable`
	INNER JOIN `boardTable` ON `boardTable`.`boardID` = `gameTable`.`gameID`;
    
    -- Item / Tile Table
    SELECT
	  `itemTypeTable`.`itemID`,
      `boardTileTable`.`tileID`
	FROM `itemTypeTable`
	INNER JOIN `boardTileTable` ON `boardTileTable`.`tileID` = `itemTypeTable`.`itemID`;
    
    -- TABLE POPULATION
    
    -- Populates the Player Table
	INSERT INTO `playerTable`(`email`, `username`, `password`) 
	VALUES 
		('russle99@hotmail.com', 'russle99', 'password1234'),
        ('angle42@hotmail.com', 'Angle42', 'password1234'),
        ('marysmith24@hotmail.com', 'Mary101', 'password1234');
	SELECT * FROM `playerTable`;
    
    -- Populates the Board Tile Table
    INSERT INTO `boardTileTable`(`tileRow`, `tileColumn`)
    VALUES -- this creates a 10x10 grid
		(1,1), (1,2), (1,3), (1,4), (1,5),
		(2,1), (2,2), (2,3), (2,4), (2,5),
		(3,1), (3,2), (3,3), (3,4), (3,5),
		(4,1), (4,2), (4,3), (4,4), (4,5),
		(5,1), (5,2), (5,3), (5,4), (5,5),
		(6,1), (6,2), (6,3), (6,4), (6,5),
		(7,1), (7,2), (7,3), (7,4), (7,5),
		(8,1), (8,2), (8,3), (8,4), (8,5),
		(9,1), (9,2), (9,3), (9,4), (9,5),
		(10,1), (10,2), (10,3), (10,4), (10,5);
	SELECT * FROM `boardTileTable`;
    
    -- Populates the Item Table
	INSERT INTO `itemTypeTable`(`itemName`) 
	VALUES 
		('apple'),
        ('frog'),
        ('car');
	SELECT * FROM `itemTypeTable`;
    
END// 
DELIMITER ;
CALL create_insert_tables;