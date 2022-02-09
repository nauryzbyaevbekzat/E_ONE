CREATE DATABASE EventumOne;
USE  EventumOne; 
GO
CREATE TABLE h_color (
    id int NOT NULL PRIMARY KEY,
    name varchar(255) NOT NULL,
    
);
GO
CREATE TABLE car (
    id int NOT NULL PRIMARY KEY,
    brand_name  varchar(255) NOT NULL,
    model_name  varchar(255) NOT NULL,
    h_color_id int FOREIGN KEY REFERENCES  h_color(id)
);