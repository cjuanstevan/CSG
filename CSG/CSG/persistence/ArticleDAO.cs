using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.model;

namespace CSG.persistence
{
    class ArticleDAO : IArticleDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public string BulkLoad(List<Article> articles)
        {
            string reportT = "";
            string reportF = "";
            int counterT = 0;
            int counterF = 0;

            try
            {
                Database.Connect();
                foreach (var a in articles)
                {
                    command = new OdbcCommand
                    {
                        Connection = Database.GetConn(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "{call csg.Article_Create(?,?,?,?,?)}"
                    };
                    command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = a.Article_code;
                    command.Parameters.Add("Description", OdbcType.VarChar, 50).Value = a.Article_description;
                    command.Parameters.Add("Model", OdbcType.VarChar, 50).Value = a.Article_model;
                    command.Parameters.Add("Serial", OdbcType.VarChar, 50).Value = a.Article_serial;
                    command.Parameters.Add("Warranty", OdbcType.SmallInt).Value = a.Article_warranty;
                    if (command.ExecuteNonQuery() > 0)
                    {
                        //registro quién se creó
                        reportT += "CODE: " + a.Article_code + " | ARTICLE: " + a.Article_description + Environment.NewLine;
                        //aumento el contador
                        counterT += 1;
                    }
                    else
                    {
                        //registro quién no se creó
                        reportF += "CODE: " + a.Article_code + " | ARTICLE: " + a.Article_description + Environment.NewLine;
                        //aumento el contador
                        counterF += 1;
                    }
                    //limpiamos el command (Probamos sin esto y veremos qué sucede)
                    //command.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ArticleDAO->BulkLoad: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return "RESULTADO:" + Environment.NewLine +
                "Exitosos(" + counterT + "): " + Environment.NewLine +
                reportT + Environment.NewLine +
                "Fallidos(" + counterF + "): " + Environment.NewLine +
                reportF;
        }

        public void Create(Article article)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Article_Create(?,?,?,?,?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = article.Article_code;
                command.Parameters.Add("Description", OdbcType.VarChar, 50).Value = article.Article_description;
                command.Parameters.Add("Model", OdbcType.VarChar, 50).Value = article.Article_model;
                command.Parameters.Add("Serial", OdbcType.VarChar, 50).Value = article.Article_serial;
                command.Parameters.Add("Warranty", OdbcType.SmallInt).Value = article.Article_warranty;
                
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Artículo creado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha creado el artículo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ArticleDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public void Delete(string code)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Article_Delete(?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = code;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Artículo eliminado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha eliminado el artículo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ArticleDAO->Delete: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public List<Article> Read_all()
        {
            List<Article> articles = new List<Article>();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Article_ReadAll}"
                };
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Article article = new Article
                    {
                        Article_code = dataReader.GetString(0),
                        Article_description = dataReader.GetString(1),
                        Article_model = dataReader.GetString(2),
                        Article_serial = dataReader.GetString(3),
                        Article_warranty = ushort.Parse(dataReader.GetInt32(4).ToString())
                    };
                    articles.Add(article);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ArticleDAO->Read_all: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return articles;
        }

        public Article Read_once(string code)
        {
            Article article = new Article();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Article_ReadOnce(?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = code;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    article = new Article
                    {
                        Article_code = dataReader.GetString(0),
                        Article_description = dataReader.GetString(1),
                        Article_model = dataReader.GetString(2),
                        Article_serial = dataReader.GetString(3),
                        Article_warranty = ushort.Parse(dataReader.GetInt32(4).ToString())
                    };
                }
                else
                {
                    article = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ArticleDAO->Read_once: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return article;
        }

        public bool Read_once_exist(string code)
        {
            bool response = false;
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Article_ReadOnceExist(?)}",
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = code;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    response = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ArticleDAO->Read_once_exist: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return response;
        }

        public void Update(Article article)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Article_Update(?,?,?,?,?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = article.Article_code;
                command.Parameters.Add("Description", OdbcType.VarChar, 50).Value = article.Article_description;
                command.Parameters.Add("Model", OdbcType.VarChar, 50).Value = article.Article_model;
                command.Parameters.Add("Serial", OdbcType.VarChar, 50).Value = article.Article_serial;
                command.Parameters.Add("Warranty", OdbcType.SmallInt).Value = article.Article_warranty;

                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Artículo actualizado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha actualizado el artículo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ArticleDAO->Update: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }
    }
}
