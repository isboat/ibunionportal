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
    public class AssociationRepository : BaseRepository, IAssociationRepository
    {
        private readonly ILogProvider logProvider;

        public AssociationRepository(ILogProvider logProvider)
        {
            this.logProvider = logProvider;
        }

        public List<Association> GetAllAssociations()
        {
            this.logProvider.Info("AssociationRepository, GetAllAssociations");
            try
            {
                using (var connection = new MySqlConnection(this.ConString))
                {
                    var query = "select * from associations";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();

                        var record = cmd.ExecuteReader();

                        var records = new List<Association>();
                        while (record.Read())
                        {
                            records.Add(new Association
                            {
                                Id = Convert.ToInt32(record["idass"].ToString()),
                                Name = record["name"].ToString(),
                                Address = record["address"].ToString(),
                                Country = record["country"].ToString(),
                                Email = record["email"].ToString(),
                                JoinDate = record["joined_date"].ToString(),
                                Password = record["password"].ToString(),
                                PaymentType = record["paymenttype"].ToString(),
                                Telephone = record["telephone"].ToString()
                            });
                        }

                        return records;
                    }
                }
            }
            catch (Exception ex)
            {
                this.logProvider.Error("AssociationRepository, GetAllAssociations", ex);
                throw;
            }
        }

        public Association GetAssociation(int id)
        {
            this.logProvider.Info("AssociationRepository, GetAssociation id = " + id);
            try
            {
                using (var connection = new MySqlConnection(this.ConString))
                {
                    var query = string.Format("select * from associations where idass ='{0}' limit 1", id);

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();

                        var record = cmd.ExecuteReader();

                        if (record.Read())
                        {
                            return new Association
                            {
                                Id = Convert.ToInt32(record["idass"].ToString()),
                                Name = record["name"].ToString(),
                                Address = record["address"].ToString(),
                                Country = record["country"].ToString(),
                                Email = record["email"].ToString(),
                                JoinDate = record["joined_date"].ToString(),
                                Password = record["password"].ToString(),
                                PaymentType = record["paymenttype"].ToString(),
                                Telephone = record["telephone"].ToString()
                            };
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                this.logProvider.Error("AssociationRepository, GetAssociation id = " + id, ex);
                throw;
            }
        }

        public int SaveAssociation(Association association)
        {
            this.logProvider.Info("AssociationRepository, SaveAssociation id=" + (association.Id > 0 ? association.Id.ToString() : "no id (adding assoc)"));
            try
            {
                string query;

                if (association.Id > 0)
                {
                    query = string.Format(
                        "update associations set name = '{0}', joined_date = '{1}', address = '{2}', telephone = '{3}', country = '{4}', " +
                        " paymenttype = '{5}', email = '{6}' " + "where idass = {7};",
                        association.Name, association.JoinDate, association.Address, association.Telephone,
                        association.Country, association.PaymentType, association.Email, association.Id);
                }
                else
                {
                    query = string.Format(
                        "insert into associations(name, joined_date, address, telephone, country, paymenttype, email) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                        association.Name, association.JoinDate, association.Address, association.Telephone, association.Country, association.PaymentType, association.Email);
                }

                using (var connection = new MySqlConnection(ConString))
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
                logProvider.Error("AssociationRepository, SaveAssociation id=" + (association.Id > 0 ? association.Id.ToString() : "no id (adding assoc)"), ex);
                throw;
            }
        }
    }
}
