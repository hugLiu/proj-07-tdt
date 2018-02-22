using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTDataInterface.Model
{
    public class DrillingWell
    {
        #region 属性
        //井ID
        public string WellID { get; set; }

        //井名
        public string WellName { get; set; }

        //井别(勘探，开发，评价)
        public string WellType { get; set; }

        //井状态
        public string WellStaus { get; set; }

        //X 坐标(单位：米)
        public double XCoordinate { get; set; }

        //Y 坐标(单位：米)
        public double YCoordinate { get; set; }

        #endregion
    }
}
