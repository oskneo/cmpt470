-- MySQL dump 10.13  Distrib 5.5.59, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: cmpt470finaldb
-- ------------------------------------------------------
-- Server version	5.5.59-0ubuntu0.14.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Answers`
--

DROP TABLE IF EXISTS `Answers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Answers` (
  `AnswerId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `QId` int(10) unsigned NOT NULL,
  `RefAId` int(10) unsigned NOT NULL,
  `Reply` longtext NOT NULL,
  `Time` datetime NOT NULL,
  `UserName` longtext,
  `FileName` longtext,
  `FilePath` longtext,
  `FileUploaded` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`AnswerId`),
  KEY `IX_Answers_QId` (`QId`),
  CONSTRAINT `FK_Answers_Questions_QId` FOREIGN KEY (`QId`) REFERENCES `Questions` (`QId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Answers`
--

LOCK TABLES `Answers` WRITE;
/*!40000 ALTER TABLE `Answers` DISABLE KEYS */;
INSERT INTO `Answers` VALUES (1,2,0,'dsfafagrga','2018-03-30 00:04:08','01012bbe-3687-4bd1-9f46-62df38c0d78c',NULL,NULL,'\0'),(2,1,0,'You can take the skytrain','2018-03-30 00:08:00','4b7c809f-2a57-4871-a1c5-a1e28c126bbc',NULL,NULL,'\0'),(3,4,0,'esfsdf','2018-03-30 02:31:58','725eda2e-92dc-43c7-add6-dd142182930a',NULL,NULL,'\0'),(4,5,0,'wrwer','2018-03-30 02:44:00','725eda2e-92dc-43c7-add6-dd142182930a',NULL,NULL,'\0'),(5,5,4,'wewrr','2018-03-30 02:44:12','725eda2e-92dc-43c7-add6-dd142182930a',NULL,NULL,'\0'),(6,6,0,'ddse','2018-03-30 02:51:19','725eda2e-92dc-43c7-add6-dd142182930a',NULL,NULL,'\0'),(7,7,0,'dfsfdf','2018-04-04 09:05:15','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(10,10,0,'gdgsg','2018-04-05 02:01:25','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(11,10,10,'re5yt','2018-04-05 02:01:30','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(12,10,0,'dsfsg','2018-04-05 02:01:36','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(13,10,10,'dfssg','2018-04-05 02:01:49','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(14,7,0,'dfghd','2018-04-05 02:07:45','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(15,7,14,'gfgdh','2018-04-05 02:07:50','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(16,10,11,'dgh','2018-04-05 02:10:47','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(17,12,0,'ery','2018-04-05 02:11:00','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(18,26,0,'sfsf','2018-04-05 02:43:59','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(19,26,0,'faff','2018-04-05 02:44:08','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(20,26,19,'afe','2018-04-05 02:44:14','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(21,27,0,'klmlm','2018-04-05 02:56:13','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(22,27,0,'klmlm','2018-04-05 02:56:14','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(23,26,0,'mlmk','2018-04-05 02:56:25','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(24,26,19,'mlkm','2018-04-05 02:56:48','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(25,27,0,'vyv','2018-04-05 02:57:05','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL,NULL,'\0'),(26,1,2,'Oh cool','2018-04-06 11:38:11','agassic',NULL,NULL,'\0'),(27,1,0,'Try this','2018-04-06 11:38:18','agassic',NULL,NULL,'\0'),(28,1,27,'try more','2018-04-06 16:41:34','daniel',NULL,NULL,'\0'),(29,1,2,'yes','2018-04-06 17:07:38','daniel',NULL,NULL,'\0'),(30,1,26,'Is is ok now?','2018-04-06 23:05:26','c111',NULL,NULL,'\0'),(31,1,30,'no','2018-04-07 02:49:51','daniel',NULL,NULL,'\0'),(37,30,0,'vbcb','2018-04-07 14:11:53','m111',NULL,NULL,'\0'),(38,1,29,'Try to show image.','2018-04-07 14:12:34','m111','??? (2016_03_27 09_23_35 UTC).gif','files/??? (2016_03_27 09_23_35 UTC).gif',''),(39,1,38,'try this','2018-04-07 15:24:59','m111','shopbot.gif (2016_03_27 09_23_35 UTC).png','files/shopbot.gif (2016_03_27 09_23_35 UTC).png',''),(40,1,38,'try this','2018-04-07 15:24:59','m111','shopbot.gif (2016_03_27 09_23_35 UTC).png','files/shopbot.gif (2016_03_27 09_23_35 UTC).png',''),(41,1,0,'Look!','2018-04-09 02:03:35','agassic','Desktop - SolarSystem.jpg','files/Desktop - SolarSystem.jpg',''),(42,1,2,'asdf','2018-04-10 06:47:52','daniel',NULL,NULL,'\0');
/*!40000 ALTER TABLE `Answers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetRoleClaims`
--

DROP TABLE IF EXISTS `AspNetRoleClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetRoleClaims` (
  `Id` int(11) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  `RoleId` varchar(127) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetRoleClaims`
--

LOCK TABLES `AspNetRoleClaims` WRITE;
/*!40000 ALTER TABLE `AspNetRoleClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetRoleClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetRoles`
--

DROP TABLE IF EXISTS `AspNetRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetRoles` (
  `Id` varchar(127) NOT NULL,
  `ConcurrencyStamp` longtext,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetRoles`
--

LOCK TABLES `AspNetRoles` WRITE;
/*!40000 ALTER TABLE `AspNetRoles` DISABLE KEYS */;
INSERT INTO `AspNetRoles` VALUES ('aee05c05-5bec-4135-ad35-614d1123100e','b633df60-8e6c-49cf-8b22-1dccd0977941','Admin','ADMIN'),('ea6befb4-10da-4c01-86d5-44095492dc23','3b179cc1-49d0-4c8e-9946-aba5b2a5e46a','Student','STUDENT');
/*!40000 ALTER TABLE `AspNetRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserClaims`
--

DROP TABLE IF EXISTS `AspNetUserClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserClaims` (
  `Id` int(11) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  `UserId` varchar(127) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserClaims`
--

LOCK TABLES `AspNetUserClaims` WRITE;
/*!40000 ALTER TABLE `AspNetUserClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserLogins`
--

DROP TABLE IF EXISTS `AspNetUserLogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(127) NOT NULL,
  `ProviderKey` varchar(127) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(127) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserLogins`
--

LOCK TABLES `AspNetUserLogins` WRITE;
/*!40000 ALTER TABLE `AspNetUserLogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserLogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserRoles`
--

DROP TABLE IF EXISTS `AspNetUserRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(127) NOT NULL,
  `RoleId` varchar(127) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserRoles`
--

LOCK TABLES `AspNetUserRoles` WRITE;
/*!40000 ALTER TABLE `AspNetUserRoles` DISABLE KEYS */;
INSERT INTO `AspNetUserRoles` VALUES ('01012bbe-3687-4bd1-9f46-62df38c0d78c','aee05c05-5bec-4135-ad35-614d1123100e'),('2fea5226-7f27-43ee-bd8b-41c9acee632f','aee05c05-5bec-4135-ad35-614d1123100e'),('4b7c809f-2a57-4871-a1c5-a1e28c126bbc','aee05c05-5bec-4135-ad35-614d1123100e'),('588af858-4652-4e68-879c-aa228637f056','aee05c05-5bec-4135-ad35-614d1123100e'),('8068c516-280b-4489-9886-a3e4c7803cbe','aee05c05-5bec-4135-ad35-614d1123100e'),('91cbfd9c-3d9c-4437-aa2b-12148ef57669','aee05c05-5bec-4135-ad35-614d1123100e'),('c33aebca-44e1-434a-9c63-bc7ce9dd195d','aee05c05-5bec-4135-ad35-614d1123100e'),('d495db3f-7361-4840-ae18-4345c6fa10cc','aee05c05-5bec-4135-ad35-614d1123100e'),('f20266e0-2331-4abe-b650-7692021f4c28','aee05c05-5bec-4135-ad35-614d1123100e'),('0d682168-9b53-4b5b-9646-59d79740b5db','ea6befb4-10da-4c01-86d5-44095492dc23'),('27e63e90-6aa2-4ac2-b74d-e108ac8c7735','ea6befb4-10da-4c01-86d5-44095492dc23'),('638ea80b-011e-497f-b82a-4259fe831eaf','ea6befb4-10da-4c01-86d5-44095492dc23'),('725eda2e-92dc-43c7-add6-dd142182930a','ea6befb4-10da-4c01-86d5-44095492dc23'),('74a21881-c903-4074-b2fc-1f0fb0806c04','ea6befb4-10da-4c01-86d5-44095492dc23'),('7e85d3ae-e59b-4fcb-a96f-503e129c46a3','ea6befb4-10da-4c01-86d5-44095492dc23');
/*!40000 ALTER TABLE `AspNetUserRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserTokens`
--

DROP TABLE IF EXISTS `AspNetUserTokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(127) NOT NULL,
  `LoginProvider` varchar(127) NOT NULL,
  `Name` varchar(127) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserTokens`
--

LOCK TABLES `AspNetUserTokens` WRITE;
/*!40000 ALTER TABLE `AspNetUserTokens` DISABLE KEYS */;
INSERT INTO `AspNetUserTokens` VALUES ('588af858-4652-4e68-879c-aa228637f056','[AspNetUserStore]','AuthenticatorKey','2T5VJMS56HN2P37KDS6Q335IAEU6OXRX');
/*!40000 ALTER TABLE `AspNetUserTokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUsers`
--

DROP TABLE IF EXISTS `AspNetUsers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUsers` (
  `Id` varchar(127) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `ConcurrencyStamp` longtext,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `PasswordHash` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `SecurityStamp` longtext,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `StudentId` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUsers`
--

LOCK TABLES `AspNetUsers` WRITE;
/*!40000 ALTER TABLE `AspNetUsers` DISABLE KEYS */;
INSERT INTO `AspNetUsers` VALUES ('01012bbe-3687-4bd1-9f46-62df38c0d78c',0,'683c8cb5-7fb0-4ac9-97ef-2dfa3208fa10','a111@aa.com','\0','',NULL,'A111@AA.COM','A111','AQAAAAEAACcQAAAAEC8BU9+pvDR9ucwoWQ3Q/DwUraGPZaQ42CPxZqmpsK1hkRFE6HOOPPcqQy3KCpIPtg==',NULL,'\0','822ea7d5-c9ea-493a-a9e4-7dc1fdf1b0e5','\0','a111','39874928347'),('0d682168-9b53-4b5b-9646-59d79740b5db',0,'160ecc8e-2a46-42dc-aa55-990853ab99c0','agassic1234@sfu.ca','\0','',NULL,'AGASSIC1234@SFU.CA','AGASSIC1234','AQAAAAEAACcQAAAAEGg+Mz3lk4T8jv39hXcIOI3ojdABtCLbUbFyati6ziTOOxqiAREB7O38Cf1aiOlbkQ==',NULL,'\0','2cf0ab65-6760-4931-b23e-903efd020429','\0','agassic1234','1234567891'),('27e63e90-6aa2-4ac2-b74d-e108ac8c7735',0,'7b87cecf-a4df-4118-a53a-c4fdca329e36','c111@aa.com','\0','',NULL,'C111@AA.COM','C111','AQAAAAEAACcQAAAAEGmTX6JDk09LdwqA9fITpz+FwQ5y95kyECASNKrIy+MxuCk7sOL7dzpamjWhzCw+1g==',NULL,'\0','fedad404-053a-4fd0-9f35-fbd21fe90347','\0','c111','3432525'),('2fea5226-7f27-43ee-bd8b-41c9acee632f',0,'e461dad3-ec76-4762-8426-4638c93560f6','gza21@sfu.ca','\0','',NULL,'GZA21@SFU.CA','FRANCESCO6','AQAAAAEAACcQAAAAEMJpMsJu6jm/U0hWVHr7dh0q2cqR7GTL1xouzrT0aCtL3Jcb8LoilhAT+Abyj+J9rw==',NULL,'\0','868024e9-5a43-4849-838a-92e4dfd7a3dd','\0','francesco6','453436'),('4b7c809f-2a57-4871-a1c5-a1e28c126bbc',0,'4e963e0e-156a-491c-885f-85374ea4a2d3','agassic@sfu.ca','\0','',NULL,'AGASSIC@SFU.CA','AGASSIC','AQAAAAEAACcQAAAAEMzDYAlbdEi4PCjxGG3d6ivKBKjpKMgZiobUYiE7cngnjphBOchKbfPn3CP7ljEoWA==',NULL,'\0','8a4f9a25-1fcf-4229-b505-09f8fdeba127','\0','agassic','123456789'),('588af858-4652-4e68-879c-aa228637f056',0,'74cf7371-3ead-403a-82c3-c924a2ed2f4e','danielpeng@live.ca','\0','',NULL,'DANIELPENG@LIVE.CA','DANIEL','AQAAAAEAACcQAAAAEEnY4xOlJz7ZNm8Yki24k7wEycJ4LwwwCQJronH7NIpqiR1deJDmAhBhaEUvUryO1g==',NULL,'\0','464626a2-5f66-45e8-bf53-ce9613ce3192','\0','daniel','123456789'),('638ea80b-011e-497f-b82a-4259fe831eaf',0,'e7496ac1-eb4e-4231-9c83-80b8e97a4c81','omg@sfu.ca','\0','',NULL,'OMG@SFU.CA','DP-NA','AQAAAAEAACcQAAAAEIDrjre3jgw8iT07xFzX0uVsXARGWkvU89Ym1woTKTrZSpckF3hKhLQMnvVSR1MyLg==',NULL,'\0','e797dc70-5546-4417-bccd-34adbf8f1334','\0','DP-NA','1223344889'),('725eda2e-92dc-43c7-add6-dd142182930a',0,'536d1f07-a1e2-4238-ae93-2d14b841c5e0','m111@uu.com','\0','',NULL,'M111@UU.COM','M111','AQAAAAEAACcQAAAAEDqGkK6g1IoXkZFRJRYzfx0xH9mkY+8n1KyPSRKkpYcPOKyVre/rDnnaSRdgeRnKZw==','111111111','\0','8fdd842d-c2d4-48bd-980c-5c5a78a2112f','\0','m111',NULL),('74a21881-c903-4074-b2fc-1f0fb0806c04',0,'058a2cc1-442a-44a2-beac-ed402f5b7eb3','agassic12345@sfu.ca','\0','',NULL,'AGASSIC12345@SFU.CA','AGASSIC12345','AQAAAAEAACcQAAAAEHqrKmWydrh0CLhyaBZwimPJgG/TewySK7ISNYEQC/2fFUb38VWCX6em0oRfTqvM0g==',NULL,'\0','b2db0907-d509-4147-bdc4-9ab35b1b6f7f','\0','agassic12345','1234567891'),('7e85d3ae-e59b-4fcb-a96f-503e129c46a3',0,'ac66fe4d-45c7-4c8f-9c55-78172b1b2150','agassicheung1222@gmail.com','\0','',NULL,'AGASSICHEUNG1222@GMAIL.COM','AGASSI','AQAAAAEAACcQAAAAEKGTdtM0Hdmzr1WWVBLYEyL1aFwg7TaWhY8PZh0+6DEqjY/5iXujEzCMeFMFY1yxNw==',NULL,'\0','939afde6-516a-4a6d-84ab-8cdfac62ff41','\0','agassi',NULL),('8068c516-280b-4489-9886-a3e4c7803cbe',0,'be033d2e-8fac-4203-b704-c66f45b3a71f','t112@aa.oo','\0','',NULL,'T112@AA.OO','T112','AQAAAAEAACcQAAAAEJcG2jx8aDZgTRry+I4LTGfKoliJGEvAbhBCsbOTxW0mjlb1mhAeOU3iH4pvc2un0Q==',NULL,'\0','31067016-4e04-4521-a3bd-2f75450fefe1','\0','t112','345435'),('91cbfd9c-3d9c-4437-aa2b-12148ef57669',0,'32236e45-e42e-4d0a-8969-e6514332dfa8','q222@ss.com','\0','',NULL,'Q222@SS.COM','Q222','AQAAAAEAACcQAAAAEN4pievsUMF/3BwnnA751XYuT6UYMv3IdCmhLy1Zzt+Di//oEa/61dEi/pmvkEqK/g==',NULL,'\0','d29295a6-cd7e-4e0c-96f1-2990525a3970','\0','q222','3543543'),('c33aebca-44e1-434a-9c63-bc7ce9dd195d',0,'e3de8d8b-50d5-4a02-b701-bbcd7f85d797','tt@aa.com','\0','',NULL,'TT@AA.COM','TT','AQAAAAEAACcQAAAAEG+UjVN9rjCXPbBCFK6mmc/zm5HWCldSQo9WLVBCYgJCgVWIpJmMnPqbI4b3v+z5xQ==',NULL,'\0','f58f0e5c-3127-4832-b20c-1cb176684082','\0','tt','4536356'),('d495db3f-7361-4840-ae18-4345c6fa10cc',0,'89694346-64b2-4d52-b3e0-e5d9e689cd36','t111@aa.com','\0','',NULL,'T111@AA.COM','T111','AQAAAAEAACcQAAAAEMH5loIOgDvZ7YEUlupw9DBvrtFDqdxaIk9UEnGqnJBfvaqRXddNoMI8843oHwqnDA==',NULL,'\0','d2d9bea9-7ed9-4b29-9338-8d62fc4cec89','\0','t111','53452'),('f20266e0-2331-4abe-b650-7692021f4c28',0,'b8708213-bd17-4e45-b9e9-c6835bad9de7','dpdpdp@123.com','\0','',NULL,'DPDPDP@123.COM','DANIELPENG','AQAAAAEAACcQAAAAECtbmI5H7AMCM7PbSxc8QiB8Xujw2odcSwsiWYlGd8T5I0ZWJ/zzZBxzFI4Koj4j0Q==',NULL,'\0','623ee5f6-4eaf-4fb9-a41d-89daedd910cb','\0','DanielPeng','123213213');
/*!40000 ALTER TABLE `AspNetUsers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Courses`
--

DROP TABLE IF EXISTS `Courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Courses` (
  `CourseId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CourseNumber` longtext,
  `Department` longtext,
  `Description` longtext,
  `Instructor` longtext,
  `Semester` longtext,
  `Session` longtext,
  `Year` int(10) unsigned NOT NULL,
  PRIMARY KEY (`CourseId`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Courses`
--

LOCK TABLES `Courses` WRITE;
/*!40000 ALTER TABLE `Courses` DISABLE KEYS */;
INSERT INTO `Courses` VALUES (1,'470','CMPT','CMPT 470 Offered at Harbour Center ','Lisa Tang','Spring 2018','D100',2018),(2,'102','CMPT','CMPT 102 Offered at SFU Burnaby','Kambiz Haji Hajikolaei ','Spring 2018','D100',2018),(3,'120','CMPT','CMPT 120 Offered at SFU Burnaby','Angelica Lim ','Spring 2018','D100',2018),(4,'125','CMPT','CMPT 125 Offered at SFU Burnaby','Bobby Chan ','Spring 2018','D100',2018),(5,'127','CMPT','CMPT 127 Offered at SFU Burnaby','Richard Vaughan ','Spring 2018','D100',2018),(6,'129','CMPT','CMPT 129 Offered at SFU Burnaby','Brad Bart ','Spring 2-18','D100',2018),(7,'129','CMPT','CMPT 129 Offered at SFU Burnaby','Brad Bart ','Spring 2018','D100',2018),(8,'135','CMPT','CMPT 135 Offered at SFU Surrey','John Edgar ','Spring 2018','D100',2018),(9,'165','CMPT','CMPT 165 Offered at SFU Surrey','Liaqat Ali ','Spring 2018','D100',2018),(10,'166','CMPT','CMPT 166 Offered at SFU Surrey','Harinder Khangura ','Spring 2018','D100',2018),(11,'213','CMPT','CMPT 213 Offered at SFU Surrey','Brian Fraser','Spring 2018','D100',2018),(12,'218','CMPT','CMPT 218 Offered at SFU Burnaby','Bobby Chan','Spring 2018','D100',2018),(13,'225','CMPT','CMPT 225 Offered at SFU Burnaby','David Mitchell ','Spring 2018','D100',2018),(14,'276','CMPT','CMPT 276 Offered at SFU Burnaby','Brian Fraser ','Spring 2018','D100',2018),(15,'295','CMPT','CMPT 295 Offered at SFU Burnaby','Brad Bart','Spring 2018','D100',2018),(16,'300','CMPT','CMPT 300 Offered at SFU Burnaby','Keval Vora ','Spring 2018','D100',2018),(17,'307','CMPT','CMPT 307 Offered at SFU Burnaby','Valentine Kabanets ','Spring 2018','D100',2018),(18,'310','CMPT','CMPT 310 Offered at SFU Burnaby','Oliver Schulte','Spring 2018','D100',2018),(19,'320','CMPT','CMPT 320 Offered at Harbour Center ','Herbert Tsang ','Spring 2018','E100',2018),(20,'322','CMPT','CMPT 322 Offered at SFU Surrey','John Edgar ','Spring 2018','D100',2018),(21,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ',NULL,'spring','d103',2017),(22,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ',NULL,'summer','d102',2016),(23,'100','chin','Introduction to the study of Mandarin Chinese and to the development of basic oral and written skills for those with no background in Mandarin. Students will study phonetics, vocabulary, syntax, grammar and culture.','Billie Ng','spring','d300',2017),(24,'755','chem','An advanced treatment of strategy in organic synthesis. The principles and use of modern synthetic methodology.',NULL,'fall','g100',2017),(25,'100','chin','Introduction to the study of Mandarin Chinese and to the development of basic oral and written skills for those with no background in Mandarin. Students will study phonetics, vocabulary, syntax, grammar and culture.','Billie Ng','spring','d100',2016),(26,'100','chin','Introduction to the study of Mandarin Chinese and to the development of basic oral and written skills for those with no background in Mandarin. Students will study phonetics, vocabulary, syntax, grammar and culture.','Billie Ng','spring','d300',2016),(27,'100','chin','Introduction to the study of Mandarin Chinese and to the development of basic oral and written skills for those with no background in Mandarin. Students will study phonetics, vocabulary, syntax, grammar and culture.','Billie Ng','spring','e100',2016),(28,'100','chin','Introduction to the study of Mandarin Chinese and to the development of basic oral and written skills for those with no background in Mandarin. Students will study phonetics, vocabulary, syntax, grammar and culture.','Billie Ng','spring','d200',2016),(29,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ','Anne Lavergne','spring','d103',2017),(30,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ','Anne Lavergne','spring','d100',2017),(31,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ','Anne Lavergne','spring','d102',2017),(32,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ','Anne Lavergne','spring','d106',2017),(33,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ','Anne Lavergne','spring','d101',2017),(34,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ','Anne Lavergne','spring','d104',2017),(35,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ','Anne Lavergne','spring','d105',2017),(36,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ','Anne Lavergne','spring','d107',2017),(37,'120','cmpt','An elementary introduction to computing science and computer programming, suitable for students with little or no programming background. Students will learn fundamental concepts and terminology of computing science, acquire elementary skills for programming in a high-level language and be exposed to diverse fields within, and applications of computing science. Topics will include: pseudocode, data types and control structures, fundamental algorithms, computability and complexity, computer architecture, and history of computing science. Treatment is informal and programming is presented as a problem-solving tool. ','Anne Lavergne','spring','d108',2017),(38,'470','cogs','Third term of work experience in the Cognitive Science Co-operative Education Program. Students should apply to the Faculty of Arts co-operative education co-ordinator by the end of the third week of the term preceding the employment term. Units from this course do not count towards the units required for an SFU degree. ','Suzanne Stanley','spring','d200',2016),(39,'470','cogs','Third term of work experience in the Cognitive Science Co-operative Education Program. Students should apply to the Faculty of Arts co-operative education co-ordinator by the end of the third week of the term preceding the employment term. Units from this course do not count towards the units required for an SFU degree. ','Suzanne Stanley','spring','d100',2016),(40,'fgfdg','fgfd','fdgdfg','fdgfg','gsdgf','fdgf',1324),(41,'gsfvg','hbg','bgf','bfbgdxc','fdgdf','vcxfdv',453),(42,'hklhlk','kjhnkl','hlklh','hklhlk','dfvdv','hlkhlk',35435);
/*!40000 ALTER TABLE `Courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Events`
--

DROP TABLE IF EXISTS `Events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Events` (
  `EventId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Date` datetime NOT NULL,
  `Description` longtext NOT NULL,
  `Location` longtext NOT NULL,
  `NumberOfSeats` int(11) NOT NULL,
  `Time` datetime NOT NULL,
  `Title` longtext NOT NULL,
  `OccupiedSeats` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`EventId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Events`
--

LOCK TABLES `Events` WRITE;
/*!40000 ALTER TABLE `Events` DISABLE KEYS */;
INSERT INTO `Events` VALUES (1,'2018-03-08 00:00:00','slefjlak','sdkfjklsjf',11,'2018-03-30 00:00:00','Abcd',4),(2,'2018-04-10 00:00:00','STUDY FOR FINAL','BURNABY',8,'2018-04-06 00:12:00','CMPT123 FINAL',2),(3,'2018-03-05 00:00:00','STUDY FOR MIDTERM','SURRY',5,'2018-04-06 12:03:00','CMPT223 MID',1),(4,'2018-04-10 00:00:00','adfa','Downtown',5,'2018-04-06 14:00:00','CMPT234',0),(5,'2018-04-08 00:00:00','dfgdf','dgdhhj',7,'2018-04-08 00:00:00','srgesrg',7),(6,'2018-04-14 00:00:00','Galkjdsfhlkajsdf','Burnaby Campus',7,'2018-04-08 12:31:00','Event',7),(7,'2018-04-04 00:00:00','fgdfg','jhyj',11,'2018-04-08 00:00:00','fgrdrfg',0),(8,'2018-01-01 00:00:00','fgd','ghfg',44,'2018-04-08 00:00:00','gfdg',0),(9,'2018-01-01 00:00:00','fdgdg','fgdx',33,'2018-04-08 00:00:00','grfdsg',0),(10,'2018-01-01 00:00:00','hgfhd','ghgvf',3,'2018-04-08 00:00:00','fdgdf',0),(11,'2019-01-01 00:00:00','event','event',31,'2018-04-08 00:01:00','event',0),(12,'2018-04-13 00:00:00','asdf','bby',2,'2018-04-10 04:56:00','asdf',0);
/*!40000 ALTER TABLE `Events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Files`
--

DROP TABLE IF EXISTS `Files`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Files` (
  `FileId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Date` datetime NOT NULL,
  `Description` longtext NOT NULL,
  `File` longblob NOT NULL,
  `FileName` longtext NOT NULL,
  `Size` int(11) NOT NULL,
  `Time` datetime NOT NULL,
  `UserId` varchar(127) DEFAULT NULL,
  `AnswerId` int(10) unsigned NOT NULL DEFAULT '0',
  `CourseId` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`FileId`),
  KEY `IX_Files_UserId` (`UserId`),
  CONSTRAINT `FK_Files_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Files`
--

LOCK TABLES `Files` WRITE;
/*!40000 ALTER TABLE `Files` DISABLE KEYS */;
/*!40000 ALTER TABLE `Files` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Questions`
--

DROP TABLE IF EXISTS `Questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Questions` (
  `QId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CourseId` int(10) unsigned NOT NULL,
  `Description` longtext NOT NULL,
  `Time` datetime NOT NULL,
  `Title` longtext NOT NULL,
  `UserId` varchar(127) DEFAULT NULL,
  `UserName` longtext,
  PRIMARY KEY (`QId`),
  KEY `IX_Questions_CourseId` (`CourseId`),
  KEY `IX_Questions_UserId` (`UserId`),
  CONSTRAINT `FK_Questions_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE NO ACTION,
  CONSTRAINT `FK_Questions_Courses_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `Courses` (`CourseId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Questions`
--

LOCK TABLES `Questions` WRITE;
/*!40000 ALTER TABLE `Questions` DISABLE KEYS */;
INSERT INTO `Questions` VALUES (1,1,'How do you get to Harbour Center','2018-03-30 00:03:44','Question 1','0d682168-9b53-4b5b-9646-59d79740b5db',NULL),(2,1,'dfsdgsdg','2018-03-30 00:03:46','sfdsf','01012bbe-3687-4bd1-9f46-62df38c0d78c',NULL),(3,1,'jgjgkmgk','2018-03-30 01:18:34','hgkgj','01012bbe-3687-4bd1-9f46-62df38c0d78c',NULL),(4,1,'khkh','2018-03-30 02:31:47','k,hkh','725eda2e-92dc-43c7-add6-dd142182930a',NULL),(5,1,'eqrqf','2018-03-30 02:43:53','qefqf','725eda2e-92dc-43c7-add6-dd142182930a',NULL),(6,1,'rdrsers','2018-03-30 02:51:10','dcszdad','725eda2e-92dc-43c7-add6-dd142182930a',NULL),(7,11,'dsgdg','2018-04-03 10:58:44','dfsf','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(8,2,'dhdh','2018-04-03 14:22:28','dfsf','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(9,2,'safafa','2018-04-03 14:23:05','kljkljv','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(10,11,'dsfss','2018-04-03 14:24:00','fdhdfg','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(11,11,'ghdd','2018-04-03 14:24:12','gfhh','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(12,11,'fjfjf','2018-04-05 02:10:55','ryey','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(13,34,'dsghdh','2018-04-05 02:11:32','rtete','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(14,34,'dsghdh','2018-04-05 02:11:50','rtete','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(15,34,'dsghdh','2018-04-05 02:11:55','rtete','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(16,34,'rhty','2018-04-05 02:12:14','fgdhd','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(17,23,'esrgry','2018-04-05 02:12:52','wrwerwt','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(18,23,'rettwr','2018-04-05 02:13:28','gsgsr','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(19,33,'tg44','2018-04-05 02:18:21','frfe','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(20,35,'gerge','2018-04-05 02:22:42','ergeg','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(21,35,'eh','2018-04-05 02:25:50','erg','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(22,29,'23rr','2018-04-05 02:28:06','dqdqd','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(23,29,'23rr','2018-04-05 02:28:58','dqdqd','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(24,29,'3fgg','2018-04-05 02:34:41','faff','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(25,29,'rsggsr','2018-04-05 02:40:02','dfsf','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(26,36,'resgsg','2018-04-05 02:43:52','zvz','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(27,36,'eafrr','2018-04-05 02:44:25','affa','d495db3f-7361-4840-ae18-4345c6fa10cc',NULL),(28,1,'sfdg','2018-04-06 11:08:58','sfdg','588af858-4652-4e68-879c-aa228637f056','daniel'),(29,1,'asdfasdf','2018-04-06 11:09:36','adsf','588af858-4652-4e68-879c-aa228637f056','daniel'),(30,39,'vgbcdb','2018-04-07 13:53:47','fgdg','c33aebca-44e1-434a-9c63-bc7ce9dd195d','tt'),(31,1,'adf','2018-04-10 06:50:34','adf','588af858-4652-4e68-879c-aa228637f056','daniel');
/*!40000 ALTER TABLE `Questions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `QuizQuestions`
--

DROP TABLE IF EXISTS `QuizQuestions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `QuizQuestions` (
  `QuizQuestionId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `AnswerA` longtext NOT NULL,
  `AnswerB` longtext NOT NULL,
  `AnswerC` longtext NOT NULL,
  `AnswerD` longtext NOT NULL,
  `CorrectAnswer` tinyint(3) unsigned NOT NULL,
  `Finished` bit(1) NOT NULL,
  `Index` int(10) unsigned NOT NULL,
  `Question` longtext NOT NULL,
  `QuizId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`QuizQuestionId`),
  KEY `IX_QuizQuestions_QuizId` (`QuizId`),
  CONSTRAINT `FK_QuizQuestions_Quizs_QuizId` FOREIGN KEY (`QuizId`) REFERENCES `Quizs` (`QuizId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `QuizQuestions`
--

LOCK TABLES `QuizQuestions` WRITE;
/*!40000 ALTER TABLE `QuizQuestions` DISABLE KEYS */;
INSERT INTO `QuizQuestions` VALUES (29,'2','3','4','5',65,'\0',1,'1+1',27),(30,'4','5','6','7',65,'\0',2,'1+3',27),(31,'3','4','5','6',66,'\0',3,'2+2',27),(32,'9','8','7','6',67,'\0',4,'5+2',27),(33,'5','6','7','8',65,'',5,'2+3',27),(34,'F','F','F','T',68,'\0',1,'fdasa  D',28),(35,'F','F','T','F',67,'',2,'C',28),(36,'fdgf','bf','fbf','fbvxd',67,'',1,'gfsdg',29),(37,'2','3','4','5',65,'\0',1,'1+1',31),(38,'6','7','8','9',65,'\0',2,'1+1+3+1',31),(39,'8','5','6','4',68,'',3,'2+2',31);
/*!40000 ALTER TABLE `QuizQuestions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Quizs`
--

DROP TABLE IF EXISTS `Quizs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Quizs` (
  `QuizId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CourseId` int(10) unsigned NOT NULL,
  `Date` datetime NOT NULL,
  `Description` longtext NOT NULL,
  `Title` longtext NOT NULL,
  PRIMARY KEY (`QuizId`),
  KEY `IX_Quizs_CourseId` (`CourseId`),
  CONSTRAINT `FK_Quizs_Courses_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `Courses` (`CourseId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Quizs`
--

LOCK TABLES `Quizs` WRITE;
/*!40000 ALTER TABLE `Quizs` DISABLE KEYS */;
INSERT INTO `Quizs` VALUES (27,1,'2018-04-07 00:00:00','1+1','1+1'),(28,1,'2018-04-08 00:00:00','jhgf','kjhg'),(29,1,'2018-01-01 00:00:00','fdbz','fgsdfg'),(30,1,'2018-04-22 00:00:00','asdf','asdf'),(31,2,'2018-04-06 00:00:00','1+1+2','1+1');
/*!40000 ALTER TABLE `Quizs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `StudentCourses`
--

DROP TABLE IF EXISTS `StudentCourses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `StudentCourses` (
  `StudentCourseId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CourseId` int(10) unsigned NOT NULL DEFAULT '0',
  `UserId` varchar(127) DEFAULT NULL,
  `GroupNumber` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`StudentCourseId`),
  KEY `IX_StudentCourses_UserId` (`UserId`),
  KEY `IX_StudentCourses_CourseId` (`CourseId`),
  CONSTRAINT `FK_StudentCourses_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE NO ACTION,
  CONSTRAINT `FK_StudentCourses_Courses_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `Courses` (`CourseId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `StudentCourses`
--

LOCK TABLES `StudentCourses` WRITE;
/*!40000 ALTER TABLE `StudentCourses` DISABLE KEYS */;
INSERT INTO `StudentCourses` VALUES (1,1,'0d682168-9b53-4b5b-9646-59d79740b5db',1),(2,1,'01012bbe-3687-4bd1-9f46-62df38c0d78c',1),(3,1,'725eda2e-92dc-43c7-add6-dd142182930a',1),(4,11,'d495db3f-7361-4840-ae18-4345c6fa10cc',1),(5,2,'d495db3f-7361-4840-ae18-4345c6fa10cc',0),(6,10,'d495db3f-7361-4840-ae18-4345c6fa10cc',0),(7,1,'4b7c809f-2a57-4871-a1c5-a1e28c126bbc',1),(8,2,'4b7c809f-2a57-4871-a1c5-a1e28c126bbc',0),(9,23,'4b7c809f-2a57-4871-a1c5-a1e28c126bbc',0),(10,4,'4b7c809f-2a57-4871-a1c5-a1e28c126bbc',0),(11,34,'d495db3f-7361-4840-ae18-4345c6fa10cc',0),(12,23,'d495db3f-7361-4840-ae18-4345c6fa10cc',0),(13,33,'d495db3f-7361-4840-ae18-4345c6fa10cc',0),(14,35,'d495db3f-7361-4840-ae18-4345c6fa10cc',0),(15,29,'d495db3f-7361-4840-ae18-4345c6fa10cc',0),(16,36,'d495db3f-7361-4840-ae18-4345c6fa10cc',0),(17,1,'27e63e90-6aa2-4ac2-b74d-e108ac8c7735',1),(18,17,'4b7c809f-2a57-4871-a1c5-a1e28c126bbc',0),(19,1,'588af858-4652-4e68-879c-aa228637f056',1),(20,3,'588af858-4652-4e68-879c-aa228637f056',0),(21,2,'588af858-4652-4e68-879c-aa228637f056',1),(22,9,'4b7c809f-2a57-4871-a1c5-a1e28c126bbc',0),(23,2,'725eda2e-92dc-43c7-add6-dd142182930a',2),(24,1,'8068c516-280b-4489-9886-a3e4c7803cbe',2),(25,4,'588af858-4652-4e68-879c-aa228637f056',0),(26,2,'f20266e0-2331-4abe-b650-7692021f4c28',0),(27,1,'f20266e0-2331-4abe-b650-7692021f4c28',1),(28,3,'f20266e0-2331-4abe-b650-7692021f4c28',0),(29,1,'c33aebca-44e1-434a-9c63-bc7ce9dd195d',0),(30,39,'c33aebca-44e1-434a-9c63-bc7ce9dd195d',0),(31,39,'725eda2e-92dc-43c7-add6-dd142182930a',0),(32,1,'638ea80b-011e-497f-b82a-4259fe831eaf',0);
/*!40000 ALTER TABLE `StudentCourses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `StudentEvents`
--

DROP TABLE IF EXISTS `StudentEvents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `StudentEvents` (
  `StudentEventId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `EventId` int(10) unsigned NOT NULL,
  `UserId` varchar(127) DEFAULT NULL,
  PRIMARY KEY (`StudentEventId`),
  KEY `IX_StudentEvents_EventId` (`EventId`),
  KEY `IX_StudentEvents_UserId` (`UserId`),
  CONSTRAINT `FK_StudentEvents_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE NO ACTION,
  CONSTRAINT `FK_StudentEvents_Events_EventId` FOREIGN KEY (`EventId`) REFERENCES `Events` (`EventId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `StudentEvents`
--

LOCK TABLES `StudentEvents` WRITE;
/*!40000 ALTER TABLE `StudentEvents` DISABLE KEYS */;
INSERT INTO `StudentEvents` VALUES (1,1,'725eda2e-92dc-43c7-add6-dd142182930a'),(2,1,'27e63e90-6aa2-4ac2-b74d-e108ac8c7735'),(3,1,'4b7c809f-2a57-4871-a1c5-a1e28c126bbc'),(4,2,'588af858-4652-4e68-879c-aa228637f056'),(5,1,'588af858-4652-4e68-879c-aa228637f056'),(6,3,'588af858-4652-4e68-879c-aa228637f056'),(7,2,'725eda2e-92dc-43c7-add6-dd142182930a'),(8,5,'0d682168-9b53-4b5b-9646-59d79740b5db'),(9,5,'01012bbe-3687-4bd1-9f46-62df38c0d78c'),(10,5,'725eda2e-92dc-43c7-add6-dd142182930a'),(11,5,'4b7c809f-2a57-4871-a1c5-a1e28c126bbc'),(12,5,'27e63e90-6aa2-4ac2-b74d-e108ac8c7735'),(13,5,'588af858-4652-4e68-879c-aa228637f056'),(14,5,'f20266e0-2331-4abe-b650-7692021f4c28'),(15,6,'0d682168-9b53-4b5b-9646-59d79740b5db'),(16,6,'01012bbe-3687-4bd1-9f46-62df38c0d78c'),(17,6,'725eda2e-92dc-43c7-add6-dd142182930a'),(18,6,'4b7c809f-2a57-4871-a1c5-a1e28c126bbc'),(19,6,'27e63e90-6aa2-4ac2-b74d-e108ac8c7735'),(20,6,'588af858-4652-4e68-879c-aa228637f056'),(21,6,'f20266e0-2331-4abe-b650-7692021f4c28');
/*!40000 ALTER TABLE `StudentEvents` ENABLE KEYS */;
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
INSERT INTO `__EFMigrationsHistory` VALUES ('00000000000000_CreateIdentitySchema','2.0.1-rtm-125'),('20180320115935_Initial','2.0.1-rtm-125'),('20180320121741_addRoles','2.0.1-rtm-125'),('20180327132141_studentcourse','2.0.1-rtm-125'),('20180327132945_studentcourse2','2.0.1-rtm-125'),('20180327133310_studentcourse3','2.0.1-rtm-125'),('20180327133547_studentcourse4','2.0.1-rtm-125'),('20180327133710_studentcourse5','2.0.1-rtm-125'),('20180327133849_studentcourse6','2.0.1-rtm-125'),('20180327134353_studentcourse7','2.0.1-rtm-125'),('20180327134614_studentcourse8','2.0.1-rtm-125'),('20180327142044_studentId','2.0.1-rtm-125'),('20180327155058_addcourse','2.0.1-rtm-125'),('20180327175817_CourseId','2.0.1-rtm-125'),('20180327234048_question','2.0.1-rtm-125'),('20180327235614_answer','2.0.1-rtm-125'),('20180328011810_event','2.0.1-rtm-125'),('20180328011921_studentevent','2.0.1-rtm-125'),('20180328013330_file','2.0.1-rtm-125'),('20180328035602_time','2.0.1-rtm-125'),('20180328103608_answer2','2.0.1-rtm-125'),('20180328124451_none','2.0.1-rtm-125'),('20180403152027_newfile','2.0.1-rtm-125'),('20180403191003_group','2.0.1-rtm-125'),('20180405052632_eventseat','2.0.1-rtm-125'),('20180405182256_quiz','2.0.1-rtm-125'),('20180406025935_questionanserUsername','2.0.1-rtm-125'),('20180406031358_questionUsername','2.0.1-rtm-125'),('20180406034119_answerfile','2.0.1-rtm-125'),('20180407002508_quizmodel','2.0.1-rtm-125'),('20180407074557_file3','2.0.1-rtm-125');
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

-- Dump completed on 2018-04-11  3:16:55
