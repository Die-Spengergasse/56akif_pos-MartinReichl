using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExProperties
{
    public class Lehrer
    {
        private decimal? _bruttogehalt = null;

        public string Vorname { get; set; } = string.Empty;

        public string Zuname { get; set; }

        public decimal? Bruttogehalt 
        { 
            get
            {
                return _bruttogehalt;
            }

            set
            {
                if(_bruttogehalt == null)
                {
                    _bruttogehalt = value;
                }
            } 
        }

        public string? Kuerzel 
        {
            get
            {
                return Zuname?.Substring(0, 3).ToUpper() ?? "";
            }
        }

        public decimal? Nettogehalt
        {
            get
            {
                if (Bruttogehalt != null)
                {
                    return Bruttogehalt * 0.8M;
                }

                return 0;
            }
        }
    }
}
