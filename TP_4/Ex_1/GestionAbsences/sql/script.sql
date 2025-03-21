CREATE TABLE Eleves (
                        ID INT PRIMARY KEY,
                        Nom VARCHAR(50) NOT NULL,
                        Prenom VARCHAR(50) NOT NULL,
                        Groupe VARCHAR(20) NOT NULL
);

CREATE TABLE Absences (
                          Num_semaine INT NOT NULL,
                          ID INT NOT NULL,
                          Nbr_absences INT CHECK (Nbr_absences >= 0),
                          PRIMARY KEY (Num_semaine, ID),
                          FOREIGN KEY (ID) REFERENCES Eleves(ID) ON DELETE CASCADE
);
-- Insertion des élèves
-- INSERT INTO Eleves (ID, Nom, Prenom, Groupe) VALUES
--                                                  (1, 'Dupont', 'Jean', 'GI1'),
--                                                  (2, 'Martin', 'Sophie', 'GI1'),
--                                                  (3, 'Durand', 'Paul', 'GI2');

-- Insertion des absences
-- INSERT INTO Absences (Num_semaine, ID, Nbr_absences) VALUES
--                                                          (1, 1, 2),  -- Jean Dupont a 2 absences en semaine 1
--                                                          (1, 2, 0),  -- Sophie Martin aucune absence en semaine 1
--                                                          (1, 3, 3),  -- Paul Durand a 3 absences en semaine 1
--                                                          (2, 1, 1),  -- Jean Dupont a 1 absence en semaine 2
--                                                          (2, 3, 0);  -- Paul Durand aucune absence en semaine 2

SELECT * FROM Eleves;
SELECT * FROM Absences;

SELECT * FROM Absences WHERE Num_semaine = 4 AND ID = 1;

-- DROP TABLE Absences;
-- DROP TABLE Eleves;

