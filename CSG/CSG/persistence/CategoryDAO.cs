using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.model;

namespace CSG.persistence
{
    class CategoryDAO : ICategoryDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;

        public List<Category> Read_all()
        {
            List<Category> categories = new List<Category>();
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "{call csg.Category_Read_all}"
                };
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Category category = new Category()
                    {
                        Category_id = dataReader.GetByte(0),
                        Category_name = dataReader.GetString(1)
                    };
                    categories.Add(category);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Database.Disconnect();
            }
            return categories;
        }

        public Category Read_once(byte id)
        {
            Category category = new Category();
            try
            {
                if (!Database.GetConn().State.ToString().Equals("Open"))
                {
                    Database.Connect();
                }
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "{call csg.Category_Read_once(?)}"
                };
                command.Parameters.Add("Id", OdbcType.TinyInt).Value = id;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    category = new Category()
                    {
                        Category_id = dataReader.GetByte(0),
                        Category_name = dataReader.GetString(1)
                    };
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en CategoryDAO->Read_once: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return category;
        }
    }
}
