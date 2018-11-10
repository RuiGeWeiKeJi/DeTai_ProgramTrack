using System;
using System . Data;
using System . Reflection;
using Utility;
using ProcessControl . HelperClass;
using System . Drawing;
using DevExpress . XtraGrid . Views . Grid . ViewInfo;
using DevExpress . XtraEditors . Drawing;
using DevExpress . Utils;

namespace ProcessControl
{
    public partial class FormMain :FormBase
    {
        ProcessControlBLL.Bll.MainBll _bll=null;
        DataTable tableViewPro,tableViewContract,tableViewProcess,tableViewOther;
        string proNum=string.Empty,contractNum=string.Empty;

        public FormMain ( )
        {
            InitializeComponent ( );

            _bll = new ProcessControlBLL . Bll . MainBll ( );
            GridViewMoHuSelect . SetFilter ( gvPro );
            GridViewMoHuSelect . SetFilter ( gvCon );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaintHelper ( ) );

            tableViewProcess = new DataTable ( );
            tableViewProcess . Columns . Add ( "U0" ,typeof ( System . String ) );
            tableViewProcess . Columns . Add ( "U1" ,typeof ( System . Decimal ) );
            tableViewProcess . Columns . Add ( "U2" ,typeof ( System . Decimal ) );
            tableViewProcess . Columns . Add ( "U3" ,typeof ( System . Decimal ) );
            tableViewProcess . Columns . Add ( "U4" ,typeof ( System . Decimal ) );
            tableViewProcess . Columns . Add ( "U5" ,typeof ( System . Decimal ) );
            tableViewProcess . Columns . Add ( "U6" ,typeof ( System . Decimal ) );
            tableViewProcess . Columns . Add ( "U7" ,typeof ( System . Decimal ) );
            tableViewProcess . Columns . Add ( "U8" ,typeof ( System . String ) );
        }

        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            tableViewPro = _bll . getTableViewPro ( txtPro . Text );
            gcPro . DataSource = tableViewPro;

            getFocuseContract ( 0 );
        }

        private void gvPro_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            getFocuseContract ( gvPro . FocusedRowHandle );
        }

        void getFocuseContract ( int num )
        {
            proNum = ( string ) gvPro . GetRowCellValue ( num ,"DKA001" );
            if ( string . IsNullOrEmpty ( proNum ) )
                return;
            tableViewContract = _bll . getTableViewContract ( proNum );
            gcCon . DataSource = tableViewContract;

            getFocuseAll ( 0 );
        }

        private void gvCon_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            getFocuseAll ( gvCon . FocusedRowHandle );
        }

        void getFocuseAll ( int num )
        {
            gcOt . DataSource = null;
            contractNum = ( string ) gvCon . GetRowCellValue ( num ,"IDA001" );
            if ( string . IsNullOrEmpty ( contractNum ) )
                return;
            decimal f1 = 0M, f2 = 0M, f3 = 0M, f4 = 0M, f5 = 0M, f6 = 0M, f7 = 0M;
            f1 = _bll . getMoney ( contractNum );
            f2 = _bll . getPlan ( contractNum );
            f3 = _bll . getPurchase ( contractNum );
            f4 = _bll . getProduction ( contractNum );
            f5 = _bll . getComplete ( contractNum );
            f6 = _bll . getDeliver ( contractNum );
            f7 = _bll . getBilling ( contractNum );
            tableViewProcess . Rows . Clear ( );
            DataRow row = tableViewProcess . NewRow ( );
            row [ "U0" ] = contractNum;
            row [ "U1" ] = f1;
            row [ "U2" ] = f2;
            row [ "U3" ] = f3;
            row [ "U4" ] = f4;
            row [ "U5" ] = f5;
            row [ "U6" ] = f6;
            row [ "U7" ] = f7;
            row [ "U8" ] = string . Empty;
            tableViewProcess . Rows . Add ( row );
            gcProcess . DataSource = tableViewProcess;

            tableViewOther = _bll . getTableViewContractOther ( contractNum );
            gcOt . DataSource = tableViewOther;
            labInfo . Text = "采购合同明细";
            setStyle ( );
        }

        private void gvProcess_RowCellClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowCellClickEventArgs e )
        {
            gvOt . Columns . Clear ( );
            gcOt . DataSource = null;
            tableViewOther = new DataTable ( );
            labInfo . Text = string . Empty;
            if ( e . Column == U0 )
            {
                tableViewOther = _bll . getTableViewContractOther ( contractNum );
                labInfo . Text = "采购合同明细";
            }
            if ( e . Column == U1 )
            {
                tableViewOther = _bll . getTableViewMoneyOther ( contractNum );
                labInfo . Text = "预付款明细";
            }
            if ( e . Column == U2 )
            {
                tableViewOther = _bll . getTableViewPlat ( contractNum );
                labInfo . Text = "计划明细";
            }
            if ( e . Column == U3 )
            {
                tableViewOther = _bll . getTableViewPurchase ( contractNum );
                labInfo . Text = "采购明细";
            }
            if ( e . Column == U4 )
            {
                tableViewOther = _bll . getTableViewProduction ( contractNum );
                labInfo . Text = "生产明细";
            }
            if ( e . Column == U5 )
            {
                tableViewOther = _bll . getTableViewComplete ( contractNum );
                labInfo . Text = "完工明细";
            }
            if ( e . Column == U6 )
            {
                tableViewOther = _bll . getTableViewDeliver ( contractNum );
                labInfo . Text = "交付明细";
            }
            if ( e . Column == U7 )
            {
                tableViewOther = _bll . getTableViewBilling ( contractNum );
                labInfo . Text = "开票明细";
            }
            gcOt . DataSource = tableViewOther;
            setStyle ( );
        }

        void setStyle ( )
        {
            foreach ( DevExpress . XtraGrid . Columns . GridColumn co in gvOt . Columns )
            {
                co . OptionsFilter . FilterPopupMode = DevExpress . XtraGrid . Columns . FilterPopupMode . CheckedList;
                co . AppearanceCell . Font = new System . Drawing . Font ( "宋体" ,10.5F ,System . Drawing . FontStyle . Bold ,System . Drawing . GraphicsUnit . Point ,( ( byte ) ( 134 ) ) );
                co . AppearanceCell . Options . UseFont = true;
                co . AppearanceHeader . ForeColor = System . Drawing . Color . DarkOrange;
                co . AppearanceHeader . Options . UseForeColor = true;
                co . AppearanceHeader . Font = new System . Drawing . Font ( "宋体" ,10.5F ,System . Drawing . FontStyle . Bold ,System . Drawing . GraphicsUnit . Point ,( ( byte ) ( 134 ) ) );
                co . AppearanceHeader . Options . UseFont = true;
                co . AppearanceHeader . ForeColor = System . Drawing . Color . DarkOrange;
                co . AppearanceHeader . Options . UseForeColor = true;
            }
        }

        private void gvProcess_CustomDrawCell ( object sender ,DevExpress . XtraGrid . Views . Base . RowCellCustomDrawEventArgs e )
        {
            if ( e . Column == U1  )
            {
                e . Appearance . DrawBackground ( e . Cache ,e . Bounds );
                DrawProgessBar ( e );
                //e . Handled = true;
                DrawEditor ( e );
            }
            if ( e . Column == U2  )
            {
                e . Appearance . DrawBackground ( e . Cache ,e . Bounds );
                DrawProgessBar ( e );
                //e . Handled = true;
                DrawEditor ( e );
            }
            if ( e . Column == U3  )
            {
                e . Appearance . DrawBackground ( e . Cache ,e . Bounds );
                DrawProgessBar ( e );
                //e . Handled = true;
                DrawEditor ( e );
            }
            if ( e . Column == U4 )
            {
                e . Appearance . DrawBackground ( e . Cache ,e . Bounds );
                DrawProgessBar ( e );
                //e . Handled = true;
                DrawEditor ( e );
            }
            if (  e . Column == U5  )
            {
                e . Appearance . DrawBackground ( e . Cache ,e . Bounds );
                DrawProgessBar ( e );
                //e . Handled = true;
                DrawEditor ( e );
            }
            if ( e . Column == U6  )
            {
                e . Appearance . DrawBackground ( e . Cache ,e . Bounds );
                DrawProgessBar ( e );
                //e . Handled = true;
                DrawEditor ( e );
            }
            if (  e . Column == U7 )
            {
                e . Appearance . DrawBackground ( e . Cache ,e . Bounds );
                DrawProgessBar ( e );
                //e . Handled = true;
                DrawEditor ( e );
            }
        }

        private void DrawProgessBar ( DevExpress . XtraGrid . Views . Base . RowCellCustomDrawEventArgs e )
        {
            decimal percent = Convert . ToDecimal ( e . CellValue );
            int with = ( int ) ( 100 * Math . Abs ( percent ) * e . Bounds . Width / 100 );
            Rectangle rect = new Rectangle ( e . Bounds . X ,e . Bounds . Y ,with ,e . Bounds . Height );
            Brush b = Brushes . Green;
            if ( percent < 0 )
                b = Brushes . Red;
            else if ( percent < 1 )
                b = Brushes . Yellow;
            else
                b = Brushes . Green;
            e . Graphics . FillRectangle ( b ,rect );
        }

        private void DrawEditor ( DevExpress . XtraGrid . Views . Base . RowCellCustomDrawEventArgs e )
        {
            GridCellInfo cell = e . Cell as GridCellInfo;
            Point offset = cell . CellValueRect . Location;
            BaseEditPainter pb = cell . ViewInfo . Painter as BaseEditPainter;
            AppearanceObject savedStyle = cell . ViewInfo . PaintAppearance;
            if ( !offset . IsEmpty )
                cell . ViewInfo . Offset ( offset . X ,offset . Y );
            try
            {
                pb . Draw ( new ControlGraphicsInfoArgs ( cell . ViewInfo ,e . Cache ,cell . Bounds ) );
            }
            finally
            {
                if ( !offset . IsEmpty )
                    cell . ViewInfo . Offset ( -offset . X ,-offset . Y );
            }
        }

    }
}