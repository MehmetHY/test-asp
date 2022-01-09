-- Create database
CREATE OR REPLACE DATABASE `todoapp_asp_net_core_6_mvc`;

-- Switch to database
USE `todoapp_asp_net_core_6_mvc`;


-- Create `UserModel` table
CREATE OR REPLACE TABLE `UserModel` (
    `Id` INT NOT NULL UNIQUE AUTO_INCREMENT,
    `Name` VARCHAR(64) UNIQUE NOT NULL,
    `Password` VARCHAR(64) NOT NULL,

    CONSTRAINT `PK_UserModel`
        PRIMARY KEY (`Id`)
);

-- UserModel Add
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_UserModel_Add`(IN `Name` VARCHAR(64), IN `Password` VARCHAR(64))
    BEGIN

        INSERT 
            INTO `UserModel` 
                (`Name`, `Password`)
            VALUES
                (`Name`, `Password`);

    END //
DELIMITER ;


-- UserModel Get
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_UserModel_Get`(IN `Id` INT)
    BEGIN

        SELECT *
            FROM `UserModel`
            WHERE `Id` = `Id`;

    END //
DELIMITER ;


-- UserModel NameExists
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_UserModel_NameExists`(IN `name` VARCHAR(64))
    BEGIN

        DECLARE `result` INT;

        SELECT COUNT(*) 
            INTO `result` 
            FROM `UserModel`
            WHERE `UserModel`.`Name` = `name`;
        
        SELECT `result` > 0;

    END //
DELIMITER ;


-- UserModel PasswordCorrect
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_UserModel_PasswordCorrect`(IN `name` VARCHAR(64), IN `password` CHAR(64))
    BEGIN

        DECLARE `result` INT;

        SELECT COUNT(*)
            INTO `result`
            FROM `UserModel`
            WHERE `UserModel`.`Name` = `name` AND `UserModel`.`Password` = `password`;
        
        SELECT `result` > 0;

    END //
DELIMITER ;


-- UserModel GetByName
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_UserModel_GetByName`(IN `name` VARCHAR(64))
    BEGIN

        SELECT * 
            FROM `UserModel`
            WHERE `UserModel`.`Name` = `name`;

    END //
DELIMITER ;



-- Create `CategoryModel` table
CREATE OR REPLACE TABLE `CategoryModel` (
    `Id` INT NOT NULL UNIQUE AUTO_INCREMENT,
    `Name` VARCHAR(64) NOT NULL,
    `UserId` INT NOT NULL,
    `BaseCategoryId` INT,

    CONSTRAINT `PK_CategoryModel`
        PRIMARY KEY (`Id`),

    CONSTRAINT `FK_CategoryModel_UserModel`
        FOREIGN KEY (`UserId`)
        REFERENCES `UserModel` (`Id`) 
        ON DELETE CASCADE
        ON UPDATE CASCADE,

    CONSTRAINT `FK_CategoryModel_BaseCategoryModel`
        FOREIGN KEY (`BaseCategoryId`)
        REFERENCES `CategoryModel` (`Id`) 
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- CategoryModel Get
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_CategoryModel_Get`(IN `Id` INT)
    BEGIN
    
        SELECT *
            FROM `CategoryModel`
            WHERE `CategoryModel`.`Id` = `Id`;
    
    END //
DELIMITER ;

-- CategoryModel Add
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_CategoryModel_Add`(IN `Name` VARCHAR(64), IN `UserId` INT, IN `BaseCategoryId` INT)
    BEGIN

        INSERT 
            INTO `CategoryModel`
                (`Name`, `UserId`, `BaseCategoryId`)
            VALUES
                (`Name`, `UserId`, `BaseCategoryId`);

    END //
DELIMITER ;



-- CategoryModel Remove
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_CategoryModel_Remove`(IN `Id` INT)
    BEGIN
    
        DELETE 
            FROM `CategoryModel`
            WHERE
                `CategoryModel`.`Id` = `Id`;
    
    END //
DELIMITER ;

DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_CategoryModel_Update`(IN `Id` INT, IN `Name` VARCHAR(64))
    BEGIN
    
        UPDATE `CategoryModel`
            SET
                `CategoryModel`.`Name` = `Name`
            WHERE
                `CategoryModel`.`Id` = `Id`;
    
    END //
DELIMITER ;

-- CategoryModel GetOfUser
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_CategoryModel_GetOfUser`(IN `userId` INT)
    BEGIN

        SELECT * 
            FROM `CategoryModel`
            WHERE `CategoryModel`.`UserId` = `userId` AND `CategoryModel`.`BaseCategoryId` IS NULL
            ORDER BY `CategoryModel`.`Name` ASC;

    END //
DELIMITER ;


-- CategoryModel GetOfCategory
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_CategoryModel_GetOfCategory`(IN `categoryId` INT)
    BEGIN

        SELECT * 
            FROM `CategoryModel`
            WHERE `CategoryModel`.`BaseCategoryId` = `categoryId`
            ORDER BY `CategoryModel`.`Name` ASC;

    END //
DELIMITER ;


-- CategoryModel GetByName
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_CategoryModel_GetByName`(IN `userId` INT, IN `categoryName` VARCHAR(64))
    BEGIN

        SELECT * 
            FROM `CategoryModel`
            WHERE `CategoryModel`.`UserId` = `userId` AND `CategoryModel`.`Name` = `categoryName`
            ORDER BY `CategoryModel`.`Name` ASC;

    END //
DELIMITER ;

-- CategoryModel UserHasCategory
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_CategoryModel_UserHasCategory`(IN `userId` INT, IN `categoryId` INT)
    BEGIN
        
        DECLARE `count` INT;

        SELECT COUNT(*)
            INTO `count`
            FROM `CategoryModel`
            WHERE `CategoryModel`.`Id` = `categoryId` AND `CategoryModel`.`UserId` = `userId`;

        SELECT `count` > 0;
    
    END //
DELIMITER ;

-- CategoryModel bool NameExists(int? userId, string? name)
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_CategoryModel_NameExists`(IN `userId` INT , IN `name` VARCHAR(64))
    BEGIN
    
        DECLARE `count` INT;

        SELECT COUNT(*)
            INTO `count`
            FROM `CategoryModel`
            WHERE 
                `CategoryModel`.`Name` = `name` 
                AND
                `CategoryModel`.`UserId` = `userId`
                AND
                `CategoryModel`.`BaseCategoryId` IS NULL;
        
        SELECT `count` > 0;
    
    END //
DELIMITER ;

-- CategoryModel bool NameExistsInCategory(int? baseCategoryId, string? name)
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_CategoryModel_NameExistsInCategory`(IN `baseCategoryId` INT , IN `name` VARCHAR(64))
    BEGIN
    
        DECLARE `count` INT;

        SELECT COUNT(*)
            INTO `count`
            FROM `CategoryModel`
            WHERE `CategoryModel`.`Name` = `name` AND `CategoryModel`.`BaseCategoryId` = `baseCategoryId`;
        
        SELECT `count` > 0;
    
    END //
DELIMITER ;



-- Create `TodoModel` table
CREATE OR REPLACE TABLE `TodoModel` (
    `Id` INT NOT NULL UNIQUE AUTO_INCREMENT,
    `Title` VARCHAR(256) NOT NULL,
    `Description` VARCHAR(1000) DEFAULT '',
    `CategoryId` INT NOT NULL,
    `UserId` INT NOT NULL,
    `State` INT NOT NULL DEFAULT 1,
    `Index` INT NOT NULL,

    CONSTRAINT `PK_TodoModel`
        PRIMARY KEY (`Id`),

    CONSTRAINT `FK_TodoModel_CategoryModel`
        FOREIGN KEY (`CategoryId`)
        REFERENCES `CategoryModel` (`Id`)
        ON DELETE CASCADE
        ON UPDATE CASCADE,

    CONSTRAINT `FK_TodoModel_UserModel`
        FOREIGN KEY (`UserId`)
        REFERENCES `UserModel` (`Id`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

-- TodoModel Add
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_TodoModel_Add`(
        IN `Title` VARCHAR(256),
        IN `Description` VARCHAR(1000),
        IN `CategoryId` INT,
        IN `UserId` INT,
        IN `State` INT,
        IN `Index` INT)
    BEGIN

        DECLARE `lastIndex` INT;

        SELECT
            MAX(`TodoModel`.`Index`) + 1
            INTO `lastIndex`
            FROM `TodoModel`
            WHERE `TodoModel`.`CategoryId` = `CategoryId`;

        INSERT 
            INTO `TodoModel`
                (`Title`, `Description`, `CategoryId`, `UserId`, `State`, `Index`)
            VALUES
                (`Title`, `Description`, `CategoryId`, `UserId`, `State`, IFNULL(`lastIndex`, 1));

    END //
DELIMITER ;



-- TodoModel void Remove(int? id)
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_TodoModel_Remove`(IN `id` INT)
    BEGIN
    
        DELETE
            FROM `TodoModel`
            WHERE
                `TodoModel`.`Id` = `id`;
        
    END //
DELIMITER ;

-- TodoModel Update
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_TodoModel_Update`
        (
            IN `Id` INT,
            IN `Title` VARCHAR(64),
            IN `Description` VARCHAR(1000),
            IN `State` INT,
            IN `Index` INT
        )
    BEGIN
    
        UPDATE `TodoModel`
            SET
                `TodoModel`.`Title` = `Title`,
                `TodoModel`.`Description` = `Description`,
                `TodoModel`.`State` = `State`,
                `TodoModel`.`Index` = `Index`
            WHERE
                `TodoModel`.`Id` = `Id`;
    
    END //
DELIMITER ;

-- TodoModel GetOfUser
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_TodoModel_GetOfUser`(IN `userId` INT)
    BEGIN

        SELECT *
            FROM `TodoModel`
            WHERE `TodoModel`.`UserId` = `userId`
            ORDER BY `TodoModel`.`Index` ASC;

    END //
DELIMITER ;


-- TodoModel GetOfCategory
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_TodoModel_GetOfCategory`(IN `categoryId` INT)
    BEGIN

        SELECT *
            FROM `TodoModel`
            WHERE `TodoModel`.`CategoryId` = `categoryId`
            ORDER BY `TodoModel`.`Index` ASC;

    END //
DELIMITER ;


-- TodoModel GetOfCategoryByName
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_TodoModel_GetOfCategoryByName`(IN `userId` INT, IN `categoryName` VARCHAR(64))
    BEGIN

        SELECT *
            FROM `TodoModel`
            WHERE `TodoModel`.`CategoryId` = 
                (
                    SELECT `CategoryModel`.`Id`
                        FROM `CategoryModel`
                        WHERE `CategoryModel`.`UserId` = `userId` AND `CategoryModel`.`Name` = `categoryName`
                        LIMIT 1
                )
            ORDER BY `TodoModel`.`Index` ASC;

    END //
DELIMITER ;

-- TodoModel GetByIndex(int? index, int? categoryId, int? userId)
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_TodoModel_GetByIndex`(IN `index` INT, IN `categoryId` INT, IN `userId` INT)
    BEGIN
    
        SELECT *
            FROM `TodoModel`
            WHERE 
                `TodoModel`.`UserId` = `userId`
                AND
                `TodoModel`.`CategoryId` = `categoryId`
                AND
                `TodoModel`.`Index` = `index`;
    
    END //
DELIMITER ;

-- TodoModel GetMaxIndex(int? categoryId, int? userId)
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_TodoModel_GetMaxIndex`(IN `categoryId` INT, IN `userId` INT)
    BEGIN
    
        SELECT MAX(`TodoModel`.`Index`)
            FROM `TodoModel`
            WHERE `TodoModel`.`CategoryId` = `categoryId` AND `TodoModel`.`UserId` = `userId`;
    
    END //
DELIMITER ;

-- TodoModel GetUpperNeighbour(int? index, int? categoryId, int? userId)
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_TodoModel_GetUpperNeighbour`(IN `index` INT, IN `categoryId` INT, IN `userId` INT)
    BEGIN
    
        SELECT *
            FROM `TodoModel`
            WHERE
                `TodoModel`.`UserId` = `userId`
                AND
                `TodoModel`.`CategoryId` = `categoryId`
                AND
                `TodoModel`.`Index` < `index`
            ORDER BY `TodoModel`.`Index` DESC
            LIMIT 1;
    
    END //
DELIMITER ;

-- TodoModel GetLowerNeighbour(int? index, int? categoryId, int? userId)
DELIMITER //
    CREATE OR REPLACE PROCEDURE `SP_TodoModel_GetLowerNeighbour`(IN `index` INT, IN `categoryId` INT, IN `userId` INT)
    BEGIN
    
        SELECT *
            FROM `TodoModel`
            WHERE
                `TodoModel`.`UserId` = `userId`
                AND
                `TodoModel`.`CategoryId` = `categoryId`
                AND
                `TodoModel`.`Index` > `index`
            ORDER BY `TodoModel`.`Index` ASC
            LIMIT 1;
    
    END //
DELIMITER ;