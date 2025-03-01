ALTER TABLE client MODIFY numTel VARCHAR(50);

INSERT INTO client (idClient, nom, prenom, rue, numMaison, codePostal, numTel, email, ville, totalCommande, metroProche)  
VALUES  
(1, 'Dupont', 'Jean', 'Rue de la Paix', 12, 75001, 1234567890, 'jean.dupont@email.com', 'Paris', 5, 'Châtelet'),  
(2, 'Martin', 'Sophie', 'Avenue des Champs', 45, 75008, 9876543210, 'sophie.martin@email.com', 'Paris', 10, 'George V'),  
(3, 'Lemoine', 'Paul', 'Boulevard Haussmann', 78, 75009, 1122334455, 'paul.lemoine@email.com', 'Paris', 3, 'Havre-Caumartin'),  
(4, 'Bernard', 'Julie', 'Rue Lafayette', 23, 75010, 6677889900, 'julie.bernard@email.com', 'Paris', 8, 'Poissonnière'),  
(5, 'Dubois', 'Alexandre', 'Rue de Rivoli', 99, 75004, 5544332211, 'alexandre.dubois@email.com', 'Paris', 15, 'Saint-Paul');  

ALTER TABLE commande MODIFY prix DECIMAL(10,2);

INSERT INTO commande (idCommande, nom, prix, tempsPreparation, statut, date, idClient)  
VALUES  
(1, 'Pizza Margherita', 12, 15, 'En préparation', '2025-02-28', 1),  
(2, 'Burger Deluxe', 15, 10, 'Prêt', '2025-02-27', 2),  
(3, 'Sushi Mix', 20, 25, 'Livré', '2025-02-26', 3),  
(4, 'Salade César', 9, 5, 'Annulé', '2025-02-25', 4),  
(5, 'Pâtes Carbonara', 14, 12, 'En attente', '2025-02-24', 5);  

ALTER TABLE cuisinier MODIFY numTel VARCHAR(50);

INSERT INTO cuisinier (idCuisinier, nom, prenom, rue, codePostal, numTel, email, ville, platDuJour, totalCommande, metroProche)  
VALUES  
(1, 'Lefevre', 'Paul', 'Rue des Gourmets', 75010, '0612345678', 'paul.lefevre@email.com', 'Paris', 'Bœuf Bourguignon', 30, 'Poissonnière'),  
(2, 'Morel', 'Sophie', 'Avenue du Goût', 75012, '0678901234', 'sophie.morel@email.com', 'Paris', 'Quiche Lorraine', 25, 'Bercy'),  
(3, 'Durand', 'Michel', 'Boulevard des Saveurs', 75014, '0654321098', 'michel.durand@email.com', 'Paris', 'Coq au Vin', 40, 'Alésia'),  
(4, 'Dubois', 'Julie', 'Rue des Délices', 75005, '0789456123', 'julie.dubois@email.com', 'Paris', 'Ratatouille', 20, 'Maubert-Mutualité'),  
(5, 'Marchand', 'Lucas', 'Place du Chef', 75018, '0798563412', 'lucas.marchand@email.com', 'Paris', 'Cassoulet', 35, 'Abbesses');  

ALTER TABLE ingredient MODIFY prix DECIMAL(10,2);
ALTER TABLE ingredient MODIFY volume DECIMAL(10,2);

INSERT INTO ingredient (idIngredient, nom, volume, origine, prix)  
VALUES  
('ING001', 'Tomate', 500, 'France', 3),  
('ING002', 'Mozzarella', 250, 'Italie', 5),  
('ING003', 'Basilic', 50, 'France', 2),  
('ING004', 'Steak', 300, 'Argentine', 8),  
('ING005', 'Fromage', 200, 'Suisse', 6);  

INSERT INTO plat (idPlat, regime, dateFabrication, datePeremption, prix, nomPlat, nationalite)  
VALUES  
(1, 'Végétarien', '2025-02-25', '2025-03-05', 12.50, 'Salade César', 'Française'),  
(2, 'Omnivore', '2025-02-24', '2025-03-04', 15.00, 'Burger Deluxe', 'Américaine'),  
(3, 'Sans gluten', '2025-02-26', '2025-03-06', 18.00, 'Sushi Mix', 'Japonaise'),  
(4, 'Végétalien', '2025-02-27', '2025-03-07', 14.00, 'Ratatouille', 'Française'),  
(5, 'Halal', '2025-02-23', '2025-03-03', 20.00, 'Couscous Royal', 'Marocaine');  



