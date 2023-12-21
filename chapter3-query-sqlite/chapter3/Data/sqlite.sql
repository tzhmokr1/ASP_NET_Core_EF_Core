PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
INSERT INTO __EFMigrationsHistory VALUES('20191215101015_InitialMigration','3.1.0');
CREATE TABLE IF NOT EXISTS "AssemblySteps" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AssemblySteps" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Cost" INTEGER NOT NULL
);
INSERT INTO AssemblySteps VALUES(1,'Bohren',2);
INSERT INTO AssemblySteps VALUES(2,'Fügen',1);
INSERT INTO AssemblySteps VALUES(3,'Kleben',2);
CREATE TABLE IF NOT EXISTS "PartDefinitions" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PartDefinitions" PRIMARY KEY AUTOINCREMENT,
    "Cost" INTEGER NOT NULL,
    "Name" TEXT NOT NULL
);
INSERT INTO PartDefinitions VALUES(1,100,'0815-1');
INSERT INTO PartDefinitions VALUES(2,100,'0815-2');
INSERT INTO PartDefinitions VALUES(3,120,'0815-3');
INSERT INTO PartDefinitions VALUES(4,120,'0815-4');
CREATE TABLE IF NOT EXISTS "Rounds" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Rounds" PRIMARY KEY AUTOINCREMENT,
    "Start" TEXT NOT NULL DEFAULT (datetime('now')),
    "End" TEXT NULL
);
INSERT INTO Rounds VALUES(1,'2019-12-15 11:10:37.797533',NULL);
CREATE TABLE IF NOT EXISTS "Products" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Products" PRIMARY KEY AUTOINCREMENT,
    "Start" TEXT NOT NULL DEFAULT (datetime('now')),
    "End" TEXT NULL,
    "RoundId" INTEGER NULL,
    CONSTRAINT "FK_Products_Rounds_RoundId" FOREIGN KEY ("RoundId") REFERENCES "Rounds" ("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "Stations" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Stations" PRIMARY KEY AUTOINCREMENT,
    "RoundId" INTEGER NULL,
    "Position" TEXT NOT NULL,
    CONSTRAINT "FK_Stations_Rounds_RoundId" FOREIGN KEY ("RoundId") REFERENCES "Rounds" ("Id") ON DELETE RESTRICT
);
INSERT INTO Stations VALUES(1,1,'Station_6');
INSERT INTO Stations VALUES(2,1,'Station_5');
INSERT INTO Stations VALUES(3,1,'Station_4');
INSERT INTO Stations VALUES(4,1,'Station_3');
INSERT INTO Stations VALUES(5,1,'Station_2');
INSERT INTO Stations VALUES(6,1,'Station_1');
CREATE TABLE IF NOT EXISTS "Parts" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Parts" PRIMARY KEY AUTOINCREMENT,
    "ProductId" INTEGER NULL,
    "PartDefinitionId" INTEGER NULL,
    CONSTRAINT "FK_Parts_PartDefinitions_PartDefinitionId" FOREIGN KEY ("PartDefinitionId") REFERENCES "PartDefinitions" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Parts_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "StationsAssemblyStepss" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_StationsAssemblyStepss" PRIMARY KEY AUTOINCREMENT,
    "StationId" INTEGER NULL,
    "AssemblyStepId" INTEGER NULL,
    CONSTRAINT "FK_StationsAssemblyStepss_AssemblySteps_AssemblyStepId" FOREIGN KEY ("AssemblyStepId") REFERENCES "AssemblySteps" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_StationsAssemblyStepss_Stations_StationId" FOREIGN KEY ("StationId") REFERENCES "Stations" ("Id") ON DELETE RESTRICT
);
DELETE FROM sqlite_sequence;
INSERT INTO sqlite_sequence VALUES('AssemblySteps',3);
INSERT INTO sqlite_sequence VALUES('PartDefinitions',4);
INSERT INTO sqlite_sequence VALUES('Rounds',1);
INSERT INTO sqlite_sequence VALUES('Products',50);
INSERT INTO sqlite_sequence VALUES('Stations',6);
CREATE INDEX "IX_Parts_PartDefinitionId" ON "Parts" ("PartDefinitionId");
CREATE INDEX "IX_Parts_ProductId" ON "Parts" ("ProductId");
CREATE INDEX "IX_Products_RoundId" ON "Products" ("RoundId");
CREATE INDEX "IX_Stations_RoundId" ON "Stations" ("RoundId");
CREATE INDEX "IX_StationsAssemblyStepss_AssemblyStepId" ON "StationsAssemblyStepss" ("AssemblyStepId");
CREATE INDEX "IX_StationsAssemblyStepss_StationId" ON "StationsAssemblyStepss" ("StationId");
COMMIT;
