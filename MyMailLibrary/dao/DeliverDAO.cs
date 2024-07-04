using Microsoft.Data.SqlClient;
using MyMailLibrary.DBContext;
using MyMailLibrary.entity;

using System.Data;


namespace MyMailLibrary.dao
{
    public class DeliverDAO : BaseDAL
    {
        private static DeliverDAO instance = null;
        private static readonly object instanceLock = new object();

        private DeliverDAO() { }

        public static DeliverDAO Instance
        {
            get 
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DeliverDAO();
                    }
                }
                return instance; 
            }
        }

        public IEnumerable<Deliver> GetMailDelivers(int mailId)
        {
            IDataReader dataReader = null;
            String sql = "SELECT [id]\n" +
                        "      ,[mail]\n" +
                        "      ,[to]\n" +
                        "      ,[readstatus]\n" +
                        "  FROM [dbo].[Deliver] WHERE mail = " + mailId;
            var delivers = new List<Deliver>();
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    delivers.Add(new Deliver
                    {
                        Id = dataReader.GetInt32(0),
                        Mail = dataReader.GetInt32(1),
                        To = dataReader.GetInt32(2),
                        ReadStatus = dataReader.GetInt32(3),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader?.Close();
                CloseConnection();
            }

            return delivers;
        }

        public IEnumerable<Deliver> GetReadStatusDelivers(int userid, int status)
        {
            IDataReader dataReader = null;
            String sql = "SELECT [id]\n" +
                        "      ,[mail]\n" +
                        "      ,[to]\n" +
                        "      ,[readstatus]\n" +
                        "  FROM [dbo].[Deliver] WHERE readstatus = " + status + "and [to] = " + userid;
            var delivers = new List<Deliver>();
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    delivers.Add(new Deliver
                    {
                        Id = dataReader.GetInt32(0),
                        Mail = dataReader.GetInt32(1),
                        To = dataReader.GetInt32(2),
                        ReadStatus = dataReader.GetInt32(3),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader?.Close();
                CloseConnection();
            }

            return delivers;
        }

        public IEnumerable<Deliver> GetUserDeliversByMailType(int userid, int mailType, int status)
        {
            IDataReader dataReader = null;
            String sql = "SELECT [Deliver].[id]\n" +
                        "      ,[mail]\n" +
                        "      ,[to]\n" +
                        "      ,[readstatus]\n" +
                        "  FROM [MyMail].[dbo].[Deliver] inner join [MyMail].[dbo].Mail on [Deliver].mail = [Mail].id\n" +
                        "  WHERE [Deliver].[to] = " + userid + " and [Mail].type = " + mailType + "and [Deliver].readstatus = " + status;
            var delivers = new List<Deliver>();
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    delivers.Add(new Deliver
                    {
                        Id = dataReader.GetInt32(0),
                        Mail = dataReader.GetInt32(1),
                        To = dataReader.GetInt32(2),
                        ReadStatus = dataReader.GetInt32(3),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader?.Close();
                CloseConnection();
            }

            return delivers;
        }

        public Deliver GetDeliver(int id)
        {
            IDataReader dataReader = null;
            String sql = "SELECT [id]\n" +
                        "      ,[mail]\n" +
                        "      ,[to]\n" +
                        "      ,[readstatus]\n" +
                        "  FROM [dbo].[Deliver] WHERE id = " + id;
            Deliver deliver = null;
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                if (dataReader.Read())
                {
                    deliver = new Deliver
                    {
                        Id = dataReader.GetInt32(0),
                        Mail = dataReader.GetInt32(1),
                        To = dataReader.GetInt32(2),
                        ReadStatus = dataReader.GetInt32(3),
                    };
                }
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally 
            {
                dataReader?.Close();
            }
            return deliver;
        }

        public Deliver GetDeliver(int mailId, int userid)
        {
            IDataReader dataReader = null;
            String sql = "SELECT [id]\n" +
                        "      ,[mail]\n" +
                        "      ,[to]\n" +
                        "      ,[readstatus]\n" +
                        "  FROM [dbo].[Deliver] WHERE mail = " + mailId + "and [to] = " + userid;
            Deliver deliver = null;
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                if (dataReader.Read())
                {
                    deliver = new Deliver
                    {
                        Id = dataReader.GetInt32(0),
                        Mail = dataReader.GetInt32(1),
                        To = dataReader.GetInt32(2),
                        ReadStatus = dataReader.GetInt32(3),
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader?.Close();
            }
            return deliver;
        }

        public Deliver AddNew(Deliver deliver)
        {
            try
            {
                String sql = "INSERT INTO [dbo].[Deliver]\n" +
                                "           ([mail]\n" +
                                "           ,[to]\n" +
                                "           ,[readstatus])\n" +
                                "     VALUES\n" +
                                "           (@Mail\n" +
                                "           ,@To\n" +
                                "           ,@ReadStatus);\n" +
                                "SELECT SCOPE_IDENTITY()";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@Mail", 4, deliver.Mail, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@To", 4, deliver.To, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@ReadStatus", 4, deliver.ReadStatus, DbType.Int32));
                deliver.Id = dataProvider.Insert(sql, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
            return deliver;
        }

        public void Update(Deliver deliver)
        {
            try
            {
                Deliver existance = GetDeliver(deliver.Id);
                if (existance != null)
                {
                    String sql = "UPDATE [dbo].[Deliver]\n" +
                                    "   SET [mail] = @Mail\n" +
                                    "      ,[to] = @To\n" +
                                    "      ,[readstatus] = @ReadStatus\n" +
                                    " WHERE id = " + deliver.Id;
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@Mail", 4, deliver.Mail, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@To", 4, deliver.To, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@ReadStatus", 4, deliver.ReadStatus, DbType.Int32));
                    dataProvider.Update(sql, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("Deliver isn't exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Delete(int id)
        {
            try
            {
                Deliver existance = GetDeliver(id);
                if (existance != null)
                {
                    String sql = "DELETE FROM [dbo].[Deliver]\n" +
                                "      WHERE id = " + id;
                    dataProvider.Delete(sql, CommandType.Text);
                }
                else
                {
                    throw new Exception("Deliver isn't exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
