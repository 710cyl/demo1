CREATE DATABASE  IF NOT EXISTS `test` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `test`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win64 (x86_64)
--
-- Host: localhost    Database: test
-- ------------------------------------------------------
-- Server version	5.7.5-m15-log

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
-- Table structure for table `内部车队`
--

DROP TABLE IF EXISTS `内部车队`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `内部车队` (
  `锁状态` varchar(45) DEFAULT NULL,
  `登记人` varchar(45) DEFAULT NULL,
  `登记时间` varchar(45) DEFAULT NULL,
  `修改人` varchar(45) DEFAULT NULL,
  `修改时间` varchar(45) DEFAULT NULL,
  `编号` varchar(45) NOT NULL,
  `车队` varchar(45) DEFAULT NULL,
  `车号` varchar(45) DEFAULT NULL,
  `司机` varchar(45) DEFAULT NULL,
  `说明` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`编号`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `内部车队`
--

LOCK TABLES `内部车队` WRITE;
/*!40000 ALTER TABLE `内部车队` DISABLE KEYS */;
/*!40000 ALTER TABLE `内部车队` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `基本系统`
--

DROP TABLE IF EXISTS `基本系统`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `基本系统` (
  `编号` varchar(45) NOT NULL,
  `岗位设置` varchar(45) DEFAULT NULL,
  `应收账款` varchar(45) DEFAULT NULL,
  `应付账款` varchar(45) DEFAULT NULL,
  `入库方式` varchar(45) DEFAULT NULL,
  `出库方式` varchar(45) DEFAULT NULL,
  `运输方式` varchar(45) DEFAULT NULL,
  `岗位性质` varchar(45) DEFAULT NULL,
  `借款性质` varchar(45) DEFAULT NULL,
  `客户类型` varchar(45) DEFAULT NULL,
  `费用类别` varchar(45) DEFAULT NULL,
  `民族` varchar(45) DEFAULT NULL,
  `仓库` varchar(45) DEFAULT NULL,
  `报销类型` varchar(45) DEFAULT NULL,
  `油气种类` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`编号`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `基本系统`
--

LOCK TABLES `基本系统` WRITE;
/*!40000 ALTER TABLE `基本系统` DISABLE KEYS */;
INSERT INTO `基本系统` VALUES ('1','ewq',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('2','eqwqw',NULL,NULL,NULL,'wee',NULL,NULL,NULL,'we',NULL,NULL,'qw','eqw','qwe'),('3','wqeqe',NULL,'eqw','eq',NULL,'qwe',NULL,'qweq','qw',NULL,NULL,'e',NULL,NULL),('4','weqwwe','qewe','qweqw',NULL,NULL,'qw','we',NULL,'eqw',NULL,NULL,'qw','eqwe','qwe'),('5',NULL,'qwee',NULL,NULL,NULL,'eq',NULL,NULL,NULL,'e',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `基本系统` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `外部车队`
--

DROP TABLE IF EXISTS `外部车队`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `外部车队` (
  `锁状态` varchar(45) DEFAULT NULL,
  `登记人` varchar(45) DEFAULT NULL,
  `登记时间` varchar(45) DEFAULT NULL,
  `修改人` varchar(45) DEFAULT NULL,
  `修改时间` varchar(45) DEFAULT NULL,
  `编号` varchar(45) NOT NULL,
  `车队` varchar(45) DEFAULT NULL,
  `车号` varchar(45) DEFAULT NULL,
  `司机` varchar(45) DEFAULT NULL,
  `说明` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`编号`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `外部车队`
--

LOCK TABLES `外部车队` WRITE;
/*!40000 ALTER TABLE `外部车队` DISABLE KEYS */;
INSERT INTO `外部车队` VALUES ('1','1','1','1','1','1','1','1','1','1'),(NULL,NULL,NULL,NULL,NULL,'2',NULL,NULL,NULL,NULL),(NULL,NULL,NULL,NULL,NULL,'3',NULL,NULL,NULL,NULL),(NULL,NULL,NULL,NULL,NULL,'4',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `外部车队` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `客户档案`
--

DROP TABLE IF EXISTS `客户档案`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `客户档案` (
  `锁状态` varchar(45) DEFAULT NULL,
  `客户编号` varchar(45) NOT NULL,
  `客户简称` varchar(45) DEFAULT NULL,
  `客户全称` varchar(45) DEFAULT NULL,
  `速查码` varchar(45) DEFAULT NULL,
  `地址` varchar(45) DEFAULT NULL,
  `开户行` varchar(45) DEFAULT NULL,
  `税号` varchar(45) DEFAULT NULL,
  `联系人` varchar(45) DEFAULT NULL,
  `电话` varchar(45) DEFAULT NULL,
  `登记人` varchar(45) DEFAULT NULL,
  `登记时间` varchar(45) DEFAULT NULL,
  `修改人` varchar(45) DEFAULT NULL,
  `修改时间` varchar(45) DEFAULT NULL,
  `客户类别1` varchar(45) DEFAULT NULL,
  `客户类别2` varchar(45) DEFAULT NULL,
  `客户类别3` varchar(45) DEFAULT NULL,
  `客户类别4` varchar(45) DEFAULT NULL,
  `客户类别5` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`客户编号`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `客户档案`
--

LOCK TABLES `客户档案` WRITE;
/*!40000 ALTER TABLE `客户档案` DISABLE KEYS */;
INSERT INTO `客户档案` VALUES (NULL,'1',NULL,NULL,NULL,NULL,'1111111111111111111111',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(NULL,'2',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(NULL,'3',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `客户档案` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `维修材料`
--

DROP TABLE IF EXISTS `维修材料`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `维修材料` (
  `锁状态` varchar(45) DEFAULT NULL,
  `登记人` varchar(45) DEFAULT NULL,
  `登记时间` varchar(45) DEFAULT NULL,
  `修改人` varchar(45) DEFAULT NULL,
  `修改时间` varchar(45) DEFAULT NULL,
  `编号` varchar(45) NOT NULL,
  `速查码` varchar(45) DEFAULT NULL,
  `类别` varchar(45) DEFAULT NULL,
  `名称` varchar(45) DEFAULT NULL,
  `单位` varchar(45) DEFAULT NULL,
  `备注` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`编号`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `维修材料`
--

LOCK TABLES `维修材料` WRITE;
/*!40000 ALTER TABLE `维修材料` DISABLE KEYS */;
/*!40000 ALTER TABLE `维修材料` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `资金账户`
--

DROP TABLE IF EXISTS `资金账户`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `资金账户` (
  `编号` varchar(45) NOT NULL,
  `账户性质` varchar(45) DEFAULT NULL,
  `账户名称` varchar(45) DEFAULT NULL,
  `开户行` varchar(45) DEFAULT NULL,
  `账号` varchar(45) DEFAULT NULL,
  `期初余额` varchar(45) DEFAULT NULL,
  `收款总额` varchar(45) DEFAULT NULL,
  `付款总额` varchar(45) DEFAULT NULL,
  `现余额` varchar(45) DEFAULT NULL,
  `说明` varchar(45) DEFAULT NULL,
  `锁状态` varchar(2) DEFAULT NULL,
  `登记人` varchar(45) DEFAULT NULL,
  `登记时间` varchar(45) DEFAULT NULL,
  `修改人` varchar(45) DEFAULT NULL,
  `修改时间` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`编号`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `资金账户`
--

LOCK TABLES `资金账户` WRITE;
/*!40000 ALTER TABLE `资金账户` DISABLE KEYS */;
INSERT INTO `资金账户` VALUES ('1','123','3123','1231123','123123','1321323','1231231','131231','1312','131231','1','12313','12313','123123','2131231');
/*!40000 ALTER TABLE `资金账户` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `idcustomers` varchar(20) NOT NULL DEFAULT '用户ID',
  `authorities` varchar(45) NOT NULL DEFAULT '用户权限',
  `passwrdcustomsers` varchar(45) NOT NULL DEFAULT '用户密码',
  PRIMARY KEY (`idcustomers`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES ('admin','管理员','123'),('S201625031','学生','S201625031'),('T123456','老师','T123456');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'test'
--

--
-- Dumping routines for database 'test'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-31 17:07:29
