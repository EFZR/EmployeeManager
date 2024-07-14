CREATE PROCEDURE Authenticate(@usu_email AS VARCHAR(80)) AS BEGIN
SELECT *
FROM [dbo].[Usuario]
WHERE [usu_email] LIKE @usu_email END;
