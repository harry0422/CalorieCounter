
-- drop table public.tbl_daily_activities;

create table tbl_daily_activities (
	id          serial       not null,
	description varchar(255) not null,
	factor      float8       not null,
	constraint tbl_daily_activities_pkey primary key (id)
);

insert into tbl_daily_activities values (1, 'Little to no exercise', 1.2);
insert into tbl_daily_activities values (2, 'Light exercise',        1.37);
insert into tbl_daily_activities values (3, 'Moderate exercise',     1.55);
insert into tbl_daily_activities values (4, 'Exercises hard',        1.725);
insert into tbl_daily_activities values (5, 'Extra active',          1.9);

-- drop table tbl_users;

create table tbl_users (
	user_id        varchar(255) not null,
	email          varchar(255) not null,
	password       varchar(255) not null,
	name           varchar(255) not null,
	age            int4         not null,
	weight         float8       not null,
	height         float8       not null,
	gender         varchar(255) not null,
	creation_date  timestamp    not null,
	status         varchar(255) not null,
	daily_activity int4         not null,
	constraint tbl_users_pkey primary key (user_id)
);

alter table tbl_users add constraint daily_activity_fk foreign key (daily_activity) references tbl_daily_activities(id);



select * from tbl_users;
select * from tbl_daily_activities;
