param(
	[Parameter(Mandatory)]
	[string]$version,
	[Parameter(Mandatory)]
	[string]$fromMigration,
	[Parameter(Mandatory)]
	[string]$toMigration
)

$scriptDir = echo $MyInvocation.MyCommand.Path | Split-Path;
$scriptDir | Push-Location;

dotnet ef migrations script -o ".\SQL\${version}_up.sql" -i `
	-p "..\KnowledgeSharing.Persistence.Db.csproj" `
	$fromMigration `
	$toMigration;
dotnet ef migrations script -o ".\SQL\${version}_down.sql" -i `
	-p "..\KnowledgeSharing.Persistence.Db.csproj" `
	$toMigration `
	$fromMigration;

Pop-Location;