using MySql.Data.MySqlClient;
using Portal.Common.Logging;
using Portal.DataAccess.Interfaces;
using Portal.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DataAccess.Repositories
{
    public class DemoRepository : BaseRepository, IDemoRepository
    {
        private readonly ILogProvider logProvider;

        public DemoRepository(ILogProvider logProvider)
        {
            this.logProvider = logProvider;
        }

        public List<DemoSummary> GetRequestedDemos()
        {
            this.logProvider.Info("DemoRepository, GetRequestedDemos");
            try
            {
                using (var connection = new MySqlConnection(this.ConString))
                {
                    var query = "select * from demorequest where completed = 0 AND scheduled = 0";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();

                        var record = cmd.ExecuteReader();

                        var records = new List<DemoSummary>();
                        while (record.Read())
                        {
                            records.Add(new DemoSummary
                            {
                                Id = Convert.ToInt32(record["iddemoreq"].ToString()),
                                AsscName = record["asscname"].ToString(),
                                Telephone = record["telephone"].ToString()
                            });
                        }

                        return records;
                    }
                }
            }
            catch (Exception ex)
            {
                this.logProvider.Error("DemoRepository, GetRequestedDemos", ex);
                throw;
            }
        }
    }
}
