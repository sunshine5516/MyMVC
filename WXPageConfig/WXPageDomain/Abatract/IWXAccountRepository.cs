

using WXPageModel;

namespace WXPageDomain.Abatract
{
    /// <summary>
    /// 微信账号
    /// </summary>
    public interface IWXAccountRepository : IRepository<WXAccountInfo>
    {
        void SaveWXAccount(WXAccountInfo wxAccount);
        void DeleteWXAccount(string wxAccountId);
    }
}
