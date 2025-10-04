@echo off
@echo This cmd file creates a Data API Builder configuration based on the chosen database objects.
@echo To run the cmd, create an .env file with the following contents:
@echo dab-connection-string=your connection string
@echo ** Make sure to exclude the .env file from source control **
@echo **
dotnet tool install -g Microsoft.DataApiBuilder
dab init -c dab-config.json --database-type mssql --connection-string "@env('dab-connection-string')" --host-mode Development
@echo Adding tables
dab add "Excursione" --source "[dbo].[Excursiones]" --fields.include "Id,Nombre,Descripcion,Precio" --permissions "anonymous:*" 
dab add "ViajeDetalle" --source "[dbo].[ViajeDetalles]" --fields.include "Id,ViajeId,ExcursionId,CantidadPersonas,Subtotal" --permissions "anonymous:*" 
dab add "Viaje" --source "[dbo].[Viajes]" --fields.include "Id,Destino,FechaInicio,FechaFin,PrecioTotal,Estado" --permissions "anonymous:*" 
@echo Adding views and tables without primary key
@echo Adding relationships
dab update ViajeDetalle --relationship Excursione --target.entity Excursione --cardinality one
dab update Excursione --relationship ViajeDetalle --target.entity ViajeDetalle --cardinality many
dab update ViajeDetalle --relationship Viaje --target.entity Viaje --cardinality one
dab update Viaje --relationship ViajeDetalle --target.entity ViajeDetalle --cardinality many
@echo Adding stored procedures
dab add "SpActualizarEstadoViaje" --source "[dbo].[SP_ACTUALIZAR_ESTADO_VIAJE]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
dab add "SpActualizarFechaInicio" --source "[dbo].[SP_ACTUALIZAR_FECHA_INICIO]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
dab add "SpObtenerExcursionesPorViaje" --source "[dbo].[SP_OBTENER_EXCURSIONES_POR_VIAJE]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
dab add "SpObtenerPrimerViajePorEstado" --source "[dbo].[SP_OBTENER_PRIMER_VIAJE_POR_ESTADO]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
dab add "SpObtenerViajePorId" --source "[dbo].[SP_OBTENER_VIAJE_POR_ID]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
dab add "SpObtenerViajesCaro" --source "[dbo].[SP_OBTENER_VIAJES_CAROS]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
dab add "SpObtenerViajesNoCancelado" --source "[dbo].[SP_OBTENER_VIAJES_NO_CANCELADOS]" --source.type "stored-procedure" --permissions "anonymous:execute" --rest.methods "get" --graphql.operation "query" 
@echo **
@echo ** run 'dab validate' to validate your configuration **
@echo ** run 'dab start' to start the development API host **
