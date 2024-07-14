CREATE PROCEDURE CreateAccount(@usu_nombreUsuario AS VARCHAR(60), @usu_email AS VARCHAR(80), @usu_password AS VARCHAR(255)) AS BEGIN
INSERT INTO [dbo].[Usuario]
 ([usu_nombreUsuario]
,[usu_email]
,[usu_password]) VALUES
 (@usu_nombreUsuario
,@usu_email
,@usu_password) END;
