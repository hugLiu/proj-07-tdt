using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTDataInterface.IDAL;
using TDTDataInterface.Utils;

namespace TDTDataInterface.DAL
{
    public class OracleHelper:IOracleHelper
    {
        OracleUtil oUtil = null;
        /// <summary>
        /// 构造函数，初始化oracle工具类
        /// </summary>
        public OracleHelper()
        {
            oUtil = new OracleUtil();
        }

        /// <summary>
        /// 获取查询结果集
        /// </summary>
        /// <param name="connetctionString">连接字符串</param>
        /// <param name="sql">sql语句</param>
        /// <returns>查询结果集</returns>
        public DataSet GetDataSet(string connetctionString, string sql)
        {
            DataSet dSet = new DataSet();
            oUtil = new OracleUtil(connetctionString);
            dSet = oUtil.ExecuteQuery(sql);
            return dSet;
        }

        /// <summary>
        /// 获取查询结果集
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="obj">可选参数(第一个可选参数为数据库连接字符串)</param>
        /// <returns></returns>
        public DataSet GetDataSet(string sql, params object[] obj)
        {
            if (obj.Length > 0)
            {
                return GetDataSet(obj[0].ToString(), sql);
            }
            else
            {
                DataSet dSet = oUtil.ExecuteQuery(sql);
                return dSet;
            }
        }

        /// <summary>
        /// 获取查询结果表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="obj">可选参数(第一个可选参数为数据库连接字符串)</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, params object[] obj)
        {
            return GetDataSet(sql, obj).Tables[0];
        }
    }
}
