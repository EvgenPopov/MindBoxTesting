CREATE TABLE [dbo].[Categories](
Id			 INT			NOT NULL,
CategoryName NVARCHAR(32)	NULL,
CONSTRAINT PK_Categories PRIMARY KEY (ID))

GO

CREATE TABLE [dbo].[Products](
Id			INT				NOT NULL,
ProductName NVARCHAR(32)	NULL,
CONSTRAINT PK_Products PRIMARY KEY (ID))

GO

CREATE TABLE [dbo].[CategoriesProducts](
CategoriesId	INT		NOT NULL,
ProductsId		INT		NOT NULL,
CONSTRAINT PK_CategoriesProducts				PRIMARY KEY(CategoriesID, ProductsId),
CONSTRAINT FK_CategoriesProducts_CategoriesId	FOREIGN KEY (CategoriesId)	REFERENCES [dbo].[Categories] (Id),
CONSTRAINT FK_CategoriestProducts_ProductsId	FOREIGN KEY (ProductsId)	REFERENCES [dbo].[Products] (Id));

GO

DECLARE @i int = 0;
DECLARE @endValue int = 20;

WHILE(@i <= @endValue)
BEGIN 
	INSERT [dbo].[Categories] VALUES(@i, 'CatName' + CAST(@i AS NVARCHAR(5)));
	INSERT [dbo].[Products] VALUES(@i,'ProdName'+ CAST(@i AS NVARCHAR(5)));
	SET @i += 1;
END

INSERT [dbo].CategoriesProducts VALUES (1,1),(1,2),(1,3),(2,1),(3,1),(5,1),(5,7),(8,8)
GO

Select pr.ProductName 'Имя продукта', ct.CategoryName 'Имя категории' 
FROM Products pr
LEFT OUTER JOIN dbo.CategoriesProducts cp
ON cp.ProductsId = pr.Id
Left OUTER JOIN Categories ct
ON ct.id = cp.CategoriesId 

