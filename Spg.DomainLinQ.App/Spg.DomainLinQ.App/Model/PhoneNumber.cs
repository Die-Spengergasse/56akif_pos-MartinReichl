using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// Number
    /// (2P)
    /// </summary>
    public class PhoneNumber
    {
        // TODO: Implementation
        public string Number { get; set; } = string.Empty;

        public PhoneNumber(string number)
        {
            Number = number;
        }
    }
}
