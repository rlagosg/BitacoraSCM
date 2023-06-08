-- DEBES ACTIVAR EL INICIO DE SESION DE MODO MIXTO SI NO ESTA ACTIVO

IF NOT EXISTS (SELECT 1 FROM sys.syslogins WHERE name = 'SCM')
BEGIN
    USE master;
    CREATE LOGIN SCM WITH PASSWORD = '123';
    USE SCM;
    CREATE USER SCM FOR LOGIN SCM;
    GRANT SELECT, INSERT, UPDATE, DELETE TO SCM;
END

-- CREAR UN ROL PARA ASIGNAR PERMISOS AL USUARIO SCM
-----------------------------------------------------------
IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'EJECUTOR' AND type = 'R')
BEGIN
    CREATE ROLE EJECUTOR;

    -- Asignar permiso de ejecución a todos los procedimientos almacenados existentes
    DECLARE @sql NVARCHAR(MAX) = '';
    SELECT @sql += 'GRANT EXECUTE ON ' + QUOTENAME(SCHEMA_NAME(schema_id)) + '.' + QUOTENAME(name) + ' TO EJECUTOR;' + CHAR(13)
    FROM sys.procedures;
    EXEC sp_executesql @sql;

    -- Asignar permiso de SELECT a todas las tablas existentes
    SET @sql = '';
    SELECT @sql += 'GRANT SELECT ON ' + QUOTENAME(SCHEMA_NAME(schema_id)) + '.' + QUOTENAME(name) + ' TO EJECUTOR;' + CHAR(13)
    FROM sys.tables;
    EXEC sp_executesql @sql;

    -- Asignar permiso de UPDATE a todas las tablas existentes
    SET @sql = '';
    SELECT @sql += 'GRANT UPDATE ON ' + QUOTENAME(SCHEMA_NAME(schema_id)) + '.' + QUOTENAME(name) + ' TO EJECUTOR;' + CHAR(13)
    FROM sys.tables;
    EXEC sp_executesql @sql;

    -- Asignar el rol al usuario específico
    EXEC sp_addrolemember 'EJECUTOR', 'SCM';
END

