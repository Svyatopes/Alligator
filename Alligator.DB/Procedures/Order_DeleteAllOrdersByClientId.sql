CREATE PROCEDURE [dbo].[Order_DeleteAllOrdersByClientId]
@ClientId int 
AS
BEGIN
DELETE FROM dbo.[Order]
      WHERE ClientId  = @ClientId
END
