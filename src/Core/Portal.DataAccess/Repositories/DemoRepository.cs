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

        public Demo GetDemo(int id)
        {
            this.logProvider.Info("DemoRepository, GetDemo");

            try
            {
                var query = string.Format("select * from demorequest where iddemoreq = {0} limit 1", id);

                using (var connection = new MySqlConnection(this.ConString))
                {
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();

                        var record = cmd.ExecuteReader();

                        if (record.Read())
                        {
                            return new Demo
                            {
                                Id = Convert.ToInt32(record["iddemoreq"].ToString()),
                                AsscName = record["asscname"].ToString(),
                                Firstname = record["firstname"].ToString(),
                                Lastname = record["lastname"].ToString(),
                                Telephone = record["telephone"].ToString(),
                                AsscAddr = record["asscaddr"].ToString(),
                                AsscCountry = record["country"].ToString(),
                                Email = record["email"].ToString(),
                                Schedule = record["scheduled"].ToString() == "1",
                                Completed = record["completed"].ToString() == "1",
                                ScheduleDate = record["scheduleddate"].ToString(),
                                CompletionDate = record["completeddate"].ToString()
                            };
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                this.logProvider.Error("DemoRepository, GetDemo", ex);
                throw;
            }
        }

        public int SaveDemo(Demo demo)
        {
            this.logProvider.Info("DemoRepository, SaveDemo id=" + demo.Id);
            try
            {
                var query = string.Format("update demorequest set asscname = '{0}', firstname = '{1}', lastname = '{2}', telephone = '{3}', asscaddr = '{4}', " +
                                          "country = '{5}', email = '{6}', scheduled = {7}, completed = {8}, scheduleddate = '{9}', completeddate = '{10}' " +
                                          "where iddemoreq = {11};",
                                          demo.AsscName, demo.Firstname, demo.Lastname, demo.Telephone, demo.AsscAddr, demo.AsscCountry, demo.Email,
                                          demo.Schedule? 1 : 0, demo.Completed? 1 : 0, demo.ScheduleDate, demo.CompletionDate, demo.Id);

                using (var connection = new MySqlConnection(this.ConString))
                {
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                this.logProvider.Error("DemoRepository, SaveDemo=" + demo.Id, ex);
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
