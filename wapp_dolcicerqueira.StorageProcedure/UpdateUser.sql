CREATE PROCEDURE dbo.UpdateUser
    @UserName varchar(50),
    @UserEmail varchar(100),
	@UserPassword varchar(50),
    @UserAdmin bit,
    @UserBlocked bit,
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Users
    SET UserName = @UserName,
        UserEmail = @UserEmail,
        UserPassword = @UserPassword,
        UserAdmin = @UserAdmin,
        UserBlocked = @UserBlocked,
    WHERE UserId = @UserId;
END
