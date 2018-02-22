using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTDataInterface.Utils
{
    public class OracleUtil
    {
         //默认连接字符串
        static string connectionString = DesEncryptUtil.DesDecrypt(ConfigurationSettings.AppSettings["Oracle"]);
        //连接字符串
        string conString = string.Empty;
        
        /// <summary>
        /// 构造函数，不带参数默认读取配置连接字符串
        /// </summary>
        public OracleUtil()
            : this(connectionString)
        { 
            
        }

        /// <summary>
        /// 构造函数，初始化OracleHelper实例
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public OracleUtil(string conString)
        {
            this.conString = conString;
        }

        /// <summary>
        /// 执行sql语句查询数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回查询结果集</returns>
        public DataSet ExecuteQuery(string sql)
        {
            DataSet dSet = new DataSet();
            using (OracleConnection oConn = new OracleConnection()) 
            {
                oConn.ConnectionString = conString;
                oConn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oConn;
                cmd.CommandText = sql;
                OracleDataAdapter adp = new OracleDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(dSet);
                oConn.Close();
            }
            return dSet;
        }
    }
}
