create database if not exists countries;
use countries;

create table if not exists countries (
	country_id int primary key auto_increment not null,
    name_country nvarchar(50) not null,
    budget int not null,
    life_level int(100) not null,
    nuclear char(1) character set utf8mb4 not null
);
insert into countries (name_country, budget, life_level, nuclear) values ("Россия", 0, 0, '0');
insert into countries (name_country, budget, life_level, nuclear) values ("США", 0, 0, '0');
insert into countries (name_country, budget, life_level, nuclear) values ("Израиль", 0, 0, '0');
insert into countries (name_country, budget, life_level, nuclear) values ("Польша", 0, 0, '0');
insert into countries (name_country, budget, life_level, nuclear) values ("Германия", 0, 0, '0');
insert into countries (name_country, budget, life_level, nuclear) values ("Япония", 0, 0, '0');
insert into countries (name_country, budget, life_level, nuclear) values ("Китай", 0, 0, '0');

create table if not exists cities (
	city_id int primary key auto_increment not null,
    name_city nvarchar(100) not null,
    country_id int not null,
    growth int(100) not null,
    life_level int(100) not null,
    income int not null,
    armament int not null,
    foreign key (country_id) references countries (country_id)
);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Москва", 1, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Санкт-Петербург", 1, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Владивосток", 1, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Новосибирск", 1, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Вашингтон", 3, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Нью-Йорк", 3, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Лос-Анджелес", 3, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Сан-Франциско", 3, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Иерусалим", 2, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Тель-Авив", 2, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Хайфа", 2, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Назарет", 2, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Варшава", 4, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Краков", 4, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Люблин", 4, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Вроцлав", 4, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Берлин", 5, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Мюнхен", 5, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Кёлн", 5, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Гамбург", 5, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Токио", 6, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Осака", 6, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Хиросима", 6, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Нагасаки", 6, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Пекин", 7, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Шанхай", 7, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("Гуанчжоу", 7, 0, 0, 0, 0);
insert into cities (name_city, country_id, growth, life_level, income, armament) values ("ШэньЧжень", 7, 0, 0, 0, 0);

create table if not exists sanctions (
	sanction_id int primary key auto_increment not null,
	sender nvarchar(50) not null,
    target nvarchar(50) not null
);

create table if not exists income (
	income_id int primary key auto_increment not null,
    country_id int not null,
    income_description nvarchar(255) not null,
    income_value int not null,
    foreign key (country_id) references countries (country_id)
);
create table if not exists expenses (
	expense_id int primary key auto_increment not null,
    country_id int not null,
    expense_description nvarchar(255) not null,
    expense_value int not null,
    foreign key (country_id) references countries (country_id)
);