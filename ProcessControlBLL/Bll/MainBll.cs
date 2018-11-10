using System . Data;

namespace ProcessControlBLL . Bll
{
    public class MainBll
    {
        Dao.MainDao dal=null;
        public MainBll ( )
        {
            dal = new Dao . MainDao ( );
        }

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable getTableViewPro ( string name )
        {
            return dal . getTableViewPro ( name );
        }

        /// <summary>
        /// 获取项目所属合同
        /// </summary>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public DataTable getTableViewContract ( string proNum )
        {
            return dal . getTableViewContract ( proNum );
        }

        /// <summary>
        /// 获取已付款
        /// </summary>
        /// <param name="proNum">项目号</param>
        /// <param name="contractNum">合同号</param>
        /// <returns></returns>
        public decimal getMoney ( string contractNum )
        {
            return dal . getMoney ( contractNum );
        }

        /// <summary>
        /// 获取计划
        /// </summary>
        /// <param name="proNum">项目号</param>
        /// <param name="contractNum">合同号</param>
        /// <returns></returns>
        public decimal getPlan ( string contractNum )
        {
            return dal . getPlan ( contractNum );
        }

        /// <summary>
        /// 获取采购
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public decimal getPurchase ( string contractNum )
        {
            return dal . getPurchase ( contractNum );
        }

        /// <summary>
        /// 获取生产
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public decimal getProduction ( string contractNum )
        {
            return dal . getProduction ( contractNum );
        }

        /// <summary>
        /// 获取完工
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public decimal getComplete ( string contractNum )
        {
            return dal . getComplete ( contractNum );
        }

        /// <summary>
        /// 获取交付
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public decimal getDeliver ( string contractNum )
        {
            return dal . getDeliver ( contractNum );
        }

        /// <summary>
        /// 获取开票
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public decimal getBilling ( string contractNum )
        {
            return dal . getBilling ( contractNum );
        }

        /// <summary>
        /// 获取合同明细
        /// </summary>
        /// <returns></returns>
        public DataTable getTableViewContractOther ( string contractNum )
        {
            return dal . getTableViewContractOther ( contractNum );
        }

        /// <summary>
        /// 获取预收款明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewMoneyOther ( string contractNum )
        {
            return dal . getTableViewMoneyOther ( contractNum );
        }

        /// <summary>
        /// 获取计划明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewPlat ( string contractNum )
        {
            return dal . getTableViewPlat ( contractNum );
        }

        /// <summary>
        /// 获取采购明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewPurchase ( string contractNum )
        {
            return dal . getTableViewPurchase ( contractNum );
        }

        /// <summary>
        /// 获取生产明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewProduction ( string contractNum )
        {
            return dal . getTableViewProduction ( contractNum );
        }

        /// <summary>
        /// 获取完工明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewComplete ( string contractNum )
        {
            return dal . getTableViewComplete ( contractNum );
        }

        /// <summary>
        /// 获取交付明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewDeliver ( string contractNum )
        {
            return dal . getTableViewDeliver ( contractNum );
        }

        /// <summary>
        /// 获取开票明细
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getTableViewBilling ( string contractNum )
        {
            return dal . getTableViewBilling ( contractNum );
        }

    }
}


