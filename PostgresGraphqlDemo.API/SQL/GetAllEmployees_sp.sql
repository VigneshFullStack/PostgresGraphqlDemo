CREATE OR REPLACE FUNCTION public.get_all_employees()
RETURNS JSON AS
$$
BEGIN
    RETURN (
        SELECT json_agg(e) 
        FROM employees e
    );
END
$$ LANGUAGE plpgsql;

-- SELECT public.get_all_employees() AS "JsonResult";
