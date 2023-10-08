CREATE PROCEDURE dbo.DeleteUser
    @UserId int
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Users
    WHERE UserId = @UserId;
END
