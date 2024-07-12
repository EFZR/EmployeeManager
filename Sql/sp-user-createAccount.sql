-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CreateAccount(@usu_nombreUsuario AS VARCHAR(60), @usu_email AS VARCHAR(80), @usu_password AS VARCHAR(255))
AS
BEGIN
INSERT INTO [dbo].[Usuario]
           ([usu_nombreUsuario]
           ,[usu_email]
           ,[usu_password])
     VALUES
           (@usu_nombreUsuario
           ,@usu_email
           ,@usu_password)
END
GO
