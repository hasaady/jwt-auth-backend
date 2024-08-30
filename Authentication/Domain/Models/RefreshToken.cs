using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Models
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
