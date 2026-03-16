using System.Text;
using StoreSystem.Models;

namespace StoreSystem.Data;

public partial class DBActor
{
    private SqlConnection _sqlConnection = 
        new(File.ReadLines(@$"C:\connectionStrings\connectionString.txt").ElementAt(0));
}