global using Dapper;
global using Microsoft.Data.SqlClient;
using System.Collections;
using System.Runtime.InteropServices;
using StoreSystem.Data;
using StoreSystem.Models;
using StoreSystem.Models.DataBase;
using StoreSystem.Models.DataEntities;
using StoreSystem.Models.QueryComposition;

DBActor db = new();

db.Delete(new ProductPurchaseEntity {PurchaseId = 3, ProductId = 1});