START TRANSACTION;


DO $EF$
BEGIN
    IF EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220522151153_correct-column-name') THEN
    ALTER TABLE store."order" RENAME COLUMN finalized_at TO "FinalizedAt";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220522151153_correct-column-name') THEN
    DELETE FROM "__EFMigrationsHistory"
    WHERE "MigrationId" = '20220522151153_correct-column-name';
    END IF;
END $EF$;
COMMIT;

