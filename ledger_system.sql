-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 07, 2024 at 06:25 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ledger system`
--

-- --------------------------------------------------------

--
-- Table structure for table `creditvoucher`
--

CREATE TABLE `creditvoucher` (
  `Voucherno` int(11) NOT NULL,
  `Customerid` bigint(20) NOT NULL,
  `Customername` varchar(255) DEFAULT NULL,
  `Customerphoneno` varchar(15) DEFAULT NULL,
  `Naration` varchar(5000) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `Amount` decimal(20,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `creditvoucher`
--

INSERT INTO `creditvoucher` (`Voucherno`, `Customerid`, `Customername`, `Customerphoneno`, `Naration`, `Date`, `Amount`) VALUES
(11, 1, 'صائم غفور', '03128998252', 'asdaxa', '2024-09-03 11:37:53', 1000.00);

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `Customerid` bigint(20) NOT NULL,
  `Customername` varchar(255) DEFAULT NULL,
  `Customerphoneno` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`Customerid`, `Customername`, `Customerphoneno`) VALUES
(1, 'صائم غفور', '03128998252'),
(2, 'عامر غفور', '03336998252');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `Productid` int(11) NOT NULL,
  `Productname` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`Productid`, `Productname`) VALUES
(1, 'کریلا'),
(2, 'کدو'),
(3, 'گھوبھی'),
(4, 'گاجر'),
(5, 'مولی'),
(6, 'آڑو'),
(7, 'پیاذ'),
(8, 'بیگن'),
(9, 'پالک'),
(10, 'توری'),
(11, 'پھلیاں'),
(12, 'آروی'),
(13, 'سیب'),
(14, 'انگور');

-- --------------------------------------------------------

--
-- Table structure for table `recovery`
--

CREATE TABLE `recovery` (
  `Voucherno` int(11) NOT NULL,
  `Balance` decimal(20,2) NOT NULL,
  `Customerid` bigint(20) NOT NULL,
  `Customername` varchar(255) NOT NULL,
  `Narration` varchar(5000) NOT NULL,
  `Date` datetime NOT NULL,
  `Amount` decimal(20,2) NOT NULL,
  `Customerphoneno` varchar(15) NOT NULL,
  `Productname` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `recovery`
--

INSERT INTO `recovery` (`Voucherno`, `Balance`, `Customerid`, `Customername`, `Narration`, `Date`, `Amount`, `Customerphoneno`, `Productname`) VALUES
(11, 40.00, 1, 'صائم غفور', 'recovery', '2024-09-03 16:37:51', 2000.00, '03128998252', 'کریلا');

-- --------------------------------------------------------

--
-- Table structure for table `saleinvoice`
--

CREATE TABLE `saleinvoice` (
  `Customername` varchar(255) NOT NULL,
  `Voucherno` int(11) NOT NULL,
  `Customerid` bigint(20) NOT NULL,
  `Balance` decimal(20,2) NOT NULL,
  `Productname` varchar(255) NOT NULL,
  `Productid` int(11) NOT NULL,
  `Date` datetime NOT NULL,
  `Customerphoneno` varchar(15) NOT NULL,
  `Qty` int(11) NOT NULL,
  `Rate` decimal(20,2) NOT NULL,
  `Gariafee` decimal(20,2) NOT NULL,
  `Totalgariafee` decimal(20,2) NOT NULL,
  `Total` decimal(20,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `saleinvoice`
--

INSERT INTO `saleinvoice` (`Customername`, `Voucherno`, `Customerid`, `Balance`, `Productname`, `Productid`, `Date`, `Customerphoneno`, `Qty`, `Rate`, `Gariafee`, `Totalgariafee`, `Total`) VALUES
('صائم غفور', 11, 1, 2040.00, 'کریلا', 1, '2024-09-03 16:04:19', '03128998252', 2, 1000.00, 20.00, 40.00, 2040.00);

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `Supplierid` int(11) NOT NULL,
  `Suppliername` varchar(255) NOT NULL,
  `Supplierphoneno` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`Supplierid`, `Suppliername`, `Supplierphoneno`) VALUES
(1, 'صائم غفور', '03128998252'),
(2, 'محمد سرمد', '03006998252');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `Name` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`Name`, `Password`) VALUES
('Saim', 'saim123');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `creditvoucher`
--
ALTER TABLE `creditvoucher`
  ADD PRIMARY KEY (`Voucherno`),
  ADD KEY `Customerid` (`Customerid`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`Customerid`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`Productid`);

--
-- Indexes for table `recovery`
--
ALTER TABLE `recovery`
  ADD PRIMARY KEY (`Voucherno`),
  ADD KEY `Customerid` (`Customerid`);

--
-- Indexes for table `saleinvoice`
--
ALTER TABLE `saleinvoice`
  ADD PRIMARY KEY (`Voucherno`),
  ADD KEY `Customerid` (`Customerid`),
  ADD KEY `Productid` (`Productid`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`Supplierid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `creditvoucher`
--
ALTER TABLE `creditvoucher`
  MODIFY `Voucherno` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `Customerid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `Productid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `Supplierid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `creditvoucher`
--
ALTER TABLE `creditvoucher`
  ADD CONSTRAINT `creditvoucher_ibfk_1` FOREIGN KEY (`Customerid`) REFERENCES `customer` (`Customerid`);

--
-- Constraints for table `recovery`
--
ALTER TABLE `recovery`
  ADD CONSTRAINT `recovery_ibfk_1` FOREIGN KEY (`Customerid`) REFERENCES `customer` (`Customerid`);

--
-- Constraints for table `saleinvoice`
--
ALTER TABLE `saleinvoice`
  ADD CONSTRAINT `saleinvoice_ibfk_1` FOREIGN KEY (`Customerid`) REFERENCES `creditvoucher` (`Customerid`),
  ADD CONSTRAINT `saleinvoice_ibfk_2` FOREIGN KEY (`Productid`) REFERENCES `product` (`Productid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
