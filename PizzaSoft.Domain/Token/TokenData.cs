using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSoft.Domain.Token
{
    public class TokenData
    {
        public Guid UserId { get; set; }
        public long Exp { get; set; }
        public string Jti { get; set; }
    }
}
