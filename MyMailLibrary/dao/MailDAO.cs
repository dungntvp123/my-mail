using Microsoft.Data.SqlClient;
using MyMailLibrary.DBContext;
using MyMailLibrary.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailLibrary.dao
{
    public class MailDAO : BaseDAL
    {
        private static MailDAO instance = null;
        private static readonly object instanceLock = new object();

        private MailDAO() { }

        public static MailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MailDAO();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Mail> GetMailList(int from, int type)
        {
            IDataReader dataReader = null;
            String sql = "SELECT [id]\n" +
                        "      ,[from]\n" +
                        "      ,[subject]\n" +
                        "      ,[content]\n" +
                        "      ,[type]\n" +
                        "  FROM [dbo].[Mail] WHERE type = " + type + " and [from] = " + from;
            var mails = new List<Mail>();
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    mails.Add(new Mail
                    {
                        Id = dataReader.GetInt32(0),
                        From = dataReader.GetInt32(1),
                        Subject = dataReader.GetString(2),
                        Content = dataReader.GetString(3),
                        Type = dataReader.GetInt32(4),
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
            return mails;
        }

        public Mail GetMailById(int id)
        {
            IDataReader dataReader = null;
            String sql = "SELECT [id]\n" +
                        "      ,[from]\n" +
                        "      ,[subject]\n" +
                        "      ,[content]\n" +
                        "      ,[type]\n" +
                        "  FROM [dbo].[Mail] WHERE id = " + id;
            Mail mail = null;
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                if (dataReader.Read())
                {
                    mail = new Mail
                    {
                        Id = dataReader.GetInt32(0),
                        From = dataReader.GetInt32(1),
                        Subject = dataReader.GetString(2),
                        Content = dataReader.GetString(3),
                        Type = dataReader.GetInt32(4),
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
                CloseConnection();
            }
            return mail;
        }

        public Mail AddNew(Mail mail)
        {
            try
            {
                String sql = "INSERT INTO [dbo].[Mail]\n" +
                                "           ([from]\n" +
                                "           ,[subject]\n" +
                                "           ,[content]\n" +
                                "           ,[type])\n" +
                                "     VALUES\n" +
                                "           (@From\n" +
                                "           ,@Subject\n" +
                                "           ,@Content\n" +
                                "           ,@Type);\n" +
                                "SELECT SCOPE_IDENTITY()";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@From", 4, mail.From, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@Subject", 100, mail.Subject, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Content", 8000, mail.Content, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Type", 4, mail.Type, DbType.Int32));
                mail.Id = dataProvider.Insert(sql, CommandType.Text, parameters.ToArray());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return mail;
        }

        public void Update(Mail mail)
        {
            try
            {
                Mail existance = GetMailById(mail.Id);
                if (existance != null)
                {
                    String sql = "UPDATE [dbo].[Mail]\n" +
                                "   SET [from] = @From\n" +
                                "      ,[subject] = @Subject\n" +
                                "      ,[content] = @Content\n" +
                                "      ,[type] = @Type\n" +
                                " WHERE id = " + mail.Id;
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@From", 4, mail.From, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@Subject", 100, mail.Subject, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Content", 8000, mail.Content, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Type", 4, mail.Type, DbType.Int32));
                    dataProvider.Update(sql, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("Mail isn't exsit");
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
                Mail existance = GetMailById(id);
                if (existance != null)
                {
                    String sql = "DELETE FROM [dbo].[Mail]\n" +
                                "      WHERE id = " + id;
                    dataProvider.Delete(sql, CommandType.Text);
                }
                else
                {
                    throw new Exception("Mail isn't exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
