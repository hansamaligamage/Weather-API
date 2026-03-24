CREATE USER weatherapp_user WITH PASSWORD = 'HelloRajarata123';

ALTER ROLE db_datareader ADD MEMBER weatherapp_user;
ALTER ROLE db_datawriter ADD MEMBER weatherapp_user;
ALTER ROLE db_ddladmin ADD MEMBER weatherapp_user;
