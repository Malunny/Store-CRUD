SELECT * FROM [ProductPurchase]

INSERT INTO Purchases (ClientId, EmployeeId, NumberProducts, TotalPrice, [Date])
VALUES (1, 2, 2, 6049.89, GETDATE());

SELECT * FROM Purchases;
SELECT * FROM Products;
INSERT INTO ProductPurchase (PurchaseId, ProductId)
VALUES 
(3, 1), -- Compra 1, Produto 1 (iPhone)
(3, 2); -- Compra 1, Produto 2 (Camiseta)

GO
