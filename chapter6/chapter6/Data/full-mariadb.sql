-- MySQL dump 10.17  Distrib 10.3.21-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: lean_training
-- ------------------------------------------------------
-- Server version	10.3.21-MariaDB-1:10.3.21+maria~bionic

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `AssemblySteps`
--
CREATE DATABASE lean_training;
use lean_training;

DROP TABLE IF EXISTS `AssemblySteps`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AssemblySteps` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `Cost` int(11) NOT NULL,
  `Mandatory` tinyint(1) NOT NULL DEFAULT 0,
  `LatestUser` longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT 'Admin',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AssemblySteps`
--

LOCK TABLES `AssemblySteps` WRITE;
/*!40000 ALTER TABLE `AssemblySteps` DISABLE KEYS */;
INSERT INTO `AssemblySteps` VALUES (1,'Bohren',2,0,'Admin'),(2,'Fügen',1,0,'Admin'),(3,'Kleben',2,0,'Admin');
/*!40000 ALTER TABLE `AssemblySteps` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PartDefinitions`
--

DROP TABLE IF EXISTS `PartDefinitions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `PartDefinitions` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Cost` int(11) NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `LatestUser` longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT 'Admin',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PartDefinitions`
--

LOCK TABLES `PartDefinitions` WRITE;
/*!40000 ALTER TABLE `PartDefinitions` DISABLE KEYS */;
INSERT INTO `PartDefinitions` VALUES (1,100,'0815','Admin'),(2,100,'0816','Admin'),(3,120,'0818','Admin'),(4,120,'0819','Admin');
/*!40000 ALTER TABLE `PartDefinitions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Parts`
--

DROP TABLE IF EXISTS `Parts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Parts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) DEFAULT NULL,
  `PartDefinitionId` int(11) DEFAULT NULL,
  `LatestUser` longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT 'Admin',
  PRIMARY KEY (`Id`),
  KEY `IX_Parts_PartDefinitionId` (`PartDefinitionId`),
  KEY `IX_Parts_ProductId` (`ProductId`),
  CONSTRAINT `FK_Parts_PartDefinitions_PartDefinitionId` FOREIGN KEY (`PartDefinitionId`) REFERENCES `PartDefinitions` (`Id`),
  CONSTRAINT `FK_Parts_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Parts`
--

LOCK TABLES `Parts` WRITE;
/*!40000 ALTER TABLE `Parts` DISABLE KEYS */;
INSERT INTO `Parts` VALUES (1,18,1,'Admin'),(2,27,2,'Admin'),(3,27,3,'Admin'),(4,27,4,'Admin'),(5,28,1,'Admin'),(6,28,2,'Admin'),(7,28,3,'Admin'),(8,28,4,'Admin'),(9,29,1,'Admin'),(10,29,2,'Admin'),(11,29,3,'Admin'),(12,29,4,'Admin'),(13,30,1,'Admin'),(14,30,2,'Admin'),(15,30,3,'Admin'),(16,30,4,'Admin'),(17,31,1,'Admin'),(18,31,2,'Admin'),(19,34,4,'Admin'),(20,34,3,'Admin'),(21,34,2,'Admin'),(22,34,1,'Admin'),(23,33,4,'Admin'),(24,33,3,'Admin'),(25,26,4,'Admin'),(26,33,2,'Admin'),(27,32,4,'Admin'),(28,32,3,'Admin'),(29,32,2,'Admin'),(30,32,1,'Admin'),(31,31,4,'Admin'),(32,31,3,'Admin'),(33,33,1,'Admin'),(34,26,3,'Admin'),(35,27,1,'Admin'),(36,26,1,'Admin'),(37,26,2,'Admin'),(38,21,2,'Admin'),(39,21,1,'Admin'),(40,20,4,'Admin'),(41,20,3,'Admin'),(42,20,2,'Admin'),(43,21,4,'Admin'),(44,20,1,'Admin'),(45,19,3,'Admin'),(46,19,2,'Admin'),(47,19,1,'Admin'),(48,18,4,'Admin'),(49,18,3,'Admin'),(50,18,2,'Admin'),(51,19,4,'Admin'),(52,22,1,'Admin'),(53,21,3,'Admin'),(54,22,3,'Admin'),(55,25,4,'Admin'),(56,25,3,'Admin'),(57,25,2,'Admin'),(58,22,2,'Admin'),(59,24,4,'Admin'),(60,24,3,'Admin'),(61,25,1,'Admin'),(62,24,1,'Admin'),(63,23,4,'Admin'),(64,23,3,'Admin'),(65,23,2,'Admin'),(66,23,1,'Admin'),(67,22,4,'Admin'),(68,24,2,'Admin');
/*!40000 ALTER TABLE `Parts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Products`
--

DROP TABLE IF EXISTS `Products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Products` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Start` datetime(6) NOT NULL,
  `End` datetime(6) DEFAULT NULL,
  `RoundId` int(11) DEFAULT NULL,
  `StationId` int(11) NOT NULL DEFAULT 1,
  `LatestUser` longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT 'Admin',
  PRIMARY KEY (`Id`),
  KEY `IX_Products_RoundId` (`RoundId`),
  KEY `IX_Products_StationId` (`StationId`),
  CONSTRAINT `FK_Products_Rounds_RoundId` FOREIGN KEY (`RoundId`) REFERENCES `Rounds` (`Id`),
  CONSTRAINT `FK_Products_Stations_StationId` FOREIGN KEY (`StationId`) REFERENCES `Stations` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Products`
--

LOCK TABLES `Products` WRITE;
/*!40000 ALTER TABLE `Products` DISABLE KEYS */;
INSERT INTO `Products` VALUES (1,'2019-12-20 15:54:17.956611',NULL,1,1,'Admin'),(2,'2019-12-20 15:29:17.956611',NULL,1,1,'Admin'),(3,'2019-12-20 15:58:17.956611',NULL,1,1,'Admin'),(4,'2019-12-20 16:19:17.956611',NULL,1,1,'Admin'),(5,'2019-12-20 15:31:17.956611',NULL,1,2,'Admin'),(6,'2019-12-20 16:19:17.956611',NULL,1,2,'Admin'),(7,'2019-12-20 15:45:17.956611',NULL,1,2,'Admin'),(8,'2019-12-20 15:35:17.956611',NULL,1,3,'Admin'),(9,'2019-12-20 15:28:17.956611',NULL,1,3,'Admin'),(10,'2019-12-20 16:07:17.956611',NULL,1,3,'Admin'),(11,'2019-12-20 16:09:17.956611',NULL,1,4,'Admin'),(12,'2019-12-20 15:56:17.956611',NULL,1,4,'Admin'),(13,'2019-12-20 15:46:17.956611',NULL,1,4,'Admin'),(14,'2019-12-20 16:23:17.956611',NULL,1,5,'Admin'),(15,'2019-12-20 15:31:17.956611',NULL,1,5,'Admin'),(16,'2019-12-20 16:10:17.956611',NULL,1,5,'Admin'),(17,'2019-12-20 15:33:17.956611',NULL,1,6,'Admin'),(18,'2019-12-20 15:58:17.956611',NULL,1,1,'Admin'),(19,'2019-12-20 15:52:17.956611',NULL,1,1,'Admin'),(20,'2019-12-20 15:24:17.956611',NULL,1,1,'Admin'),(21,'2019-12-20 15:49:17.956611',NULL,1,1,'Admin'),(22,'2019-12-20 15:42:17.956611',NULL,1,1,'Admin'),(23,'2019-12-20 16:23:17.956611',NULL,1,1,'Admin'),(24,'2019-12-20 15:31:17.956611',NULL,1,1,'Admin'),(25,'2019-12-20 16:15:17.956611',NULL,1,1,'Admin'),(26,'2019-12-20 15:34:17.956611',NULL,1,1,'Admin'),(27,'2019-12-20 15:45:17.956611',NULL,1,1,'Admin'),(28,'2019-12-20 16:12:17.956611',NULL,1,1,'Admin'),(29,'2019-12-20 16:22:17.956611',NULL,1,1,'Admin'),(30,'2019-12-20 16:23:17.956611',NULL,1,1,'Admin'),(31,'2019-12-20 16:19:17.956611',NULL,1,1,'Admin'),(32,'2019-12-20 16:20:17.956611',NULL,1,1,'Admin'),(33,'2019-12-20 16:03:17.956611',NULL,1,1,'Admin'),(34,'2019-12-20 16:08:17.956611',NULL,1,1,'Admin'),(35,'2019-12-20 15:32:17.956611',NULL,1,1,'Admin'),(36,'2019-12-20 15:40:17.956611',NULL,1,1,'Admin'),(37,'2019-12-20 15:40:17.956611',NULL,1,1,'Admin'),(38,'2019-12-20 15:51:17.956611',NULL,1,1,'Admin'),(39,'2019-12-20 15:34:17.956611',NULL,1,1,'Admin'),(40,'2019-12-20 15:45:17.956611',NULL,1,1,'Admin'),(41,'2019-12-20 16:22:17.956611',NULL,1,1,'Admin'),(42,'2019-12-20 15:39:17.956611',NULL,1,1,'Admin'),(43,'2019-12-20 16:07:17.956611',NULL,1,1,'Admin'),(44,'2019-12-20 16:02:17.956611',NULL,1,1,'Admin'),(45,'2019-12-20 15:44:17.956611',NULL,1,1,'Admin'),(46,'2019-12-20 15:52:17.956611',NULL,1,1,'Admin'),(47,'2019-12-20 16:10:17.956611',NULL,1,1,'Admin'),(48,'2019-12-20 16:06:17.956611',NULL,1,1,'Admin'),(49,'2019-12-20 15:56:17.956611',NULL,1,1,'Admin'),(50,'2019-12-20 16:10:17.956611',NULL,1,1,'Admin');
/*!40000 ALTER TABLE `Products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Rounds`
--

DROP TABLE IF EXISTS `Rounds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Rounds` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Start` datetime(6) NOT NULL,
  `End` datetime(6) DEFAULT NULL,
  `LatestUser` longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT 'Admin',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Rounds`
--

LOCK TABLES `Rounds` WRITE;
/*!40000 ALTER TABLE `Rounds` DISABLE KEYS */;
INSERT INTO `Rounds` VALUES (1,'2019-12-20 15:24:17.956611',NULL,'Admin');
/*!40000 ALTER TABLE `Rounds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Stations`
--

DROP TABLE IF EXISTS `Stations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Stations` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoundId` int(11) DEFAULT NULL,
  `Position` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `LatestUser` longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT 'Admin',
  PRIMARY KEY (`Id`),
  KEY `IX_Stations_RoundId` (`RoundId`),
  CONSTRAINT `FK_Stations_Rounds_RoundId` FOREIGN KEY (`RoundId`) REFERENCES `Rounds` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Stations`
--

LOCK TABLES `Stations` WRITE;
/*!40000 ALTER TABLE `Stations` DISABLE KEYS */;
INSERT INTO `Stations` VALUES (1,1,'Station_6','Admin'),(2,1,'Station_5','Admin'),(3,1,'Station_4','Admin'),(4,1,'Station_3','Admin'),(5,1,'Station_2','Admin'),(6,1,'Station_1','Admin');
/*!40000 ALTER TABLE `Stations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `StationsAssemblyStepss`
--

DROP TABLE IF EXISTS `StationsAssemblyStepss`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `StationsAssemblyStepss` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StationId` int(11) DEFAULT NULL,
  `AssemblyStepId` int(11) DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL DEFAULT current_timestamp(6),
  `LatestUser` longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT 'Admin',
  PRIMARY KEY (`Id`),
  KEY `IX_StationsAssemblyStepss_AssemblyStepId` (`AssemblyStepId`),
  KEY `IX_StationsAssemblyStepss_StationId` (`StationId`),
  CONSTRAINT `FK_StationsAssemblyStepss_AssemblySteps_AssemblyStepId` FOREIGN KEY (`AssemblyStepId`) REFERENCES `AssemblySteps` (`Id`),
  CONSTRAINT `FK_StationsAssemblyStepss_Stations_StationId` FOREIGN KEY (`StationId`) REFERENCES `Stations` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `StationsAssemblyStepss`
--

LOCK TABLES `StationsAssemblyStepss` WRITE;
/*!40000 ALTER TABLE `StationsAssemblyStepss` DISABLE KEYS */;
INSERT INTO `StationsAssemblyStepss` VALUES (1,5,1,'2019-12-23 12:32:33.405050','Admin'),(2,1,3,'2019-12-23 12:32:33.405050','Admin'),(3,2,2,'2019-12-23 12:32:33.405050','Admin'),(4,3,2,'2019-12-23 12:32:33.405050','Admin'),(5,4,2,'2019-12-23 12:32:33.405050','Admin'),(6,6,1,'2019-12-23 12:32:33.405050','Admin');
/*!40000 ALTER TABLE `StationsAssemblyStepss` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20191220141905_InitialMigration','3.1.0'),('20191223110648_AddStationsProperty','3.1.0'),('20191223111110_FixedStationProperty','3.1.0'),('20191223121806_AddedStationProductRelationship','3.1.0'),('20191223123132_AddedShadowProperties','3.1.0');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-23 12:35:35
