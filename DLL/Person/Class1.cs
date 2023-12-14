using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompany
{
    public class Person
    {
        private string name;
        private string surname;
        private string patronymic;
        private DateTime dateOfBirth;

        public string Name
        {
            set
            {
                if (value.All(Char.IsLetter) && !string.IsNullOrEmpty(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new Exception("Имя содержит запрещенные символы");
                }
            }
            get
            {
                return this.name;
            }
        }

        public string Surname
        {
            set
            {
                if (value.All(Char.IsLetter) && !string.IsNullOrEmpty(value))
                {
                    this.surname = value;
                }
                else
                {
                    throw new Exception("Фамилия содержит запрещенные символы");
                }
            }
            get
            {
                return this.surname;
            }
        }

        public string Patronymic
        {

            set
            {
                if (value.All(Char.IsLetter) && !string.IsNullOrEmpty(value))
                {
                    this.patronymic = value;
                }
                else
                {
                    throw new Exception("Отчество содержит запрещенные символы");
                }
            }
            get
            {
                return this.patronymic;
            }
        }

        public DateTime DateOfBirth
        {
            set
            {
                if (value.Year >= DateTime.Now.Year - 100 && value.Year <= DateTime.Now.Year - 18) // проверка введенного года рождения
                {
                    if (value.Year == DateTime.Now.Year - 18)
                    {
                        if (value.Month <= DateTime.Now.Month)
                        {
                            if (value.Month == DateTime.Now.Month)
                            {
                                if (value.Day < DateTime.Now.Day)
                                {

                                }
                                else
                                {
                                    throw new Exception("Не соблюдается возрастное ограничение");
                                }
                            }
                            else
                            {
                                this.dateOfBirth = value;
                            }
                        }
                        else
                        {
                            throw new Exception("Не соблюдается возрастное ограничение");
                        }
                    }
                    else
                    {
                        this.dateOfBirth = value;
                    }
                }
                else
                {
                    throw new Exception("Не соблюдается возрастное ограничение");
                }
            }
            get
            {
                return this.dateOfBirth;
            }
        }
    }
}
