using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestDataAccess
{
    class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            //var fileName = @"E:\Epam_training\GitProjectFinal\Business\TestDataAccess\Credentials.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static UserData GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where method=@method");
                var value = connection.Query<UserData>(query,new { method = keyName }).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
        public static Dictionary<string,string> GetUsersName(List<string> keyName)
        {
            
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select method as [Key],login as [Value] from [DataSet$] where method IN @Methods");
                var value = connection.Query<KeyValuePair<string, string>>(query, new { Methods = keyName})
                .ToDictionary(pair => pair.Key, pair => pair.Value);
                connection.Close();
                return value;
                
            }

        }

    }
}
