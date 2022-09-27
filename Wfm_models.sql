CREATE TABLE employees (
    employee_id int NOT NULL,
    name varchar(50) NOT NULL,
    status varchar(50) NOT NULL,
    manager varchar(30),
    wfm_manager varchar(30),
    email text,
    lockstatus varchar(30),
    experience decimal(5,0),
    profile_id int,
    primary key (employee_id)
);

insert into employees values ( 600,'Manju', 'approved','Sambath','Sathish','Manju@softura.com','Not Locked',2,100)
insert into employees values ( 620,'Navreen', 'rejected','Kumaran','Wasim','navreen@softura.com','Locked',3,101)
insert into employees values ( 632,'Shakthi', 'approved','Sabitha','Sabitha','ShakthiRM@softura.com','Not Locked',4,102)


CREATE TABLE users (
    username varchar(30) NOT NULL,
    password varchar(30) NOT NULL,
    name varchar(30) NOT NULL,
    role varchar(30) NOT NULL,
    email text
);

insert into users values ('Abi' , 'Abi@20', 'Abirami','Software Engineer','Abirami@gmail.com')
insert into users values ('Viki' , 'Viki@10', 'Vignesh','Trainee','Vignesh@gmail.com')
insert into users values ('Priya' , 'Priya@30', 'Priyadharshni','Test Engineer','priya@gmail.com')


CREATE TABLE skills (
	skillid decimal(5,0) NOT NULL,
    name varchar(30) NOT NULL,
    primary key (skillid)
);

insert into skills values (1, 'java, sql server, C#')
insert into skills values (2, 'Angular, react js, node js')
insert into skills values (3, 'Python, javascript, jquery')

CREATE TABLE skillmap (
	employee_id int ,
	skillid decimal(5,0) ,
	FOREIGN KEY (employee_id) REFERENCES employees (employee_id),
    FOREIGN KEY (skillid) REFERENCES skills (skillid)
);

insert into skillmap values (600, 1)
insert into skillmap values (620, 2)
insert into skillmap values (632, 3)

CREATE TABLE softlock (
	employee_id int ,
	manager varchar(30),
    reqdate date,
    status varchar(30),
    lastupdated date,
    lockid int not null ,
    requestmessage text,
    wfmremark text,
    managerstatus varchar(30),
    mgrstatuscomment text,
    mgrlastupdate date,
    primary key (lockid),
	FOREIGN KEY (employee_id) REFERENCES employees (employee_id)
);

insert into softlock values (632, 'Sabitha','2022-09-05','Requested','2022-08-16',10,'Employee selected','','','',null)

drop table Brand