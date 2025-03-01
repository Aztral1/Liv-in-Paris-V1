use premierrendupsi;

-- Sélection de tout les clients	
SELECT * FROM client;

-- Liste des plats dispos avec leurs prix 
SELECT nomPlat, prix FROM plat;

-- Sélection des cuisiniers travaillant à Paris 
SELECT nom, prenom FROM cuisinier WHERE ville = 'Paris';

-- Plats végétariens 
SELECT nomPlat FROM plat WHERE regime = 'Végétarien';

-- Ingrédients d'origine française 
SELECT nom FROM ingredient WHERE origine = 'France';

-- statut spécifique ( en attente ) commmande
SELECT * FROM commande WHERE statut = 'En attente';

-- clients ayant commandé plus de 10 fois
SELECT nom, prenom, totalCommande FROM client WHERE totalCommande > 10;

-- liste des commandes d'un client spécifique ( client 1 ) 
SELECT * FROM commande WHERE idClient = 1;










