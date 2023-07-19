select * from sysObjects where Type = 'U' 

select * from UserLogins;
select * from UserDetails;
select * from MessageDetails;

update UserDetails set Name = 'Hari Prasath', Email = 'hprasath21212@gmail.com',Mobile='7448915571' where id = 1;


insert into UserDetails values(2,'Avinas','avinas@gmail.com','9874648756');
insert into UserDetails values(3,'Arun Hiruthik','arun@gmail.com','7569858885');
insert into UserDetails values(4,'Guhan','guhan@gmail.com','8759515878');

insert into MessageDetails values('Hi from arun',1,3,'2023-07-15 12:22:01.997');
insert into MessageDetails values('Hi from avi',1,2,'2023-07-15 12:22:01.997');
insert into MessageDetails values('from avi to hari',2,1,'2023-07-17 5:22:56');
insert into MessageDetails values('from guhan to hari',1,4,'2023-07-17 5:22:56');

update MessageDetails set SenderId = 1,RecipientId = 4 where MessageId = 5;
insert into UserLogins(UserName,Password) values('guhan','1234');
insert into UserLogins(UserName,Password) values('arun','1234');