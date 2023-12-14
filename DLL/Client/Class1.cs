using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TravelCompany;

namespace TravelCompany
{
    public class Client : Person
    {
        private Pasport pasport;
        private Image image;
        public Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }
        public Client(string namev, string surnamev, string patron, DateTime date, Pasport pasportv, Image imageP)
        {
            Name = namev;
            Surname = surnamev;
            Patronymic = patron;
            DateOfBirth = date;
            pasport = pasportv;
            Image = imageP;
        }

        public Client(string namev, string surnamev, string patron, DateTime date, Pasport pasportv)
        {
            Name = namev;
            Surname = surnamev;
            Patronymic = patron;
            DateOfBirth = date;
            pasport = pasportv;
        }

        public Client()
        {

        }


    }
}
