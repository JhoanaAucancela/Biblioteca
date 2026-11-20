-- Script generado con: dotnet ef migrations script
-- Ejecutar en phpMyAdmin (http://localhost/phpmyadmin) -> pestaña SQL
CREATE DATABASE IF NOT EXISTS Biblioteca CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE Biblioteca;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;
CREATE TABLE `Autores` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nombre` varchar(60) NOT NULL,
    `Apellido` varchar(60) NOT NULL,
    `Nacionalidad` varchar(40) NOT NULL,
    `Fecha_Nacimiento` datetime(6) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Categorias` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nombre` varchar(50) NOT NULL,
    `Descripcion` varchar(200) NOT NULL,
    `Estante` varchar(10) NOT NULL,
    `Activa` tinyint(1) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Socios` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nombre` varchar(60) NOT NULL,
    `Apellido` varchar(60) NOT NULL,
    `Email` varchar(100) NOT NULL,
    `Telefono` varchar(10) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Libros` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Titulo` varchar(150) NOT NULL,
    `Anio_Publicacion` int NOT NULL,
    `AutorId` int NOT NULL,
    `CategoriaId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Libros_Autores_AutorId` FOREIGN KEY (`AutorId`) REFERENCES `Autores` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Libros_Categorias_CategoriaId` FOREIGN KEY (`CategoriaId`) REFERENCES `Categorias` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Prestamos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Fecha_Prestamo` datetime(6) NOT NULL,
    `Fecha_Devolucion` datetime(6) NOT NULL,
    `LibroId` int NOT NULL,
    `SocioId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Prestamos_Libros_LibroId` FOREIGN KEY (`LibroId`) REFERENCES `Libros` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Prestamos_Socios_SocioId` FOREIGN KEY (`SocioId`) REFERENCES `Socios` (`Id`) ON DELETE RESTRICT
);

INSERT INTO `Autores` (`Id`, `Apellido`, `Fecha_Nacimiento`, `Nacionalidad`, `Nombre`)
VALUES (1, 'García Márquez', '1927-03-06 00:00:00.000000', 'Colombiana', 'Gabriel');
SELECT ROW_COUNT();

INSERT INTO `Autores` (`Id`, `Apellido`, `Fecha_Nacimiento`, `Nacionalidad`, `Nombre`)
VALUES (2, 'Icaza', '1906-07-10 00:00:00.000000', 'Ecuatoriana', 'Jorge');
SELECT ROW_COUNT();

INSERT INTO `Autores` (`Id`, `Apellido`, `Fecha_Nacimiento`, `Nacionalidad`, `Nombre`)
VALUES (3, 'Allende', '1942-08-02 00:00:00.000000', 'Chilena', 'Isabel');
SELECT ROW_COUNT();


INSERT INTO `Categorias` (`Id`, `Activa`, `Descripcion`, `Estante`, `Nombre`)
VALUES (1, TRUE, 'Narrativa de ficción extensa', 'A-1', 'Novela');
SELECT ROW_COUNT();

INSERT INTO `Categorias` (`Id`, `Activa`, `Descripcion`, `Estante`, `Nombre`)
VALUES (2, TRUE, 'Obras de denuncia social', 'B-2', 'Realismo social');
SELECT ROW_COUNT();

INSERT INTO `Categorias` (`Id`, `Activa`, `Descripcion`, `Estante`, `Nombre`)
VALUES (3, TRUE, 'Narraciones breves', 'C-1', 'Cuento');
SELECT ROW_COUNT();


INSERT INTO `Socios` (`Id`, `Apellido`, `Email`, `Nombre`, `Telefono`)
VALUES (1, 'López', 'maria.lopez@mail.com', 'María', '0991234567');
SELECT ROW_COUNT();

INSERT INTO `Socios` (`Id`, `Apellido`, `Email`, `Nombre`, `Telefono`)
VALUES (2, 'Pérez', 'carlos.perez@mail.com', 'Carlos', '0987654321');
SELECT ROW_COUNT();


INSERT INTO `Libros` (`Id`, `Anio_Publicacion`, `AutorId`, `CategoriaId`, `Titulo`)
VALUES (1, 1967, 1, 1, 'Cien años de soledad');
SELECT ROW_COUNT();

INSERT INTO `Libros` (`Id`, `Anio_Publicacion`, `AutorId`, `CategoriaId`, `Titulo`)
VALUES (2, 1934, 2, 2, 'Huasipungo');
SELECT ROW_COUNT();

INSERT INTO `Libros` (`Id`, `Anio_Publicacion`, `AutorId`, `CategoriaId`, `Titulo`)
VALUES (3, 1982, 3, 1, 'La casa de los espíritus');
SELECT ROW_COUNT();


INSERT INTO `Prestamos` (`Id`, `Fecha_Devolucion`, `Fecha_Prestamo`, `LibroId`, `SocioId`)
VALUES (1, '2026-11-25 00:00:00.000000', '2026-11-10 00:00:00.000000', 1, 1);
SELECT ROW_COUNT();

INSERT INTO `Prestamos` (`Id`, `Fecha_Devolucion`, `Fecha_Prestamo`, `LibroId`, `SocioId`)
VALUES (2, '2026-11-30 00:00:00.000000', '2026-11-15 00:00:00.000000', 2, 2);
SELECT ROW_COUNT();


CREATE INDEX `IX_Libros_AutorId` ON `Libros` (`AutorId`);

CREATE INDEX `IX_Libros_CategoriaId` ON `Libros` (`CategoriaId`);

CREATE INDEX `IX_Prestamos_LibroId` ON `Prestamos` (`LibroId`);

CREATE INDEX `IX_Prestamos_SocioId` ON `Prestamos` (`SocioId`);

CREATE UNIQUE INDEX `IX_Socios_Email` ON `Socios` (`Email`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20261120052002_inicial', '10.0.15');

COMMIT;

