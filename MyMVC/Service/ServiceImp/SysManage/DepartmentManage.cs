using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Service.ServiceImp
{
    /// <summary>
    /// 部门管理
    /// </summary>
    public class DepartmentManage : RepositoryBase<SYS_DEPARTMENT>, IDepartmentManage
    {
        /// <summary>
        /// 创建部门编号
        /// </summary>
        /// <param name="parentCode">上级部门ID</param>
        /// <returns></returns>
        public string CreateCode(string parentCode)
        {
            string _strCode = string.Empty;
            #region 验证上级部门Code是否为空。为空返回第一级部门Code
            if (string.IsNullOrEmpty(parentCode))
            {
                var query = this.LoadAll(p => p.PARENTCODE == null || p.PARENTID == "").OrderBy(p => p.CODE).ToList();
                if (!query.Any())
                {
                    return "001";
                }
                for (int i = 1; i <=query.Count; i++)
                {
                    string code = query[i-1].CODE;
                    if (string.IsNullOrEmpty(code))
                    {
                        return FormatCode(i);
                    }
                    if (i != int.Parse(code))
                    {
                        return FormatCode(i);
                    }
                }
                return FormatCode(query.Count + 1);
            }
            #endregion
            #region 上级部门不为空,返回当前上级部门下的部门Code
            /* *根据部门编号获取下级部门 查询条件为：
             * 1.下级部门编号长度=当前部门编号+3 
              * 2.下级部门上级部门ID=当前部门ID
              * */
            var parentDpt = this.Get(p => p.ID == parentCode);
            if (parentDpt != null)//上级部门存在
            {
                var queryable = this.LoadAll(p => p.CODE.Length == parentDpt.CODE.Length + 3 && p.PARENTID ==parentCode).OrderBy(p => p.CODE).ToList();
                if (queryable.Any())
                {
                    //需要验证是否存在编号缺失的情况 方法:遍历下级部门列表，
                    //用部门编号去掉上级部门编号，然后转化成数字和for循环的索引进行对比,遇到第一个不相等时，返回此编号，并跳出循环
                    for (int i = 1; i <= queryable.Count(); i++)
                    {
                        string _code = queryable[i - 1].CODE;
                        _code = _code.Substring(parentDpt.CODE.Length);
                        int _intCode = 0;
                        Int32.TryParse(_code, out _intCode);
                        //下级部门编号中不存在
                        if (i != _intCode)
                        {
                            //返回此编号,并退出循环
                            _strCode = parentDpt.CODE + FormatCode(i);
                            return _strCode;
                        }
                    }
                    _strCode = parentDpt.CODE + FormatCode(queryable.Count + 1);
                }
                else
                {
                    _strCode = parentDpt.CODE + FormatCode(1);
                    return _strCode;
                }
            }
            #endregion
            //throw new NotImplementedException();
            return _strCode;
        }

        /// <summary>
        /// 功能描述:根据传入的数字 返回补码后的3位部门编号
        /// 
        /// </summary>
        public string FormatCode(int dptCode)
        {
            try
            {
                string _strCode = string.Empty;
                //<=9 一位数
                if (dptCode <= 9 && dptCode >= 1)
                {
                    return "00" + dptCode;
                }
                //<=99 两位数
                else if (dptCode <= 99 && dptCode > 9)
                {
                    return "0" + dptCode;
                }
                //<==999 三位数
                else if (dptCode <= 999 && dptCode > 99)
                {
                    return _strCode;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// y验证当前删除的部门是否存在下级部门
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public bool DepartmentIsExists(string idList)
        {
            //var entity= this.LoadAll(p=>idList.Contains(p.PARENTID));
            return this.IsExist(p => idList.Contains(p.PARENTID));
        }
        /// <summary>
        /// 获取父级列表
        /// </summary>
        /// <returns></returns>
        public IList GetDepartmentByDetail()
        {
            var list = RecursiveDepartment(this.LoadAll(null).ToList())
                .Select(p => new
                {
                    id = p.ID,
                    code = p.CODE,
                    name = GetDepartmentName(p.NAME, p.BUSINESSLEVEL)
                }).ToList();

            return Common.JsonConverter.JsonClass(list);
        }
        /// <summary>
        /// 根据ID获取当前部门名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDepartmentName(string id)
        {
            var query = this.LoadAll(p => p.ID == id);
            if (query == null || !query.Any())
                return "";
            return query.First().NAME;
        }
        /// <summary>
        /// 显示错层方法
        /// </summary>
        public object GetDepartmentName(string name, decimal? level)
        {
            if (level > 1)
            {
                string nbsp = "&nbsp;&nbsp;";
                for (int i = 0; i < level; i++)
                {
                    nbsp += "&nbsp;&nbsp;";
                }
                name = nbsp + "|--" + name;
            }
            return name;
        }
        /// <summary>
        /// 根据部门ID递归部门列表，返回子部门+本部门的对象集合
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<SYS_DEPARTMENT> RecursiveDepartment(string parentId)
        {
            //原始数据
            var list = this.LoadAll(null);
            //新数据
            var result = new List<Domain.SYS_DEPARTMENT>();
            if (list.Any())
            {
                result.AddRange(list.Where(p => p.ID == parentId).ToList());
                if (!string.IsNullOrEmpty(parentId))
                    ChildDepartment(list.ToList(), result, parentId);
                else
                    ChildDepartment(list.ToList(), result, null);//oracle使用null sql使用空
            }
            return result;
        }
        /// <summary>
        /// 递归部门列表，返回排序后的对象集合
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<SYS_DEPARTMENT> RecursiveDepartment(List<SYS_DEPARTMENT> list)
        {
            var result = new List<Domain.SYS_DEPARTMENT>();
            if (list.Count > 0)
            {
                ChildDepartment(list, result, null);
            }
            return result;
        }

        private void ChildDepartment(List<SYS_DEPARTMENT> newlist, List<SYS_DEPARTMENT> list, string id)
        {
            var result = newlist.Where(p => p.PARENTID == id).OrderBy(p => p.CODE).ThenBy(p => p.SHOWORDER).ToList();
            if (result.Any())
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    list.Add(result[i]);
                    ChildDepartment(newlist, list, result[i].ID);
                }
            }
        }
    }
}
