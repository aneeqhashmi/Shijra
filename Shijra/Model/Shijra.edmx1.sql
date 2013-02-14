



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 01/25/2013 18:56:06
-- Generated from EDMX file: c:\users\ahashmi\documents\visual studio 2010\Projects\Shijra\Shijra\Model\Shijra.edmx
-- Target version: 2.0.0.0
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

--    ALTER TABLE `PersonDetails1` DROP CONSTRAINT `FK_persondetails`;
--    ALTER TABLE `persons` DROP CONSTRAINT `FK_persons`;

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `PersonDetails1`;
    DROP TABLE IF EXISTS `persons`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PersonDetails'

CREATE TABLE `PersonDetails` (
    `PersonId` bigint  NOT NULL,
    `Education` varchar(100)  NULL,
    `Occupation` varchar(100)  NULL
);

-- Creating table 'persons'

CREATE TABLE `persons` (
    `Id` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `FirstName` varchar(100)  NOT NULL,
    `MiddleName` varchar(100)  NULL,
    `LastName` varchar(100)  NOT NULL,
    `FatherId` bigint  NOT NULL
);



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on `PersonId` in table 'PersonDetails'

ALTER TABLE `PersonDetails`
ADD CONSTRAINT `PK_PersonDetails`
    PRIMARY KEY (`PersonId` );



-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `PersonId` in table 'PersonDetails'

ALTER TABLE `PersonDetails`
ADD CONSTRAINT `FK_persondetails`
    FOREIGN KEY (`PersonId`)
    REFERENCES `persons`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `FatherId` in table 'persons'

ALTER TABLE `persons`
ADD CONSTRAINT `FK_persons`
    FOREIGN KEY (`FatherId`)
    REFERENCES `persons`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_persons'

CREATE INDEX `IX_FK_persons` 
    ON `persons`
    (`FatherId`);

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
