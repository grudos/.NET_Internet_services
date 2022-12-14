use SportsAgents;

create table Users(
	[Login] nvarchar(128) not null,
	[Password] nvarchar(255) not null,
	EMail nvarchar(128) not null,
    FullName nvarchar(40) not null,
    Age int not null,
	primary key ([Login])
);

create table Athletes(
    ID int identity(1,1) not null,
    FullName nvarchar(40) not null,
    Age int not null,
	DisciplineName nvarchar(30) not null,
	UserLogin nvarchar(128) not null,

	primary key (ID),
	foreign key (UserLogin) references Users([Login]),
);

insert into Users([Login], [Password], EMail, FullName, Age)
values('admin@student.pg.edu.pl', 'admin', 'admin@student.pg.edu.pl', 'admin admin', 30);

insert into Users([Login], [Password], EMail, FullName, Age)
values('user1@example.com', 'user1', 'user1@example.com', 'user user', 30);

insert into Athletes(FullName, Age, DisciplineName, UserLogin)
values('Robert Kubica', 35, 'Formula 1', 'user1@example.com');

insert into Athletes(FullName, Age, DisciplineName, UserLogin)
values('Bartosz Zmarlik', 35, '?uzel', 'user1@example.com');

insert into Athletes(FullName, Age, DisciplineName, UserLogin)
values('Robert Lewandowski', 35, 'Pi?ka No?na', 'user1@example.com');

/*
drop table if exists Athletes
drop table if exists Users

select * from Users
select * from Athletes
*/