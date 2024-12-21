-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 20 Ara 2024, 01:11:16
-- Sunucu sürümü: 10.4.32-MariaDB
-- PHP Sürümü: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `bus_booking_system`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `bookings`
--

CREATE TABLE `bookings` (
  `BookingID` int(11) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `BusID` int(11) NOT NULL,
  `BookingDate` datetime NOT NULL,
  `Status` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `bookings`
--

INSERT INTO `bookings` (`BookingID`, `CustomerID`, `BusID`, `BookingDate`, `Status`) VALUES
(1, 0, 1, '2024-12-20 03:11:01', 'Booked');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `buses`
--

CREATE TABLE `buses` (
  `BusID` int(11) NOT NULL,
  `BusName` varchar(255) NOT NULL,
  `DepartureLocation` varchar(255) NOT NULL,
  `ArrivalLocation` varchar(255) NOT NULL,
  `DepartureTime` datetime NOT NULL,
  `SeatsAvailable` int(11) NOT NULL,
  `CompanyID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `buses`
--

INSERT INTO `buses` (`BusID`, `BusName`, `DepartureLocation`, `ArrivalLocation`, `DepartureTime`, `SeatsAvailable`, `CompanyID`) VALUES
(1, 'DOU Turizm', 'Istanbul', 'Ankara', '2024-12-20 00:47:39', 39, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `companies`
--

CREATE TABLE `companies` (
  `CompanyID` int(11) NOT NULL,
  `CompanyName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `CompanyID` int(11) NOT NULL DEFAULT 0,
  `IsAdmin` int(1) NOT NULL DEFAULT 0,
  `IsDeveloper` int(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `bookings`
--
ALTER TABLE `bookings`
  ADD PRIMARY KEY (`BookingID`);

--
-- Tablo için indeksler `buses`
--
ALTER TABLE `buses`
  ADD PRIMARY KEY (`BusID`);

--
-- Tablo için indeksler `companies`
--
ALTER TABLE `companies`
  ADD UNIQUE KEY `CompanyID` (`CompanyID`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD UNIQUE KEY `UserID` (`UserID`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `bookings`
--
ALTER TABLE `bookings`
  MODIFY `BookingID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `buses`
--
ALTER TABLE `buses`
  MODIFY `BusID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `companies`
--
ALTER TABLE `companies`
  MODIFY `CompanyID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
