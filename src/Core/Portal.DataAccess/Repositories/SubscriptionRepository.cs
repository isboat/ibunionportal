using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Portal.Common.Logging;
using Portal.DataAccess.Interfaces;
using Portal.DataObjects;

namespace Portal.DataAccess.Repositories
{
    public class SubscriptionRepository : BaseRepository, ISubscriptionRepository
    {
        private readonly ILogProvider logProvider;

        public SubscriptionRepository(ILogProvider logProvider)
        {
            this.logProvider = logProvider;
        }

        public List<Subscription> GetSubscriptions(int assocId)
        {
            this.logProvider.Info("SubscriptionRepository, GetSubscriptions associd=" + assocId);

            try
            {
                var query = string.Format("select * from subscriptions where idassoc = {0}", assocId);

                using (var connection = new MySqlConnection(this.ConString))
                {
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();

                        var record = cmd.ExecuteReader();

                        var subscriptions = new List<Subscription>();

                        while (record.Read())
                        {
                            subscriptions.Add(new Subscription
                            {
                                Id = Convert.ToInt32(record["id"].ToString()),
                                AssocId = Convert.ToInt32(record["idassoc"].ToString()),
                                StartDate = record["startdate"].ToString(),
                                EndDate = record["enddate"].ToString()
                            });
                        }

                        return subscriptions;
                    }
                }
            }
            catch (Exception ex)
            {
                this.logProvider.Error("SubscriptionRepository, GetSubscriptions associd=" + assocId, ex);
                throw;
            }
        }

        public int UpdateSubscription(Subscription subscribe)
        {
            this.logProvider.Info("SubscriptionRepository, UpdateSubscription id=" + subscribe.Id);
            try
            {
                var query = "";

                if (subscribe.Id > 0)
                {
                    query = string.Format(
                        "update subscriptions set startdate = '{0}', enddate = '{1}' where id = {2};",
                        subscribe.StartDate, subscribe.EndDate, subscribe.Id);
                }
                else
                {
                    query = string.Format(
                        "insert into subscriptions(startdate, enddate, idassoc) values('{0}', '{1}', '{2}')",
                        subscribe.StartDate, subscribe.EndDate, subscribe.AssocId);
                }

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
                this.logProvider.Error("SubscriptionRepository, UpdateSubscription id=" + subscribe.Id, ex);
                throw;
            }
        }
    }
}
