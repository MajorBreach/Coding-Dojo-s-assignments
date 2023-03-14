SELECT * FROM dojo_and_ninjas_db.dojos;
insert into dojo_and_ninjas_db.dojos (Name)
values ("Ranked"), ("Geckos"), ("John");
-- ---------------------------------------------------------- 
delete from dojo_and_ninjas_db.dojos
WHERE (id = 1);
delete from dojo_and_ninjas_db.dojos
where (id = 2);
delete from dojo_and_ninjas_db.dojos
where (id = 3);

insert into dojo_and_ninjas_db.ninjas (first_name, last_name,age,dojo_id)
value ("ranked" , "up" , 1 , 1), 
("geckos","mike",2,1),
("john","qq",3,1);


insert into dojo_and_ninjas_db.ninjas (first_name, last_name,age,dojo_id)
value ("ll" , "ii" , 10 , 2), 
("xx","rr",20,2),
("bb","qq",30,2);


insert into dojo_and_ninjas_db.ninjas (first_name, last_name,age,dojo_id)
value ("ll" , "ii" , 10 , 3), 
("xx","rr",20,3),
("bb","qq",30,3);

Select * from dojo_and_ninjas_db.dojos
left join dojo_and_ninjas_db.ninjas on dojos.id = ninjas.dojo_id
where dojos.id = 1;

select * from dojo_and_ninjas_db.dojos
left join dojo_and_ninjas_db.ninjas on dojos.id = ninjas.dojo_id
WHERE dojos.id = 3;

select * from dojo_and_ninjas_db.dojos  where dojos.id = (select dojo_id from ninjas where id = 6);





