
USE Credito
GO

-- CREATE TABLES AND INSERT VALUES ---------------------------------------------
CREATE TABLE dbo.Cliente (
	[ID] INT PRIMARY KEY IDENTITY (1, 1),
	[Nome] VARCHAR(500) NOT NULL,
	[UF] VARCHAR(2) NOT NULL,
    [Celular] VARCHAR(13) NULL 
	)
GO

INSERT INTO dbo.Cliente (Nome, UF, Celular) VALUES 
('Maria Amelia da Silva', 'AM', '097-672130034'),('Carlos Nascimento', 'SP', '011-867890987'),
('João Pedro Matos', 'RJ', '022-278909956'),('Pedro Rodrigues', 'SP', '011-989760104'),
('Casa das Tintas Ltda', 'SP', '011-987673478')
 

CREATE TABLE dbo.TipoFinanciamento (
	[ID] INT PRIMARY KEY IDENTITY (1, 1),
	[Tipo] VARCHAR(200) NOT NULL,
	[Ativo] BIT NOT NULL
	)
GO

INSERT INTO dbo.TipoFinanciamento(Tipo, Ativo) VALUES 
('Crédito Direto', 1), ('Crédito Consignado',1), ('Crédito Pessoa Física', 1),
('Crédito Pessoa Jurídica', 1), ('Crédito Imobiliário', 1)


CREATE TABLE dbo.Financiamento (
	[ID] INT PRIMARY KEY IDENTITY (1, 1),
	[ClienteID] INT FOREIGN KEY REFERENCES dbo.Cliente(ID) NOT NULL,
	[TipoFinanciamentoID] INT FOREIGN KEY REFERENCES dbo.TipoFinanciamento(ID) NOT NULL,
	[ValorTotal] MONEY  NOT NULL 
	)
GO

INSERT INTO dbo.Financiamento(ClienteID, TipoFinanciamentoID, ValorTotal) VALUES
(1, 2, 4161.36), (2, 3, 8868.48),(3, 2, 16415.70), (4, 3, 5221.38), (5, 1, 14963.60)


CREATE TABLE dbo.Parcela (
	[ID] INT PRIMARY KEY IDENTITY (1, 1),
	[FinanciamentoID] INT FOREIGN KEY REFERENCES dbo.Financiamento(ID) NOT NULL,
	[Numero] INT NOT NULL,
	[ValorParcela] MONEY  NOT NULL,
	[DataVencimento] DATETIME NOT NULL,
	[DataPagamento] DATETIME NULL
	)
GO

INSERT INTO dbo.Parcela (FinanciamentoID, Numero, ValorParcela, DataVencimento, DataPagamento) VALUES
(1, 1, 346.78, '2020-01-01 00:00', '2020-01-02 00:00'),
(1, 2, 346.78, '2020-02-01 00:00', '2020-02-05 00:00'),
(1, 3, 346.78, '2020-03-01 00:00', '2020-03-02 00:00'),
(1, 4, 346.78, '2020-04-01 00:00', NULL),
(1, 5, 346.78, '2020-05-01 00:00', '2020-05-12 00:00'),
(1, 6, 346.78, '2020-06-01 00:00', NULL),
(1, 7, 346.78, '2020-07-01 00:00', NULL),
(1, 8, 346.78, '2020-08-01 00:00', NULL),
(1, 9, 346.78, '2020-09-01 00:00', NULL),
(1, 10, 346.78,'2020-10-01 00:00', NULL),
(1, 11, 346.78,'2020-11-01 00:00', NULL),
(1, 12, 346.78,'2020-12-01 00:00', NULL),
(2, 1, 1478.08,'2020-03-15 00:00', '2020-03-17 00:00'), 
(2, 2, 1478.08,'2020-04-15 00:00', NULL),
(2, 2, 1478.08,'2020-05-15 00:00', NULL),
(2, 3, 1478.08,'2020-06-15 00:00', NULL),
(2, 4, 1478.08,'2020-07-15 00:00', NULL),
(2, 5, 1478.08,'2020-08-15 00:00', NULL),
(2, 6, 1478.08,'2020-09-15 00:00', NULL),
(3, 1, 2345.10,'2020-02-10 00:00', '2020-02-09 00:00'),
(3, 2, 2345.10,'2020-03-10 00:00', '2020-03-11 00:00'),
(3, 3, 2345.10,'2020-04-10 00:00', '2020-04-10 00:00'),
(3, 4, 2345.10,'2020-05-10 00:00', NULL),
(3, 5, 2345.10,'2020-06-10 00:00', NULL),
(3, 6, 2345.10,'2020-07-10 00:00', NULL),
(3, 7, 2345.10,'2020-08-10 00:00', NULL),
(4, 1, 870.23,'2019-12-08 00:00', '2019-12-20 00:00'),
(4, 2, 870.23,'2020-01-08 00:00', '2020-01-08 00:00'),
(4, 3, 870.23,'2020-02-08 00:00', '2020-02-07 00:00'),
(4, 4, 870.23,'2020-03-08 00:00', '2020-03-10 00:00'),
(4, 5, 870.23,'2020-04-08 00:00', NULL),
(4, 6, 870.23,'2020-05-08 00:00', NULL),
(5, 1, 1870.45,'2019-09-10 00:00', '2019-09-10 00:00'),
(5, 2, 1870.45,'2019-10-10 00:00', '2019-10-09 00:00'),
(5, 3, 1870.45,'2019-11-10 00:00', '2019-11-10 00:00'),
(5, 4, 1870.45,'2019-12-10 00:00', NULL),
(5, 5, 1870.45,'2020-01-10 00:00', '2020-01-09 00:00'),
(5, 6, 1870.45,'2020-02-10 00:00', '2020-02-10 00:00'), 
(5, 7, 1870.45,'2020-03-10 00:00', '2020-03-09 00:00'), 
(5, 8, 1870.45,'2020-04-10 00:00', '2020-04-06 00:00')
------------------------------------------------------------------------------------ 
--QUERY: Listar todos os clientes do estado de SP que tenham mais de 60% das parcelas pagas.
SELECT CLI.NOME
	   ,CLI.UF
	   ,CLI.CELULAR
	   ,TFIN.TIPO [TIPO FINANCIAMENTO]
	   ,FIN.VALORTOTAL
	   ,Cast(CAST(COUNT(PARC.DATAPAGAMENTO)  *100 AS DECIMAL(10,2)) / CAST(COUNT(PARC.DATAVENCIMENTO)  *100 AS DECIMAL(10,2)) *100 as decimal(18,2)) AS [Porcentagem]
 FROM CLIENTE CLI
JOIN FINANCIAMENTO FIN ON FIN.CLIENTEID = CLI.ID
JOIN TIPOFINANCIAMENTO TFIN ON FIN.TIPOFINANCIAMENTOID = TFIN.ID
JOIN PARCELA PARC ON FIN.ID = PARC.FINANCIAMENTOID
WHERE CLI.UF = 'SP' 
GROUP BY CLI.NOME, CLI.UF, CLI.CELULAR ,TFIN.TIPO , FIN.VALORTOTAL
HAVING(Cast(CAST(COUNT(PARC.DATAPAGAMENTO)  *100 AS DECIMAL(10,2)) / CAST(COUNT(PARC.DATAVENCIMENTO)  *100 AS DECIMAL(10,2)) *100 as decimal(18,2))) > 60.00
--------------------------------------------------------------------------------------------
--QUERY: Listar os primeiros 4 clientes que tenham alguma parcela com mais de 05 dias atrasadas (Data Vencimento maior que data atual E data pagamento nula)

SELECT TOP 4 CLI.NOME
			,CLI.UF
			,CLI.CELULAR
			,DATEDIFF(DAY, PARC.DATAVENCIMENTO, GETDATE()) [Qtde dias em atraso]
 FROM CLIENTE CLI
JOIN FINANCIAMENTO FIN ON FIN.CLIENTEID = CLI.ID
JOIN TIPOFINANCIAMENTO TFIN ON FIN.TIPOFINANCIAMENTOID = TFIN.ID
JOIN PARCELA PARC ON FIN.ID = PARC.FINANCIAMENTOID
WHERE DATAPAGAMENTO IS NULL 
AND  DATEDIFF(DAY, PARC.DATAVENCIMENTO, GETDATE()) > 5
GROUP BY CLI.NOME, CLI.UF, CLI.CELULAR ,PARC.DATAVENCIMENTO
--------------------------------------------------------------------------------------------
--QUERY: Listar todos os clientes que já atrasaram em algum momento duas ou mais parcelas em mais de 10 dias, e que o valor do financiamento seja maior que R$ 10.000,00.

SELECT  CLI.NOME
		,CLI.UF
		,CLI.CELULAR
		,DATEDIFF(DAY, DATAVENCIMENTO, DATAPAGAMENTO) [Qtde Parcelas]
 FROM CLIENTE CLI
JOIN FINANCIAMENTO FIN ON FIN.CLIENTEID = CLI.ID
JOIN TIPOFINANCIAMENTO TFIN ON FIN.TIPOFINANCIAMENTOID = TFIN.ID
JOIN PARCELA PARC ON FIN.ID = PARC.FINANCIAMENTOID
WHERE DATEDIFF(DAY, DATAVENCIMENTO, DATAPAGAMENTO) > 10
AND FIN.VALORTOTAL > 10000.00
GROUP BY CLI.NOME, CLI.UF, CLI.CELULAR,DATAVENCIMENTO, DATAPAGAMENTO

----------------------------------------------------------------------------------






















