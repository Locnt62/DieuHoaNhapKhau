using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class Slide : EntityBase
    {
        [DataColum]
        public int SlideBannerId { get; set; }
        [DataColum]
        public string SlideBannerImage { get; set; }
        [DataColum]
        public string SlideBannerDes { get; set; }
        [DataColum]
        public string Note { get; set; }
        [DataColum]
        public bool IsActive { get; set; }
        [DataColum]
        public DateTime CreateDate { get; set; }
        [DataColum]
        public DateTime UpdateDate { get; set; }
        [DataColum]
        public string CreateBy { get; set; }
        [DataColum]
        public string Language { get; set; }
    }
}
