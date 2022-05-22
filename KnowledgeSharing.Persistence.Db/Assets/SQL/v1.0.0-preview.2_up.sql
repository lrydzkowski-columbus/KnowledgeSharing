START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220522140311_add-finalized-at-column-to-order-table') THEN
    ALTER TABLE store."order" ADD "FinalizedAt" timestamp with time zone NULL;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220522140311_add-finalized-at-column-to-order-table') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220522140311_add-finalized-at-column-to-order-table', '6.0.4');
    END IF;
END $EF$;
COMMIT;

