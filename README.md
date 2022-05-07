# locRentApi

############### DataBase Configuration ####################
create database locrent;

para a criação do banco é utilizado o fluent migrator

a criação do banco é manual.

dotnet tool install -g FluentMigrator.DotNet.Cli

é necessário colocar o caminho absoluto da DLL do projeto de infra.
dotnet fm migrate -p mysql -c "Server=localhost;Database=locRent;Uid=root;Pwd=teste-123;" -a " local do projeto \Loc.Rent.Infrastructure.dll" --allowDirtyAssemblies

INSERT INTO `country` (`id`, `name`) VALUES ('1', 'Brasil');

INSERT INTO `state` (`name`, `initials`, `country_id`) VALUES ('Minas Gerais', 'MG', '1');
INSERT INTO `state` (`name`, `initials`, `country_id`) VALUES ('São Paulo', 'SP', '1');
INSERT INTO `state` (`name`, `initials`, `country_id`) VALUES ('Rio de Janeiro', 'RJ', '1');

INSERT INTO `city` (`name`, `state_id`) VALUES ('Belo Horizonte', '1');
INSERT INTO `city` (`name`, `state_id`) VALUES ('São Paulo', '2');
INSERT INTO `city` (`name`, `state_id`) VALUES ('Rio de Janeiro', '3');

INSERT INTO `manufacturer` (`name`) VALUES ('Fiat');
INSERT INTO `manufacturer` (`name`) VALUES ('Volkswagen');
INSERT INTO `manufacturer` (`name`) VALUES ('Ford');
INSERT INTO `manufacturer` (`name`) VALUES ('BMW');
INSERT INTO `manufacturer` (`name`) VALUES ('Hyundai');

INSERT INTO `model` (`id`,`name`,`manufacturer_id`) VALUES (1,'Novo Palio Attractive 1.4',1);
INSERT INTO `model` (`id`,`name`,`manufacturer_id`) VALUES (2,'Gol Copa 1.6',2);
INSERT INTO `model` (`id`,`name`,`manufacturer_id`) VALUES (3,'Ka+',3);
INSERT INTO `model` (`id`,`name`,`manufacturer_id`) VALUES (4,'350I',4);
INSERT INTO `model` (`id`,`name`,`manufacturer_id`) VALUES (5,'HB20 Premium 1.6',5);

Rota padrão https://localhost:5001/swagger/index.html

############################################################

Tecnologias Utilizadas

- .Netcore 5.0
- Mysql
- FluentMigrator
- FluentHibernate
- FluentValidation
- caelum.Stella.CSharp
- xUnit
- Swagger
- NHibernate
- LinqKit