using Belatrix.LoggerPluggable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Belatrix.LoggerPluggable.LogManagerDataBase
{
    public class LogRepository : ILogRepository
    {

        private string connectionString;
        public LogRepository() { }

        public LogRepository(Dictionary<string, string> parameters)
        {
            this.connectionString = parameters["ConnectionString"];
        }



        public void SaveMessage(Types.MessageLog message)
        {
            using (SqlConnection oCn = new SqlConnection(this.connectionString))
            {
                oCn.Open();
                using (SqlCommand oCmd = new SqlCommand("SP_LOGGER_R", oCn))
                {
                    oCmd.Connection = oCn;
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.Parameters.Add("@TITLELOG", SqlDbType.VarChar).Value = message.Title;
                    oCmd.Parameters.Add("MESSAGELOG", SqlDbType.VarChar).Value = message.Message;
                    oCmd.ExecuteNonQuery();
                }

            }
        }
    }
}
