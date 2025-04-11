using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTopup
{
    public class OnlineTopupCommon
    {
        private string _pass = "1234";
        public string Pass
        {
            get { return _pass; }
            set
            {
                if (value.Length == 4 || value.Length == 6)
                {
                    _pass = value;
                }
            }
        }

        public string User { get; set; }

    }
}
