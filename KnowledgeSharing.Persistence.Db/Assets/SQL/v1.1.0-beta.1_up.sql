START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220527112641_add_image_url_col_to_product_table') THEN
    ALTER TABLE store.product ADD image_url text NULL;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220527112641_add_image_url_col_to_product_table') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220527112641_add_image_url_col_to_product_table', '6.0.4');
    END IF;
END $EF$;
COMMIT;

