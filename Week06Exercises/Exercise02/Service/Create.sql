CREATE DATABASE Exercise02;
USE Exercise02;
CREATE TABLE SurveyResponses (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Age INT,
    Gender VARCHAR(50),
    MaritalStatus VARCHAR(50),
    Occupation VARCHAR(100),
    MonthlyIncome VARCHAR(100),
    EducationalQualifications VARCHAR(100),
    FamilySize INT,
    Latitude DOUBLE,
    Longitude DOUBLE,
    PinCode VARCHAR(20),
    Output BOOLEAN,
    Feedback VARCHAR(255)
);


CREATE TABLE AITrainData (
    ID INT AUTO_INCREMENT PRIMARY KEY, -- Assuming you need a unique identifier for each record
    Age INT,
    Gender VARCHAR(255),
    MaritalStatus VARCHAR(255),
    Occupation VARCHAR(255),
    MonthlyIncome VARCHAR(255), -- Kept as VARCHAR assuming it may contain formatted strings (e.g., "$5,000"). Change to INT or DECIMAL if you store raw numbers.
    FamilySize INT
);
