-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Mar 20, 2020 at 08:55 PM
-- Server version: 8.0.17
-- PHP Version: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `asanmobilya`
--

-- --------------------------------------------------------

--
-- Table structure for table `musteri`
--

CREATE TABLE `musteri` (
  `musteriid` int(11) NOT NULL,
  `musteriad` text COLLATE utf8_turkish_ci NOT NULL,
  `musterisoyad` text COLLATE utf8_turkish_ci NOT NULL,
  `musterisira` text COLLATE utf8_turkish_ci NOT NULL,
  `musteritelefon` text COLLATE utf8_turkish_ci NOT NULL,
  `musteriadres` text CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL,
  `musterikefil` text COLLATE utf8_turkish_ci NOT NULL,
  `kefiltel` text COLLATE utf8_turkish_ci NOT NULL,
  `musteriborc` text COLLATE utf8_turkish_ci NOT NULL,
  `musteritaksit` text COLLATE utf8_turkish_ci NOT NULL,
  `borctarihi` text COLLATE utf8_turkish_ci NOT NULL,
  `odemetarihi` text COLLATE utf8_turkish_ci NOT NULL,
  `uruntipi` text COLLATE utf8_turkish_ci NOT NULL,
  `odemesekli` text COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Dumping data for table `musteri`
--

INSERT INTO `musteri` (`musteriid`, `musteriad`, `musterisoyad`, `musterisira`, `musteritelefon`, `musteriadres`, `musterikefil`, `kefiltel`, `musteriborc`, `musteritaksit`, `borctarihi`, `odemetarihi`, `uruntipi`, `odemesekli`) VALUES
(25, 'Esra', 'Akar', '8', 'Ereğli', '05397842934', 'Behlül', '0539545555', '500', '5', '18.03.2020', '30.03.2020', 'Masa', 'Taksitli Ödeme'),
(26, 'Fatma', 'Akar', '5', 'Ereğli', '532455', 'Faruk', '523333', '600', '6', '20.03.2020', '29.03.2020', 'Koltuk', 'Taksitli Ödeme');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `musteri`
--
ALTER TABLE `musteri`
  ADD PRIMARY KEY (`musteriid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `musteri`
--
ALTER TABLE `musteri`
  MODIFY `musteriid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
