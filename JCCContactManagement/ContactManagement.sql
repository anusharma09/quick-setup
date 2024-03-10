USE [Atef]
GO
/****** Object:  StoredProcedure [dbo].[up_CMJobStaticTablesUpdate]    Script Date: 01/08/2012 19:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
**	
**		
**		
**		
**		
*/
ALTER PROCEDURE [dbo].[up_CMJobStaticTablesUpdate]

AS
DECLARE  @CodeType			VARCHAR(10)
DECLARE @Code			VARCHAR(20)
DECLARE @Description			VARCHAR(50)

-- ------------------------------------------------
-- Update Customer Data
-- -----------------------------------------------
DECLARE @CustomerID		VARCHAR(20)
DECLARE @AlphaName		VARCHAR(20)
DECLARE @Name		VARCHAR(50)
DECLARE @Address1		VARCHAR(50)
DECLARE @Address2		VARCHAR(50)
DECLARE @City		VARCHAR(35)
DECLARE @State		CHAR(2)
DECLARE @ZipCode		VARCHAR(20)
DECLARE @Telephone		VARCHAR(20)
DECLARE @FaxNo		VARCHAR(20)
DECLARE @Contact		VARCHAR(50)
DECLARE CUR_Customers CURSOR  FAST_FORWARD READ_ONLY FOR 
SELECT Cust_ID, Alpha_Name, [Name], Address1, Address2, City, State, zip_Cd, Telephone, Fax_No, Contact FROM StarBldr.dbo.ARCustomers
OPEN CUR_Customers
FETCH NEXT FROM CUR_Customers
INTO @CustomerID, @AlphaName, @Name, @Address1, @Address2, @City, @State, @ZipCode, @Telephone, @FaxNo, @Contact
WHILE @@FETCH_STATUS = 0	
	BEGIN
		UPDATE tblCMCompany SET
			CMCompanyAlphaName		= @AlphaName,
			CMCompanyName			= @Name,
			CMCompanyAddress		= @Address1,
			CMCompanyAddress2		= @Address2,
			CMCompanyCity			= @City,
			CMCompanyState			= @State,
			CMCompanyZip			= @ZipCode,
			CMCompanyPhone			= @Telephone,
			CMCompanyFax			= @FaxNo
			
		WHERE CMCompanySystemID = @CustomerID AND IsCustomer = 1	
		IF @@ROWCOUNT = 0
			INSERT INTO tblCMCompany (CMCompanySystemID,			
				CMCompanyAlphaName,			
				CMCompanyName,				
				CMCompanyAddress,			
				CMCompanyAddress2,			
				CMCompanyCity,				
				CMCompanyState,				
				CMCompanyZip,				
				CMCompanyPhone,				
				CMCompanyFax,
				ISCustomer)			
			VALUES(
				@CustomerID,
				@AlphaName,
				@Name,
				@Address1,
				@Address2,
				@City,
				@State,
				@ZipCode,
				@Telephone,
				@FaxNo,
				1)
		FETCH NEXT FROM CUR_Customers
		INTO @CustomerID, @AlphaName, @Name, @Address1, @Address2, @City, @State, @ZipCode, @Telephone, @FaxNo, @Contact
	END
CLOSE CUR_Customers
DEALLOCATE CUR_Customers


UpdateVendor:
-- ------------------------------------------------
-- Update Vendor Table
-- -----------------------------------------------
DECLARE @VendorID		VARCHAR(20)
DECLARE @AlphaName1		VARCHAR(20)
DECLARE @Name1		VARCHAR(50)
DECLARE @Address11		VARCHAR(50)
DECLARE @Address12		VARCHAR(50)
DECLARE @City1		VARCHAR(35)
DECLARE @State1		CHAR(2)
DECLARE @ZipCode1		VARCHAR(20)
DECLARE @Telephone1		VARCHAR(20)
DECLARE @FaxNo1		VARCHAR(20)
DECLARE @Contact1		VARCHAR(50)
DECLARE CUR_Vendors CURSOR  FAST_FORWARD READ_ONLY FOR
/* Update From Starbuilder */ 
SELECT Vend_ID, Alpha_Name, [Name], Address1, Address2, City, State, zip_Cd, Telephone, LTRIM(RTRIM(Fax_No)), Contact FROM StarBldr.dbo.APVendors
OPEN CUR_Vendors
FETCH NEXT FROM CUR_Vendors
INTO @VendorID, @AlphaName1, @Name1, @Address11, @Address12, @City1, @State1, @ZipCode1, @Telephone1, @FaxNo1, @Contact1
WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE tblCMCompany SET
			CMCompanyAlphaName		= @AlphaName1,
			CMCompanyName			= @Name1,
			CMCompanyAddress		= @Address11,
			CMCompanyAddress2		= @Address12,
			CMCompanyCity			= @City1,
			CMCompanyState			= @State1,
			CMCompanyZip			= @ZipCode1,
			CMCompanyPhone			= @Telephone1,
			CMCompanyFax			= @FaxNo1
		WHERE CMCompanySystemID = @VendorID AND IsVendor = 1	
		IF @@ROWCOUNT = 0
			INSERT INTO tblCMCompany (CMCompanySystemID,			
				CMCompanyAlphaName,			
				CMCompanyName,				
				CMCompanyAddress,			
				CMCompanyAddress2,			
				CMCompanyCity,				
				CMCompanyState,				
				CMCompanyZip,				
				CMCompanyPhone,				
				CMCompanyFax,
				ISVendor)			
			VALUES(
				@VendorID,
				@AlphaName1,
				@Name1,
				@Address11,
				@Address12,
				@City1,
				@State1,
				@ZipCode1,
				@Telephone1,
				@FaxNo1,
				1)
		
		
		FETCH NEXT FROM CUR_Vendors
		INTO @VendorID, @AlphaName1, @Name1, @Address11, @Address12, @City1, @State1, @ZipCode1, @Telephone1, @FaxNo1, @Contact1
	END
CLOSE CUR_Vendors 
DEALLOCATE CUR_Vendors













