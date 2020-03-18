using CSG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.persistence;

namespace CSG.logic
{
    class ClientLog
    {
        public void Create(Client client)
        {
            try
            {
                //Procedemos a crear el cliente
                DAOFactory.GetClientDAO().Create(client);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ClientLog->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }

        public bool Read_once_exist(string id)
        {
            return DAOFactory.GetClientDAO().Read_once_exist(id);
        }

        public Client Read_once(string id)
        {
            return DAOFactory.GetClientDAO().Read_once(id);
        }

        public void Update(Client client)
        {
            
        }
    }
}
