CREATE DATABASE bd_agencia;
USE bd_agencia;

CREATE TABLE [dbo].[tipoUsuarios](
	[idTipoUsuario] INT NOT NULL,
	[nome]			VARCHAR(20) NOT NULL,
    PRIMARY KEY CLUSTERED ([idTipoUsuario] ASC)
);

INSERT INTO tipoUsuarios VALUES (1, 'Cliente'), (2, 'Manicure')

CREATE TABLE [dbo].[usuarios](
    [idUsuario]      INT		  IDENTITY (1, 1) NOT NULL,
    [email]          VARCHAR (50) NOT NULL,
    [senha]          VARCHAR (20) NOT NULL,
	[nome]           VARCHAR (50) NOT NULL,
	[telefone]       VARCHAR (20) NOT NULL,
	[cpf]            VARCHAR (11) NOT NULL,
	[idTipoUsuario]  INT		  NOT NULL,
    PRIMARY KEY CLUSTERED ([idUsuario] ASC),
    FOREIGN KEY ([idTipoUsuario]) REFERENCES [dbo].[tipoUsuarios] ([idTipoUsuario])
);

CREATE TABLE [dbo].[enderecos](
	[idEndereco]  INT	  IDENTITY (1, 1) NOT NULL,
	[rua]         VARCHAR (50) NOT NULL,
    [numero]      VARCHAR (10) NOT NULL,
    [complemento] VARCHAR (50) NOT NULL,
    [bairro]      VARCHAR (30) NOT NULL,
    [cep]         VARCHAR (9)  NOT NULL,
    [cidade]      VARCHAR (50) NOT NULL,
    [estado]      VARCHAR (50) NOT NULL,
	[idUsuario]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([idEndereco] ASC),
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[usuarios] ([idUsuario])
);

CREATE TABLE [dbo].[servicos] (
    [idServico]    INT          IDENTITY (1, 1) NOT NULL,
    [tipoServico]  VARCHAR (25) NOT NULL,
    [valorServico] FLOAT (53)   NOT NULL,
	[idManicure] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([idServico] ASC),
    FOREIGN KEY ([idManicure]) REFERENCES [dbo].[usuarios] ([idUsuario])
);

CREATE TABLE [dbo].[agendamento] (
    [idAgendamento]    INT          IDENTITY (1, 1) NOT NULL,
    [dataAgendamento]  DATETIME     NOT NULL,
    [localAgendamento] VARCHAR (50) NOT NULL,
    [idManicure]       INT          NOT NULL,
    [idServico]        INT          NOT NULL,
    [idCliente]        INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([idAgendamento] ASC),
    FOREIGN KEY ([idManicure]) REFERENCES [dbo].[usuarios] ([idUsuario]),
    FOREIGN KEY ([idServico]) REFERENCES [dbo].[servicos] ([idServico]),
    FOREIGN KEY ([idCliente]) REFERENCES [dbo].[usuarios] ([idUsuario])
);
DELETE FROM agendamento WHERE idAgendamento BETWEEN 7 AND 11;



SELECT * FROM usuarios;
SELECT * FROM tipoUsuarios;
SELECT * FROM servicos;
SELECT * FROM agendamento;

