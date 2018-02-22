using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TDTDataInterface.IDAL
{
    public interface IOracleHelper
    {
        /// <summary>
        /// 获取查询结果集
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="obj">可选参数(第一个可选参数为数据库连接字符串)</param>
        /// <returns></returns>
        DataSet GetDataSet(string sql, params object[] obj);

        /// <summary>
        /// 获取查询结果表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="obj">可选参数(第一个可选参数为数据库连接字符串)</param>
        /// <returns></returns>
        DataTable GetDataTable(string sql, params object[] obj);
    }
}
