using System;
using System.Collections.Generic;
using System.Linq;
using WXPageDomain.Models;
using WXPageDomain.Abatract;
using System.Web;
using System.Linq.Expressions;

namespace WXPageDomain.Concrete
{
    public class EFWXReplayContentsRepository : BaseRepository<ReplayContents>, IWXReplayContentsRepository
    {
        public static List<ReplayContents> WXReplayContentsList = new List<ReplayContents>()
        {
            new ReplayContents { Id="2",WXAccountId="1",InsertTime=DateTime.Now,ReplayContent="你好，凡人",ReplyType="文字",RequestType="关键字回复",State="Normal",ImageUrl="",ReplyId="",KeyName="你好",Note="",Title=""},
            new ReplayContents { Id="1",WXAccountId="1",InsertTime=DateTime.Now,ReplayContent="Hello，java world",ReplyType="文字",RequestType="关键字回复",State="Normal",ImageUrl="",ReplyId="",KeyName="hello",Note="",Title=""},
            new ReplayContents { Id="2",WXAccountId="1",InsertTime=DateTime.Now,ReplayContent="你好，凡人",ReplyType="文字",RequestType="首次关注",State="Normal",ImageUrl="",ReplyId="",KeyName="你好",Note="",Title=""},
            new ReplayContents { Id="3",WXAccountId="3",InsertTime=DateTime.Now,ReplayContent="",ReplyType="图片",RequestType="首次关注",State="Normal",ImageUrl="/upload/c594ac71-f42e-4dd3-b0fe-b55729d53821psb.jpg",ReplyId="",KeyName="",Note="",Title=""}
        };
        
        public List<ReplayContents> ReplayContent
        {
            get
            {
                return WXReplayContentsList;
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="wxReplayContent"></param>
        public void SaveReplayContents(ReplayContents wxReplayContent)
        {
            WXReplayContentsList.Add(wxReplayContent);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="wxReplayContent"></param>
        public void AddReplayContents(ReplayContents wxReplayContent)
        {

            WXReplayContentsList.Add(wxReplayContent);
        }
        /// <summary>
        /// 根据微信ID获取默认回复信息
        /// </summary>
        /// <param name="wxAccontID"></param>
        /// <returns></returns>
        public ReplayContents GetReplayContent(string wxAccontID)
        {
            var content = WXReplayContentsList.Where(p => p.WXAccountId == wxAccontID).FirstOrDefault();
            return content;
        }
        public IQueryable<ReplayContents> FindAll
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<ReplayContents> FindAllInfo
        {
            get
            {
                return WXReplayContentsList;
            }
        }


        public void DeleteReplayContents(string wxReplayContentId)
        {
            throw new NotImplementedException();
        }


        public void Save(ReplayContents wxReplayContent)
        {
            //string wxAccount;
            var data = WXReplayContentsList.Where(p => p.WXAccountId == wxReplayContent.WXAccountId).FirstOrDefault();
            ///是否存在，若存在执行更新操作，否则添加
            if (data != null)
            {
                data = wxReplayContent;
            }
            else///添加
            {
                ///根据id获取账号信息
                var wxAccountInfo = EFWXAccountRepository.WXAccountList.Where(p => p.Id == wxReplayContent.Id).FirstOrDefault();
                if (wxAccountInfo != null)
                {
                    wxReplayContent.WXAccountId = wxAccountInfo.Id;
                }

                wxReplayContent.Id = Guid.NewGuid().ToString();
                wxReplayContent.InsertTime = DateTime.Now;
                WXReplayContentsList.Add(wxReplayContent);
            }
        }

        public void Save(IEnumerable<ReplayContents> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(ReplayContents entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<ReplayContents> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<ReplayContents, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ReplayContents GetByKey(object key)
        {
            throw new NotImplementedException();
        }
    }
}
