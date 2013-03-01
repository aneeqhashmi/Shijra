/*
SQLyog Ultimate v8.55 
MySQL - 5.5.24-log : Database - shijra
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`shijra` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `shijra`;

/*Table structure for table `persondetails` */

DROP TABLE IF EXISTS `persondetails`;

CREATE TABLE `persondetails` (
  `PersonId` bigint(20) NOT NULL,
  `Education` varchar(100) DEFAULT NULL,
  `Occupation` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`PersonId`),
  CONSTRAINT `FK_persondetails` FOREIGN KEY (`PersonId`) REFERENCES `persons` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `persondetails` */

/*Table structure for table `persons` */

DROP TABLE IF EXISTS `persons`;

CREATE TABLE `persons` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(100) NOT NULL,
  `MiddleName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `FatherId` bigint(20) DEFAULT NULL,
  `UrduName` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `Gender` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `IX_FK_persons` (`FatherId`),
  CONSTRAINT `FK_persons` FOREIGN KEY (`FatherId`) REFERENCES `persons` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=latin1;

/*Data for the table `persons` */

insert  into `persons`(`Id`,`FirstName`,`MiddleName`,`LastName`,`FatherId`,`UrduName`,`Gender`) values (1,'Qusai',NULL,NULL,1,'قصئ',1),(2,'Abdul Munaf','','',1,'عبدالمناف',1),(3,'Hashim',NULL,NULL,2,'ھاشم',1),(4,'Asad',NULL,NULL,3,NULL,1),(5,'Habaar',NULL,NULL,4,NULL,1),(6,'Abdur Rehman',NULL,NULL,5,NULL,1),(7,'Abdur Rahim',NULL,NULL,6,NULL,1),(8,'Taj','Uddin','Al-Matraf',7,NULL,1),(9,'Hazim',NULL,NULL,8,NULL,1),(10,'Hazima',NULL,NULL,9,NULL,1),(11,'Matraf',NULL,NULL,10,NULL,1),(12,'Hussain',NULL,NULL,11,NULL,1),(13,'Abdullah',NULL,NULL,12,NULL,1),(14,'Hussain',NULL,NULL,13,NULL,1),(15,'Shams',NULL,'Uddin',14,NULL,1),(16,'Ali',NULL,'Qazi',15,NULL,1),(17,'Jalal',NULL,'Uddin',16,NULL,1),(18,'Kamal','Uddin','Abu Bakr',17,NULL,1),(19,'Sheikh Wajih','Uddin','Mohammad Ghous',18,NULL,1),(20,'Hazrat Baha Uddin','Abu Mohammad','Zikriya Multani',19,NULL,1),(21,'Sadar','Uddin','Arif',20,NULL,1),(22,'Sheikh Emad',NULL,'Uddin',21,NULL,1),(23,'Sheikh','Mohammad','Yousuf',22,NULL,1),(24,'Shah Abdullah',NULL,NULL,23,NULL,1),(25,'Shah Ahmed',NULL,'Qureshi',24,NULL,1),(26,'Shah Turkaman',NULL,'Qureshi',25,NULL,1),(27,'Shah Suleman',NULL,'Qureshi',26,NULL,1),(28,'Sheikh Bairam',NULL,NULL,27,NULL,1),(29,'Sheikh Jamal','Uddin','Qureshi',28,NULL,1),(30,'Sheikh Buddhan',NULL,NULL,29,NULL,1),(31,'Sheikh Dawood',NULL,'Hafiz',30,NULL,1),(32,'Fateh Mohammad',NULL,NULL,31,NULL,1),(33,'Ghulam Murtaza',NULL,NULL,32,NULL,1),(34,'Sheikh Mohammad',NULL,'Allah yaar',33,NULL,1),(35,'Sheikh Daleel','Ullah','Qureshi',34,NULL,1),(36,'Sheikh Lal','Mohammad','Khursheed',35,NULL,1),(37,'Salamat Ali',NULL,NULL,36,NULL,1),(38,'Mohammad Ali',NULL,NULL,36,NULL,1),(39,'Ahmed Ali',NULL,NULL,36,NULL,1),(40,'Qasim Ali',NULL,NULL,36,NULL,1),(41,'Saadat Ali',NULL,NULL,36,NULL,1),(42,'Barkat Ali',NULL,NULL,36,NULL,1),(43,'Hubt-e-Ali',NULL,NULL,36,NULL,1);

/* Procedure structure for procedure `doiterate` */

/*!50003 DROP PROCEDURE IF EXISTS  `doiterate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `doiterate`(p1 INT)
BEGIN
	 label1: LOOP
	UPDATE persons
	SET FatherId = NULL
	WHERE FatherId = p1;
	UPDATE persons
	SET Id = p1-19
	WHERE Id= p1;
	UPDATE persons
	SET FatherId = p1-19
	WHERE FatherId = NULL;	 
	 
	    SET p1 = p1 + 1;
	    IF p1 < 56 THEN
	      ITERATE label1;
	    END IF;
	    LEAVE label1;
	  END LOOP label1;
	
	
    END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
