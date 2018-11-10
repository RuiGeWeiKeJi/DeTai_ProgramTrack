using ProcessControl . HelperClass;
using DevExpress . Skins;

namespace ProcessControl
{
    public partial class FormBase :DevExpress . XtraEditors . XtraForm
    {
        protected static DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel=new DevExpress.LookAndFeel.DefaultLookAndFeel();
        public FormBase ( )
        {
            InitializeComponent ( );

            defaultLookAndFeel . LookAndFeel . SkinName = ConfigHelper . getFeedConfig ( );
            Skin GridSkin = GridSkins . GetSkin ( defaultLookAndFeel . LookAndFeel );
        }

    }
}