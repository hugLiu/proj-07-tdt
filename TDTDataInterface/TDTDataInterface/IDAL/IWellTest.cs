using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTDataInterface.Model;

namespace TDTDataInterface.IDAL
{
    public interface IWellTest
    {
        /// <summary>
        /// 获取单井领域模型
        /// </summary>
        /// <param name="wellName">井号</param>
        /// <returns>单井领域模型实体</returns>
        string GetSingleWell(string wellName);

        /// <summary>
        /// 获取正钻井领域模型集
        /// </summary>
        /// <param name="wellName">井号</param>
        /// <returns>正钻井领域模型实体集</returns>
        List<DrillingWell> GetDrillingWellList(string wellName);
    }
}
