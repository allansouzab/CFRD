using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginModel
    {
        private IView _viewmanager;

        public LoginModel(IView viewmanager)
        {
            _viewmanager = viewmanager;
        }
    }
}
