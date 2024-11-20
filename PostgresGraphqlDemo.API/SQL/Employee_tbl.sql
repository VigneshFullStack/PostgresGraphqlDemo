-- CREATE TABLE "Employees"
-- (
--     "Id" SERIAL PRIMARY KEY,
--     "Name" VARCHAR(100) NOT NULL,
--     "Age" INT CHECK ("Age" > 18),
--     "Gender" VARCHAR(10) CHECK ("Gender" IN ('Male', 'Female', 'Other')),
--     "Salary" DECIMAL(10, 2) NOT NULL,
--     "CreatedBy" VARCHAR(100) NOT NULL,
--     "CreatedAt" TIMESTAMP DEFAULT NOW(),
--     "ModifiedBy" VARCHAR(100),
--     "ModifiedAt" TIMESTAMP DEFAULT NOW()
-- );

-- INSERT INTO "Employees" ("Name", "Age", "Gender", "Salary", "CreatedBy", "CreatedAt", "ModifiedBy", "ModifiedAt") VALUES
-- ('John Doe', 30, 'Male', 55000.00, 'Admin', NOW(), NULL, NULL),
-- ('Jane Smith', 28, 'Female', 62000.00, 'Admin', NOW(), NULL, NULL),
-- ('Alex Johnson', 35, 'Other', 48000.50, 'HR', NOW(), 'Admin', NOW()),
-- ('Emily Davis', 40, 'Female', 75000.75, 'Manager', NOW(), NULL, NULL),
-- ('Michael Brown', 45, 'Male', 67000.25, 'Admin', NOW(), 'Manager', NOW());

Select * from "Employees";


