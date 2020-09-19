using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class NewCategoryBase : EntityBase
    {
        [DataColum]
        public int NewCategoryId { get; set; }
        [DataColum]
        public int ParentId { get; set; }
        [DataColum]
        public string NewCateName { get; set; }

        private NewCategoryBase _parentNewId;

        public List<NewCategoryBase> Childern { get; set; }
        public NewCategoryBase ParentNewId
        {
            get
            {
                return _parentNewId ?? (_parentNewId = new NewCategoryBase()
                {
                    ParentNewId = _parentNewId
                });
            }
            set
            {
                _parentNewId = value;
            }
        }
        public int HLevel
        {
            get; set;
        }
        public string HlevelTitle
        {
            get
            {
                if (HLevel > 0)
                {
                    var l = "";
                    for (var i = 1; i <= HLevel; ++i)
                    {
                        l += "|--";
                    }
                    return string.Format("{0}{1}", l, NewCateName);

                }

                return NewCateName;
            }
        }
    }
}
