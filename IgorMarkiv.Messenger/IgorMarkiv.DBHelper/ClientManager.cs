using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HELIX.ExceptionDLL;
using Helix.DBHelper.Engine;

namespace Helix.DBHelper
{
    public static class ClientManager
    {

        private static DB _DB;

        public static void Init(DB dB)
        {
            _DB = dB;
        }

        //public static void CreateClient(string clientKey, string clientName, string clientLocation)
        //{
        //    _DB.CreateClient(clientKey, clientName, clientLocation);
        //}

        //public static void UpdateClient(int id, string clientKey, string clientName, string clientLocation)
        //{
        //    if (!_DB.EditClient(id, clientKey, clientName, clientLocation))
        //        throw new HelixException(HelixExceptionCode.E03);
        //}

        //public static void RemoveClient(string clientKey)
        //{
        //    if (!_DB.RemoveClient(clientKey))
        //        throw new HelixException(HelixExceptionCode.E03);
        //}

        //public static List<ClientData> GetClientsList()
        //{
        //    return _DB.GetAllClients();
        //}

        //public static DataSet GetClientsDataSet()
        //{
        //    DataSet set = new DataSet("ClientsDataSet");
        //    DataTable table = new DataTable();

        //    table.Columns.Add("id", typeof(int));
        //    table.Columns.Add("key", typeof(string));
        //    table.Columns.Add("name", typeof(string));
        //    table.Columns.Add("location", typeof(string));

        //    var clients = GetClientsList();

        //    foreach (ClientData c in clients)
        //    {
        //        DataRow row = table.NewRow();

        //        row["id"] = c.id;
        //        row["key"] = c.key;
        //        row["name"] = c.name;
        //        row["location"] = c.location;

        //        table.Rows.Add(row);
        //    }
        //    set.Tables.Add(table);
        //    return set;
        //}

        //public static DataRow GetClientById(int clientId)
        //{
        //    var clients = GetClientsDataSet().Tables[0];
        //    foreach(DataRow row in clients.Rows)
        //    {
        //        if ((int)row["id"] == clientId)
        //            return row;
        //    }
        //    throw new HelixException(HelixExceptionCode.E03);
        //}

        //public static bool CheckClient(string clientKey)
        //{
        //    return _DB.IsClientRegistered(clientKey);
        //}

        //public static DataSet GetUsersAllowedToClient(int clientId)
        //{
        //    int[] ids = _DB.GetClientsAllowedUsersIds(clientId);
        //    DataTable users = UserRoleManager.GetAllUsersTable().Tables[0];
        //    DataSet set = new DataSet("UsersAllowed");
        //    DataTable table = users.Clone();

        //    foreach (DataRow row in users.Rows)
        //    {
        //        if (ids.Contains((int)row["id"]))
        //            table.ImportRow(row);
        //    }
        //    set.Tables.Add(table);
        //    return set;
        //}

        //public static DataSet GetClientsAvailableToUser(int userId)
        //{
        //    int[] ids = _DB.GetUsersAvailableClientsIds(userId);
        //    DataTable clients = GetClientsDataSet().Tables[0];
        //    DataSet set = new DataSet("ClientsAvailable");
        //    DataTable table = clients.Clone();

        //    foreach (DataRow row in clients.Rows)
        //    {
        //        if (ids.Contains((int)row["id"]))
        //            table.ImportRow(row);
        //    }
        //    set.Tables.Add(table);
        //    return set;
        //}

        //public static bool IsUserAllowed(int userId, string clientKey)
        //{
        //    return _DB.IsUserToClient(userId, clientKey);
        //}

        //public static void AllowUserToClient(int userId, string clientKey)
        //{
        //    _DB.CreateUserToClient(userId, clientKey);
        //}

        //public static void DenyUserToClient(int userId, string clientKey)
        //{
        //    if (!_DB.RemoveUserToClient(userId, clientKey))
        //        throw new HelixException(HelixExceptionCode.E03);
        //}

    }
}
