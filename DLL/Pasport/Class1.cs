using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompany
{
    public class Pasport
    {
        private string seria;
        private string number;
        private DateTime dateOfIssue;
        private string issued;

        public string Seria
        {
            set
            {
                if (value.All(Char.IsDigit) && !string.IsNullOrEmpty(value))
                {
                    this.seria = value;
                }
                else
                {
                    throw new Exception("Серия паспорта содержит запрещенные символы");
                }
            }
            get
            {
                return this.seria;
            }
        }

        public string Number
        {
            set
            {
                if (value.All(Char.IsDigit) && !string.IsNullOrEmpty(value))
                {
                    this.number = value;
                }
                else
                {
                    throw new Exception("Номер паспорта содержит запрещенные символы");
                }
            }
            get
            {
                return this.number;
            }
        }

        public DateTime DateOfIssue
        {
            set
            {
                if (value.Year >= DateTime.Now.Year - 100 && value.Year <= DateTime.Now.Year) // проверка введенного года 
                {
                    this.dateOfIssue = value;
                }
                else
                {
                    throw new Exception("Неверная дата выдачи паспорта");
                }
            }
            get
            {
                return this.dateOfIssue;
            }
        }
        public string Issued
        {
            set
            {
                this.issued = value;
            }
            get
            {
                return this.issued;
            }
        }


        public Pasport(string seriav, string num, DateTime datev, string issuedv)
        {
            Seria = seriav;
            Number = num;
            DateOfIssue = datev;
            Issued = issuedv;
        }
    }
}
