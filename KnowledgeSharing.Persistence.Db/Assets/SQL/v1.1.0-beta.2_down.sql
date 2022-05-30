START TRANSACTION;


DO $EF$
BEGIN
    IF EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220530084428_remove-column') THEN
    ALTER TABLE store.product ADD image_url text NULL;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220530084428_remove-column') THEN
    DELETE FROM "__EFMigrationsHistory"
    WHERE "MigrationId" = '20220530084428_remove-column';
    END IF;
END $EF$;
COMMIT;

