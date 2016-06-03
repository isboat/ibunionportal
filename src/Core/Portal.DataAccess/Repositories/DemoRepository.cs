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
                var query = "select * from demorequest where completed = 0 AND scheduled = 0";
                return GetDemoSummaries(query);
            }
            catch (Exception ex)
            {
                this.logProvider.Error("DemoRepository, GetRequestedDemos", ex);
                throw;
            }
        }

        public List<Demo> GetCompletedDemos()
        {
            this.logProvider.Info("DemoRepository, GetCompletedDemos");

            try
            {
                var query = "select * from demorequest where completed = 1";
                return GetDemos(query);
            }
            catch (Exception ex)
            {
                this.logProvider.Error("DemoRepository, GetCompletedDemos", ex);
                throw;
            }
        }

        public List<Demo> GetScheduledDemos()
        {
            this.logProvider.Info("DemoRepository, GetScheduledDemos");

            try
            {
                var query = "select * from demorequest where scheduled = 1";
                return GetDemos(query);
            }
            catch (Exception ex)
            {
                this.logProvider.Error("DemoRepository, GetScheduledDemos", ex);
                throw;
            }
        }

        private List<Demo> GetDemos(string query)
        {
            using (var connection = new MySqlConnection(this.ConString))
            {
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    connection.Open();

                    var record = cmd.ExecuteReader();

                    var records = new List<Demo>();
                    while (record.Read())
                    {
                        records.Add(new Demo
                        {
                            Id = Convert.ToInt32(record["iddemoreq"].ToString()),
                            AsscName = record["asscname"].ToString(),
                            Telephone = record["telephone"].ToString(),
                            AsscAddr = record["asscaddr"].ToString(),
                            AsscCountry = record["country"].ToString(),
                            Email = record["email"].ToString(),
                            Schedule = record["scheduled"].ToString() == "1",
                            Completed = record["completed"].ToString() == "1",
                            ScheduleDate = record["scheduledate"].ToString(),
                            CompletionDate= record["completeddate"].ToString()
                        });
                    }

                    return records;
                }
            }
        }

        private List<DemoSummary> GetDemoSummaries(string query)
        {
            using (var connection = new MySqlConnection(this.ConString))
            {

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
    }
}
