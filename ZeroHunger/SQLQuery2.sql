/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Type]
      ,[Quantity]
      ,[Status]
      ,[AssignedEmployee]
      ,[RequestedRestaurant]
  FROM [ZeroHunger].[dbo].[Food]

  