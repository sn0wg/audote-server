\c Audote;

CREATE TABLE Animal (
    Id integer Primary Key Generated Always as Identity,
    Name varchar(255),
    Age integer,
    Kind integer,
    Gender integer,
    Active boolean,
    Description text,
    City varchar(255),
    State char(2)
);

CREATE TABLE Picture (
    Id integer Primary Key Generated Always as Identity,
    Description text,
    Path varchar(255),
    ContentType varchar(100),
    AnimalId integer references Animal(Id)
);