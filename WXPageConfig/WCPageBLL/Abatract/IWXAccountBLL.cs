

using WXPageModel;

namespace WXPageBLL.Abatract
{
    /// <summary>
    /// 微信账号业务处理
    /// </summary>
    public interface IWXAccountBLL:IBLL<WXAccountInfo>
    {
        void DeleteWXAccount(string wxAccountId);
    }
}
