//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class SYS_BUSSINESSCUSTOMER
    {
        public int ID { get; set; }
        public string Fk_DepartId { get; set; }
        public string FK_RELATIONID { get; set; }
        public string CompanyName { get; set; }
        public int CompanyProvince { get; set; }
        public int CompanyCity { get; set; }
        public int CompanyArea { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTel { get; set; }
        public string CompanyWebSite { get; set; }
        public string ChargePersionName { get; set; }
        public int ChargePersionSex { get; set; }
        public string ChargePersionQQ { get; set; }
        public string ChargePersionEmail { get; set; }
        public string ChargePersionPhone { get; set; }
        public bool IsValidate { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public int CustomerStyle { get; set; }
    }
}
