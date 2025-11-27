INSERT INTO dbo.Categories (Name, CreatedDate, ModifiedDate)
VALUES
    (N'Thriller', SYSDATETIME(), SYSDATETIME()),
    (N'Comedy',   SYSDATETIME(), SYSDATETIME()),
    (N'Action',   SYSDATETIME(), SYSDATETIME());

    select * from Categories