-- Create the Exercise01 database if it doesn't already exist
CREATE DATABASE IF NOT EXISTS Exercise01;
-- Switch to using the Exercise01 database
USE Exercise01;

-- Create the Persons table with the required columns and constraints
CREATE TABLE Persons (
Id INT AUTO_INCREMENT PRIMARY KEY,  -- Auto-incrementing primary key for unique identification
Name VARCHAR(100) NOT NULL,         -- Person's name, required field with max 100 characters
Age INT NOT NULL,                   -- Person's age, required field as integer
Email VARCHAR(255) NOT NULL         -- Person's email, required field with max 255 characters
);