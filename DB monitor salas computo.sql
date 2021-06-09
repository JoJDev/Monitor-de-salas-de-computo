DELETE DATABASE IF EXISTS monitor_salas_computo;
CREATE DATABASE if not exists monitor_salas_computo;

CREATE TABLE usuarios (
  usuario_id SERIAL PRIMARY KEY NOT NULL ,
  usuario_nombre VARCHAR(44) NOT NULL,
  usuario_nickname VARCHAR(24) NOT NULL,
  usuario_contrasena VARCHAR(24) NOT NULL,
  usuario_tipo VARCHAR(1) NOT NULL,
  usuario_numero_cuenta VARCHAR(10) NOT NULL,
  usuario_carrera VARCHAR(5) NOT NULL,
  usuario_fecha_inicio DATE NOT NULL,
  usuario_fecha_nacimiento DATE NOT NULL  
  );

CREATE TABLE salas (
  sala_id SERIAL PRIMARY KEY NOT NULL,
  sala_nombre VARCHAR(20) NOT NULL,
  sala_plantel VARCHAR(30) NULL,
  sala_ip_inicial VARCHAR(16) NULL,
  sala_ip_final VARCHAR(16) NULL,
  sala_gateway VARCHAR(16) NOT NULL,
  sala_servidor VARCHAR(16) 
  );

CREATE TABLE computadoras (
  comp_id SERIAL PRIMARY KEY NOT NULL,
  sala_id SMALLINT REFERENCES salas(sala_id), 
  comp_nombre VARCHAR(25) NOT NULL,
  comp_ip VARCHAR(15) NULL,
  comp_submascara VARCHAR(15) NULL,
  comp_fecha_adquisicion TIMESTAMP  NOT NULL
  );

CREATE TABLE registros (
  registro_id SERIAL PRIMARY KEY NOT NULL,
  usuario_id INT REFERENCES usuarios(usuario_id),
  comp_id INT REFERENCES computadoras(comp_id),
  registro_fecha_inicio TIMESTAMP NOT NULL,
  registro_duracion_tiempo TIME NOT NULL,
  registro_tipo_desconexion VARCHAR(3) NOT NULL  
  );

  CREATE TABLE configuraciones(
    conf_id SERIAL PRIMARY KEY NOT NULL,
    sala_id SMALLINT REFERENCES salas(sala_id),
    conf_tiempo_espera SMALLINT DEFAULT 5,
    conf_perm_usb BOOLEAN DEFAULT 'false',
  );
    
    insert into usuarios(usuario_nombre,usuario_nickname,usuario_contrasena, usuario_tipo, usuario_numero_cuenta, usuario_carrera
					   , usuario_fecha_inicio, usuario_fecha_nacimiento) values 
                       ('jesus', 'admin', 'admin', '0', '1621057', 'ico', '2016-08-03', '1995-03-27'),
                       ('jesus2', 'ayudante', 'ayudante', '1', '1621057', 'ico', '2016-08-03', '1995-03-27'),
                       ('jesus3', 'usuario', 'usuario', '2', '1621057', 'ico', '2016-08-03', '1995-03-27');
    
    insert into salas (sala_nombre, sala_plantel, sala_ip_inicial, sala_ip_final, sala_gateway, sala_servidor)
  VALUES ('Lab1', 'CU Ecatepec', '192.168.1.2', '192.168.1.50', '192.168.1.1', '192.168.1.254')
  , ('Lab2', 'C.U. Ecatepec', '192.168.1.52', '192.168.1.100', '192.168.1.1', '192.168.1.254');
