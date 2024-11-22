using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Extentions
{
    public class EmailValidation
    {
        public static bool Validate(string email)
        {
            try
            {
                var enderecoEmail = new MailAddress(email);
                return enderecoEmail.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
