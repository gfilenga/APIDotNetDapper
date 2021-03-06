CREATE PROCEDURE spGetCustomerOrdersResult
	@Document CHAR(11)
	AS
	SELECT 
		c.[Id],
		CONCAT(c.[FirstName],' ', c.[LastName]) AS [Name],
		c.[Document],
		COUNT(o.Id)
	FROM
		[Customer] c 
	INNER JOIN 
		[Order] o 
	ON 
		o.[CustomerId] = c.[Id]