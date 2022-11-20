/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[UserName]
      ,[Location]
      ,[Password]
      ,[PhoneNumber]
  FROM [ZeroHunger].[dbo].[Restaurant]

