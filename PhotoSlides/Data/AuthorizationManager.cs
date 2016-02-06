using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSlides.Data
{
    public class AuthorizationManager
    {
        public static AuthorizationManager Instance = new AuthorizationManager();
        private string _userName;
        public void Initialize(string userName)
        {
            _userName = userName;
        }

        public string Key
        {
            get { return _userName; }
        }
    }
}
