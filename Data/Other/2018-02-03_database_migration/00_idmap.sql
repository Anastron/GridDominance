-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server Version:               10.1.19-MariaDB - mariadb.org binary distribution
-- Server Betriebssystem:        Win32
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Exportiere Struktur von Tabelle gdapi_data.idmap
DROP TABLE IF EXISTS `idmap`;
CREATE TABLE IF NOT EXISTS `idmap` (
  `levelid` char(38) NOT NULL,
  `worldid` char(38) NOT NULL,
  `id` varchar(7) NOT NULL,
  `name` varchar(128) NOT NULL,
  `shortid` smallint(6) NOT NULL,
  PRIMARY KEY (`levelid`),
  UNIQUE KEY `shortid` (`shortid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Exportiere Daten aus Tabelle gdapi_data.idmap: ~104 rows (ungefähr)
DELETE FROM `idmap`;
/*!40000 ALTER TABLE `idmap` DISABLE KEYS */;
INSERT INTO `idmap` (`levelid`, `worldid`, `id`, `name`, `shortid`) VALUES
	('{b16b00b5-0001-4000-0000-000001000001}', '{d34db335-0001-4000-7711-000000200001}', '1-1', 'Introduction', 101),
	('{b16b00b5-0001-4000-0000-000001000002}', '{d34db335-0001-4000-7711-000000200001}', '1-2', 'Neutral Player', 102),
	('{b16b00b5-0001-4000-0000-000001000003}', '{d34db335-0001-4000-7711-000000200001}', '1-3', 'Simple Split', 103),
	('{b16b00b5-0001-4000-0000-000001000004}', '{d34db335-0001-4000-7711-000000200001}', '1-4', 'Hexagon', 104),
	('{b16b00b5-0001-4000-0000-000001000005}', '{d34db335-0001-4000-7711-000000200001}', '1-5', 'Overcoming Walls', 105),
	('{b16b00b5-0001-4000-0000-000001000006}', '{d34db335-0001-4000-7711-000000200001}', '1-6', 'Central Authority', 106),
	('{b16b00b5-0001-4000-0000-000001000007}', '{d34db335-0001-4000-7711-000000200001}', '1-7', 'Detour', 107),
	('{b16b00b5-0001-4000-0000-000001000008}', '{d34db335-0001-4000-7711-000000200001}', '1-8', 'Big Mama', 108),
	('{b16b00b5-0001-4000-0000-000001000009}', '{d34db335-0001-4000-7711-000000200001}', '1-9', '3x3', 109),
	('{b16b00b5-0001-4000-0000-000001000010}', '{d34db335-0001-4000-7711-000000200001}', '1-10', 'Shortcut', 110),
	('{b16b00b5-0001-4000-0000-000001000011}', '{d34db335-0001-4000-7711-000000200001}', '1-11', 'Indirection', 111),
	('{b16b00b5-0001-4000-0000-000001000012}', '{d34db335-0001-4000-7711-000000200001}', '1-12', 'Quarters', 112),
	('{b16b00b5-0001-4000-0000-000001000013}', '{d34db335-0001-4000-7711-000000200001}', '1-13', 'Crosss Over', 113),
	('{b16b00b5-0001-4000-0000-000001000014}', '{d34db335-0001-4000-7711-000000200001}', '1-14', 'Defence In Depth', 114),
	('{b16b00b5-0001-4000-0000-000002000001}', '{d34db335-0001-4000-7711-000000200002}', '2-1', 'Double Trouble', 201),
	('{b16b00b5-0001-4000-0000-000002000002}', '{d34db335-0001-4000-7711-000000200002}', '2-2', 'Surrounded', 202),
	('{b16b00b5-0001-4000-0000-000002000003}', '{d34db335-0001-4000-7711-000000200002}', '2-3', 'Reflections', 203),
	('{b16b00b5-0001-4000-0000-000002000004}', '{d34db335-0001-4000-7711-000000200002}', '2-4', 'Neutral Zone', 204),
	('{b16b00b5-0001-4000-0000-000002000005}', '{d34db335-0001-4000-7711-000000200002}', '2-5', 'FFA', 205),
	('{b16b00b5-0001-4000-0000-000002000006}', '{d34db335-0001-4000-7711-000000200002}', '2-6', 'Satellites I', 206),
	('{b16b00b5-0001-4000-0000-000002000007}', '{d34db335-0001-4000-7711-000000200002}', '2-7', 'Satellites II', 207),
	('{b16b00b5-0001-4000-0000-000002000008}', '{d34db335-0001-4000-7711-000000200002}', '2-8', 'Glass Walls', 208),
	('{b16b00b5-0001-4000-0000-000002000009}', '{d34db335-0001-4000-7711-000000200002}', '2-9', 'Normal Walls', 209),
	('{b16b00b5-0001-4000-0000-000002000010}', '{d34db335-0001-4000-7711-000000200002}', '2-10', 'Tunnelling', 210),
	('{b16b00b5-0001-4000-0000-000002000011}', '{d34db335-0001-4000-7711-000000200002}', '2-11', 'Three-Body Problem', 211),
	('{b16b00b5-0001-4000-0000-000002000012}', '{d34db335-0001-4000-7711-000000200002}', '2-12', 'Extended Triangle', 212),
	('{b16b00b5-0001-4000-0000-000002000013}', '{d34db335-0001-4000-7711-000000200002}', '2-13', 'Cubicles', 213),
	('{b16b00b5-0001-4000-0000-000002000014}', '{d34db335-0001-4000-7711-000000200002}', '2-14', 'The Block', 214),
	('{b16b00b5-0001-4000-0000-000002000015}', '{d34db335-0001-4000-7711-000000200002}', '2-15', 'The Block II', 215),
	('{b16b00b5-0001-4000-0000-000002000016}', '{d34db335-0001-4000-7711-000000200002}', '2-16', 'Standoff', 216),
	('{b16b00b5-0001-4000-0000-000002000017}', '{d34db335-0001-4000-7711-000000200002}', '2-17', 'Black Hole', 217),
	('{b16b00b5-0001-4000-0000-000002000018}', '{d34db335-0001-4000-7711-000000200002}', '2-18', 'Black Hole Transit', 218),
	('{b16b00b5-0001-4000-0000-000002000019}', '{d34db335-0001-4000-7711-000000200002}', '2-19', 'Collision Course', 219),
	('{b16b00b5-0001-4000-0000-000002000020}', '{d34db335-0001-4000-7711-000000200002}', '2-20', 'White Hole', 220),
	('{b16b00b5-0001-4000-0000-000002000021}', '{d34db335-0001-4000-7711-000000200002}', '2-21', 'Cutting Edge', 221),
	('{b16b00b5-0001-4000-0000-000002000022}', '{d34db335-0001-4000-7711-000000200002}', '2-22', 'Gridlines', 222),
	('{b16b00b5-0001-4000-0000-000002000023}', '{d34db335-0001-4000-7711-000000200002}', '2-23', 'Chess', 223),
	('{b16b00b5-0001-4000-0000-000002000024}', '{d34db335-0001-4000-7711-000000200002}', '2-24', 'Quadratic Formation', 224),
	('{b16b00b5-0001-4000-0000-000002000025}', '{d34db335-0001-4000-7711-000000200002}', '2-25', 'In Glass', 225),
	('{b16b00b5-0001-4000-0000-000002000026}', '{d34db335-0001-4000-7711-000000200002}', '2-26', '4D Chess', 226),
	('{b16b00b5-0001-4000-0000-000002000027}', '{d34db335-0001-4000-7711-000000200002}', '2-27', 'The Fortress', 227),
	('{b16b00b5-0001-4000-0000-000003000001}', '{d34db335-0001-4000-7711-000000200003}', '3-1', 'New Toys', 301),
	('{b16b00b5-0001-4000-0000-000003000002}', '{d34db335-0001-4000-7711-000000200003}', '3-2', 'Reflections II', 302),
	('{b16b00b5-0001-4000-0000-000003000003}', '{d34db335-0001-4000-7711-000000200003}', '3-3', 'To Infinity... And Beyond!', 303),
	('{b16b00b5-0001-4000-0000-000003000004}', '{d34db335-0001-4000-7711-000000200003}', '3-4', 'The Law of Snell', 304),
	('{b16b00b5-0001-4000-0000-000003000005}', '{d34db335-0001-4000-7711-000000200003}', '3-5', 'Bullets vs Lasers', 305),
	('{b16b00b5-0001-4000-0000-000003000006}', '{d34db335-0001-4000-7711-000000200003}', '3-6', 'Knights Of Round', 306),
	('{b16b00b5-0001-4000-0000-000003000007}', '{d34db335-0001-4000-7711-000000200003}', '3-7', 'Knights Of Round II', 307),
	('{b16b00b5-0001-4000-0000-000003000008}', '{d34db335-0001-4000-7711-000000200003}', '3-8', 'Knights Of The Glasstable', 308),
	('{b16b00b5-0001-4000-0000-000003000009}', '{d34db335-0001-4000-7711-000000200003}', '3-9', 'Back To The Roots', 309),
	('{b16b00b5-0001-4000-0000-000003000010}', '{d34db335-0001-4000-7711-000000200003}', '3-10', 'Same, Same ... But Different', 310),
	('{b16b00b5-0001-4000-0000-000003000011}', '{d34db335-0001-4000-7711-000000200003}', '3-11', 'Blocks Of Glass', 311),
	('{b16b00b5-0001-4000-0000-000003000012}', '{d34db335-0001-4000-7711-000000200003}', '3-12', 'Lasers Crossing', 312),
	('{b16b00b5-0001-4000-0000-000003000013}', '{d34db335-0001-4000-7711-000000200003}', '3-13', 'A Rift In Space', 313),
	('{b16b00b5-0001-4000-0000-000003000014}', '{d34db335-0001-4000-7711-000000200003}', '3-14', 'Gravity Well', 314),
	('{b16b00b5-0001-4000-0000-000003000015}', '{d34db335-0001-4000-7711-000000200003}', '3-15', 'Overcoming Gravity', 315),
	('{b16b00b5-0001-4000-0000-000003000016}', '{d34db335-0001-4000-7711-000000200003}', '3-16', 'Command Center', 316),
	('{b16b00b5-0001-4000-0000-000003000017}', '{d34db335-0001-4000-7711-000000200003}', '3-17', 'Multiplicator', 317),
	('{b16b00b5-0001-4000-0000-000003000018}', '{d34db335-0001-4000-7711-000000200003}', '3-18', 'Laser Zone', 318),
	('{b16b00b5-0001-4000-0000-000003000019}', '{d34db335-0001-4000-7711-000000200003}', '3-19', 'Fibre Connection', 319),
	('{b16b00b5-0001-4000-0000-000003000020}', '{d34db335-0001-4000-7711-000000200003}', '3-20', 'The Block III', 320),
	('{b16b00b5-0001-4000-0000-000003000021}', '{d34db335-0001-4000-7711-000000200003}', '3-21', 'The Block IV', 321),
	('{b16b00b5-0001-4000-0000-000003000022}', '{d34db335-0001-4000-7711-000000200003}', '3-22', 'Laser Cubicles', 322),
	('{b16b00b5-0001-4000-0000-000003000023}', '{d34db335-0001-4000-7711-000000200003}', '3-23', 'Torus Gravity', 323),
	('{b16b00b5-0001-4000-0000-000003000024}', '{d34db335-0001-4000-7711-000000200003}', '3-24', 'Orbital Mechanics', 324),
	('{b16b00b5-0001-4000-0000-000003000025}', '{d34db335-0001-4000-7711-000000200003}', '3-25', 'Orbital Mechanics II', 325),
	('{b16b00b5-0001-4000-0000-000003000026}', '{d34db335-0001-4000-7711-000000200003}', '3-26', 'Modern Advantage', 326),
	('{b16b00b5-0001-4000-0000-000003000027}', '{d34db335-0001-4000-7711-000000200003}', '3-27', 'From Big To Small', 327),
	('{b16b00b5-0001-4000-0000-000003000028}', '{d34db335-0001-4000-7711-000000200003}', '3-28', 'The Fortress II', 328),
	('{b16b00b5-0001-4000-0000-000003000029}', '{d34db335-0001-4000-7711-000000200003}', '3-29', 'Laserlines', 329),
	('{b16b00b5-0001-4000-0000-000003000030}', '{d34db335-0001-4000-7711-000000200003}', '3-30', 'Battlefield', 330),
	('{b16b00b5-0001-4000-0000-000003000031}', '{d34db335-0001-4000-7711-000000200003}', '3-31', 'Bigger Than You Thought', 331),
	('{b16b00b5-0001-4000-0000-000004000001}', '{d34db335-0001-4000-7711-000000200004}', '4-1 ', 'Bullet Transfer', 401),
	('{b16b00b5-0001-4000-0000-000004000002}', '{d34db335-0001-4000-7711-000000200004}', '4-2 ', 'Relay Network', 402),
	('{b16b00b5-0001-4000-0000-000004000003}', '{d34db335-0001-4000-7711-000000200004}', '4-3 ', 'Mesh Network', 403),
	('{b16b00b5-0001-4000-0000-000004000004}', '{d34db335-0001-4000-7711-000000200004}', '4-4 ', 'Topological Horror', 404),
	('{b16b00b5-0001-4000-0000-000004000005}', '{d34db335-0001-4000-7711-000000200004}', '4-5 ', 'Heavy Machinery', 405),
	('{b16b00b5-0001-4000-0000-000004000006}', '{d34db335-0001-4000-7711-000000200004}', '4-6 ', 'Trench Warfare', 406),
	('{b16b00b5-0001-4000-0000-000004000007}', '{d34db335-0001-4000-7711-000000200004}', '4-7 ', 'Machine Gun Singularity', 407),
	('{b16b00b5-0001-4000-0000-000004000008}', '{d34db335-0001-4000-7711-000000200004}', '4-8 ', 'Four Player Bullet Hell', 408),
	('{b16b00b5-0001-4000-0000-000004000009}', '{d34db335-0001-4000-7711-000000200004}', '4-9 ', 'Overkill', 409),
	('{b16b00b5-0001-4000-0000-000004000010}', '{d34db335-0001-4000-7711-000000200004}', '4-10', 'Three For One', 410),
	('{b16b00b5-0001-4000-0000-000004000011}', '{d34db335-0001-4000-7711-000000200004}', '4-11', 'The Long Way', 411),
	('{b16b00b5-0001-4000-0000-000004000012}', '{d34db335-0001-4000-7711-000000200004}', '4-12', 'Two Lane Road', 412),
	('{b16b00b5-0001-4000-0000-000004000013}', '{d34db335-0001-4000-7711-000000200004}', '4-13', 'Two Lane Road II', 413),
	('{b16b00b5-0001-4000-0000-000004000014}', '{d34db335-0001-4000-7711-000000200004}', '4-14', 'Front Yard', 414),
	('{b16b00b5-0001-4000-0000-000004000015}', '{d34db335-0001-4000-7711-000000200004}', '4-15', 'Kepplers Damnation', 415),
	('{b16b00b5-0001-4000-0000-000004000016}', '{d34db335-0001-4000-7711-000000200004}', '4-16', 'The Ultimate Shield', 416),
	('{b16b00b5-0001-4000-0000-000004000017}', '{d34db335-0001-4000-7711-000000200004}', '4-17', 'Roundabout', 417),
	('{b16b00b5-0001-4000-0000-000004000018}', '{d34db335-0001-4000-7711-000000200004}', '4-18', 'Behind The Glass Wall', 418),
	('{b16b00b5-0001-4000-0000-000004000019}', '{d34db335-0001-4000-7711-000000200004}', '4-19', '3x3 with Machine Guns', 419),
	('{b16b00b5-0001-4000-0000-000004000020}', '{d34db335-0001-4000-7711-000000200004}', '4-20', 'Eyes', 420),
	('{b16b00b5-0001-4000-0000-000004000021}', '{d34db335-0001-4000-7711-000000200004}', '4-21', 'Three Color Hexagon', 421),
	('{b16b00b5-0001-4000-0000-000004000022}', '{d34db335-0001-4000-7711-000000200004}', '4-22', 'Lasers Crossing II', 422),
	('{b16b00b5-0001-4000-0000-000004000023}', '{d34db335-0001-4000-7711-000000200004}', '4-23', 'Battle Boxes', 423),
	('{b16b00b5-0001-4000-0000-000004000024}', '{d34db335-0001-4000-7711-000000200004}', '4-24', 'Per Herbam Ad Astra', 424),
	('{b16b00b5-0001-4000-0000-000004000025}', '{d34db335-0001-4000-7711-000000200004}', '4-25', 'Laser Flanking', 425),
	('{b16b00b5-0001-4000-0000-000004000026}', '{d34db335-0001-4000-7711-000000200004}', '4-26', 'Defence In Depth II', 426),
	('{b16b00b5-0001-4000-0000-000004000027}', '{d34db335-0001-4000-7711-000000200004}', '4-27', 'Core Wars', 427),
	('{b16b00b5-0001-4000-0000-000004000028}', '{d34db335-0001-4000-7711-000000200004}', '4-28', 'Familiar Faces', 428),
	('{b16b00b5-0001-4000-0000-000004000029}', '{d34db335-0001-4000-7711-000000200004}', '4-29', 'Quad', 429),
	('{b16b00b5-0001-4000-0000-000004000030}', '{d34db335-0001-4000-7711-000000200004}', '4-30', 'Protect And Attack', 430),
	('{b16b00b5-0001-4000-0000-000004000031}', '{d34db335-0001-4000-7711-000000200004}', '4-31', 'Destiny', 431),
	('{b16b00b5-0001-4000-9999-000000000002}', '{d34db335-0001-4000-7711-000000100001}', 'X-X', 'Tutorial', 11);
/*!40000 ALTER TABLE `idmap` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
