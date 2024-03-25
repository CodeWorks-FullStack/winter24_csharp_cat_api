CREATE TABLE accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key', createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created', updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update', name varchar(255) COMMENT 'User Name', email varchar(255) COMMENT 'User Email', picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

-- NOTE first step for setting up web API is to create tables to store data in
CREATE TABLE cats (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, numberOfLegs INT NOT NULL DEFAULT 4, name VARCHAR(50) NOT NULL, color VARCHAR(50) NOT NULL, likesCheese BOOLEAN DEFAULT true, hasTail BOOLEAN DEFAULT true
);

-- NOTE everything below not necessary, but gives us data to play around with
INSERT INTO
    cats (
        name, numberOfLegs, color, likesCheese, hasTail
    )
VALUES (
        "Gopher", 4, "black", true, true
    );

INSERT INTO
    cats (
        name, numberOfLegs, color, likesCheese, hasTail
    )
VALUES (
        "Georgie", 4, "grey", true, true
    ),
    (
        "Cybil", 4, "calico", false, true
    );

DELETE FROM cats WHERE id = 3;

SELECT * FROM cats;

DROP TABLE cats;