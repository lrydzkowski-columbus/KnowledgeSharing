START TRANSACTION;


DO $EF$
BEGIN
    IF EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220522140311_add-finalized-at-column-to-order-table') THEN
    ALTER TABLE store."order" DROP COLUMN "FinalizedAt";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220522140311_add-finalized-at-column-to-order-table') THEN
    DELETE FROM "__EFMigrationsHistory"
    WHERE "MigrationId" = '20220522140311_add-finalized-at-column-to-order-table';
    END IF;
END $EF$;
COMMIT;

