//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewsRealease.DAL.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class NewsType
    {
        public NewsType()
        {
            this.News = new HashSet<News>();
        }
    
        public int type_id { get; set; }
        public string type_name { get; set; }
        public Nullable<int> type_flag { get; set; }
    
        public virtual ICollection<News> News { get; set; }
    }
}
