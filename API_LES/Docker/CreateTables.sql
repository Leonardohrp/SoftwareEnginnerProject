--> Seguir a ordem de criação e associação de chaves

  CREATE TABLE Users(
	IdUser int IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(30),
	LastName varchar(30),
	email varchar(40),
	login varchar(30),
	Password varchar(max)
);

CREATE TABLE Setor (
	CodSetor int IDENTITY(1,1) PRIMARY KEY,
	NomeSetor varchar(50),
	Ramal varchar(20)
);

CREATE TABLE Cargo (
	CodCargo int IDENTITY(1,1) PRIMARY KEY,
	NomeCargo varchar(30),
	PisoSalarial float
);

CREATE TABLE Cargo_Setor (
	IdCargoSetor int IDENTITY(1,1) PRIMARY KEY,
	CodSetor int NOT NULL,
	CodCargo int NOT NULL,
	CONSTRAINT FK_CARGO_SETOR_CODCARGO FOREIGN KEY (CodCargo) REFERENCES Cargo(CodCargo),
	CONSTRAINT FK_SETOR_CODSETOR FOREIGN KEY (CodSetor) REFERENCES Setor(CodSetor)
);

CREATE TABLE Beneficio (
	CodBeneficio int IDENTITY(1,1) PRIMARY KEY,
	TpBeneficio varchar(50),
	Nome varchar(20),
	Valor float
);

CREATE TABLE Cargo_Beneficio(
	IdCargoSetor int IDENTITY(1,1) PRIMARY KEY,
	CodCargo int NOT NULL,
	CodBeneficio int NOT NULL,
	CONSTRAINT FK_BENEFICIO_CODBENEFICIO FOREIGN KEY (CodBeneficio) REFERENCES Beneficio(CodBeneficio),
	CONSTRAINT FK_CARGO_CODCARGO FOREIGN KEY (CodCargo) REFERENCES Cargo(CodCargo)
);

CREATE TABLE Funcionario (
	CodFunc int IDENTITY(1,1) PRIMARY KEY,
	Nome varchar(80),
	NrDoc varchar(30),
	Endereco varchar(100),
	EstadoCivil varchar(20),
	CodCargo int,
	Salario float,
	DtContratacao Date,
	DtDesligamento Date,
	CONSTRAINT FK_FUNCIONARIO_CODCARGO FOREIGN KEY (CodCargo) REFERENCES Cargo(CodCargo)
);

CREATE TABLE Promov_Funcionario (
	CodPromocao int IDENTITY(1,1) PRIMARY KEY,
	CodFunc int,
	CodCargo int,
	DtPromocao Date,
	CONSTRAINT FK_PROV_FUNCIONARIO_CODFUNC FOREIGN KEY (CodFunc) REFERENCES Funcionario(CodFunc)
);


CREATE TABLE Mov_Funcionario (
	CodMov int IDENTITY(1,1) PRIMARY KEY,
	DtMov Date,
	CodFunc int,
	CodCargo int,
	CONSTRAINT FK_MOV_FUNCIONARIO_CODFUNC FOREIGN KEY (CodFunc) REFERENCES Funcionario(CodFunc)
);









