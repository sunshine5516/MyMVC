using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WXPageBLL.Abatract;
using WXPageDomain.Abatract;
using WXPageDomain.Concrete;
using WXPageDomain.Models;

namespace WXPageBLL.Concrete
{
    public class WXReplayContentsBLL : IWXReplayContentsBLL
    {
        private IWXReplayContentsRepository _repository;
        public WXReplayContentsBLL() : this(new EFWXReplayContentsRepository()) 
        {
        }
        public WXReplayContentsBLL(IWXReplayContentsRepository repository)
        {
            _repository = repository;
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
                return _repository.FindAllInfo;
            }
        }

        public List<ReplayContents> ReplayContent
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(Expression<Func<ReplayContents, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<ReplayContents> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(ReplayContents entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteReplayContents(string wxReplayContentId)
        {
            throw new NotImplementedException();
        }

        public ReplayContents GetByKey(object key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据微信ID获取默认回复信息
        /// </summary>
        /// <param name="wxAccontID"></param>
        /// <returns></returns>
        public ReplayContents GetReplayContent(string wxAccontID)
        {
            return _repository.GetReplayContent(wxAccontID);
        }

        public void Save(IEnumerable<ReplayContents> entities)
        {
            throw new NotImplementedException();
        }

        public void Save(ReplayContents entity)
        {
            throw new NotImplementedException();
        }

        public void SaveReplayContents(ReplayContents wxReplayContent)
        {
            //string wxAccount;
            var data = FindAllInfo.Where(p => p.WXAccountId == wxReplayContent.WXAccountId).FirstOrDefault();
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
                //WXReplayContentsList.Add(wxReplayContent);
                _repository.SaveReplayContents(wxReplayContent);
            }
        }
    }
}
