


--CREAMOS LA BD
CREATE DATABASE SCM
GO

USE SCM
GO

--------------------------
------- USUARIOS
--------------------------
CREATE TABLE Modulos (
    IdModulo VARCHAR(100) PRIMARY KEY,
    Descripcion VARCHAR(200) NULL,
    Activo bit
);

CREATE TABLE Roles (
    IdRol int PRIMARY KEY NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200) NULL,
    Activo bit
);
GO

--------------------------
------- PERSONAS
--------------------------
CREATE TABLE Nacionalidades (
    IdNacionalidad INT PRIMARY KEY IDENTITY(1,1),
    Pais VARCHAR(40) NOT NULL,     
    Nacionalidad VARCHAR(40) NOT NULL, 
    Activo bit
);

CREATE TABLE Personas (
    IdPersona VARCHAR(13) PRIMARY KEY,
    PrimerNombre VARCHAR(70) NOT NULL,
    SegundoNombre VARCHAR(70),
    PrimerApellido VARCHAR(70) NOT NULL,
    SegundoApellido VARCHAR(70),
    IdNacionalidad INT FOREIGN KEY REFERENCES Nacionalidades(IdNacionalidad) ON UPDATE CASCADE NOT NULL,
    FechaNac DATE,
    Genero VARCHAR(10),
    RTN VARCHAR(15),                                         
    Activo bit
);
GO

CREATE TABLE Fotografias(
    IdFoto INT PRIMARY KEY IDENTITY(1,1),
    IdPersona VARCHAR(13) FOREIGN KEY REFERENCES Personas(IdPersona) ON UPDATE CASCADE NOT NULL,
    fotografia image,
    Activo bit
)

CREATE TABLE Tipos (
    IdTipo INT PRIMARY KEY IDENTITY(1, 1),
    Nombre VARCHAR(25),
    Descripcion VARCHAR(500),
    Tipo VARCHAR(25),
    Activo bit
)

CREATE TABLE Municipios(
    IdMunicipio INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(70) NOT NULL,
    Descripcion VARCHAR(500),
    Activo bit
);

--Se permite volver a crear la misma direccion, por la condicion de actualizacion en cascada, por lo que la validacion se hara en un SP
CREATE TABLE Direcciones (
    IdDireccion INT PRIMARY KEY IDENTITY(1, 1),
    Nombre VARCHAR(100),
    Descripcion VARCHAR(500),
    IdMunicipio INT FOREIGN KEY REFERENCES Municipios(IdMunicipio) ON UPDATE CASCADE NULL,
    IdTipo INT FOREIGN KEY REFERENCES Tipos(IdTipo) ON UPDATE CASCADE NOT NULL,
    Activo bit
);
GO

CREATE TABLE Contactos (
    IdContacto INT PRIMARY KEY IDENTITY(1,1),
    IdPersona VARCHAR(13) FOREIGN KEY REFERENCES Personas(IdPersona) ON UPDATE CASCADE NOT NULL,
    Contacto VARCHAR(50),
    Descripcion VARCHAR(500),
    IdTipo INT FOREIGN KEY REFERENCES Tipos(IdTipo) ON UPDATE CASCADE NOT NULL,
    Activo bit
);
GO

CREATE TABLE DireccionPersona(    
    IdDireccion INT PRIMARY KEY IDENTITY(1,1),
    IdPersona VARCHAR(13) FOREIGN KEY REFERENCES Personas(IdPersona) ON UPDATE CASCADE NOT NULL,
    Colonia INT FOREIGN KEY REFERENCES Direcciones(IdDireccion) NULL,
    Barrio INT FOREIGN KEY REFERENCES Direcciones(IdDireccion) NULL,
    Aldea INT FOREIGN KEY REFERENCES Direcciones(IdDireccion) NULL,
    Residencial INT FOREIGN KEY REFERENCES Direcciones(IdDireccion) NULL,
    Comentario VARCHAR(500) NULL,
    Activo bit
);
GO


--------------------------
------- EMPLEADO
--------------------------
CREATE TABLE Empleados (
    IdEmpleado INT PRIMARY KEY IDENTITY(1,1),
    IdPersona VARCHAR(13) FOREIGN KEY REFERENCES Personas(IdPersona) ON UPDATE CASCADE NOT NULL,
    Activo bit
);
GO

CREATE TABLE RolesEmpleados (
    IdRolesEmpleados INT PRIMARY KEY IDENTITY(1,1),
    IdEmpleado INT FOREIGN KEY REFERENCES Empleados(IdEmpleado) ON UPDATE CASCADE,
    IdRol INT FOREIGN KEY REFERENCES Roles(IdRol) ON UPDATE CASCADE,
    CONSTRAINT ROL_EMP UNIQUE (IdEmpleado, IdRol)
);
GO

-----UNION EMPLEADO-USUARIO
CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(25) UNIQUE,
    Contrasenia VARBINARY(64),
    IdEmpleado INT FOREIGN KEY REFERENCES Empleados(IdEmpleado) ON UPDATE CASCADE NOT NULL,
    Activo bit
);

CREATE TABLE Permisos (
    IdPermiso INT PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario) ON UPDATE CASCADE,
    IdModulo VARCHAR(100) FOREIGN KEY REFERENCES Modulos(IdModulo) ON UPDATE CASCADE NOT NULL,
    Vista INT NOT NULL,
    Salvar INT NOT NULL,
    Modificar INT NOT NULL,
    Eliminar INT NOT NULL,
    Activo bit
);
GO

--------------------------
------- EXPEDIENTES
--------------------------
---Tabla para los diferentes estados en que puede estar el expediente segun el rol del usuario
CREATE TABLE Estados (
    IdEstado INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(25),
    Descripcion VARCHAR(100),
    Activo bit
);
GO

CREATE TABLE EstadosRoles (
    IdEstadoRol INT PRIMARY KEY IDENTITY(1,1),
    IdRol INT FOREIGN KEY REFERENCES Roles(IdRol) ON UPDATE CASCADE NOT NULL,
    IdEstado INT FOREIGN KEY REFERENCES Estados(IdEstado) ON UPDATE CASCADE NOT NULL,
    Numero INT,
    Activo bit
);
GO

CREATE TABLE Expedientes (
    IdExpediente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) UNIQUE,     
    Activo BIT
);
GO

--Informacion general para el expediente en todos los controles o secciones, estos seran los campos que comparten todos los controles
CREATE TABLE Controles (
    IdControl INT PRIMARY KEY IDENTITY(1,1),
    IdExpediente INT FOREIGN KEY REFERENCES Expedientes(IdExpediente) ON UPDATE CASCADE NOT NULL,
    FechaInicio DATETIME,    
    Iniciador INT FOREIGN KEY REFERENCES Empleados(IdEmpleado) NOT NULL,
    ObsIni VARCHAR(500),
    Finalizador INT FOREIGN KEY REFERENCES Empleados(IdEmpleado) NULL,    
    FechaFin DATETIME NULL,
    ObsFin VARCHAR(500) NULL,     
    Activo bit
);
GO

--Tabla para poder almacenar el cambio entre usuarios y roles
CREATE TABLE Cambios_Proceso (
    IdCambios INT PRIMARY KEY IDENTITY(1,1),
    IdControl INT FOREIGN KEY REFERENCES Controles(IdControl) ON UPDATE CASCADE NOT NULL,
    Fecha DATETIME,
    IdRol INT FOREIGN KEY REFERENCES Roles(IdRol) NOT NULL,  
    Envio INT FOREIGN KEY REFERENCES Empleados(IdEmpleado) NOT NULL, 
    Recibio INT FOREIGN KEY REFERENCES Empleados(IdEmpleado) NOT NULL,
    Observaciones VARCHAR(500) NULL,
    EstadoActual INT NULL,
    Duracion TIME,
    Porcentaje INT,
    Activo bit
);
GO

--Historial de estados o cambios de estado dentro de los controles o secciones
CREATE TABLE Control_Estados (
    IdControlEstado INT PRIMARY KEY IDENTITY(1,1),
    IdCambios INT FOREIGN KEY REFERENCES Cambios_Proceso(IdCambios) ON UPDATE CASCADE NOT NULL,                                   
    IdEmpleado INT FOREIGN KEY REFERENCES Empleados(IdEmpleado) ON UPDATE CASCADE NOT NULL,
    IdEstadoRol INT FOREIGN KEY REFERENCES EstadosRoles(IdEstadoRol) ON UPDATE CASCADE NOT NULL,
    Completado BIT NOT NULL,    
    Fecha DATETIME,   
    FechaFin DATETIME NULL,   
    Duracion TIME,   
    Activo BIT
);
GO

CREATE TABLE Comentarios (
    IdComentario INT PRIMARY KEY IDENTITY(1,1),
    IdControlEstado INT FOREIGN KEY REFERENCES Control_Estados(IdControlEstado) ON UPDATE CASCADE NOT NULL,   
    Observaciones VARCHAR(500),
    Fecha DATETIME,
    Activo BIT
);

--Comenzamos a separa los controloes o secciones en que pasara el expediente y agregamos los campos que solamente tendran cada uno de los controles
CREATE TABLE Control_Verficacion (
    IdControlVer INT PRIMARY KEY IDENTITY(1,1),
    IdControl INT FOREIGN KEY REFERENCES Controles(IdControl) ON UPDATE CASCADE NOT NULL, 
    Activo bit
);
GO

CREATE TABLE Control_Campo (
    IdControlCam INT PRIMARY KEY IDENTITY(1,1),
    IdControl INT FOREIGN KEY REFERENCES Controles(IdControl) ON UPDATE CASCADE NOT NULL, 
    Activo bit
);
GO
CREATE TABLE Control_Tecnico (
    IdControlTec INT PRIMARY KEY IDENTITY(1,1),
    IdControl INT FOREIGN KEY REFERENCES Controles(IdControl) ON UPDATE CASCADE NOT NULL, 
    Activo bit
);
GO
--Tabla para relacionar los tecnicos que estaran dentro del control tecnico del expediente
CREATE TABLE Control_Tecnicos(
    IdTec INT PRIMARY KEY IDENTITY(1,1),
    IdTenico INT FOREIGN KEY REFERENCES Empleados(IdEmpleado) NOT NULL, 
    IdControlTec INT FOREIGN KEY REFERENCES Control_Tecnico(IdControlTec) ON UPDATE CASCADE NOT NULL,
    Activo bit
);
GO
CREATE TABLE Control_Dibujante (
    IdControlDib INT PRIMARY KEY IDENTITY(1,1),
    IdControl INT FOREIGN KEY REFERENCES Controles(IdControl) ON UPDATE CASCADE NOT NULL, 
    Activo bit
);
GO


--------------------------------
--INSERSION DE DATOS
--------------------------------

--ROLES DEL SISTEMA
-----------------------------------------------------------
INSERT INTO Roles (IdRol, Nombre, Activo) VALUES
(1, 'CAMPO', 1), (2, 'TECNICO', 1), (3, 'VERIFICADOR', 1), (4, 'DIBUJANTE', 1), (5, 'ADMINISTRADOR',1);
GO
--ESTADOS GLOABLAES DEL SISTEMA
-----------------------------------------------------------
INSERT INTO Estados (Nombre, Descripcion, Activo) VALUES
('Iniciado', 'Proceso iniciado', 1), ('Finalizado', 'Proceso finalizado', 1);
GO

--ESTADOS DE ROLES DEL SISTEMA
-----------------------------------------------------------
INSERT INTO EstadosRoles(IdRol, IdEstado, Numero, Activo) VALUES
(1, 1, 1, 1), (2, 1, 1, 1), (3, 1, 1, 1), (4, 1, 1, 1), (1, 2, 2, 1), (2, 2, 2, 1), (3, 2, 2, 1), (4, 2, 2, 1);
GO

--TIPOS DE DIRECCIONES
-----------------------------------------------------------
INSERT INTO Tipos (Nombre, Tipo, Activo) VALUES
('ALDEA', 'DIRECCION', 1), ('BARRIO', 'DIRECCION', 1), ('COLONIA', 'DIRECCION', 1), ('RESIDENCIAL', 'DIRECCION', 1), ( 'TELEFONO','CONTACTO', 1), ( 'CORREO','CONTACTO', 1);
GO
---NACIONALIDADES
-----------------------------------------------------------
INSERT INTO Nacionalidades (Nacionalidad, Pais, Activo) VALUES
('Afgana','Afganistán', 1), ('Albanesa','Albania', 1), ('Alemana','Alemania', 1), ('Alto volteña','Alto volta', 1), ('Andorrana','Andorra', 1), ('Angoleña','Angola', 1), ('Argelina','Argelia', 1), ('Argentina','Argentina', 1), ('Australiana','Australia', 1), ('Austriaca','Austria', 1), ('Bahamesa','Bahamas', 1), ('Bahreina','Bahrein', 1), ('Bangladesha','Bangladesh', 1), ('Barbadesa','Barbados', 1), ('Belga','Belgica', 1), ('Beliceña','Belice', 1), ('Bermudesa','Bermudas', 1), ('Birmana','Birmania', 1), ('Boliviana','Bolivia', 1), ('Botswanesa','Botswana', 1), ('Brasileña','Brasil', 1), ('Bulgara','Bulgaria', 1), ('Burundesa','Burundi', 1), ('Butana','Butan', 1), ('Camboyana','Khemer Rep de Camboya ', 1), ('Camerunesa','Camerun', 1), ('Canadiense','Canada', 1), ('Centroafricana','Rep Centroafricana', 1), ('Chadeña','Chad', 1), ('Checoslovaca','Rep. Checa', 1), ('Chilena','Chile', 1), ('China','China', 1), ('Chipriota','Chipre', 1), ('Colombiana','Colombia', 1), ('Congoleña','Congo', 1), ('Costarricense','Costa Rica', 1), ('Cubana','Cuba', 1), ('Dahoneya','Dahoney', 1), ('Danes','Dinamarca', 1), ('Dominicana','Rep. Dominicana', 1), ('Ecuatoriana','Ecuador', 1), ('Egipcia','Egipto', 1), ('Emirata','Emiratos Arabes Udo.', 1), ('Escosesa','Escocia', 1), ('Eslovaca','Rep. Eslovaca', 1), ('Española','España', 1), ('Estona','Estonia', 1), ('Etiope','Etiopia', 1), ('Fijena','Fiji', 1), ('Filipina','Filipinas', 1), ('Finlandesa','Finlandia', 1), ('Francesa','Francia', 1), ('Gabiana','Gambia', 1), ('Gabona','Gabon', 1), ('Galesa','Gales', 1), ('Ghanesa','Ghana', 1), ('Granadeña','Granada', 1), ('Griega','Grecia', 1), ('Guatemalteca','Guatemala', 1), ('Guinesa Ecuatoriana','Guinea Ecuatorial', 1), ('Guinesa','Guinea', 1), ('Guyanesa','Guyana', 1), ('Haitiana','Haiti', 1), ('Holandesa','Holanda', 1), ('Hondureña','Honduras', 1), ('Hungara','Hungria', 1), ('India','India', 1), ('Indonesa','Indonesia', 1), ('Inglesa','Inglaterra', 1), ('Iraki','Irak', 1), ('Irani','Iran', 1), ('Irlandesa','Irlanda', 1), ('Islandesa','Islandia', 1), ('Israeli','Israel', 1), ('Italiana','Italia', 1), ('Jamaiquina','Jamaica', 1), ('Japonesa','Japon', 1), ('Jordana','Jordania', 1), ('Katensa','Katar', 1), ('Keniana','Kenia', 1), ('Kuwaiti','Kwait', 1), ('Laosiana','Laos', 1), ('Leonesa','Sierra leona', 1), ('Lesothensa','Lesotho', 1), ('Letonesa','Letonia', 1), ('Libanesa','Libano', 1), ('Liberiana','Liberia', 1), ('Libeña','Libia', 1), ('Liechtenstein','Liechtenstein', 1), ('Lituana','Lituania', 1), ('Luxemburgo','Luxemburgo', 1), ('Madagascar','Madagascar', 1), ('Malaca','Fede. de Malasia', 1), ('Malawi','Malawi', 1), ('Maldivas','Maldivas', 1), ('Mali','Mali', 1), ('Maltesa','Malta', 1), ('Marfilesa','Costa de Marfil', 1), ('Marroqui','Marruecos', 1), ('Mauricio','Mauricio', 1), ('Mauritana','Mauritania', 1), ('Mexicana','México', 1), ('Monaco','Monaco', 1), ('Mongolesa','Mongolia', 1), ('Nauru','Nauru', 1), ('Neozelandesa','Nueva Zelandia', 1), ('Nepalesa','Nepal', 1), ('Nicaraguense','Nicaragua', 1), ('Nigerana','Niger', 1), ('Nigeriana','Nigeria', 1), ('Norcoreana','Corea del Norte', 1), ('Norirlandesa','Irlanda del norte', 1), ('Norteamericana','Estados unidos', 1), ('Noruega','Noruega', 1), ('Omana','Oman', 1), ('Pakistani','Pakistan', 1), ('Panameña','Panama', 1), ('Paraguaya','Paraguay', 1), ('Peruana','Peru', 1), ('Polaca','Polonia', 1), ('Portoriqueña','Puerto Rico', 1), ('Portuguesa','Portugal', 1), ('Rhodesiana','Rhodesia', 1), ('Ruanda','Ruanda', 1), ('Rumana','Rumania', 1), ('Rusa','Russia', 1), ('Salvadoreña','El Salvador', 1), ('Samoa Occidental','Samoa Occidental', 1), ('San marino','San Marino', 1), ('Saudi','Arabia Saudita', 1), ('Senegalesa','Senegal', 1), ('Sikkim','Sikkim', 1), ('Singapur','Singapur', 1), ('Siria','Siria', 1), ('Somalia','Somalia', 1), ('Sovietica','Union Sovietica', 1), ('Sri Lanka','Sri Lanka (Ceylan) ', 1), ('Suazilandesa','Suazilandia', 1), ('Sudafricana','Sudafrica', 1), ('Sudanesa','Sudan', 1), ('Sueca','Suecia', 1), ('Suiza','Suiza', 1), ('Surcoreana','Corea del Sur', 1), ('Tailandesa','Tailandia', 1), ('Tanzana','Tanzania', 1), ('Tonga','Tonga', 1), ('Tongo','Tongo', 1), ('Trinidad y Tobago','Trinidad y Tobago', 1), ('Tunecina','Tunez', 1), ('Turca','Turquia', 1), ('Ugandesa','Uganda', 1), ('Uruguaya','Uruguay', 1), ('Vaticano','Vaticano', 1), ('Venezolana','Venezuela', 1), ('Vietnamita','Vietnam', 1), ('Yemen Rep Arabe','Yemen Rep. Arabe', 1), ('Yemen Rep Dem','Yemen Rep. Dem', 1), ('Yugoslava','Yugoslavia', 1), ('Zaire','Zaire', 1); 
GO
---MUNICIPIOS
-----------------------------------------------------------
INSERT INTO Municipios (nombre, descripcion, activo) VALUES
('Comayagua', '0301', 1), ('Ajuterique', '0302', 1), ('El Rosario', '0303', 1), ('Esquías', '0304', 1), ('Humuya', '0305', 1), ('La Libertad', '0306', 1), ('Lamaní', '0307', 1), ('La Trinidad', '0308', 1), ('Lejamaní', '0309', 1), ('Meámbar', '0310', 1), ('Minas de Oro', '0311', 1), ('Ojos de Agua', '0312', 1), ('San Jerónimo', '0313', 1), ('San José de Comayagua', '0314', 1), ('San José del Potrero', '0315', 1), ('San Luis', '0316', 1), ('San Sebastián', '0317', 1), ('Siguatepeque', '0318', 1), ('Villa de San Antonio', '0319', 1), ('Las Lajas', '0320', 1), ('Taulabé', '0321', 1); 
GO
---BARRIOS
-----------------------------------------------------------
INSERT INTO Direcciones (Nombre, Activo, IdTipo, IdMunicipio) VALUES 
('Barrio Abajo', 1, 2, 1), ('Barrio Arriba', 1, 2, 1), ('Barrio Brisas de Altamira', 1, 2, 1), ('Barrio Cabañas', 1, 2, 1), ('Barrio Inva', 1, 2, 1), ('Barrio La Caridad', 1, 2, 1), ('Barrio La Independencia', 1, 2, 1), ('Barrio La Joya', 1, 2, 1), ('Barrio La Zarcita', 1, 2, 1), ('Barrio Los Lirios', 1, 2, 1), ('Barrio Lourdes', 1, 2, 1), ('Barrio San Antonio de la Sabana', 1, 2, 1), ('Barrio San Blas', 1, 2, 1), ('Barrio San Francisco', 1, 2, 1), ('Barrio San José', 1, 2, 1), ('Barrio San Juan', 1, 2, 1), ('Barrio San Pablo', 1, 2, 1), ('Barrio San Ramón', 1, 2, 1), ('Barrio San Sebastián', 1, 2, 1), ('Barrio Santa Lucía', 1, 2, 1), ('Barrio Suyapa', 1, 2, 1), ('Barrio Torondón', 1, 2, 1); 
GO
---COLONIAS
-----------------------------------------------------------
INSERT INTO Direcciones (Nombre, Activo, IdTipo, IdMunicipio) VALUES
('Colonia 1 de Mayo', 1, 3, 1), ('Colonia 10 de Mayo', 1, 3, 1), ('Colonia 2 de Mayo', 1, 3, 1), ('Colonia 21 de Abril', 1, 3, 1), ('Colonia Boquín', 1, 3, 1), ('Colonia Brisas de Suyapa', 1, 3, 1), ('Colonia Brisas del Humuya', 1, 3, 1), ('Colonia Brisas del Valle', 1, 3, 1), ('Colonia Centenario', 1, 3, 1), ('Colonia Concepción', 1, 3, 1), ('Colonia Del Inva', 1, 3, 1), ('Colonia El Sauce', 1, 3, 1), ('Colonia Escoto', 1, 3, 1), ('Colonia Fiallos', 1, 3, 1), ('Colonia Francisco Morazán', 1, 3, 1), ('Colonia Fuerzas Armadas', 1, 3, 1), ('Colonia Incehsa', 1, 3, 1), ('Colonia Lomas del Río', 1, 3, 1), ('Colonia Los Almendros', 1, 3, 1), ('Colonia Los Jazmines', 1, 3, 1), ('Colonia Mazzarela', 1, 3, 1), ('Colonia Mejía Fiallos', 1, 3, 1), ('Colonia Mejicapa', 1, 3, 1), ('Colonia Mejores Alimentos', 1, 3, 1), ('Colonia Milagro de Dios', 1, 3, 1), ('Colonia Nueva Comayagua', 1, 3, 1), ('Colonia Nueva Esperanza', 1, 3, 1), ('Colonia Nueva Valladolid', 1, 3, 1), ('Colonia Piedras Bonitas', 1, 3, 1), ('Colonia Polanco', 1, 3, 1), ('Colonia San Carlos', 1, 3, 1), ('Colonia San Martín', 1, 3, 1), ('Colonia San Miguel', 1, 3, 1), ('Colonia San Rafael', 1, 3, 1); 
GO
---ALDEAS
-----------------------------------------------------------
INSERT INTO Direcciones (Nombre, Activo, IdTipo, IdMunicipio) VALUES
('Aldea El Negrito', 1, 1, 1), ('Aldea El Portillo de la Mora', 1, 1, 1), ('Aldea El Taladro', 1, 1, 1), ('Aldea El Volcán', 1, 1, 1), ('Aldea San Miguel de Selguapa', 1, 1, 1); 
GO
---RESIDENCIALES
-----------------------------------------------------------
INSERT INTO Direcciones(Nombre, Activo, IdTipo, IdMunicipio) VALUES 
('Residencial Los Arcos', 1, 4, 1); 
GO 


--------------------------------
--PROCEDIMIENTOS ALMACENADOS
--------------------------------

---NACIONALIDADES
-----------------------------------------------------------
--Listar
CREATE PROCEDURE SCM_SP_NACIONALIDADES_LIST
@texto varchar(40)=''
AS
BEGIN
    SELECT IdNacionalidad as ID, Pais, Nacionalidad FROM Nacionalidades WHERE Pais LIKE '%' + @texto + '%' AND Activo = 1 ORDER BY Pais;
END;
GO


--Guardar/modificat
CREATE PROCEDURE SCM_SP_NACIONALIDADES_SAVE
@opcion int = 0,
@id int = 0,
@pais varchar(40)='',
@nac varchar(40)=''
AS
BEGIN
	IF @opcion =1 -- Nuevo Registro
		BEGIN        
			INSERT INTO Nacionalidades (Pais, Nacionalidad, Activo) VALUES (@pais,@nac,1);
		END;
	ELSE --Actualizar Registro
		BEGIN
			UPDATE Nacionalidades SET Nacionalidad = @nac WHERE IdNacionalidad = @id;
		END;    
END;
GO

--Eliminar
CREATE PROCEDURE SCM_SP_NACIONALIDADES_DELETE
@id int = 0
AS
BEGIN
	UPDATE NACIONALIDADES SET Activo = 0 WHERE IdNacionalidad = @id;
END;
GO



----PERSONAS
-----------------------------------------------------------
--Listar
CREATE PROCEDURE SCM_SP_PERSONAS_LIST
@texto varchar(100)=''
AS
BEGIN
	SELECT p.IdPersona as ID, p.RTN, p.PrimerNombre as 'Primer Nombre', p.SegundoNombre as 'Segundo Nombre', p.PrimerApellido  as 'Primer Apellido', p.SegundoApellido as 'Segundo Apellido' , CONCAT_WS(' ',P.PrimerNombre, P.SegundoNombre, P.PrimerApellido, P.SegundoApellido) AS Nombre , n.Nacionalidad as Nacionalidad, p.FechaNac as Nacimiento, p.Genero 
	FROM Personas p 
	INNER JOIN Nacionalidades n ON p.IdNacionalidad = n.IdNacionalidad
	WHERE CONCAT(p.IdPersona,' ', p.RTN,' ', n.Nacionalidad,' ', p.PrimerNombre,' ', p.SegundoNombre,' ', p.PrimerApellido,' ', p.SegundoApellido) LIKE '%' + @texto + '%' AND p.Activo = 1;
END;
GO

--Guardar/modificar
CREATE PROCEDURE SCM_SP_PERSONAS_SAVE
    @opcion INT,
    @IdPersona VARCHAR(13),
    @PrimerNombre VARCHAR(70),
    @SegundoNombre VARCHAR(70),
    @PrimerApellido VARCHAR(70),
    @SegundoApellido VARCHAR(70),
    @IdNacionalidad INT,
    @FechaNac DATE,
    @Genero VARCHAR(10),
    @RTN VARCHAR(50)
AS
BEGIN
    IF @opcion = 1 --Guardar
    BEGIN
        IF EXISTS (SELECT 1 FROM Personas WHERE IdPersona = @IdPersona)
        BEGIN
            IF (SELECT Activo FROM Personas WHERE IdPersona = @IdPersona) = 0
            BEGIN
                UPDATE Personas                
                SET PrimerNombre = @PrimerNombre,
                SegundoNombre = @SegundoNombre,
                PrimerApellido = @PrimerApellido,
                SegundoApellido = @SegundoApellido,
                IdNacionalidad = @IdNacionalidad,
                FechaNac = @FechaNac,
                Genero = @Genero,
                RTN = @RTN,
                Activo = 1
                WHERE IdPersona = @IdPersona;
            END
        END
        ELSE
        BEGIN
            INSERT INTO Personas (IdPersona, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, IdNacionalidad, FechaNac, Genero, RTN, Activo)
            VALUES (@IdPersona, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @IdNacionalidad, @FechaNac, @Genero, @RTN, 1);
        END
    END
    ELSE IF @opcion = 2 --Modificar
    BEGIN
        IF EXISTS (SELECT 1 FROM Personas WHERE IdPersona = @IdPersona)
        BEGIN
            UPDATE Personas
            SET PrimerNombre = @PrimerNombre,
                SegundoNombre = @SegundoNombre,
                PrimerApellido = @PrimerApellido,
                SegundoApellido = @SegundoApellido,
                IdNacionalidad = @IdNacionalidad,
                FechaNac = @FechaNac,
                Genero = @Genero,
                RTN = @RTN
            WHERE IdPersona = @IdPersona;
        END
    END
END
GO

--BuscaporID
CREATE PROCEDURE SCM_SP_PERSONAS_ID
@IdPersona VARCHAR(13)
AS
BEGIN
	SELECT IdPersona, RTN, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, IdNacionalidad, FechaNac, Genero 
	FROM Personas WHERE IdPersona = @IdPersona;
END;
GO


--Eliminar
CREATE PROCEDURE SCM_SP_PERSONAS_DELETE
@IdPersona VARCHAR(13)
AS
BEGIN
	UPDATE Personas SET Activo = 0 WHERE IdPersona = @IdPersona;
    UPDATE DireccionPersona SET Activo = 0 WHERE IdPersona = @IdPersona;
    UPDATE CONTACTOS SET Activo = 0 WHERE IdPersona = @IdPersona;
END;
GO


----MUNICIPIOS
-----------------------------------------------------------

--Listar
CREATE PROCEDURE SCM_SP_MUNICIPIOS_LIST
@texto varchar(70)=''
AS
BEGIN
    SELECT IdMunicipio as ID, Nombre, Descripcion FROM Municipios WHERE CONCAT(Nombre, Descripcion) LIKE '%' + @texto + '%' AND Activo = 1;
END;
GO

--Guardar/Modificat
CREATE PROCEDURE SCM_SP_MUNICIPIOS_SAVE
@opcion int = 0,
@id int = 0,
@nombre varchar(70)='',
@desc varchar(500)=''
AS
BEGIN
	IF @opcion = 1 -- Nuevo Registro
		BEGIN                                  
            INSERT INTO Municipios (Nombre, Descripcion, Activo) VALUES (@nombre, @desc,1);            
		END;
	ELSE --Actualizar Registro
		BEGIN
			UPDATE Municipios SET Nombre = @nombre, Descripcion = @desc WHERE IdMunicipio = @id;
		END;    
END;
GO

--Eliminar
CREATE PROCEDURE SCM_SP_MUNICIPIOS_DELETE
@id int = 0
AS
BEGIN
	UPDATE MUNICIPIOS SET Activo = 0 WHERE IdMunicipio = @id;
END;
GO


----DIRECCIONES
-----------------------------------------------------------

--Listar
CREATE PROCEDURE SCM_SP_DIRECCIONES_LIST
@texto varchar(70)=''
AS
BEGIN
    SELECT d.IdDireccion as ID, d.Nombre, d.Descripcion, m.nombre as Municipio, t.nombre as Tipo 
    FROM DIRECCIONES d
    INNER JOIN Municipios m ON d.IdMunicipio = m.IdMunicipio
    INNER JOIN Tipos t ON d.IdTipo = t.IdTipo 
    WHERE CONCAT(t.Nombre, ' ', d.Nombre, ' ', d.Descripcion, ' ', m.Nombre ) LIKE '%' + @texto + '%' AND d.Activo = 1
    ORDER BY tipo, Nombre
END;
GO

--Listar con parametro
CREATE PROCEDURE SCM_SP_DIRECCIONESPARAM_LIST
@texto varchar(70)='',
@param varchar(70)=''
AS
BEGIN
    SELECT d.IdDireccion as ID, d.Nombre, d.Descripcion, m.nombre as Municipio, t.nombre as Tipo 
    FROM DIRECCIONES d
    INNER JOIN Municipios m ON d.IdMunicipio = m.IdMunicipio
    INNER JOIN Tipos t ON d.IdTipo = t.IdTipo 
    WHERE CONCAT(t.Nombre, ' ', d.Nombre, ' ', d.Descripcion, ' ', m.Nombre ) LIKE '%' + @texto + '%' AND d.Activo = 1 AND t.nombre = @param
    ORDER BY tipo, Nombre
END;
GO

--Guardar/Modificat
CREATE PROCEDURE SCM_SP_DIRECCIONES_SAVE
@opcion int = 0,
@id int = 0,
@nombre varchar(70)='',
@desc varchar(500)='',
@idMuni int = 0,
@idTipo int = 0
AS
BEGIN
	IF @opcion =1 -- Nuevo Registro
		BEGIN
            INSERT INTO DIRECCIONES (Nombre, Descripcion, IdMunicipio, IdTipo, Activo) VALUES ( @nombre, @desc, @idMuni, @idTipo, 1 );            
		END;
	ELSE --Actualizar Registro
		BEGIN
			UPDATE DIRECCIONES SET Nombre = @nombre, Descripcion = @desc, IdMunicipio = @idMuni, IdTipo = @idTipo WHERE IdDireccion = @id;
		END;    
END;
GO

--Eliminar
CREATE PROCEDURE SCM_SP_DIRECCIONES_DELETE
@id int = 0
AS
BEGIN
	UPDATE DIRECCIONES SET Activo = 0 WHERE IdDireccion = @id;
END;
GO


---DIRECCION TIPOS
-----------------------------------------------------------
--Listar
CREATE PROCEDURE SCM_SP_DIRECTIPOS_LIST
@texto varchar(70)=''
AS
BEGIN
    SELECT IdTipo as ID, Nombre, Descripcion, Tipo
    FROM TIPOS 
    WHERE CONCAT(Nombre, Descripcion) LIKE '%' + @texto + '%' 
    AND Activo = 1
    ORDER BY Nombre, Tipo;
END;
GO

--Guardar/Modificat
CREATE PROCEDURE SCM_SP_DIRECTIPOS_SAVE
@opcion int = 0,
@id int = 0,
@nombre varchar(25)='',
@desc varchar(500)='',
@tipo varchar(25)=''
AS
BEGIN
	IF @opcion =1 -- Nuevo Registro
		BEGIN  
            INSERT INTO TIPOS (Nombre, Descripcion, Tipo, Activo) VALUES ( @nombre, @desc, @Tipo, 1 );            
		END;
	ELSE --Actualizar Registro
		BEGIN
			UPDATE TIPOS SET Nombre = @nombre, Descripcion = @desc, Tipo = @tipo WHERE IdTipo = @id;
		END;    
END;
GO

--Eliminar
CREATE PROCEDURE SCM_SP_DIRECTIPOS_DELETE
@id int = 0
AS
BEGIN
	UPDATE TIPOS SET Activo = 0 WHERE IdTipo = @id;
END;
GO


---DIRECCION PERSONAS
-----------------------------------------------------------
--Listar
CREATE PROCEDURE SCM_SP_DIRECPERSONAS_LIST
    @persona varchar(70) = ''
AS
BEGIN
    SELECT DP.IdDireccion,
       DP.IdPersona,
       DP.Barrio,
       DP.Colonia,
       DP.Residencial,       
       DP.Aldea,
       CONCAT_WS(', ',
                NULLIF(A.Nombre, ''),
                NULLIF(B.Nombre, ''),
                NULLIF(C.Nombre, ''),
                NULLIF(D.Nombre, '')
       ) AS Direccion,
	   DP.Comentario
    FROM SCM.dbo.DireccionPersona AS DP
    LEFT JOIN Direcciones AS A ON DP.Aldea = A.IdDireccion -- ALDEA 
    LEFT JOIN Direcciones AS B ON DP.Barrio = B.IdDireccion -- BARRIO
    LEFT JOIN Direcciones AS C ON DP.Colonia = C.IdDireccion -- COLONIA
    LEFT JOIN Direcciones AS D ON DP.Residencial = D.IdDireccion -- RESIDENCIAL
    WHERE DP.Activo = 1 AND DP.IdPersona = @persona;
END;
GO

--Guardar/Modificat
CREATE PROCEDURE SCM_SP_DIRECPERSONAS_SAVE
@opcion int = 0,
@id int = 0,
@persona varchar(13)='',
@barrio int = 0,
@colonia int = 0,
@residencial int = 0,
@aldea int = 0,
@comen varchar(500)=''
AS
BEGIN
	IF @opcion =1 -- Nuevo Registro
		BEGIN  
            INSERT INTO DireccionPersona ( IdPersona, Barrio, Colonia, Residencial, Aldea, Comentario, Activo )  VALUES ( @persona, @barrio, @colonia, @residencial, @aldea, @comen, 1 );            
		END;
	ELSE --Actualizar Registro
		BEGIN
			UPDATE DireccionPersona SET IdPersona = @persona, Barrio = @barrio, Colonia = @colonia, Residencial = @residencial, Aldea = @aldea, Comentario = @comen WHERE IdDireccion = @id;
		END;    
END;
GO

--Eliminar
CREATE PROCEDURE SCM_SP_DIRECPERSONAS_DELETE
@id int = 0
AS
BEGIN
	UPDATE DireccionPersona SET Activo = 0 WHERE IdDireccion = @id;
END;
GO


---CONTACTOS
-----------------------------------------------------------
--Listar
CREATE PROCEDURE SCM_SP_CONTACTOS_LIST
@texto varchar(70)='',
@idPersona varchar(13)=''
AS
BEGIN
    SELECT IdContacto as ID, IdPersona as Persona, Contacto, Descripcion, IdTipo as Tipo 
    FROM CONTACTOS 
    WHERE CONCAT(Contacto, Descripcion) LIKE '%' + @texto + '%' 
    AND Activo = 1 AND IdPersona = @idPersona
    ORDER BY Contacto, Tipo;
END;
GO

--Guardar/Modificat
CREATE PROCEDURE SCM_SP_CONTACTOS_SAVE
@opcion int = 0,
@id int = 0,
@idPersona varchar(70)='',
@contacto varchar(70)='',
@desc varchar(500)='',
@idTipo int = 0

AS
BEGIN
	IF @opcion =1 -- Nuevo Registro
		BEGIN  
            INSERT INTO CONTACTOS (IdPersona, Contacto, Descripcion, IdTipo, Activo) VALUES ( @idPersona, @contacto, @desc, @idTipo, 1 );            
		END;
	ELSE --Actualizar Registro
		BEGIN
			UPDATE CONTACTOS SET  IdPersona = @IdPersona, Contacto = @contacto, Descripcion = @desc, IdTipo = @idTipo WHERE IdContacto = @id;
		END;    
END;
GO

--Eliminar
CREATE PROCEDURE SCM_SP_CONTACTOS_DELETE
@id int = 0
AS
BEGIN
	UPDATE CONTACTOS SET Activo = 0 WHERE IdContacto = @id;
END;
GO


----EMPLEADOS
-----------------------------------------------------------
--Listar todos los Empleado
CREATE PROCEDURE SCM_SP_EMPLEADOS_LIST
    @texto VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT E.IdEmpleado AS 'Empleado', P.IdPersona AS 'ID', P.RTN, CONCAT_WS(' ', P.PrimerNombre, P.SegundoNombre, P.PrimerApellido, P.SegundoApellido) AS Nombre, CONCAT_WS(' ', P.PrimerNombre, P.PrimerApellido) AS 'Nombre Corto',
           STUFF((SELECT DISTINCT ', ' + R.Nombre
                  FROM RolesEmpleados RE
                  JOIN Roles R ON RE.IdRol = R.IdRol
                  WHERE RE.IdEmpleado = E.IdEmpleado
                  FOR XML PATH('')), 1, 2, '') AS Roles
    FROM Empleados E
    JOIN Personas P ON E.IdPersona = P.IdPersona
    LEFT JOIN RolesEmpleados RE ON E.IdEmpleado = RE.IdEmpleado
    LEFT JOIN Roles R ON RE.IdRol = R.IdRol
    WHERE CONCAT_WS(' ', P.IdPersona, P.PrimerNombre, P.SegundoNombre, P.PrimerApellido, P.SegundoApellido, ISNULL(R.Nombre, '')) LIKE '%' + @texto + '%';
END;
GO

--Listar todos los empleados por rol
CREATE PROCEDURE SCM_SP_EMPLEADOS_BY_ROL_LIST
    @texto VARCHAR(100),
    @idRol INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT E.IdEmpleado AS 'Empleado', P.IdPersona AS 'ID', P.RTN, CONCAT_WS(' ', P.PrimerNombre, P.SegundoNombre, P.PrimerApellido, P.SegundoApellido) AS Nombre, CONCAT_WS(' ', P.PrimerNombre, P.PrimerApellido) AS 'Nombre Corto',
           STUFF((SELECT DISTINCT ', ' + R.Nombre
                  FROM RolesEmpleados RE
                  JOIN Roles R ON RE.IdRol = R.IdRol
                  WHERE RE.IdEmpleado = E.IdEmpleado
                  FOR XML PATH('')), 1, 2, '') AS Roles
    FROM Empleados E
    JOIN Personas P ON E.IdPersona = P.IdPersona
    LEFT JOIN RolesEmpleados RE ON E.IdEmpleado = RE.IdEmpleado
    LEFT JOIN Roles R ON RE.IdRol = R.IdRol
    WHERE CONCAT_WS(' ', P.IdPersona, P.PrimerNombre, P.SegundoNombre, P.PrimerApellido, P.SegundoApellido, ISNULL(R.Nombre, '')) LIKE '%' + @texto + '%'
          AND R.IdRol = @idRol;
END;
GO


--Empleados sin usuario
CREATE PROCEDURE SCM_SP_EMPLEADOS_LIST_SIN_USUARIO
    @texto VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT E.IdEmpleado AS 'Empleado', P.IdPersona AS 'ID', P.RTN, CONCAT_WS(' ', P.PrimerNombre, P.SegundoNombre, P.PrimerApellido, P.SegundoApellido) AS Nombre, CONCAT_WS(' ', P.PrimerNombre, P.PrimerApellido) AS 'Nombre Corto',
           STUFF((SELECT DISTINCT ', ' + R.Nombre
                  FROM RolesEmpleados RE
                  JOIN Roles R ON RE.IdRol = R.IdRol
                  WHERE RE.IdEmpleado = E.IdEmpleado
                  FOR XML PATH('')), 1, 2, '') AS Roles
    FROM Empleados E
    JOIN Personas P ON E.IdPersona = P.IdPersona
    LEFT JOIN Usuarios U ON E.IdEmpleado = U.IdEmpleado
    LEFT JOIN RolesEmpleados RE ON E.IdEmpleado = RE.IdEmpleado
    LEFT JOIN Roles R ON RE.IdRol = R.IdRol
    WHERE U.IdUsuario IS NULL
      AND CONCAT_WS(' ', P.IdPersona, P.PrimerNombre, P.SegundoNombre, P.PrimerApellido, P.SegundoApellido, ISNULL(R.Nombre, '')) LIKE '%' + @texto + '%';
END;
GO

--PERSONAS NO EMPLEADOS
CREATE PROCEDURE SCM_SP_PERSONAS_NO_EMPLEADOS_LIST
    @texto VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT P.IdPersona AS 'ID', P.RTN, P.PrimerNombre AS 'Primer Nombre', P.SegundoNombre AS 'Segundo Nombre', P.PrimerApellido AS 'Primer Apellido', P.SegundoApellido AS 'Segundo Apellido', CONCAT_WS(' ', P.PrimerNombre, P.SegundoNombre, P.SegundoNombre, P.SegundoApellido) AS Nombre, N.Nacionalidad AS Nacionalidad, P.FechaNac AS Nacimiento, P.Genero
    FROM Personas P
    INNER JOIN Nacionalidades N ON P.IdNacionalidad = N.IdNacionalidad
    WHERE CONCAT(P.IdPersona, ' ', P.RTN, ' ', N.Nacionalidad, ' ', P.PrimerNombre, ' ', P.SegundoNombre, ' ', P.PrimerApellido, ' ', P.SegundoApellido) LIKE '%' + @texto + '%' AND P.Activo = 1
    AND P.IdPersona NOT IN (SELECT E.IdPersona FROM Empleados E);
END;
GO

--Guardar/Modificat
CREATE PROCEDURE SCM_SP_EMPLEADOS_SAVE
    @opcion INT = 0,
    @id INT = 0,
    @IdPersona VARCHAR(13)
AS
BEGIN
    IF @opcion = 1 -- Nuevo Registro
    BEGIN
        -- Verificar si ya existe un empleado con ese IdPersona y está desactivado
        IF EXISTS(SELECT 1 FROM Empleados WHERE IdPersona = @IdPersona AND Activo = 0)
        BEGIN
            -- Activar el empleado existente
            UPDATE Empleados SET Activo = 1 WHERE IdPersona = @IdPersona;
        END
        ELSE
        BEGIN
            -- Crear un nuevo empleado
            INSERT INTO Empleados (IdPersona, Activo) VALUES (@IdPersona, 1);
        END;
    END;
    ELSE -- Actualizar Registro
    BEGIN
        UPDATE Empleados SET IdPersona = @IdPersona WHERE IdEmpleado = @id;
    END;
END;
GO

--Eliminar
CREATE PROCEDURE SCM_SP_EMPLEADOS_DELETE
@id int = 0
AS
BEGIN
	UPDATE EMPLEADOS SET Activo = 0 WHERE IdEmpleado = @id;
END;
GO



----ESTADOS
-----------------------------------------------------------
--Listar
CREATE PROCEDURE SCM_SP_ESTADOS_LIST
@texto varchar(70)=''
AS
BEGIN
    SELECT IdEstado as ID, Nombre, Descripcion FROM Estados WHERE CONCAT(Nombre, Descripcion) LIKE '%' + @texto + '%' AND Activo = 1 ORDER BY Nombre;
END;
GO

--Listado Excluido por Rol
CREATE PROCEDURE SCM_SP_ESTADOSEX_LIST
    @IdRol INT
AS
BEGIN
    -- Obtener los estados que no aparecen en la tabla EstadosRoles para el IdRol especificado
    SELECT E.IdEstado, E.Nombre, E.Descripcion, E.Activo
    FROM Estados E
    WHERE NOT EXISTS (
        SELECT 1
        FROM EstadosRoles ER
        WHERE ER.IdEstado = E.IdEstado
        AND ER.IdRol = @IdRol
    )
    
    UNION
    
    -- Obtener los estados que aparecen en EstadosRoles con Activo = 0 para el IdRol especificado
    SELECT E.IdEstado, E.Nombre, E.Descripcion, E.Activo
    FROM Estados E
    INNER JOIN EstadosRoles ER ON ER.IdEstado = E.IdEstado
    WHERE ER.Activo = 0
    AND ER.IdRol = @IdRol;
END
GO
--Guardar/Modificat
-----------------------------------------------
CREATE PROCEDURE SCM_SP_ESTADOS_SAVE
    @id int = 0,
    @opcion int = 0,    
    @nombre varchar(70)='',
    @desc varchar(500)=''
AS
BEGIN
    IF @opcion = 1 -- Nuevo Registro
    BEGIN
        -- Verificar si el estado ya existe
        IF EXISTS (SELECT 1 FROM Estados WHERE Nombre = @nombre)
        BEGIN
            -- Actualizar el estado existente si Activo = 0
            IF (SELECT Activo FROM Estados WHERE Nombre = @nombre) = 0
            BEGIN
                UPDATE Estados SET Nombre = @nombre, Descripcion = @desc, Activo = 1 WHERE idEstado = @id;
            END
        END
        ELSE
        BEGIN
            -- Insertar un nuevo estado
            INSERT INTO Estados (Nombre, Descripcion, Activo) VALUES (@nombre, @desc, 1);
        END
    END;
    ELSE -- Actualizar Registro
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Estados WHERE Nombre = @nombre AND idEstado <> @id)
        BEGIN
            UPDATE Estados SET Nombre = @nombre, Descripcion = @desc WHERE idEstado = @id;
        END;
    END;
END;
GO

-----------------------------------------------

--Eliminar
CREATE PROCEDURE SCM_SP_ESTADOS_DELETE
@id int = 0
AS
BEGIN
	UPDATE Estados SET Activo = 0 WHERE IdEstado = @id;
    UPDATE EstadosRoles SET Activo = 0 WHERE IdEstado = @id;
END;
GO


----ESTADOS-ROLES
-----------------------------------------------------------
CREATE PROCEDURE SCM_SP_ESTADOROL_SAVE
    @idRol INT,
    @idEstado INT,
    @Numero INT,
    @Activo BIT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM EstadosRoles WHERE IdRol = @idRol AND IdEstado = @idEstado)
    BEGIN
        UPDATE EstadosRoles
        SET Numero = @Numero, Activo = @Activo
        WHERE IdRol = @idRol AND IdEstado = @idEstado
    END
    ELSE IF @Activo = 1
    BEGIN
        INSERT INTO EstadosRoles (IdRol, IdEstado, Numero, Activo)
        VALUES (@IdRol, @IdEstado, @Numero, @Activo)
    END
END;
GO

----EXPEDIENTES
-----------------------------------------------------------
CREATE PROCEDURE SCM_SP_EXPEDIENTE_SAVE
    @nombre VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si existe el expediente
    IF EXISTS (SELECT * FROM Expedientes WHERE Nombre = @nombre)
    BEGIN
        -- Verificar si el expediente está desactivado
        IF (SELECT Activo FROM Expedientes WHERE Nombre = @nombre) = 0
        BEGIN
            -- Actualizar el expediente y activarlo
            UPDATE Expedientes
            SET Activo = 1
            WHERE Nombre = @nombre;
        END
    END
    ELSE
    BEGIN
        -- Insertar un nuevo expediente y activarlo
        INSERT INTO Expedientes (Nombre, Activo)
        VALUES (@nombre, 1);
    END
END;
GO


----CONTROLES
-----------------------------------------------------------
CREATE PROCEDURE SCM_SP_EXPEDIENTE_CONTROL_LIST
    @nombre NVARCHAR(100)
AS
BEGIN
    SELECT *
    FROM (
        SELECT
            C.IdControl,
            E.IdExpediente AS IdExpediente,
            E.Nombre AS Expediente,
            C.FechaInicio AS Iniciado,
            C.Iniciador AS IdIniciador,
            CONCAT(PIni.PrimerNombre, ' ', PIni.PrimerApellido) AS Iniciador,
            C.ObsIni AS [Observacion Inicial],
            Rol.Nombre AS Proceso,
            Et.Nombre AS Estado,
            Comentarios.[Observaciones] AS [Ultimo Comentario],
            CE.IdEmpleado AS IdEncargado,
            CONCAT(PEn.PrimerNombre, ' ', PEn.PrimerApellido) AS Encargado,
            MAX(Comentarios.Fecha) AS [Ultimo Cambio],
            C.Finalizador AS IdFinalizador,
            CONCAT(PFin.PrimerNombre, ' ', PFin.PrimerApellido) AS Finalizador,
            C.FechaFin AS Finalizacion,
            C.ObsFin AS [Observacion Final],
            CP.IdCambios,
            ROW_NUMBER() OVER (PARTITION BY E.IdExpediente ORDER BY Comentarios.Fecha DESC) AS RowNumber
        FROM
            Controles C
            INNER JOIN Expedientes E ON C.IdExpediente = E.IdExpediente
            INNER JOIN Empleados Ini ON C.Iniciador = Ini.IdEmpleado
            INNER JOIN Personas PIni ON Ini.IdPersona = PIni.IdPersona
            LEFT JOIN Cambios_Proceso CP ON C.IdControl = CP.IdControl
            LEFT JOIN Roles Rol ON CP.IdRol = Rol.IdRol
            LEFT JOIN Control_Estados CE ON CP.IdCambios = CE.IdCambios
            LEFT JOIN EstadosRoles EstRol ON CE.IdEstadoRol = EstRol.IdEstadoRol
            LEFT JOIN Estados Et ON Et.IdEstado = EstRol.IdEstado
            LEFT JOIN Empleados En ON CE.IdEmpleado = En.IdEmpleado
            LEFT JOIN Personas PEn ON En.IdPersona = PEn.IdPersona
            LEFT JOIN (
                SELECT
                    IdControlEstado,
                    Observaciones,
                    Fecha,
                    ROW_NUMBER() OVER (PARTITION BY IdControlEstado ORDER BY Fecha DESC) AS RowNumber
                FROM
                    Comentarios
            ) AS Comentarios ON CE.IdControlEstado = Comentarios.IdControlEstado
        LEFT JOIN Empleados Fin ON C.Finalizador = Fin.IdEmpleado
        LEFT JOIN Personas PFin ON Fin.IdPersona = PFin.IdPersona
        WHERE
            E.Nombre LIKE '%' + @nombre + '%'
            AND E.Activo = 1
        GROUP BY
            E.IdExpediente,
            E.Nombre,
            C.FechaInicio,
            C.Iniciador,
            PIni.PrimerNombre,
            PIni.PrimerApellido,
            C.ObsIni,
            Rol.Nombre,
            Et.Nombre,
            Comentarios.[Observaciones],
            CE.IdEmpleado,
            PEn.PrimerNombre,
            PEn.PrimerApellido,
            C.Finalizador,
            PFin.PrimerNombre,
            PFin.PrimerApellido,
            C.FechaFin,
            C.ObsFin,
            CP.IdCambios,
            Comentarios.Fecha,
            C.IdControl
        ) AS Subquery
    WHERE
        RowNumber = 1;
END;
GO


--INICIAR UN NUEVO CONTROL
CREATE PROCEDURE SCM_SP_EXPEDIENTE_CONTROL_SAVE
(
    @Nombre VARCHAR(100),
    @Envio INT,    
    @Recibio INT,
    @ObsIni VARCHAR(500),
    @Observaciones VARCHAR(500),
    @Resultado INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @FechaInicio DATETIME, @IdExpediente INT, @IdControl INT, @IdCambios INT, @IdControlEstado INT;

    -- Obtener la fecha actual del sistema
    SET @FechaInicio = GETDATE();

    -- Verificar si ya existe una transacción en curso
    IF @@TRANCOUNT = 0
    BEGIN
        -- Iniciar transacción
        BEGIN TRANSACTION;
    END

    BEGIN TRY
        -- Insertar en la tabla Expedientes y obtener el IdExpediente generado
        INSERT INTO Expedientes (Nombre, Activo)
        VALUES (@Nombre, 1);
        SET @IdExpediente = SCOPE_IDENTITY();

        -- Insertar en la tabla Controles
        INSERT INTO Controles (IdExpediente, FechaInicio, Iniciador, ObsIni, Activo)
        VALUES (@IdExpediente, @FechaInicio, @Envio, @ObsIni, 1);

        -- Obtener el IdControl generado
        SET @IdControl = SCOPE_IDENTITY();

        -- Insertar en la tabla Cambios_Proceso
        INSERT INTO Cambios_Proceso (IdControl, Fecha, IdRol, Envio, Recibio, Observaciones, Duracion, Porcentaje, Activo)
        VALUES (@IdControl, @FechaInicio, 1, @Envio, @Recibio, @Observaciones, CAST('00:00:00' AS TIME), 0, 1);

        -- Obtener el IdCambios generado
        SET @IdCambios = SCOPE_IDENTITY();

        -- Obtener el IdEstadoRol para el primer estado asignado al rol
        DECLARE @IdEstadoRol INT;
        SELECT @IdEstadoRol = IdEstadoRol
        FROM EstadosRoles
        WHERE IdRol = 1 AND Numero = 1;

        -- Insertar en la tabla Control_Estados
        INSERT INTO Control_Estados (IdCambios, IdEstadoRol, IdEmpleado, Completado, Fecha, Duracion, Activo)
        VALUES (@IdCambios, @IdEstadoRol, @Recibio, 0, GETDATE(), CAST('00:00:00' AS TIME), 1);

        -- Obtener el IdControlEstado generado
        SET @IdControlEstado = SCOPE_IDENTITY();

        -- Modificar el estado actual de Cambios_Proceso
        UPDATE Cambios_Proceso set EstadoActual = @IdControlEstado WHERE IdCambios = @IdCambios

        -- Insertar en la tabla Comentarios
        INSERT INTO Comentarios (IdControlEstado, Observaciones, Fecha, Activo)
        VALUES (@IdControlEstado, 'Proceso Iniciado', GETDATE(), 1);

        -- Confirmar la transacción solo si fue iniciada dentro del procedimiento
        IF @@TRANCOUNT = 1
        BEGIN
            COMMIT;
            SET @Resultado = 1; -- Indicar que se realizó el commit
        END
        ELSE
        BEGIN
            SET @Resultado = -1; -- Indicar que ocurrió un rollback
        END
    END TRY
    BEGIN CATCH
        -- Deshacer la transacción solo si fue iniciada dentro del procedimiento
        IF @@TRANCOUNT > 0 AND @@TRANCOUNT = 1
            ROLLBACK;

        SET @Resultado = -1; -- Indicar que ocurrió un rollback

        -- Propagar el error
        THROW;
    END CATCH;
END;
GO

--CAMBIOS DE PROCESO EN EXPEDIENTE
CREATE PROCEDURE SCM_SP_EXPEDIENTE_CAMBIOS_PROCESO_LIST
    @id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
	    CP.IdCambios,
        CONCAT_WS(' ', Pe.PrimerNombre, Pe.SegundoNombre) AS Envia,
        CP.Envio, 
        CONCAT_WS(' ', Pr.PrimerNombre, Pr.SegundoNombre) AS Recibe,
        CP.Recibio,
        R.IdRol,
        R.Nombre AS 'Al Proceso',
        CP.Observaciones,
        CP.Fecha
    FROM Cambios_Proceso CP
    INNER JOIN Roles R ON CP.IdRol = R.IdRol
    INNER JOIN Empleados EMe ON CP.Envio = EMe.IdEmpleado
    INNER JOIN Personas Pe ON EMe.IdPersona = Pe.IdPersona
    INNER JOIN Empleados EMr ON CP.Recibio = EMr.IdEmpleado
    INNER JOIN Personas Pr ON EMr.IdPersona = Pr.IdPersona
	INNER JOIN Controles C ON CP.IdControl = C.IdControl
    WHERE C.IdExpediente = @id
    ORDER BY CP.IdCambios;
END;
GO


--RESUMENES-EXPEDIENTES 
-----------------------------
--RESUMEN POR ROL
CREATE PROCEDURE SCM_SP_EXPEDIENTE_CONTROL_ESTADOS_BYROL_LIST
    @id INT,
    @idRol INT
AS
BEGIN
    SELECT
        E.IdExpediente AS Expediente,
        Rol.Nombre AS Proceso,
        Est.Nombre AS Estado,
        Com.Observaciones AS Comentario,
        Com.Fecha,
        CONCAT(P.PrimerNombre, ' ', P.PrimerApellido) AS Encargado
    FROM
        Expedientes E
        INNER JOIN Controles C ON E.IdExpediente = C.IdExpediente
        INNER JOIN Cambios_Proceso CP ON C.IdControl = CP.IdControl
        INNER JOIN Control_Estados CE ON CP.IdCambios = CE.IdCambios
        INNER JOIN Roles Rol ON CP.IdRol = Rol.IdRol
        INNER JOIN EstadosRoles ER ON CE.IdEstadoRol = ER.IdEstadoRol
        INNER JOIN Estados Est ON ER.IdEstado = Est.IdEstado
        INNER JOIN Empleados Emp ON CE.IdEmpleado = Emp.IdEmpleado
        INNER JOIN Personas P ON Emp.IdPersona = P.IdPersona
        LEFT JOIN Comentarios Com ON CE.IdControlEstado = Com.IdControlEstado
    WHERE
		E.IdExpediente = @id AND
        Rol.IdRol = @idRol
    ORDER BY
        Com.Fecha;
END;
GO


--TODUS LOS ESTADOS DE TODOS ROLES, RESUMEN COMPLETO DEL EXPEDIENTE
CREATE PROCEDURE SCM_SP_EXPEDIENTE_ESTADOS_LIST
    @id INT = 0
AS
BEGIN
    SELECT
        E.IdExpediente AS Expediente,
        Rol.Nombre AS Proceso,
        Est.Nombre AS Estado,
        Com.Observaciones AS Comentario,
        Com.Fecha,
        CONCAT(P.PrimerNombre, ' ', P.PrimerApellido) AS Encargado
    FROM
        Expedientes E
        INNER JOIN Controles C ON E.IdExpediente = C.IdExpediente
        INNER JOIN Cambios_Proceso CP ON C.IdControl = CP.IdControl
        INNER JOIN Control_Estados CE ON CP.IdCambios = CE.IdCambios
        INNER JOIN Roles Rol ON CP.IdRol = Rol.IdRol
        INNER JOIN EstadosRoles ER ON CE.IdEstadoRol = ER.IdEstadoRol
        INNER JOIN Estados Est ON ER.IdEstado = Est.IdEstado
        INNER JOIN Empleados Emp ON CE.IdEmpleado = Emp.IdEmpleado
        INNER JOIN Personas P ON Emp.IdPersona = P.IdPersona
        LEFT JOIN Comentarios Com ON CE.IdControlEstado = Com.IdControlEstado
    WHERE
        E.IdExpediente = @id        
    ORDER BY
        Com.Fecha;
END;
GO

--CONTROL-ESTADOS
------------------------

-- Listar los estados asignados a un rol pendientes de un expediente
CREATE PROCEDURE SCM_SP_CONTROL_ESTADOS_PENDIENTES_LIST
    @idCambio INT,
    @IdRol INT
AS
BEGIN
    SELECT E.IdEstado, E.Nombre
    FROM Estados E
    JOIN EstadosRoles ER ON E.IdEstado = ER.IdEstado
    WHERE ER.IdRol = @idRol
        AND NOT EXISTS (
            SELECT 1
            FROM Control_Estados CE
            WHERE CE.IdCambios = @idCambio
                AND CE.IdEstadoRol = ER.IdEstadoRol
                AND CE.Completado = 1
        );
END;
GO

--  Listar los estados asignados a un rol completados de un expediente
CREATE PROCEDURE SCM_SP_CONTROL_ESTADOS_COMPLETOS_LIST
    @idCambio INT,
    @IdRol INT
AS
BEGIN
    SELECT E.IdEstado, E.Nombre
    FROM Estados E
    JOIN EstadosRoles ER ON E.IdEstado = ER.IdEstado
    JOIN Control_Estados CE ON ER.IdEstadoRol = CE.IdEstadoRol
    WHERE CE.IdCambios = @idCambio
        AND ER.IdRol = @idRol
        AND CE.Completado = 1;
END;
GO

--Calcular los porcentajes de Avance
CREATE PROCEDURE SCM_SP_ACTUALIZAR_PORCENTAJE
    @idCambio INT,
    @idRol INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Crear tabla temporal para pendientes
    CREATE TABLE #ControlEstadosPendientes (IdEstado INT, Nombre NVARCHAR(100));

    -- Crear tabla temporal para completados
    CREATE TABLE #ControlEstadosCompletos (IdEstado INT, Nombre NVARCHAR(100));

    -- Obtener los registros pendientes
    INSERT INTO #ControlEstadosPendientes (IdEstado, Nombre)
    EXEC SCM_SP_CONTROL_ESTADOS_PENDIENTES_LIST @idCambio, @idRol;

    -- Obtener los registros completados
    INSERT INTO #ControlEstadosCompletos (IdEstado, Nombre)
    EXEC SCM_SP_CONTROL_ESTADOS_COMPLETOS_LIST @idCambio, @idRol;

    -- Obtener el total de pendientes y completados
    DECLARE @Pendientes INT, @Completados INT;
    SELECT @Pendientes = COUNT(*) FROM #ControlEstadosPendientes;
    SELECT @Completados = COUNT(*) FROM #ControlEstadosCompletos;

    -- Calcular el porcentaje
    DECLARE @Porcentaje DECIMAL(10, 2);
    SET @Porcentaje = CASE
                          WHEN @Pendientes + @Completados > 0 THEN CONVERT(DECIMAL(10, 2), @Completados) / (@Pendientes + @Completados) * 100
                          ELSE 0
                      END;

    -- Actualizar el porcentaje en la tabla Cambios_Proceso
    UPDATE Cambios_Proceso
    SET Porcentaje = @Porcentaje
    WHERE IdCambios = @idCambio;

    -- Eliminar las tablas temporales
    DROP TABLE #ControlEstadosPendientes;
    DROP TABLE #ControlEstadosCompletos;
END;
GO

-- Guardar el Control Estado
CREATE PROCEDURE SCM_SP_CONTROL_ESTADOS_SAVE
    @opcion INT,
    @IdControlEstado INT = NULL,
    @IdCambios INT,
    @IdEmpleado INT,
    @IdEstadoRol INT,
    @Completado BIT,
    @Observaciones NVARCHAR(500),
	@IdRol INT,
    @Resultado INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @opcion = 1  -- Guardar
    BEGIN
        -- Insertar en la tabla Control_Estados
        INSERT INTO Control_Estados (IdCambios, IdEmpleado, IdEstadoRol, Completado, Fecha, FechaFin, Duracion, Activo)
        VALUES (@IdCambios, @IdEmpleado, @IdEstadoRol, @Completado, GETDATE(), NULL, CAST('00:00:00' AS TIME), 1);

        -- Obtener el IdControlEstado generado
        SET @IdControlEstado = SCOPE_IDENTITY();

        -- Insertar en la tabla Comentarios
        INSERT INTO Comentarios (IdControlEstado, Observaciones, Fecha, Activo)
        VALUES (@IdControlEstado, @Observaciones, GETDATE(), 1);

        -- Establecer el resultado como 1 (éxito)
        SET @Resultado = 1;
    END
    ELSE IF @opcion = 2  -- Modificar
    BEGIN
        -- Actualizar en la tabla Control_Estados
        UPDATE Control_Estados
        SET IdCambios = @IdCambios,
            IdEmpleado = @IdEmpleado,
            IdEstadoRol = @IdEstadoRol,
            Completado = @Completado,
            FechaFin = CASE WHEN @Completado = 1 THEN GETDATE() ELSE NULL END,
            Duracion = CASE
                           WHEN @Completado = 1 THEN CONVERT(TIME, DATEADD(SECOND, DATEDIFF(SECOND, Fecha, GETDATE()), Duracion))
                           WHEN @Completado = 0 THEN CAST('00:00:00' AS TIME)
                           ELSE Duracion
                       END
        WHERE IdControlEstado = @IdControlEstado;

        -- Insertar en la tabla Comentarios
        INSERT INTO Comentarios (IdControlEstado, Observaciones, Fecha, Activo)
        VALUES (@IdControlEstado, @Observaciones, GETDATE(), 1);

        -- Establecer el resultado como 1 (éxito)
        SET @Resultado = 1;
    END

    -- Actualizar EstadoActual en la tabla Cambios_Proceso
    UPDATE Cambios_Proceso
    SET EstadoActual = @IdControlEstado
    WHERE IdCambios = @IdCambios;

	-- Llamar al procedimiento SCM_SP_ACTUALIZAR_PORCENTAJE
	EXEC SCM_SP_ACTUALIZAR_PORCENTAJE @IdCambios, @IdRol;

END;
GO


--USUARIOS
-----------------------------
--LISTAR
CREATE PROCEDURE SCM_SP_USUARIOS_LIST
    @texto NVARCHAR(100)
AS
BEGIN
    SELECT U.IdUsuario, U.Nombre AS Usuario, U.Contrasenia, CONCAT_WS(' ', P.PrimerNombre, P.SegundoNombre, P.PrimerApellido, P.SegundoApellido) AS Empleado, U.Activo
    FROM Usuarios U
    INNER JOIN Empleados E ON U.IdEmpleado = E.IdEmpleado
    INNER JOIN Personas P ON E.IdPersona = P.IdPersona
    WHERE CONCAT_WS(' ', U.Nombre, P.PrimerNombre, P.SegundoNombre, P.PrimerApellido, P.SegundoApellido) LIKE '%' + @texto + '%';
END;
GO

/* 
--GUARDAR/MODIFICAR
CREATE PROCEDURE SCM_SP_USUARIOS_SAVE
    @opcion INT,
    @nombreUsuario VARCHAR(25),
    @contrasenia VARCHAR(20),
    @idEmpleado INT,
    @activo BIT
AS
BEGIN
    DECLARE @contraseniaEncriptada VARBINARY(64)

    IF @opcion = 1
    BEGIN
        -- Encriptar la contraseña
        SET @contraseniaEncriptada = HASHBYTES('SHA2_256', @contrasenia)

        -- Insertar un nuevo usuario
        INSERT INTO Usuarios (Nombre, Contrasenia, IdEmpleado, Activo)
        VALUES (@nombreUsuario, @contraseniaEncriptada, @idEmpleado, @activo)
    END
    ELSE
    BEGIN
        -- Encriptar la contraseña
        SET @contraseniaEncriptada = HASHBYTES('SHA2_256', @contrasenia)

        -- Actualizar un usuario existente
        UPDATE Usuarios
        SET Nombre = @nombreUsuario,
            Contrasenia = @contraseniaEncriptada,
            IdEmpleado = @idEmpleado,
            Activo = @activo
        WHERE IdUsuario = @op -- Aquí asumo que el campo para identificar el usuario es IdUsuario
    END
END;
GO */



---TEMPORALES


INSERT INTO Estados (Nombre, Descripcion, Activo) VALUES
('Comprobando', 'Comprobando documentos', 1), ('Analizando', 'Analizando documentos', 1), ('Procesando', 'Procesando documentos', 1);
GO

INSERT INTO [SCM].[dbo].[Personas] ([IdPersona], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [IdNacionalidad], [FechaNac], [Genero], [RTN], [Activo]) VALUES
(1, 'John', 'Doe', 'Smith', NULL, 1, '1990-01-01', 'M', '123456789', 1),
(2, 'Jane', NULL, 'Johnson', NULL, 2, '1992-05-10', 'F', '987654321', 1),
(3, 'Michael', 'Scott', 'Adams', NULL, 1, '1985-07-15', 'M', '456789123', 1),
(4, 'Emily', 'Grace', 'Taylor', NULL, 3, '1995-12-20', 'F', '789123456', 1),
(5, 'David', NULL, 'Anderson', NULL, 2, '1988-03-25', 'M', '654321987', 1);
GO

INSERT INTO [SCM].[dbo].[Contactos] ([IdPersona], [Contacto], [Descripcion], [IdTipo], [Activo]) VALUES
(1, '1234567890', 'Teléfono principal', 1, 1),
(1, 'johndoe@example.com', 'Correo principal', 2, 1),
(1, '9876543210', 'Teléfono principal', 1, 1),
(2, 'janejohnson@example.com', 'Correo principal', 2, 1),
(3, '5555555555', 'Teléfono principal', 1, 1);
GO

INSERT INTO [SCM].[dbo].[DireccionPersona] ([IdPersona], [Colonia], [Barrio], [Aldea], [Residencial], [Comentario], [Activo]) VALUES
(1, 1, 2, 3, 4, 'Comentario 1', 1),
(2, 5, 6, 7, 8, 'Comentario 2', 1),
(3, 9, 10, 11, 12, 'Comentario 3', 1),
(4, 13, 14, 15, 16, 'Comentario 4', 1),
(5, 17, 18, 19, 20, 'Comentario 5', 1),
(1, 21, 22, 23, 24, 'Comentario 6', 1),
(2, 25, 1, 2, 3, 'Comentario 7', 1),
(3, 4, 5, 6, 7, 'Comentario 8', 1),
(4, 8, 9, 10, 11, 'Comentario 9', 1),
(5, 12, 13, 14, 15, 'Comentario 10', 1);
GO


INSERT INTO Empleados (IdPersona, Activo)
VALUES ('1', 1),
       ('2', 1),
       ('3', 1),
       ('4', 1),
       ('5', 1);
GO

INSERT INTO Usuarios (Nombre, IdEmpleado, Activo)
VALUES ('usuario1', 1, 1),
       ('usuario2', 2, 1),
       ('usuario3', 3, 1),
       ('usuario4', 4, 1),
       ('usuario5', 5, 1);
GO

INSERT INTO RolesEmpleados (IdEmpleado, IdRol)
VALUES (1, 1),
       (1, 2),
       (2, 2),
       (3, 3),
       (4, 1),
       (4, 2),
       (4, 3),
       (4, 4),
       (4, 5);
GO
/* 
INSERT INTO Expedientes (Nombre, Activo)
VALUES 
    ('CAM2023-2-86', 1),
    ('CAM2023-2-94', 1),
    ('CAM2023-1-08', 1);
GO

INSERT INTO CONTROLES(IdExpediente, FechaInicio, Iniciador, ObsIni, FechaFin, ObsFin, Activo) VALUES
(1, '2023-01-14T17:30:00', 1, 'Observaciones Iniciales 1', '2023-01-14T17:30:00', 'Observaciones Finales 1', 1),
(2, '2023-01-14T17:30:00', 2, 'Observaciones Iniciales 2', '2023-01-14T17:30:00', 'Observaciones Finales 2', 1),
(3, '2023-01-14T17:30:00', 3, 'Observaciones Iniciales 3', '2023-01-14T17:30:00', 'Observaciones Finales 3', 1);
GO


INSERT INTO Cambios_Proceso (IdControl, Fecha, IdRol, Envio, Recibio, Activo) VALUES
(1, '2023-01-14T17:30:00', 1, 1, 2, 1),
(2, '2023-01-14T17:30:00', 1, 2, 3, 1);
GO

INSERT INTO Control_Estados (IdCambios, IdEmpleado, IdEstadoRol, Completado, EstadoAnterior, Duracion, Activo)
VALUES (1, 2, 2, 0, NULL, '00:30:00', 1);
GO

INSERT INTO Comentarios (IdControlEstado, Observaciones, Fecha, Activo)
VALUES
(1, 'proceso iniciado', '2023-01-14T17:30:00', 1),
(1, 'proceso escalal', '2023-01-14T17:30:00', 1),
(1, 'proceso maxilial', '2023-01-14T17:30:00', 1),
(1, 'estoy listo', '2023-01-14T17:30:00', 1);
GO

INSERT INTO Comentarios (IdControlEstado, Observaciones, Fecha, Activo)
VALUES (1, 'esto es genial', GETDATE(), 1);
GO
 */
--ESTADOS DE ROLES DEL SISTEMA
-----------------------------------------------------------
INSERT INTO EstadosRoles(IdRol, IdEstado, Numero, Activo) VALUES
(1, 3, 3, 1), 
(1, 4, 4, 1), 
(1, 5, 5, 1),
(2, 3, 5, 1), 
(2, 4, 4, 1), 
(2, 5, 3, 1);
GO

