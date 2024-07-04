-- Active: 1694011501479@@54.183.79.228@3306@SenD
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture',
  coverImg varchar(700)
) default charset utf8 COMMENT '';

CREATE TABLE monsters(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) NOT NULL COMMENT 'Monster Name',
  type varchar(255) NOT NULL COMMENT 'Monster Type',
  subType varchar(255) COMMENT 'Monster Sub-Type',
  img varchar(100) NOT NULL COMMENT 'Monster Image',
  description varchar(1000) NOT NULL COMMENT 'Monster Description',
  power INT NOT NULL COMMENT 'Monster Power',
  toughness INT NOT NULL COMMENT 'Monster Toughness',
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
