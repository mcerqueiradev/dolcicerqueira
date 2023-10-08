CREATE PROCEDURE dbo.AddUser
    @UserName varchar(50),
    @UserEmail varchar(100),
	@UserPassword varchar(50),
    @UserAdmin bit,
    @UserBlocked bit,
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Users (UserName, UserEmail, UserPassword, UserAdmin, UserBlocked)
    VALUES (@UserName, @UserEmail, @UserPassword, @UserAdmin, @UserBlocked);
END
