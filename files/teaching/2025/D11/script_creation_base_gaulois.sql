CREATE TABLE mesvillages (
	vilno number(2) NOT NULL,
	nom varchar2(20) NOT NULL,
	nbhutte number(3),
	chef number(3),
	CONSTRAINT pk_mesvillages PRIMARY KEY(vilno)
);
CREATE TABLE mesgaulois (
	gauno number(3) NOT NULL,
	nom varchar2(15) NOT NULL,
	sexe char(1),
	metier varchar2(15),
	vilno number(2),
	CONSTRAINT pk_mesgaulois PRIMARY KEY(gauno),
	CONSTRAINT c_mesgaulois_sexe CHECK(sexe IN ('M','F') OR sexe is NULL),
	CONSTRAINT fk_mesgaulois_vilno FOREIGN KEY (vilno) REFERENCES mesvillages
);
ALTER TABLE mesvillages ADD (
	CONSTRAINT fk_mesvillages_chef FOREIGN KEY (chef) REFERENCES mesgaulois
); 