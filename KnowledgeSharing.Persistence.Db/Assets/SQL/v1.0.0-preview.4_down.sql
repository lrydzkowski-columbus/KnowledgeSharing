START TRANSACTION;


DO $EF$
BEGIN
    IF EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220524190132_add-category.is_visible-column') THEN
    ALTER TABLE store.category DROP COLUMN is_visible;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220524190132_add-category.is_visible-column') THEN
    DELETE FROM "__EFMigrationsHistory"
    WHERE "MigrationId" = '20220524190132_add-category.is_visible-column';
    END IF;
END $EF$;
COMMIT;

