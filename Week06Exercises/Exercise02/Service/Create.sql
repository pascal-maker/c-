-- Create the Exercise02 database if it doesn't already exist
-- This prevents errors if the database already exists
CREATE DATABASE IF NOT EXISTS Exercise02;

-- Switch to using the Exercise02 database for subsequent operations
USE Exercise02;

-- Create the main SurveyResponses table to store survey data
-- This table contains all the survey response information
CREATE TABLE SurveyResponses (
    Id INT AUTO_INCREMENT PRIMARY KEY,  -- Auto-incrementing primary key for unique identification
    Age INT,                            -- Age of the person (integer value)
    Gender VARCHAR(50),                 -- Gender of the person (string, max 50 characters)
    MaritalStatus VARCHAR(50),          -- Marital status of the person (string, max 50 characters)
    Occupation VARCHAR(100),            -- Occupation of the person (string, max 100 characters)
    MonthlyIncome VARCHAR(100),         -- Monthly income of the person (string, max 100 characters)
    EducationalQualifications VARCHAR(100),  -- Educational qualifications (string, max 100 characters)
    FamilySize INT,                     -- Number of family members (integer value)
    Latitude DOUBLE,                    -- Latitude coordinate for GPS location (double precision)
    Longitude DOUBLE,                   -- Longitude coordinate for GPS location (double precision)
    PinCode VARCHAR(20),                -- Postal/PIN code (string, max 20 characters)
    Output BOOLEAN,                     -- Survey output result (true/false boolean value)
    Feedback VARCHAR(255)               -- Feedback provided by the person (string, max 255 characters)
);

-- Create the AITrainData table for machine learning purposes
-- This table contains a subset of survey data specifically formatted for AI training
CREATE TABLE AITrainData (
    ID INT AUTO_INCREMENT PRIMARY KEY,  -- Auto-incrementing primary key for unique identification
    Age INT,                            -- Age of the person (integer value)
    Gender VARCHAR(255),                -- Gender of the person (string, max 255 characters)
    MaritalStatus VARCHAR(255),         -- Marital status of the person (string, max 255 characters)
    Occupation VARCHAR(255),            -- Occupation of the person (string, max 255 characters)
    MonthlyIncome VARCHAR(255),         -- Monthly income (kept as VARCHAR for formatted strings like "$5,000")
    FamilySize INT                      -- Number of family members (integer value)
);
