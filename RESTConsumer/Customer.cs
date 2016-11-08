using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumer
{
    class Customer
    {
        
     
        
            private int _id;
            private string _firstName;
            private string _lastName;
            private int _year;

           
            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }

          
            public string FirstName
            {
                get { return _firstName; }
                set { _firstName = value; }
            }

         
            public string LastName
            {
                get { return _lastName; }
                set { _lastName = value; }
            }

            
            public int Year
            {
                get { return _year; }
                set { _year = value; }
            }

            public Customer(int id, string firstName, string lastName, int year)
            {
                _id = id;
                _firstName = firstName;
                _lastName = lastName;
                _year = year;
            }

            public Customer()
            {

            }

        public override string ToString()
        {
            return $"{nameof(ID)}: {ID}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Year)}: {Year}";
        }
    }
}
