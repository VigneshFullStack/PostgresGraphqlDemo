-- CREATE TABLE employees
-- (
--     id SERIAL PRIMARY KEY,
--     name VARCHAR(100) NOT NULL,
--     age INT CHECK (age > 18),
--     gender VARCHAR(10) CHECK (gender IN ('Male', 'Female', 'Other')),
--     salary DECIMAL(10, 2) NOT NULL,
--     created_by VARCHAR(100) NOT NULL,
--     created_at TIMESTAMP DEFAULT NOW(),
--     modified_by VARCHAR(100),
--     modified_at TIMESTAMP DEFAULT NOW()
-- );


-- INSERT INTO employees (name, age, gender, salary, created_by, created_at, modified_by, modified_at) VALUES
-- ('John Doe', 30, 'Male', 55000.00, 'Admin', NOW(), NULL, NULL),
-- ('Jane Smith', 28, 'Female', 62000.00, 'Admin', NOW(), NULL, NULL),
-- ('Alex Johnson', 35, 'Other', 48000.50, 'HR', NOW(), 'Admin', NOW()),
-- ('Emily Davis', 40, 'Female', 75000.75, 'Manager', NOW(), NULL, NULL),
-- ('Michael Brown', 45, 'Male', 67000.25, 'Admin', NOW(), 'Manager', NOW());

Select * from employees;


