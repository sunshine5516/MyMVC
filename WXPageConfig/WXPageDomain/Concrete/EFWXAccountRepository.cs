using System;
using System.Collections.Generic;
using System.Linq;
using WXPageDomain.Abatract;
using System.Linq.Expressions;
using WXPageModel;

namespace WXPageDomain.Concrete
{
    public class EFWXAccountRepository :  BaseRepository<WXAccountInfo>, IWXAccountRepository
    {
        public static List<WXAccountInfo> WXAccountList = new List<WXAccountInfo>()
        {
            new WXAccountInfo { Id="1",AccountName="testAccount001",AppID="wxfd537a1b809515aa",AppSecret="2ad4fa081250612384f04bbbd7bb6df0",State="正常",EncodingAESKey="rqwe235trgfgasd",WXAccount="wx1",WXType="公众号",InterfaceURL="http://121.40.173.136/WXConfig/Weixin",Token="weixinTest",InsertTime=DateTime.Now},
            new WXAccountInfo { Id="2",AccountName="testAccount002",AppID="12312312",AppSecret="22222222",State="冻结",EncodingAESKey="rqwe235trgfgasd",WXAccount="wx1",WXType="公众号",InterfaceURL="WWW.BAIDU.COM",Token="WX001",InsertTime=DateTime.Now},
            new WXAccountInfo { Id="3",AccountName="testAccount003",AppID="34567456",AppSecret="22222222",State="正常",EncodingAESKey="rqwe235trgfgasd",WXAccount="wx1",WXType="订阅号",InterfaceURL="WWW.BAIDU.COM",Token="WX001",InsertTime=DateTime.Now},
            new WXAccountInfo { Id="4",AccountName="testAccount004",AppID="222222222",AppSecret="22222222",State="正常",EncodingAESKey="rqwe235trgfgasd",WXAccount="wx1",WXType="公众号",InterfaceURL="WWW.BAIDU.COM",Token="WX001",InsertTime=DateTime.Now},
            new WXAccountInfo { Id="5",AccountName="testAccount005",AppID="890678966",AppSecret="22222222",State="冻结",EncodingAESKey="rqwe235trgfgasd",WXAccount="wx1",WXType="公众号",InterfaceURL="WWW.BAIDU.COM",Token="WX001",InsertTime=DateTime.Now},
            new WXAccountInfo { Id="6",AccountName="testAccount006",AppID="000000000",AppSecret="22222222",State="正常",EncodingAESKey="rqwe235trgfgasd",WXAccount="wx1",WXType="企业号",InterfaceURL="WWW.BAIDU.COM",Token="WX001",InsertTime=DateTime.Now},
            new WXAccountInfo { Id="7",AccountName="testAccount007",AppID="666666666",AppSecret="22222222",State="过期",EncodingAESKey="rqwe235trgfgasd",WXAccount="wx1",WXType="公众号",InterfaceURL="WWW.BAIDU.COM",Token="WX001",InsertTime=DateTime.Now},
            new WXAccountInfo { Id="8",AccountName="testAccount008",AppID="567354362",AppSecret="22222222",State="正常",EncodingAESKey="rqwe235trgfgasd",WXAccount="wx1",WXType="公众号",InterfaceURL="WWW.BAIDU.COM",Token="WX001",InsertTime=DateTime.Now},
            new WXAccountInfo { Id="9",AccountName="testAccount009",AppID="456345642",AppSecret="22222222",State="正常",EncodingAESKey="rqwe235trgfgasd",WXAccount="wx1",WXType="企业号",InterfaceURL="WWW.BAIDU.COM",Token="WX001",InsertTime=DateTime.Now},
            new WXAccountInfo { Id="10",AccountName="testAccount010",AppID="067845674",AppSecret="22222222",State="正常",EncodingAESKey="rqwe235trgfgasd",WXAccount="wx1",WXType="订阅号",InterfaceURL="WWW.BAIDU.COM",Token="WX001",InsertTime=DateTime.Now}
        };
        /// <summary>
        /// 删除指定账号
        /// </summary>
        /// <param name="wxAccountId"></param>
        /// <returns></returns>
        public void DeleteWXAccount(string wxAccountId)
        {
            //throw new NotImplementedException();
            var data = FindAllInfo.Where(p => p.Id == wxAccountId).FirstOrDefault();
            if (data != null)
            {
                //data = wxAccount;
                FindAllInfo.Remove(data);
            }
        }

        public IQueryable<WXAccountInfo> FindAll
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<WXAccountInfo> FindAllInfo
        {
            get
            {
                return WXAccountList;
                
            }
        }

        public void SaveWXAccount(WXAccountInfo wxAccount)
        {
            var data = FindAllInfo.Where(p => p.Id == wxAccount.Id).FirstOrDefault();
            if (data != null)
            {
                data = wxAccount;
            }
            else
            {
                FindAllInfo.Add(wxAccount);
            }
        }

        public void Save(WXAccountInfo entity)
        {
            var data = FindAllInfo.Where(p => p.Id == entity.Id).FirstOrDefault();
            if (data != null)
            {
                data = entity;
            }
            else
            {
                FindAllInfo.Add(entity);
            }
        }

        public void Save(IEnumerable<WXAccountInfo> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(WXAccountInfo entity)
        {
            FindAllInfo.Remove(entity);
        }

        public void Delete(IEnumerable<WXAccountInfo> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<WXAccountInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public WXAccountInfo GetByKey(object key)
        {
            throw new NotImplementedException();
        }
    }
}