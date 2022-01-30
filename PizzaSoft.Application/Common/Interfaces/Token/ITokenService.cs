using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Domain.Token;


namespace PizzaSoft.Application.Common.Interfaces.Token
{
    public interface ITokenService
    {
        Task<AuthenticationResult> CreateTokenAsync(TokenData tokenData);
        TokenData GetTokenData();
    }
}
