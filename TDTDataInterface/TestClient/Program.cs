using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTDataInterface.IDAL;
using TDTDataInterface.DAL;
using TDTDataInterface.Model;
using System.Data;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {   
            IWellTest wellTest = new WellTest();
            string result = wellTest.GetSingleWell("艾湖1");
            Console.WriteLine(result);
            List<DrillingWell> dwList = wellTest.GetDrillingWellList("艾湖1");

            IOracleHelper oracleHelper = new OracleHelper();
            string sql = "select * from JXYCMS.CCCG01 t";
            string connectionString = "Data Source= (DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 10.72.5.142)(PORT = 1521)))(CONNECT_DATA =(SID = o10gasm3)));User ID=HOUBIN607;Password=2016#houbin;Persist Security Info=True";
            DataSet dSet = oracleHelper.GetDataSet(sql,connectionString);
        }
    }
}
