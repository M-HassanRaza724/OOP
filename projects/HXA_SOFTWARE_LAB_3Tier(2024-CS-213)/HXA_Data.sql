-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: hxa
-- ------------------------------------------------------
-- Server version	8.0.40

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES ('ali@gmail.com','HXA_ali@gmail.com_1','Web Development','Web','$20000 - $50000','02/01/2024 to 04/01/2024','A simple light theme web site for my stationary store','1','35000','Statinary Store'),('ali@gmail.com','HXA_ali@gmail.com_2','Data Analytics','Cross-platform','<$5000','12/12/2024 to 25/12/2024','Built a dashboard for analyzing sales across multiple regions','0','','');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `reviews`
--

LOCK TABLES `reviews` WRITE;
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
INSERT INTO `reviews` VALUES ('Jane Smith','5','September 25, 2024','I hired them for a website development project...'),('John Doe','5','October 12, 2024','The software house delivered beyond expectations...'),('Robert Lee','5','August 10, 2024','They delivered the app on time...');
/*!40000 ALTER TABLE `reviews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
INSERT INTO `services` VALUES ('Custom Software Development','Our team creates custom...','C++;Java;Python;.NET','Business applications;enterprise software;process automation;custom tool development'),('IT Consulting and Support','We provide expert IT consulting...','','Regular maintenance;updates;troubleshooting;tech support'),('Mobile App Development','We specialize in developing...','Swift;Kotlin;Flutter;React Native','Business apps;social networking apps;gaming apps;utility apps'),('Quality Assurance & Testing','We conduct rigorous testing...','','Functional testing;performance testing;security testing;automation testing'),('UI/UX Design','We craft intuitive, aesthetic...','User research;wireframing;prototyping;testing','App design;web design;brand identity;product design'),('Web Development','We build responsive, scalable...','HTML5;CSS3;JavaScript;React;Node.js;PHP','E-commerce sites;CMS solutions;landing pages;corporate websites');
/*!40000 ALTER TABLE `services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('admin','admin@gmail.com','pass123#','admin'),('ali','ali@gmail.com','pass123#','customer'),('hassan','hassan@gmail.com','pass123#','customer');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-24 23:02:40
