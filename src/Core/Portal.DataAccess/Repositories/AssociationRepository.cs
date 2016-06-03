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
                                Address = record["address"].ToString()
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
                                Address = record["address"].ToString()
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
    }
}
