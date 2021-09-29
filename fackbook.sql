-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 27, 2021 at 05:29 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `fackbook`
--

-- --------------------------------------------------------

--
-- Table structure for table `comments`
--

CREATE TABLE `comments` (
  `CommentID` int(11) NOT NULL,
  `CommentText` text NOT NULL,
  `DateTime` date NOT NULL,
  `UserID` int(11) NOT NULL,
  `PostID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `comments`
--

INSERT INTO `comments` (`CommentID`, `CommentText`, `DateTime`, `UserID`, `PostID`) VALUES
(56500, 'www', '0001-01-01', 22482, 71788),
(67304, 'ทำไงอ่ะ', '0001-01-01', 39413, 71788),
(70771, 'das', '0001-01-01', 22482, 71788),
(71608, 'สนุกมากเลยนะ', '0001-01-01', 39413, 107398),
(78301, 'ว่าไง', '0001-01-01', 39413, 71788),
(79094, 'd', '0001-01-01', 22482, 71788),
(79222, 'สวัสดี', '0001-01-01', 39413, 71788),
(86401, 'dsa', '0001-01-01', 22482, 71788),
(93069, 'dsada', '0001-01-01', 22482, 71788),
(111214, 'w', '0001-01-01', 22482, 71788),
(118031, 'ทำไงอ่ะ', '0001-01-01', 22482, 71788);

-- --------------------------------------------------------

--
-- Table structure for table `friendrequests`
--

CREATE TABLE `friendrequests` (
  `RequestID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `FriendID` int(11) NOT NULL,
  `RequestDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `friendrequests`
--

INSERT INTO `friendrequests` (`RequestID`, `UserID`, `FriendID`, `RequestDate`) VALUES
(47825, 22482, 25343, '0000-00-00'),
(90587, 22482, 68105, '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `postcomments`
--

CREATE TABLE `postcomments` (
  `PostCommentID` int(11) NOT NULL,
  `PostID` int(11) NOT NULL,
  `CommentID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `postcomments`
--

INSERT INTO `postcomments` (`PostCommentID`, `PostID`, `CommentID`) VALUES
(128288, 71788, 56500),
(139092, 71788, 67304),
(142559, 71788, 70771),
(150882, 71788, 79094),
(158189, 71788, 86401),
(164857, 71788, 93069),
(179006, 107398, 71608),
(183002, 71788, 111214),
(189819, 71788, 118031);

-- --------------------------------------------------------

--
-- Table structure for table `posts`
--

CREATE TABLE `posts` (
  `PostID` int(11) NOT NULL,
  `PostText` text NOT NULL,
  `Picture` text NOT NULL,
  `UserID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `posts`
--

INSERT INTO `posts` (`PostID`, `PostText`, `Picture`, `UserID`) VALUES
(71788, 'test', 'post71788.jpg', 39413),
(107398, 'ชินจังตอนใหม่', 'post107398.jpg', 39413);

-- --------------------------------------------------------

--
-- Table structure for table `userfriends`
--

CREATE TABLE `userfriends` (
  `UserFriendID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `FriendID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `userfriends`
--

INSERT INTO `userfriends` (`UserFriendID`, `UserID`, `FriendID`) VALUES
(61895, 39413, 22482),
(64756, 25343, 39413),
(113586, 39413, 74173);

-- --------------------------------------------------------

--
-- Table structure for table `userposts`
--

CREATE TABLE `userposts` (
  `UserPostID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `PostID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `Email` text NOT NULL,
  `Name` text NOT NULL,
  `Password` text NOT NULL,
  `JoinDate` date DEFAULT NULL,
  `Profile` text DEFAULT NULL,
  `Picture` text DEFAULT NULL,
  `LoginActive` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `Email`, `Name`, `Password`, `JoinDate`, `Profile`, `Picture`, `LoginActive`) VALUES
(22482, 'admin2', 'แอดมินคนสอง', '123', NULL, NULL, 'profile.png', NULL),
(25343, 'admin3', 'โดเรม่อน', '123', NULL, NULL, './image25343.jpg', NULL),
(39413, 'admin1', 'ชินจัง', '123', NULL, NULL, './image39413.jpg', NULL),
(68105, 'admin5', 'แอดมินคนห้า', '123', NULL, NULL, 'profile.png', NULL),
(74173, 'admin4', 'แอดมินคนสี่', '123', NULL, NULL, 'profile.png', NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `comments`
--
ALTER TABLE `comments`
  ADD PRIMARY KEY (`CommentID`);

--
-- Indexes for table `friendrequests`
--
ALTER TABLE `friendrequests`
  ADD PRIMARY KEY (`RequestID`);

--
-- Indexes for table `postcomments`
--
ALTER TABLE `postcomments`
  ADD PRIMARY KEY (`PostCommentID`);

--
-- Indexes for table `posts`
--
ALTER TABLE `posts`
  ADD PRIMARY KEY (`PostID`);

--
-- Indexes for table `userfriends`
--
ALTER TABLE `userfriends`
  ADD PRIMARY KEY (`UserFriendID`);

--
-- Indexes for table `userposts`
--
ALTER TABLE `userposts`
  ADD PRIMARY KEY (`UserPostID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
