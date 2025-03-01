create database premierRenduPSI;
use premierRenduPSI;

CREATE TABLE Client(
        idClient      Int NOT NULL ,
        nom           Varchar (50) NOT NULL ,
        prenom        Varchar (50) NOT NULL ,
        rue           Varchar (50) NOT NULL ,
        numMaison     Int NOT NULL ,
        codePostal    Int NOT NULL ,
        numTel        Int NOT NULL ,
        email         Varchar (50) NOT NULL ,
        ville         Varchar (50) NOT NULL ,
        totalCommande Int NOT NULL ,
        metroProche   Varchar (50) NOT NULL
	,CONSTRAINT Client_PK PRIMARY KEY (idClient)
)ENGINE=InnoDB;


CREATE TABLE Plat(
        idPlat          Int NOT NULL ,
        regime          Varchar (50) NOT NULL ,
        dateFabrication Date NOT NULL ,
        datePeremption  Date NOT NULL ,
        prix            Float NOT NULL ,
        nomPlat         Varchar (50) NOT NULL ,
        nationalite     Varchar (50) NOT NULL
	,CONSTRAINT Plat_PK PRIMARY KEY (idPlat)
)ENGINE=InnoDB;

CREATE TABLE Cuisinier(
        idCuisinier   Int NOT NULL ,
        nom           Varchar (50) NOT NULL ,
        prenom        Varchar (50) NOT NULL ,
        rue           Varchar (50) NOT NULL ,
        codePostal    Int NOT NULL ,
        numTel        Int NOT NULL ,
        email         Varchar (50) NOT NULL ,
        ville         Varchar (50) NOT NULL ,
        platDuJour    Varchar (50) NOT NULL ,
        totalCommande Int NOT NULL ,
        metroProche   Varchar (50) NOT NULL
	,CONSTRAINT Cuisinier_PK PRIMARY KEY (idCuisinier)
)ENGINE=InnoDB;

CREATE TABLE Commande(
        idCommande       Int NOT NULL ,
        nom              Varchar (50) NOT NULL ,
        prix             Int NOT NULL ,
        tempsPreparation Int NOT NULL ,
        statut           Varchar (50) NOT NULL ,
        date             Date NOT NULL ,
        idClient         Int NOT NULL
	,CONSTRAINT Commande_PK PRIMARY KEY (idCommande)

	,CONSTRAINT Commande_Client_FK FOREIGN KEY (idClient) REFERENCES Client(idClient)
)ENGINE=InnoDB;

CREATE TABLE Ingredient(
        idIngredient Varchar (50) NOT NULL ,
        nom          Varchar (50) NOT NULL ,
        volume       Int NOT NULL ,
        origine      Varchar (50) NOT NULL ,
        prix         Int NOT NULL
	,CONSTRAINT Ingredient_PK PRIMARY KEY (idIngredient)
)ENGINE=InnoDB;

CREATE TABLE realiser(
        idCuisinier Int NOT NULL ,
        idPlat      Int NOT NULL
	,CONSTRAINT realiser_PK PRIMARY KEY (idCuisinier,idPlat)

	,CONSTRAINT realiser_Cuisinier_FK FOREIGN KEY (idCuisinier) REFERENCES Cuisinier(idCuisinier)
	,CONSTRAINT realiser_Plat0_FK FOREIGN KEY (idPlat) REFERENCES Plat(idPlat)
)ENGINE=InnoDB;

CREATE TABLE servir(
        idCuisinier Int NOT NULL ,
        idClient    Int NOT NULL
	,CONSTRAINT servir_PK PRIMARY KEY (idCuisinier,idClient)

	,CONSTRAINT servir_Cuisinier_FK FOREIGN KEY (idCuisinier) REFERENCES Cuisinier(idCuisinier)
	,CONSTRAINT servir_Client0_FK FOREIGN KEY (idClient) REFERENCES Client(idClient)
)ENGINE=InnoDB;

CREATE TABLE constituer(
        idIngredient Varchar (50) NOT NULL ,
        idPlat       Int NOT NULL
	,CONSTRAINT constituer_PK PRIMARY KEY (idIngredient,idPlat)

	,CONSTRAINT constituer_Ingredient_FK FOREIGN KEY (idIngredient) REFERENCES Ingredient(idIngredient)
	,CONSTRAINT constituer_Plat0_FK FOREIGN KEY (idPlat) REFERENCES Plat(idPlat)
)ENGINE=InnoDB;

CREATE TABLE preparer(
        idCuisinier Int NOT NULL ,
        idCommande  Int NOT NULL
	,CONSTRAINT preparer_PK PRIMARY KEY (idCuisinier,idCommande)

	,CONSTRAINT preparer_Cuisinier_FK FOREIGN KEY (idCuisinier) REFERENCES Cuisinier(idCuisinier)
	,CONSTRAINT preparer_Commande0_FK FOREIGN KEY (idCommande) REFERENCES Commande(idCommande)
)ENGINE=InnoDB;

CREATE TABLE contenir(
        idPlat     Int NOT NULL ,
        idCommande Int NOT NULL
	,CONSTRAINT contenir_PK PRIMARY KEY (idPlat,idCommande)

	,CONSTRAINT contenir_Plat_FK FOREIGN KEY (idPlat) REFERENCES Plat(idPlat)
	,CONSTRAINT contenir_Commande0_FK FOREIGN KEY (idCommande) REFERENCES Commande(idCommande)
)ENGINE=InnoDB;

