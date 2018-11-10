using System . Configuration;

namespace ProcessControl . HelperClass
{
    /// <summary>
    /// App.config文件操作类
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// 获取系统皮肤
        /// </summary>
        /// <returns></returns>
        public static string getFeedConfig ( )
        {
            return getConfig ( "Feed" );
        }

        /// <summary>
        /// 读取App.config配置文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getConfig ( string key )
        {
            Configuration config = ConfigurationManager . OpenExeConfiguration ( System . Windows . Forms . Application . ExecutablePath );
            return config . AppSettings . Settings [ key ] . Value;
        }

    }
}
