using System;
using System.Text;
using System.Security.Cryptography;

namespace TravelCompany
{
    public class User
    {
        private string login;
        private string password;

        public string Login
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if(value.Length > 4)
                    {
                        this.login = value;
                    }
                    else
                    {
                        throw new Exception("Длина логина должна быть больше 4 символов");
                    }
                }
                else
                {
                    throw new Exception("Логин не может быть пустым");
                }
            }

            get
            {
                return this.login;
            }
        }
        public string Password
        {
            set
            {
                bool capsS = false;
                bool smallS = false;
                bool numS = false;
                if (value.Length >= 8)
                {
                    for (int i = 0; i < value.Length; ++i)
                    {
                        if (capsS && smallS & numS)
                        {
                            break;
                        }
                        if (Char.IsNumber(value[i]))
                        {
                            numS = true;
                        }
                        else
                        {
                            if (Char.IsLower(value[i]))
                            {
                                smallS = true;
                            }
                            else
                            {
                                if (Char.IsUpper(value[i]))
                                {
                                    capsS = true;
                                }
                            }
                        }
                    }
                }
                if (capsS && smallS & numS)
                {
                    this.password = HashPassword(value);
                }
                else
                {
                    throw new Exception("Пароль должен содержать: -не менее 8 символов; -символы нижнего и верхнего регистра; -цифры.");
                }
            }
            get
            {
                return this.password;
            }
        }

        public User(string loginN, string passwordN)
        {
            this.login = loginN;
            this.password = HashPassword(passwordN);
        }
        public User()
        {

        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                return hash;
            }
        }
    }
}
