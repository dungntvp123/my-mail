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
    public class UserDAO : BaseDAL
    {
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        private UserDAO() { }
        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<User> GetUserList()
        {
            IDataReader dataReader = null;
            String sql = "SELECT [id]\n" +
                        "      ,[mail]\n" +
                        "      ,[username]\n" +
                        "      ,[password]\n" +
                        "      ,[changepasscode]\n" +
                        "  FROM [dbo].[User]";
            var users = new List<User>();
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    users.Add(new User
                    {
                        Id = dataReader.GetInt32(0),
                        Mail = dataReader.GetString(1),
                        Username = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        ChangePassCode = dataReader.GetString(4),
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
            return users;
        }

        public User GetUserById(int id)
        {
            IDataReader dataReader = null;
            String sql = "SELECT [id]\n" +
                        "      ,[mail]\n" +
                        "      ,[username]\n" +
                        "      ,[password]\n" +
                        "      ,[changepasscode]\n" +
                        "  FROM [dbo].[User] WHERE id = " + id;
            User user = null;
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                if (dataReader.Read())
                {
                    user = new User
                    {
                        Id = dataReader.GetInt32(0),
                        Mail = dataReader.GetString(1),
                        Username = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        ChangePassCode = dataReader.GetString(4),
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
            return user;
        }

        public User GetUserByMail(string mail)
        {
            IDataReader dataReader = null;
            String sql = "SELECT [id]\n" +
                        "      ,[mail]\n" +
                        "      ,[username]\n" +
                        "      ,[password]\n" +
                        "      ,[changepasscode]\n" +
                        "  FROM [dbo].[User] WHERE mail = '" + mail + "'";
            User user = null;
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                if (dataReader.Read())
                {
                    user = new User
                    {
                        Id = dataReader.GetInt32(0),
                        Mail = dataReader.GetString(1),
                        Username = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        ChangePassCode = dataReader.GetString(4),
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
            return user;
        }
        public User AddNew(User user) 
        {
            try
            {
                String sql = "INSERT INTO [dbo].[User]\n" +
                                "           ([mail]\n" +
                                "           ,[username]\n" +
                                "           ,[password]\n" +
                                "           ,[changepasscode])\n" +
                                "     VALUES\n" +
                                "           (@Mail\n" +
                                "           ,@Username\n" +
                                "           ,@Password\n" +
                                "           ,@Changepasscode);\n" +
                                "SELECT SCOPE_IDENTITY()";
                var parameters = new List<SqlParameter>();

                parameters.Add(dataProvider.CreateParameter("@Mail", 30, user.Mail, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Username", 30, user.Username, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Password", 30, user.Password, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Changepasscode", 10, user.ChangePassCode, DbType.String));
                user.Id = dataProvider.Insert(sql, CommandType.Text, parameters.ToArray());

            } 
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }


            return user;
        }

        public void Update(User user)
        {
            try
            {
                User exsitance = GetUserById(user.Id);
                if (exsitance != null)
                {
                    String sql = "UPDATE [dbo].[User]\n" +
                                "   SET [mail] = @Mail\n" +
                                "      ,[username] = @Username\n" +
                                "      ,[password] = @Password\n" +
                                "      ,[changepasscode] = @Changepasscode\n" +
                                " WHERE id = " + user.Id;
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@Mail", 30, user.Mail, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Username", 30, user.Username, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Password", 30, user.Password, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Changepasscode", 10, user.ChangePassCode, DbType.String));
                    dataProvider.Update(sql, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("user isn't exist");
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
                User existance = GetUserById(id);
                if (existance != null)
                {
                    String sql = "DELETE FROM [dbo].[User]\n" +
                                "      WHERE id = " + id;
                    dataProvider.Delete(sql, CommandType.Text);
                } 
                else
                {
                    throw new Exception("User isn't exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
 
        }

        public User Login(string mail, string password)
        {
            IDataReader dataReader = null;
            String sql = "SELECT [id]\n" +
                        "      ,[mail]\n" +
                        "      ,[username]\n" +
                        "      ,[password]\n" +
                        "      ,[changepasscode]\n" +
                        "  FROM [dbo].[User] WHERE mail = '" + mail + "' and password = '" + password + "'";
            User user = null;
            try
            {
                dataReader = dataProvider.GetDataReader(sql, CommandType.Text, out connection);
                if (dataReader.Read())
                {
                    user = new User
                    {
                        Id = dataReader.GetInt32(0),
                        Mail = dataReader.GetString(1),
                        Username = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        ChangePassCode = dataReader.GetString(4),
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return user;
        }

    }
}
