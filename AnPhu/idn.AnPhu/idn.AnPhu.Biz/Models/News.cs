using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class News : EntityBase
    {
        [DataColum]
        public int NewsId { get; set; }
        [DataColum]
        public string NewTitle { get; set; }
        [DataColum]
        public string NewShortName { get; set; }
        [DataColum]
        public string NewBody { get; set; }
        [DataColum]
        public string NewImage { get; set; }
        [DataColum]
        public string NewKeyword { get; set; }
        [DataColum]
        public int CountView { get; set; }
        [DataColum]
        public bool IsActive { get; set; }
        [DataColum]
        public DateTime CreateDate { get; set; }
        [DataColum]
        public DateTime UpdateDate { get; set; }
        [DataColum]
        public string CreateBy { get; set; }
        [DataColum]
        public string NewSummary { get; set; }

        [DataColum]
        public int IsHot { get; set; }

        [DataColum]
        public int NewCategoryId { get; set; }
        [DataColum]
        public string NewCateName { get; set; }
        [DataColum]
        public string Language { get; set; }
        [DataColum]
        public int OrderNo { get; set; }
    }
}
