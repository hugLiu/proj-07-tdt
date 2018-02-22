using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTDataInterface.IDAL;
using TDTDataInterface.Model;
using TDTDataInterface.Utils;
using System.Data;

namespace TDTDataInterface.DAL
{
    public class WellTest:IWellTest
    {
        OracleUtil oUtil;

        public WellTest()
        {
            oUtil = new OracleUtil();
        }

        /// <summary>
        /// 获取单井领域模型
        /// </summary>
        /// <param name="wellName">井号</param>
        /// <returns>单井领域模型实体</returns>
        public string GetSingleWell(string wellName)
        {
            return wellName;
        }

        /// <summary>
        /// 获取正钻井领域模型集
        /// </summary>
        /// <param name="wellName">井号</param>
        /// <returns>正钻井领域模型实体集</returns>
        public List<DrillingWell> GetDrillingWellList(string wellName)
        {
            string sql = @"select JHDM  as WellID,
                               JH    as WellName,
                               井别  as WellType,
                               JZT   as WellStaus,
                               X坐标 as XCoordinate,
                               Y坐标 as YCoordinate
                          from (SELECT JHDM,
                                       JH,
                                       JB 井别,
                                       '正钻井' AS JZT,
                                       CASE
                                         WHEN X2_6 IS NULL THEN
                                          X1_6
                                         ELSE
                                          X2_6
                                       END X坐标,
                                       CASE
                                         WHEN Y2_6 IS NULL THEN
                                          Y1_6
                                         ELSE
                                          Y2_6
                                       END Y坐标
        
                                  FROM NEW_KTSJK.AJZH06
                                 where jl like '%探井%'
                                   and substr(kzrq, 1, 4) = to_char(sysdate, 'yyyy')
                                   and wzrq is null)";
            DataTable dTble = oUtil.ExecuteQuery(sql).Tables[0];
            List<DrillingWell> dwList = new List<DrillingWell>();
            for (int i = 0; i < dTble.Rows.Count; i++)
            {
                DrillingWell dw = new DrillingWell();
                dw.WellID = dTble.Rows[i]["WellID"].ToString();
                dw.WellName = dTble.Rows[i]["WellName"].ToString();
                dw.WellStaus = dTble.Rows[i]["WellStaus"].ToString();
                dw.WellType = dTble.Rows[i]["WellType"].ToString();
                dw.XCoordinate = Convert.ToDouble(dTble.Rows[i]["XCoordinate"]);
                dw.YCoordinate = Convert.ToDouble(dTble.Rows[i]["YCoordinate"]);
                dwList.Add(dw);
                dw = null;
            }
            return dwList;
        }
    }
}
