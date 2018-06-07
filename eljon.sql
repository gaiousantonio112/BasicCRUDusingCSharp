-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 20, 2018 at 01:33 PM
-- Server version: 10.1.25-MariaDB
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eljon`
--

-- --------------------------------------------------------

--
-- Table structure for table `profiletb`
--

CREATE TABLE `profiletb` (
  `pid` int(102) NOT NULL,
  `fname` varchar(20) DEFAULT NULL,
  `lname` varchar(20) DEFAULT NULL,
  `age` varchar(3) DEFAULT NULL,
  `bdate` varchar(45) DEFAULT NULL,
  `civstatus` varchar(23) DEFAULT NULL,
  `addrs` varchar(255) DEFAULT NULL,
  `gender` varchar(12) DEFAULT NULL,
  `msc` varchar(5) DEFAULT NULL,
  `mvs` varchar(5) DEFAULT NULL,
  `sprts` varchar(5) DEFAULT NULL,
  `gms` varchar(5) DEFAULT NULL,
  `art` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `profiletb`
--
ALTER TABLE `profiletb`
  ADD PRIMARY KEY (`pid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `profiletb`
--
ALTER TABLE `profiletb`
  MODIFY `pid` int(102) NOT NULL AUTO_INCREMENT;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
