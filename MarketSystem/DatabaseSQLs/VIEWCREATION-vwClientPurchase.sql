CREATE OR ALTER VIEW vwClientPurchase 
AS
SELECT [Clients].[Id], [Clients].[Name], [Clients].[Email],
       [Purchase].[TotalPrice], [Purchase].[NumberProducts]
FROM [Purchase]
INNER JOIN [Clients] ON [Clients].[Id] = [Purchase].[ClientId];