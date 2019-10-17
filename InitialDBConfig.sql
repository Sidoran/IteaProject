DELETE FROM  Agents
DBCC CHECKIDENT (Agents, RESEED, 0 )
DELETE FROM [Events]
DBCC CHECKIDENT ([Events], RESEED, 0 )
DELETE FROM RunBooks
DBCC CHECKIDENT (RunBooks, RESEED, 0 )
DELETE FROM RunTasks
DBCC CHECKIDENT (RunTasks, RESEED, 0 )


INSERT INTO Agents ([Name], [IpAddress])
VALUES('IH-DC2-Bot01','172.22.20.111'),
	  ('IH-DC2-Bot02','172.22.20.112')

INSERT INTO RunBooks([Name],[Author],[isActive],[WhenChanged],[WhenCreated])
VALUES ('Test Runbook','Sidorenko Andrey',1, GETDATE(),GETDATE())

INSERT INTO RunTasks ([Name],[Author],[RunBookId],[RunbookOrder],[IsActive], [WhenChanged], [WhenCreated])
VALUES ('Hello World','Sidorenko Andrey',1, 1, 1,GETDATE(),GETDATE())
