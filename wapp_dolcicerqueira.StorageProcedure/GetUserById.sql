CREATE PROCEDURE dbo.GetUserById
    @UserId int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT UserId, UserName, UserEmail, UserPassword, UserBlocked, UserAdmin
    FROM dbo.Users
    WHERE UserId = @UserId;
END
