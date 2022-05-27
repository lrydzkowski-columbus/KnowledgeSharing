START TRANSACTION;


DO $EF$
BEGIN
    IF EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220527112641_add_image_url_col_to_product_table') THEN
    ALTER TABLE store.product DROP COLUMN image_url;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220527112641_add_image_url_col_to_product_table') THEN
    DELETE FROM "__EFMigrationsHistory"
    WHERE "MigrationId" = '20220527112641_add_image_url_col_to_product_table';
    END IF;
END $EF$;
COMMIT;

