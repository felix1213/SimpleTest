DECLARE @i INT
SET @i=0
WHILE @i<10000      --10000Ϊ��Ҫִ�в���Ĵ���
BEGIN
INSERT INTO [dbo].[tbUser]
           ([AccountName]
           ,[Password]
           ,[RealName]
           ,[RoleId]
           ,[MobilePhone]
           ,[Email]
           ,[IsAble]
           ,[IfChangePwd]
           ,[Description])
     VALUES
           ('user_'+ CAST(@i AS VARCHAR)
           ,''
           ,'user_'+ CAST(@i AS VARCHAR)
           ,1
           ,''
           ,'user_'+ CAST(@i AS VARCHAR) + '@yyxx.com'
           ,1
           ,1
           ,'')
SET @i=@i+1
END
