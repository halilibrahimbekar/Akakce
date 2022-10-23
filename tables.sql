create table if not exists Product (
	Id uuid primary key,
	CreatedDateTime Date,
	ProductName varchar(100) unique not null
);
create table if not exists ProductStock (
	Id uuid primary key,
	CreatedDateTime Date,
    Stock int,
	ProductId	uuid,
    FOREIGN KEY (ProductId)
      REFERENCES Product (Id)
);

create table if not exists CustomerCart (
	Id uuid primary key,
	CreatedDateTime Date,
    Count int,
	CustomerId uuid,
	ProductId	uuid,
    FOREIGN KEY (ProductId)
      REFERENCES Product (Id)
);
insert into Product values ('3c747f97-7549-403d-8ad2-966425e09456', now(), 'Red Dress')
							,('996aabf0-7b71-4867-80d0-da404002699c', now(), 'Computer');
							
insert into ProductStock values ('597ae36b-9d63-4bd3-b6c2-70e57344ec77', now(), 5, '3c747f97-7549-403d-8ad2-966425e09456')
						,('cd56d250-e960-4d1b-a7e1-37a2a101457d', now(), 0, '996aabf0-7b71-4867-80d0-da404002699c');	