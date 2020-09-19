using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class NewCategory : NewCategoryBase
    {
        public NewCategory() : base() { }

        public NewCategory(int id) : this()
        {
            this.NewCategoryId = id;
        }
        public NewCategory(string name) : this()
        {
            this.NewCateName = name;
        }
        [DataColum]
        public string NewCateShortName { get; set; }
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
        public List<News> ListNews { set; get; }
    }
}
