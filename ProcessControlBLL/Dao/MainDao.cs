using System . Text;
using StudentMgr;
using System . Data;

namespace ProcessControlBLL . Dao
{
    public class MainDao
    {
        /// <summary>
        /// 获取项目
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable getTableViewPro ( string name )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( !string . IsNullOrEmpty ( name ) )
                strSql . AppendFormat ( "SELECT DKA001,DKA002 FROM TPADKA WHERE DKA001 NOT LIKE '@%' AND DKA008 LIKE '0000%' AND DKA002 LIKE '%{0}%' ORDER BY DKA001 " ,name );
            else
                strSql . AppendFormat ( "SELECT DKA001,DKA002 FROM TPADKA WHERE DKA001 NOT LIKE '@%' AND DKA008 LIKE '0000%' ORDER BY DKA001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 获取项目所属合同
        /// </summary>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public DataTable getTableViewContract ( string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT IDA001,IDA004 FROM DCSIDA WHERE IDA011='{0}'" ,proNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取预付款
        /// </summary>
        /// <param name="proNum">项目号</param>
        /// <param name="contractNum">合同号</param>
        /// <returns></returns>
        public decimal getMoney ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(GDA009)/IDA014)) ID FROM TPADKA LEFT JOIN DCSIDA ON DKA001=IDA011 LEFT JOIN YSFGDA ON GDA023=DKA001 AND GDA054=IDA001 WHERE IDA001='{0}' GROUP BY IDA014" ,contractNum );

            return SqlHelper . ExecuteDecimal ( "ID" ,strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取计划
        /// </summary>
        /// <param name="proNum">项目号</param>
        /// <param name="contractNum">合同号</param>
        /// <returns></returns>
        public decimal getPlan ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(FLOAT,CONVERT(DECIMAL(18,4),CASE WHEN IDA980=0 THEN 0 ELSE SUM(RAA018)/IDA980 END)) ID FROM SGMRAA A INNER JOIN TPADKA B ON A.RAA960=B.DKA001 INNER JOIN DCSIDA C ON A.RAA961=C.IDA001 WHERE IDA001='{0}' GROUP BY IDA980" ,contractNum );

            return SqlHelper . ExecuteDecimal ( "ID" ,strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取采购
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public decimal getPurchase ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(FLOAT,CONVERT(DECIMAL(18,4),CASE WHEN SUM(HDB006)=0 THEN 0 ELSE SUM(HDB018)/SUM(HDB006) END)) ID FROM DCSHDA A INNER JOIN DCSHDB B ON A.HDA001=B.HDB001 INNER JOIN TPADKA C ON B.HDB960=C.DKA001  INNER JOIN DCSIDA D ON D.IDA001=B.HDB961 WHERE IDA001='{0}' " ,contractNum );

            return SqlHelper . ExecuteDecimal ( "ID" ,strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取生产
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public decimal getProduction ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(FLOAT,CONVERT(DECIMAL(18,4),CASE WHEN SUM(RAB007)=0 THEN 0 ELSE SUM(RAB008)/SUM(RAB007) END)) ID FROM SGMRAA A INNER JOIN TPADKA B ON A.RAA960=B.DKA001 INNER JOIN SGMRAB C ON A.RAA001=C.RAB001 INNER JOIN DCSIDA D ON A.RAA961=D.IDA001 WHERE IDA001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDecimal ( "ID" ,strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取完工
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public decimal getComplete ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(FLOAT,CONVERT(DECIMAL(18,4),CASE WHEN SUM(RAA018)=0 THEN 0 ELSE SUM(RAA019)/SUM(RAA018) END)) ID FROM SGMRAA A INNER JOIN TPADKA B ON A.RAA960=B.DKA001 INNER JOIN DCSIDA C ON A.RAA961=C.IDA001 WHERE IDA001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDecimal ( "ID" ,strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取交付
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public decimal getDeliver ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(FLOAT,CONVERT(DECIMAL(18,4),CASE WHEN IDA980=0 THEN 0 ELSE SUM(LCB008)/IDA980 END)) ID FROM JSKLCB A INNER JOIN TPADKA B ON A.LCB960=B.DKA001 INNER JOIN DCSIDA C ON A.LCB961=C.IDA001 WHERE IDA001='{0}' GROUP BY IDA980  " ,contractNum );

            return SqlHelper . ExecuteDecimal ( "ID" ,strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取开票
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public decimal getBilling ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(FLOAT,CONVERT(DECIMAL(18,4),CASE WHEN SUM(IDB007)=0 THEN 0 ELSE SUM(GGB010)/SUM(IDB007) END)) ID FROM TPADKA A INNER JOIN YSFGGA B ON A.DKA001=B.GGA960 INNER JOIN DCSIDA C ON C.IDA001=B.GGA961 INNER JOIN YSFGGB D ON B.GGA001=D.GGB001 INNER JOIN DCSIDB E ON C.IDA001=E.IDB001 WHERE IDA001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDecimal ( "ID" ,strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取合同明细
        /// </summary>
        /// <returns></returns>
        public DataTable getTableViewContractOther ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT IDB003,IDB004,IDB005,IDB006,IDB007,IDB980,IDB013,IDB016,ISNULL((SELECT IDB016 FROM DCSIDB F WHERE F.IDB001=B.IDB001 AND IDB004='AZF'),0) IDB16,IDA014 FROM DCSIDA A INNER JOIN DCSIDB B ON A.IDA001=B.IDB001 INNER JOIN TPADKA C ON A.IDA011=C.DKA001 WHERE IDB001='{0}') " ,contractNum );
            strSql . Append ( "SELECT IDB003 品号,IDB004 产品名称,IDB005 型号,IDB006 单位,CONVERT(FLOAT,IDB007) 数量,CONVERT(FLOAT,IDB980) 开启方向,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),IDB013)) 单价,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),IDB016)) 金额,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),IDA014-IDB16)) 小计,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),IDB16)) 安装费,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),IDA014)) 总计 FROM CET" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取预收款明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewMoneyOther ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT GDA054 合同号,DKA002 工程名称,GDA960 合同类型,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),GDA009)) 预收金额,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),IDA014)) 应收金额 FROM YSFGDA A INNER JOIN YSFGDB B ON A.GDA001=B.GDB001 INNER JOIN TPADKA C ON A.GDA023=C.DKA001 INNER JOIN DCSIDA D ON A.GDA054=D.IDA001 WHERE IDA001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取计划明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewPlat ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DEA002 品名,CONVERT(FLOAT,RAA018) 数量 FROM SGMRAA A INNER JOIN TPADKA B ON A.RAA960=B.DKA001 INNER JOIN DCSIDA C ON B.DKA001=C.IDA011 INNER JOIN TPADEA D ON D.DEA001=A.RAA015 WHERE IDA001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取采购明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewPurchase ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT HDB004 品名,CONVERT(FLOAT,HDB006) 数量,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),HDB007)) 单价,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),HDB008)) 金额,DGA002 供应商,CONVERT(FLOAT,HDB018) 已交数量 FROM DCSHDA A INNER JOIN DCSHDB B ON A.HDA001=B.HDB001 INNER JOIN TPADGA C ON A.HDA004=C.DGA001 INNER JOIN DCSIDA D ON D.IDA001=B.HDB961 WHERE IDA001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取生产明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewProduction ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT RAB004 品名,CONVERT(FLOAT,RAB008) 数量 FROM SGMRAA A INNER JOIN SGMRAB B ON A.RAA001=B.RAB001 INNER JOIN TPADKA C ON A.RAA960=C.DKA001 INNER JOIN DCSIDA D ON C.DKA001=D.IDA011 WHERE IDA001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取完工明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewComplete ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DEA002 品名,CONVERT(FLOAT,RAA019) 数量 FROM SGMRAA A INNER JOIN TPADKA B ON A.RAA960=B.DKA001 INNER JOIN TPADEA C ON A.RAA015=C.DEA001 INNER JOIN DCSIDA D ON B.DKA001=D.IDA011 WHERE IDA001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取交付明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewDeliver ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT LCB004 品名,CONVERT(FLOAT,LCB008) 数量 FROM JSKLCA A INNER JOIN JSKLCB B ON A.LCA001=B.LCB001 INNER JOIN TPADKA C ON C.DKA001=B.LCB960 INNER JOIN DCSIDA D ON C.DKA001=D.IDA011 WHERE IDA001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取开票明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewBilling ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DKA002 项目,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),GGA019+GGA020)) 金额,GGA014 备注 FROM YSFGGA A INNER JOIN TPADKA B ON B.DKA001=A.GGA960 INNER JOIN DCSIDA C ON B.DKA001=C.IDA011 WHERE IDA001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
