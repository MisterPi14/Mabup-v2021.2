CREATE DATABASE BD_Mabup2

--TABLA USUARIOS
CREATE TABLE tb_Usuarios (ID INT IDENTITY, Nombre VARCHAR(50), Ap_Pat VARCHAR(50), Ap_Mat NVARCHAR(50), Correo NVARCHAR(50), Contraseña NVARCHAR(50), Estimado_de_tiempo TIME)
INSERT INTO tb_Usuarios(Nombre, Ap_Pat, Ap_Mat, Correo, Contraseña, Estimado_de_tiempo) VALUES ('Mabup', null, null, null, '141102', null)

SELECT * FROM tb_Usuarios
SELECT * FROM tb_Usuarios WHERE Correo = 'fbi' AND Contraseña = '14'


--TABLA TAREAS
CREATE TABLE tb_Tareas (ID INT, #Tarea INT IDENTITY, Titulo VARCHAR(80), Fecha_Inicio DATE, Hora_Inicio TIME(7), Fecha_Entrega DATE, Hora_Entrega TIME(7), Materia VARCHAR(80), Dificultad INT, Tema_Tarea VARCHAR(100), Estado BIT)
INSERT INTO tb_Tareas VALUES (1,'Resumen micro','2021-02-12', '11:23:00','2021-02-12','10:12:00','Microeconomia',5,'Costos',0)
SELECT * FROM tb_Tareas
SELECT Titulo,Fecha_Entrega,Hora_Entrega,Dificultad FROM tb_Usuarios JOIN tb_Tareas ON tb_Usuarios.id = tb_Tareas.id WHERE tb_Usuarios.id=1 AND Estado=0 AND #Tarea=1004

---TABLA FOROS
CREATE TABLE tb_Foro(ID_Foro INT IDENTITY, Tema VARCHAR(200), Materia VARCHAR(100), Fecha_creacion DATE, Hora_creacion TIME, ID_Creador INT)
INSERT INTO tb_Foro(Tema, Materia, Fecha_creacion, Hora_creacion, ID_Creador) VALUES ('Tutorial Mabup', 'Manejo del tiempo', null, null, 1)
SELECT * FROM tb_Foro 

SELECT Tema,Materia,Nombre,Ap_Pat,Ap_Mat FROM tb_Foro JOIN tb_Usuarios ON tb_Foro.ID_Creador=tb_Usuarios.ID Where ID_Foro=1 And Tema='Tutorial Mabup'
SELECT Tema,Materia,Nombre,Ap_Pat,Ap_Mat FROM tb_Foro JOIN tb_Usuarios ON tb_Foro.ID_Creador=tb_Usuarios.ID Where ID_Foro=1 And Tema='Tutorial Mabup'

---TABLA COMENTARIOS
CREATE TABLE tb_Comentarios(#Comentario INT IDENTITY, ID_usuario INT, Comentario VARCHAR(1000), Fecha DATETIME, Foro VARCHAR(200))
SELECT * FROM tb_Comentarios 



SELECT * FROM tb_Comentarios WHERE Foro='Programacion en ASP' ORDER BY Fecha 


SELECT Nombre,Ap_Pat,Ap_Mat,Comentario,Fecha FROM tb_Comentarios JOIN tb_Usuarios ON tb_Comentarios.ID_usuario=tb_Usuarios.ID Where tb_Comentarios.Foro = 'Programacion en ASP' AND tb_Comentarios.#Comentario=1

