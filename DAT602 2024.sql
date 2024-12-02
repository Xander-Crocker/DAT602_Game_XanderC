DROP DATABASE IF EXISTS DAT602TILES;
CREATE DATABASE IF NOT EXISTS DAT602TILES;
USE DAT602TILES;

-- GRANT GRANT OPTION ON *.* TO 'AdminUser'@'localhost';
-- FLUSH PRIVILEGES;

-- DROP PROCEDURE IF EXISTS create_tables;
DELIMITER $$
CREATE PROCEDURE create_tables()
BEGIN
	
	-- Drop existing tables if they exist 
	DROP TABLE IF EXISTS `Players`;
	DROP TABLE IF EXISTS `GameBoard`;
	DROP TABLE IF EXISTS `Items`;
	DROP TABLE IF EXISTS `PlayerInventory`;
	DROP TABLE IF EXISTS `PlayerMovement`;
	DROP TABLE IF EXISTS `Games`;
	DROP TABLE IF EXISTS `ChatMessages`;

	-- TABLES

	 CREATE TABLE Players (
        PlayerID INT AUTO_INCREMENT PRIMARY KEY,
        Username VARCHAR(50) UNIQUE NOT NULL,
        PasswordHash VARCHAR(255) NOT NULL,
        Email VARCHAR(100),
        FailedLoginAttempts INT DEFAULT 3,
        IsLocked BOOLEAN DEFAULT FALSE,
        IsAdmin BOOLEAN DEFAULT FALSE,
        Score INT DEFAULT 0,
        CurrentTileID INT,
        IsLoggedIn BIT DEFAULT 0
    );

    -- Create the GameBoard table
    CREATE TABLE GameBoard (
        TileID INT AUTO_INCREMENT PRIMARY KEY,
        XCoordinate INT NOT NULL,
        YCoordinate INT NOT NULL,
        PlayerID INT,
        FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID) ON DELETE SET NULL
    );

    -- Alter the Players table to add the foreign key constraint after GameBoard is created
    ALTER TABLE Players
        ADD CONSTRAINT FK_CurrentTileID FOREIGN KEY (CurrentTileID) REFERENCES GameBoard(TileID) ON DELETE SET NULL;

	-- Create the Items table 
	CREATE TABLE Items (
		ItemID INT AUTO_INCREMENT PRIMARY KEY,
		TileID INT NOT NULL,
		Description VARCHAR(255),
		Points INT DEFAULT 0,
		FOREIGN KEY (TileID) REFERENCES GameBoard(TileID) ON DELETE CASCADE
	);

	-- Create the PlayerInventory table
	CREATE TABLE PlayerInventory (
		InventoryID INT AUTO_INCREMENT PRIMARY KEY,
		PlayerID INT NOT NULL,
		ItemID INT NOT NULL,
		Quantity INT DEFAULT 1,
		FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID) ON DELETE CASCADE,
		FOREIGN KEY (ItemID) REFERENCES Items(ItemID) ON DELETE CASCADE
	);

	-- Create the PlayerMovement table
	CREATE TABLE PlayerMovement (
		MovementID INT AUTO_INCREMENT PRIMARY KEY,
		PlayerID INT,
		OldTileID INT,
		NewTileID INT,
		MovementTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
		FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID),
		FOREIGN KEY (OldTileID) REFERENCES GameBoard(TileID),
		FOREIGN KEY (NewTileID) REFERENCES GameBoard(TileID)
	);

	-- Create the Games table
	CREATE TABLE Games (
		GameID INT AUTO_INCREMENT PRIMARY KEY,
		IsRunning BOOLEAN DEFAULT TRUE,
		Player1ID INT,
		Player2ID INT,
		GameState VARCHAR(50),
		StartTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
		EndTime TIMESTAMP,
		FOREIGN KEY (Player1ID) REFERENCES Players(PlayerID),
		FOREIGN KEY (Player2ID) REFERENCES Players(PlayerID)
	);
    
	-- INSERT STATEMENTS

	INSERT INTO Players (Username, PasswordHash, Email, IsAdmin, IsLocked, Score)
	VALUES 
	('AdminUser', SHA2('adminpass', 256), 'admin@example.com', TRUE, FALSE, 0),
	('Player1', SHA2('password123', 256), 'player1@example.com', FALSE, TRUE, 0),
	('Player2', SHA2('mypassword', 256), 'player2@example.com', FALSE, FALSE, 0),
	('Player3', SHA2('test123', 256), 'player3@example.com', FALSE, FALSE, 0);

	-- Populate the GameBoard table with a 10x10 grid
	INSERT INTO GameBoard (XCoordinate, YCoordinate)
	SELECT x.n, y.n
	FROM (
		SELECT 0 AS n UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4
		UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9
	) AS x
	CROSS JOIN (
		SELECT 0 AS n UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4
		UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9
	) AS y;

	INSERT INTO Items (TileID, Description, Points)
	VALUES (1, 'Sword', 10),
	(2, 'Shield', 5),
	(3, 'Potion', 15),
	(4, 'Armor', 20);

	INSERT INTO PlayerInventory (PlayerID, ItemID)
	VALUES 
	(1, 1),
	(2, 2);

	INSERT INTO Games (IsRunning)
	VALUES (TRUE);
    
END $$
DELIMITER;

-- PROCEDURES

-- PLAYER LOGIN
DROP PROCEDURE IF EXISTS PlayerLogin;
DELIMITER $$
CREATE PROCEDURE PlayerLogin(
    IN p_Username VARCHAR(50),
    IN p_Password VARCHAR(255)
)
BEGIN
    DECLARE v_Message VARCHAR(50);
    DECLARE v_Score INT;
    DECLARE v_CurrentTileID INT;

    -- Check if the username and password match
    IF EXISTS (SELECT 1 FROM Players WHERE Username = p_Username AND PasswordHash = p_Password) THEN
        SELECT 'Login successful' AS Message, Score, CurrentTileID
        INTO v_Message, v_Score, v_CurrentTileID
        FROM Players
        WHERE Username = p_Username AND PasswordHash = p_Password;

        -- Return the result
        SELECT v_Message AS Message, v_Score AS Score, v_CurrentTileID AS CurrentTileID;
    ELSE
        -- Return failure message
        SELECT 'Invalid username or password' AS Message;
    END IF;
END $$
DELIMITER ;

-- PLAYER REGISTRATION
DELIMITER $$
CREATE PROCEDURE RegisterPlayer(
   IN pUserName VARCHAR(50),
   IN pPassword VARCHAR(255),
   IN pEmail VARCHAR(100)
)
BEGIN
   DECLARE userExists INT;
   SELECT COUNT(*) INTO userExists FROM Players WHERE Username = pUserName;
   IF userExists > 0 THEN
	   SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Username already exists';
   ELSE
	   INSERT INTO Players (Username, PasswordHash, Email) VALUES (pUserName, pPassword, pEmail);
   END IF;
END $$
DELIMITER ;

-- GET ALL PLAYERS
DELIMITER $$
CREATE PROCEDURE GetAllPlayers()
BEGIN
    SELECT 
        PlayerID,
        Username,
        PasswordHash,
        Email,
        FailedLoginAttempts,
        IsLocked,
        IsAdmin,
        Score,
        CurrentTileID,
        IsLoggedIn
    FROM 
        Players;
END $$
DELIMITER ;

-- GET BY USERNAME
DROP PROCEDURE IF EXISTS GetPlayerByUsername;
DELIMITER $$
CREATE PROCEDURE GetPlayerByUsername(IN pUsername VARCHAR(255))
BEGIN
    SELECT Username, PasswordHash AS Password, Email, Score, FailedLoginAttempts AS Attempts, IsLocked AS LockedOut, CurrentTileID AS TileID, IsAdmin, IsLoggedIn
    FROM Players
    WHERE Username = pUsername;
END $$
DELIMITER ;

-- DELETE USER
DROP PROCEDURE IF EXISTS DeletePlayer;
DELIMITER $$
CREATE PROCEDURE DeletePlayer(IN pUsername VARCHAR(50))
BEGIN
    DELETE FROM Players WHERE Username = pUsername;
END $$
DELIMITER ;

-- Set Login Status
DROP PROCEDURE IF EXISTS SetUserLoggedInStatus;
DELIMITER $$
CREATE PROCEDURE SetUserLoggedInStatus(IN pUsername VARCHAR(255), IN pIsLoggedIn BIT)
BEGIN
   UPDATE Players SET IsLoggedIn = pIsLoggedIn WHERE Username = pUsername;
END $$
DELIMITER ;

-- CREATE GET ALL LOGGED IN USERS
DROP PROCEDURE IF EXISTS GetLoggedInUsers;
DELIMITER $$
CREATE PROCEDURE GetLoggedInUsers()
BEGIN
    SELECT Username, Email, IsLoggedIn
    FROM Players
    WHERE IsLoggedIn = 1;
END $$
DELIMITER ;

-- UPDATE USER
DROP PROCEDURE IF EXISTS UpdatePlayer;
DELIMITER $$
CREATE PROCEDURE UpdatePlayer(
    IN pCurrentUsername VARCHAR(50),
    IN pNewUsername VARCHAR(255),
    IN pNewPassword VARCHAR(255),
    IN pNewEmail VARCHAR(100)
)
BEGIN
    UPDATE Players
    SET Username = pNewUsername,
        PasswordHash = pNewPassword,
        Email = pNewEmail
    WHERE Username = pCurrentUsername;
END $$
DELIMITER ;

-- LOCK/UNLOCK ACCOUNT
DROP PROCEDURE IF EXISTS LockUnlockAccount;
DELIMITER $$
CREATE PROCEDURE LockUnlockAccount (
    IN p_admin_id INT,
    IN p_target_user_id INT,
    IN p_lock BOOLEAN,
    OUT p_success BOOLEAN
)
BEGIN
    DECLARE v_is_admin BOOLEAN;

    -- Check if the requester is an admin
    SELECT IsAdmin INTO v_is_admin
    FROM Players
    WHERE PlayerID = p_admin_id;

    IF v_is_admin THEN
        -- Lock or unlock the target account
        UPDATE Players
        SET IsLocked = p_lock
        WHERE PlayerID = p_target_user_id;

        SET p_success = TRUE;
    ELSE
        SET p_success = FALSE;
    END IF;
END $$
DELIMITER ;

-- login attempts 
DROP PROCEDURE IF EXISTS IncrementFailedLoginAttempts;
DELIMITER $$
CREATE PROCEDURE IncrementFailedLoginAttempts (
    IN p_username VARCHAR(50),
    OUT p_locked_out BOOLEAN
)
BEGIN
    DECLARE v_failed_attempts INT;

    -- Increment the failed login attempts
    UPDATE Players
    SET FailedLoginAttempts = FailedLoginAttempts - 1
    WHERE Username = p_username;

    -- Get the current number of failed login attempts
    SELECT FailedLoginAttempts INTO v_failed_attempts
    FROM Players
    WHERE Username = p_username;

    -- Check if the account should be locked
    IF v_failed_attempts <= 0 THEN
        UPDATE Players
        SET IsLocked = TRUE
        WHERE Username = p_username;
        SET p_locked_out = TRUE;
    ELSE
        SET p_locked_out = FALSE;
    END IF;
END $$
DELIMITER ;

-- grant admin permissions
DROP PROCEDURE IF EXISTS GrantAdminPermissions;
DELIMITER $$
CREATE PROCEDURE GrantAdminPermissions()
BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE username VARCHAR(255);
    DECLARE isAdmin INT;
    DECLARE cur CURSOR FOR SELECT Username, IsAdmin FROM Players;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

    OPEN cur;

    read_loop: LOOP
        FETCH cur INTO username, isAdmin;
        IF done THEN
            LEAVE read_loop;
        END IF;

        IF isAdmin = 1 THEN
            SET @grant_sql = CONCAT('GRANT SELECT, INSERT, UPDATE, DELETE, CREATE, DROP, INDEX, ALTER ON DAT602TILES.* TO ''', username, '''@''localhost''');
            PREPARE stmt FROM @grant_sql;
            EXECUTE stmt;
            DEALLOCATE PREPARE stmt;
        ELSE
            SET @revoke_sql = CONCAT('REVOKE ALL PRIVILEGES ON DAT602TILES.* FROM ''', username, '''@''localhost''');
            PREPARE stmt FROM @revoke_sql;
            EXECUTE stmt;
            DEALLOCATE PREPARE stmt;
        END IF;
    END LOOP;

    CLOSE cur;
END $$
DELIMITER ;

-- CREATE GAMEBOARD
DROP PROCEDURE IF EXISTS CreateGameBoard;
DELIMITER $$
CREATE PROCEDURE CreateGameBoard (
    IN p_x INT,
    IN p_y INT
)
BEGIN
    START TRANSACTION;
    INSERT INTO GameBoard (XCoordinate, YCoordinate)
    VALUES (p_x, p_y);
    COMMIT;
END $$
DELIMITER ;

-- CREATE GET ALL TILES PROCEDURE
DROP PROCEDURE IF EXISTS GetAllTiles;
DELIMITER $$
CREATE PROCEDURE GetAllTiles()
BEGIN
    SELECT 
        g.XCoordinate AS `row`, 
        g.YCoordinate AS `col`, 
        g.TileID AS `id`
    FROM 
        GameBoard g
    LEFT JOIN 
        Items i ON g.TileID = i.TileID;
END $$
DELIMITER ;

-- CREATE GET ALL Items PROCEDURE
DROP PROCEDURE IF EXISTS GetAllItems;
DELIMITER $$
CREATE PROCEDURE GetAllItems()
BEGIN
    SELECT ItemID, TileID, Description, Points
	FROM Items;
END $$
DELIMITER ;

-- PLACE ITEM
DROP PROCEDURE IF EXISTS PlaceItem;
DELIMITER $$
CREATE PROCEDURE PlaceItem (
    IN p_tile_id INT,
    IN p_description VARCHAR(255)
)
BEGIN
    START TRANSACTION;
    INSERT INTO Items (TileID, Description)
    VALUES (p_tile_id, p_description);
    COMMIT;
END $$
DELIMITER ;

-- MOVE PLAYER
DROP PROCEDURE IF EXISTS MovePlayer;
DELIMITER $$
CREATE PROCEDURE MovePlayer (
    IN p_player_id INT,
    IN p_tile_id INT,
    OUT p_success BOOLEAN
)
BEGIN
    DECLARE v_legal_tile BOOLEAN;

    -- Check if the tile is legal (exists and not occupied)
    SELECT COUNT(*) INTO v_legal_tile
    FROM GameBoard
    WHERE TileID = p_tile_id;

    IF v_legal_tile THEN
        -- Log the player movement
        INSERT INTO PlayerMovement (PlayerID, OldTileID, NewTileID)
        SELECT PlayerID, CurrentTileID, p_tile_id
        FROM Players
        WHERE PlayerID = p_player_id;

        -- Update player's current tile
        UPDATE Players
        SET CurrentTileID = p_tile_id
        WHERE PlayerID = p_player_id;

        SET p_success = TRUE;
    ELSE
        SET p_success = FALSE;
    END IF;
    COMMIT;
END $$
DELIMITER ;

-- COLLECT ITEM
DROP PROCEDURE IF EXISTS CollectItem;
DELIMITER $$
CREATE PROCEDURE CollectItem(
    IN p_player_id INT,
    IN p_item_id INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    -- Update the item to mark it as collected
    UPDATE Items
    SET TileID = NULL -- or another way to mark it as collected
    WHERE ItemID = p_item_id AND TileID = (SELECT CurrentTileID FROM Players WHERE PlayerID = p_player_id);

    COMMIT;
END $$
DELIMITER ;

-- UPDATE SCORE
DROP PROCEDURE IF EXISTS UpdatePlayerScore;
DELIMITER $$
CREATE PROCEDURE UpdatePlayerScore(IN p_PlayerID INT, IN p_ItemID INT)
BEGIN
    DECLARE itemValue INT;

    -- Get the item value from the Items table
    SELECT ItemValue INTO itemValue FROM Items WHERE ItemID = p_ItemID;
    
    -- Update player score
    UPDATE Players SET Score = Score + itemValue WHERE PlayerID = p_PlayerID;
END $$
DELIMITER ;

-- UPDATE TILE STATE
DROP PROCEDURE IF EXISTS UpdateTileState;
DELIMITER $$
CREATE PROCEDURE UpdateTileState(IN p_PlayerID INT, IN p_NewTileID INT)
BEGIN
    -- Check if the tile is empty
    DECLARE tileOccupied INT;
    
    SELECT COUNT(*) INTO tileOccupied FROM Players WHERE CurrentTileID = p_NewTileID;
    
    IF tileOccupied = 0 THEN
        -- Player can move to the new tile
        UPDATE Players SET CurrentTileID = p_NewTileID WHERE PlayerID = p_PlayerID;
    ELSE
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Tile is occupied. Please choose another tile.';
    END IF;
END $$
DELIMITER ;

-- STOP RUNNING GAME
DROP PROCEDURE IF EXISTS StopGame;
DELIMITER $$
CREATE PROCEDURE StopGame (
    IN p_admin_id INT,
    IN p_game_id INT,
    OUT p_success BOOLEAN
)
BEGIN
    DECLARE v_is_admin BOOLEAN;

    -- Check if the requester is an admin
    SELECT IsAdmin INTO v_is_admin
    FROM Players
    WHERE PlayerID = p_admin_id;

    IF v_is_admin THEN
        -- Stop the game
        UPDATE Games
        SET IsRunning = FALSE
        WHERE GameID = p_game_id;

        SET p_success = TRUE;
    ELSE
        SET p_success = FALSE;
    END IF;
END $$
DELIMITER ;

-- KILL RUNNING GAME UPDATE
DROP PROCEDURE IF EXISTS KillRunningGame;
DELIMITER $$
CREATE PROCEDURE KillRunningGame(IN p_GameID INT)
BEGIN
    -- End the game by updating the game state
    UPDATE Games SET GameState = 'Cancelled', EndTime = CURRENT_TIMESTAMP WHERE GameID = p_GameID;
END $$
DELIMITER ;

-- RESET PLAYER SCORE WHEN GAME ENDS
DELIMITER $$
CREATE PROCEDURE EndGameAndResetScores(IN p_GameID INT)
BEGIN
    -- Update the game status to "Ended" (if it hasn't been marked already)
    UPDATE Games
    SET GameState = 'Ended', EndTime = CURRENT_TIMESTAMP
    WHERE GameID = p_GameID AND GameState != 'Ended';
    
    -- Reset scores for all players in the game
    UPDATE Players
    SET Score = 0
    WHERE PlayerID IN (SELECT Player1ID FROM Games WHERE GameID = p_GameID
                        UNION
                        SELECT Player2ID FROM Games WHERE GameID = p_GameID);
END $$
DELIMITER ;


-- TESTING


-- call needs to be commented when registering players in app
Call create_tables;
-- Check Players Table
SELECT * FROM Players;

-- Check GameBoard Table
SELECT * FROM GameBoard;
-- Check Items Table
SELECT * FROM Items;
-- Check PlayerInventory Table
SELECT * FROM PlayerInventory;
-- Check Games Table
SELECT * FROM Games;
-- Verify the player's score
SELECT * FROM Players WHERE PlayerID = 1;
-- Verify the player's inventory
SELECT * FROM PlayerInventory WHERE PlayerID = 1;

-- Verify RegisterPlayer
SELECT * 
FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME = 'RegisterPlayer' AND ROUTINE_SCHEMA = 'dat602tiles';

-- Test Login
CALL PlayerLogin('AdminUser', 'adminpass');

-- Test wrong password
-- CALL PlayerLogin('player1', 'wrongpassword');

-- Test Register
CALL RegisterPlayer('Player6', 'password123', 'player6RegisterPlayer@example.com');

-- Test Delete
CALL DeletePlayer('test');

-- Test Get all players
CALL GetAllPlayers();

-- Test Get all players
CALL GetPlayerByUsername('AdminUser');

-- Test Get all players
-- CALL GetLoggedInUsers();

-- Test Get all tiles
CALL GetAllTiles();

-- Test Get all items
CALL GetAllItems();

-- Update user data
CALL UpdatePlayer(
    'OldUsername',
    'NewUsername',
    'NewPasswordHash',
    'newemail@example.com' 
);

-- user login status
-- CALL SetUserLoggedInStatus('AdminUser', 1);

-- Lock a user account
CALL LockUnlockAccount(1, 2, TRUE, @lockuUnlock_success);
SELECT @lockuUnlock_success;

-- collect item
CALL CollectItem(1, 1); -- playerId and itemId

-- current tile
SELECT CurrentTileID FROM Players WHERE PlayerID = 6;

-- items tile
SELECT TileID FROM Items WHERE ItemID = 3;

-- Test Moving a Player
-- CALL MovePlayer(2, 2, @move_success);
SELECT @move_success;

-- Stop a game
CALL StopGame(1, 1, @stop_success);
SELECT @stop_success;
