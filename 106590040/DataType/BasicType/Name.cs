using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OrderApp
{
    public class Name
    {
        private string _firstName;
        private string _lastName;

        // name的constructor
        public Name()
        {
            _firstName = "";
            _lastName = "";
        }

        // name的constructor
        public Name(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        // surName的setter & getter
        public string FirstName
        {
            set
            {
                _firstName = value;
            }
            get
            {
                return _firstName;
            }
        }

        // forename的setter & getter
        public string LastName
        {
            set
            {
                _lastName = value;
            }
            get
            {
                return _lastName;
            }
        }
    }
}
