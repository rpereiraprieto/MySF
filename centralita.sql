CREATE DATABASE  IF NOT EXISTS `GestionTelefonica` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `GestionTelefonica`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: 192.168.0.112    Database: GestionTelefonica
-- ------------------------------------------------------
-- Server version	5.5.28-1

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
-- Table structure for table `Agendas`
--

DROP TABLE IF EXISTS `Agendas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Agendas` (
  `id` int(11) NOT NULL,
  `Nombre` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Agendas`
--

LOCK TABLES `Agendas` WRITE;
/*!40000 ALTER TABLE `Agendas` DISABLE KEYS */;
/*!40000 ALTER TABLE `Agendas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Callers`
--

DROP TABLE IF EXISTS `Callers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Callers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `idEmpresa` int(11) NOT NULL DEFAULT '1',
  `idGrupo` int(11) NOT NULL DEFAULT '1',
  `idAgenda` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `Grupos` (`idGrupo`),
  KEY `FK_Callers_Empresas` (`idEmpresa`),
  CONSTRAINT `FK_Callers_Empresas` FOREIGN KEY (`idEmpresa`) REFERENCES `Empresas` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Grupos` FOREIGN KEY (`idGrupo`) REFERENCES `Grupos` (`idGrupos`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Callers`
--

LOCK TABLES `Callers` WRITE;
/*!40000 ALTER TABLE `Callers` DISABLE KEYS */;
/*!40000 ALTER TABLE `Callers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Empresas`
--

DROP TABLE IF EXISTS `Empresas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Empresas` (
  `id` int(11) NOT NULL,
  `Nombre` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Empresas`
--

LOCK TABLES `Empresas` WRITE;
/*!40000 ALTER TABLE `Empresas` DISABLE KEYS */;
INSERT INTO `Empresas` VALUES (1,'Sin empresa');
/*!40000 ALTER TABLE `Empresas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Extensiones`
--

DROP TABLE IF EXISTS `Extensiones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Extensiones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre_UNIQUE` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Extensiones`
--

LOCK TABLES `Extensiones` WRITE;
/*!40000 ALTER TABLE `Extensiones` DISABLE KEYS */;
/*!40000 ALTER TABLE `Extensiones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Grupos`
--

DROP TABLE IF EXISTS `Grupos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Grupos` (
  `idGrupos` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idGrupos`),
  UNIQUE KEY `nombre_UNIQUE` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Grupos`
--

LOCK TABLES `Grupos` WRITE;
/*!40000 ALTER TABLE `Grupos` DISABLE KEYS */;
INSERT INTO `Grupos` VALUES (2,'Clientes'),(3,'Familia'),(1,'Sin agrupar');
/*!40000 ALTER TABLE `Grupos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Llamadas`
--

DROP TABLE IF EXISTS `Llamadas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Llamadas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL,
  `idTelefono` int(11) NOT NULL,
  `idExtension` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Estensiones` (`idExtension`),
  KEY `Telefono` (`idTelefono`),
  CONSTRAINT `Estensiones` FOREIGN KEY (`idExtension`) REFERENCES `Extensiones` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Telefono` FOREIGN KEY (`idTelefono`) REFERENCES `Telefonos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='no';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Llamadas`
--

LOCK TABLES `Llamadas` WRITE;
/*!40000 ALTER TABLE `Llamadas` DISABLE KEYS */;
/*!40000 ALTER TABLE `Llamadas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Notas`
--

DROP TABLE IF EXISTS `Notas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Notas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Texto` text,
  `Imagen` longblob,
  `idLlamada` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Llamadas` (`idLlamada`),
  CONSTRAINT `Llamadas` FOREIGN KEY (`idLlamada`) REFERENCES `Llamadas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Notas`
--

LOCK TABLES `Notas` WRITE;
/*!40000 ALTER TABLE `Notas` DISABLE KEYS */;
/*!40000 ALTER TABLE `Notas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Telefonos`
--

DROP TABLE IF EXISTS `Telefonos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Telefonos` (
  `numero` varchar(12) NOT NULL,
  `idCaller` int(11) NOT NULL,
  `idTipo` int(11) NOT NULL DEFAULT '1',
  `fijo` bit(1) NOT NULL DEFAULT b'1',
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`),
  UNIQUE KEY `numero_UNIQUE` (`numero`),
  KEY `Tipos` (`idTipo`),
  KEY `Callers` (`idCaller`),
  CONSTRAINT `Callers` FOREIGN KEY (`idCaller`) REFERENCES `Callers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Tipos` FOREIGN KEY (`idTipo`) REFERENCES `Tipos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Telefonos`
--

LOCK TABLES `Telefonos` WRITE;
/*!40000 ALTER TABLE `Telefonos` DISABLE KEYS */;
/*!40000 ALTER TABLE `Telefonos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tipos`
--

DROP TABLE IF EXISTS `Tipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Tipos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tipos`
--

LOCK TABLES `Tipos` WRITE;
/*!40000 ALTER TABLE `Tipos` DISABLE KEYS */;
INSERT INTO `Tipos` VALUES (1,'Trabajo'),(2,'Particular');
/*!40000 ALTER TABLE `Tipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'GestionTelefonica'
--

--
-- Dumping routines for database 'GestionTelefonica'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-09-11  9:53:33
