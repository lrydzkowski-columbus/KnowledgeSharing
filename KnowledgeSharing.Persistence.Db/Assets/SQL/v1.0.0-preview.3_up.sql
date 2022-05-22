START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220522151153_correct-column-name') THEN
    ALTER TABLE store."order" RENAME COLUMN "FinalizedAt" TO finalized_at;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220522151153_correct-column-name') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220522151153_correct-column-name', '6.0.4');
    END IF;
END $EF$;
COMMIT;

