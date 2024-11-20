CREATE OR REPLACE FUNCTION GetAllEmployees()
RETURNS JSON AS
$$
BEGIN
    RETURN (
        SELECT json_agg(e) 
        FROM "Employees" e
    );
END
$$ LANGUAGE plpgsql;

-- SELECT GetAllEmployees() AS "JsonResult";
