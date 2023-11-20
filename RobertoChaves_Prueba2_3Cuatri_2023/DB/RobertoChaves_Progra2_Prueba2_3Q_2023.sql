--Crear 6 tablas
--Usuarios
--Equipos
--Tecnicos
--Reparaciones
--Asignaciones
--DetallesReparacion


CREATE database RobertoChaves
go

use RobertoChaves
go


--TABLA DE USUARIOS
CREATE TABLE Usuarios
(
	UsuarioID int identity (1,1),
	Nombre TEXT NOT NULL,
	CorreoElectronico VARCHAR (50),
	Telefono VARCHAR (15) UNIQUE,
	CONSTRAINT pk_UsuarioID PRIMARY KEY (UsuarioID)
)
go



--TABLA DE TECNICOS
CREATE TABLE Tecnicos
(
	TecnicoID int identity (1,1),
	Nombre VARCHAR (50),
	Especialidad VARCHAR (50),
	CONSTRAINT pk_TecnicoID PRIMARY KEY (TecnicoID)
)
go

--TABLA DE EQUIPOS
CREATE TABLE Equipos
(
	EquipoID int identity (1,1),
	UsuarioID int,
	TipoEquipo VARCHAR (50) NOT NULL,
	Modelo VARCHAR(50),
	CONSTRAINT fk_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuarios (UsuarioID),
	CONSTRAINT pk_EquipoID PRIMARY KEY (EquipoID)
)
go


--TABLA DE REPARACIONES
CREATE TABLE Reparaciones
(
	ReparacionID int identity (1,1),
	EquipoID int,
	FechaSolicitud DATETIME,
	Estado CHAR(1),
	CONSTRAINT fk_EquipoID FOREIGN KEY (EquipoID) REFERENCES Equipos (EquipoID),
	CONSTRAINT pk_ReparacionID PRIMARY KEY (ReparacionID)
)
go


--TABLA DE ASIGNACIONES
CREATE TABLE Asignaciones
(
	AsignacionID int identity (1,1),
	ReparacionID int,
	TecnicoID int,
	FechaAsignacion DATETIME,
	CONSTRAINT fk_ReparacionID FOREIGN KEY (ReparacionID) REFERENCES Reparaciones (ReparacionID),
	CONSTRAINT fk_TecnicoID FOREIGN KEY (TecnicoID) REFERENCES Tecnicos (TecnicoID),
	CONSTRAINT pk_AsignacionID PRIMARY KEY (AsignacionID)
)
go


--TABLA DETALLES DE REPARACION
CREATE TABLE DetallesReparacion
(
	DetalleID int identity (1,1),
	ReparacionID int,
	Deacripcion VARCHAR (50),
	FechaInicio DATETIME,
	FechaFinal DATETIME,
	CONSTRAINT fk_ReparacionID_DetallesReparacion FOREIGN KEY (ReparacionID) REFERENCES Reparaciones (ReparacionID),
	CONSTRAINT pk_DetalleID PRIMARY KEY (DetalleID)
)
go

------------------------------
--Procedimientos de Almacenado
------------------------------

---------------------------------------------------------------------------------------------------------
--NOTA: Los que dicen --Consulta "Nombre Tabla" ID-- Se refiere a la "Consulta con Filtro" que se solicita
---------------------------------------------------------------------------------------------------------

---------------
--CRUD USUARIOS
---------------



--Agregar Usuarios
-------------------
CREATE PROCEDURE AgregarUsuario
    @Nombre TEXT,
    @CorreoElectronico VARCHAR(50),
    @Telefono VARCHAR(15)
AS
BEGIN
    INSERT INTO usuarios (Nombre, CorreoElectronico, Telefono)
    VALUES (@Nombre, @CorreoElectronico, @Telefono);
END;



--Borrar Usuarios
-----------------
CREATE PROCEDURE BorrarUsuarioID
    @UsuarioID INT
AS
BEGIN
    DELETE FROM usuarios
    WHERE UsuarioID = @UsuarioID;
END;



--Consultar Usuarios
--------------------
CREATE PROCEDURE ConsultarUsuarioID
    @UsuarioID INT
AS
BEGIN
    SELECT *
    FROM usuarios
    WHERE UsuarioID = @UsuarioID;
END;



--Modificar Usuarios
--------------------
CREATE PROCEDURE ModificarUsuarioID
    @UsuarioID INT,
    @Nombre TEXT,
    @CorreoElectronico VARCHAR(50),
    @Telefono VARCHAR(15)
AS
BEGIN
    UPDATE usuarios
    SET Nombre = @Nombre,
        CorreoElectronico = @CorreoElectronico,
        Telefono = @Telefono
    WHERE UsuarioID = @UsuarioID;
END;

---------------
--CRUD TECNICOS
---------------


--Agregar Tecnicos
------------------
CREATE PROCEDURE AgregarTecnico
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50)
AS
BEGIN
    INSERT INTO tecnicos (Nombre, Especialidad)
    VALUES (@Nombre, @Especialidad);
END;



--Borrar Tecnicos
-----------------
CREATE PROCEDURE BorrarTecnicoID
    @TecnicoID INT
AS
BEGIN
    DELETE FROM tecnicos
    WHERE TecnicoID = @TecnicoID;
END;


CREATE PROCEDURE ConsultarTecnicoID
    @TecnicoID INT
AS
BEGIN
    SELECT *
    FROM tecnicos
    WHERE TecnicoID = @TecnicoID;
END;



--Modificar Tecnico
--------------------
CREATE PROCEDURE ModificarTecnicoID
    @TecnicoID INT,
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50)
AS
BEGIN
    UPDATE tecnicos
    SET Nombre = @Nombre,
        Especialidad = @Especialidad
    WHERE TecnicoID = @TecnicoID;
END;



---------------
--CRUD EQUIPOS
---------------

--Crear EQUIPOS
----------------
CREATE PROCEDURE AgregarEquipo
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50)
AS
BEGIN
    INSERT INTO equipos (TipoEquipo, Modelo)
    VALUES (@TipoEquipo, @Modelo);
END;



--Borrar EQUIPOS
----------------
CREATE PROCEDURE BorrarEquipoID
    @EquipoID INT
AS
BEGIN
    DELETE FROM equipos
    WHERE EquipoID = @EquipoID;
END;


CREATE PROCEDURE ConsultarEquipoID
    @EquipoID INT
AS
BEGIN
    SELECT *
    FROM equipos
    WHERE EquipoID = @EquipoID;
END;



--Modificar EQUIPOS
-------------------

CREATE PROCEDURE ModificarEquipoID
    @EquipoID INT,
    @UsuarioID INT,
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50)
AS
BEGIN
    UPDATE equipos
    SET UsuarioID = @UsuarioID,
        TipoEquipo = @TipoEquipo,
        Modelo = @Modelo
    WHERE EquipoID = @EquipoID;
END;

-------------------------
--------Fin CRUD---------
-------------------------




















