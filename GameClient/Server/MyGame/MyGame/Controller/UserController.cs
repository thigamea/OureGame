using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.Servers;
using MyGame.DAO;
using common;
using MyGame.Model;
namespace MyGame.Controller
{
    class UserController : BaseController
    {
        private UserDAO userDAO = new UserDAO();
        private ResultDAO resultDAO = new ResultDAO();
        public UserController()
        {
            requestCode = RequestCode.User;
        }
        public string Login(string data, Client client, Server server)
        {
            string[] strs = data.Split(',');
            User user = userDAO.VerifyUser(client.MySQLConn, strs[0], strs[1]);
            if (user == null)
            {
                //Enum.GetName(typeof(ReturnCode), ReturnCode.Fail);
                return ((int)ReturnCode.Fail).ToString();
            }
            else
            {
                Result res = resultDAO.GetResultByUserid(client.MySQLConn, user.Id);
                client.SetUserData(user, res);
                return string.Format("{0},{1}", ((int)ReturnCode.Success).ToString(), user.Username);
            }
        }
        public string Register(string data, Client client, Server server)
        {
            string[] strs = data.Split(',');
            string username = strs[0]; string password = strs[1];
            bool res = userDAO.GetUserByUsername(client.MySQLConn, username);
            if (res)
            {
                return ((int)ReturnCode.Fail).ToString();
            }
            userDAO.AddUser(client.MySQLConn, username, password);
            return ((int)ReturnCode.Success).ToString();
        }
    }
}
