CREATE TABLE mescamps (
	campno number(2) NOT NULL,
	nom varchar2(20) NOT NULL,
	nbtente number(3),
	nblegio number(4),
	CONSTRAINT pk_mescamps PRIMARY KEY (campno)
);
CREATE TABLE mesbatailles (
	batno number(3) NOT NULL,
	nom varchar2(20),
	vilno number(2) NOT NULL,
	campno number(2) NOT NULL,
	datebat date,
	duree number(3),
	CONSTRAINT pk_mesbatailles PRIMARY KEY (batno),
	CONSTRAINT fk_mesbatailles_vilno FOREIGN KEY (vilno) REFERENCES mesvillages,
	CONSTRAINT fk_mesbatailles_campno FOREIGN KEY (campno) REFERENCES mescamps
);
INSERT INTO mescamps VALUES (5, 'Nanciorum', 70, 400);
INSERT INTO mesbatailles VALUES (12, 'Vosgia', 14, 5, to_date('02/09/0090', 'dd/mm/yyyy'), 20);
INSERT INTO mescamps SELECT * FROM iin_camp;
INSERT INTO mesbatailles SELECT * FROM iin_bataille; 