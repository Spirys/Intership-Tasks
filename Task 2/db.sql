if not exists (select * from sysobjects where name='Files' and xtype='U')
    create table Files (
		Id int not null identity(1,1) primary key,
		FileVersion varchar(32) not null,
        Name varchar(100) not null,
		DateTime DateTime not null
    )
go