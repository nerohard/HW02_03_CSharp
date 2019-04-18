using System;
using HW02_03.Resources;
using HW02_03.Tools;

namespace HW02_03.Models
{
    [Serializable]
    public class Person
    {
        public readonly string FirstName, SecondName, Email;
        public readonly DateTime BirthDateTime;

        public readonly bool IsAdult, IsBirthday;
        public readonly string ChineseSign , SunSign;

        public Person(){}

        public Person(string firstName , string secondName , string email , DateTime bornDateTime)
        {
            FirstName = firstName;
            SecondName = secondName;
            Email = email;
            BirthDateTime = bornDateTime;

            IsAdult = CalculateAge(bornDateTime) > 18;
            ChineseSign = CalculateChineseSign(bornDateTime);
            SunSign = CalculateSunSign(bornDateTime);
            IsBirthday = CalculateBirthday(bornDateTime);
        }

        public Person(string firstName, string secondName, string email)
        {
            FirstName = firstName;
            SecondName = secondName;
            Email = email;

            IsAdult = false;
            ChineseSign = String.Empty;
            SunSign = String.Empty;
            IsBirthday = false;
        }

        public Person(string firstName, string secondName, DateTime bornDateTime)
        {
            FirstName = firstName;
            SecondName = secondName;
            BirthDateTime = bornDateTime;

            IsAdult = CalculateAge(BirthDateTime) > 18;
            ChineseSign = CalculateChineseSign(bornDateTime);
            SunSign = CalculateSunSign(bornDateTime);
            IsBirthday = CalculateBirthday(bornDateTime);
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;
            return age;
        }

        private string CalculateChineseSign(DateTime dateOfBirth)
        {
            return ((ChineseSigns)(dateOfBirth.Date.Year % 12)).GetDescription();
        }
        
        private string CalculateSunSign(DateTime dateOfBirth)
        {
            switch (dateOfBirth.Date.Month)
            {
                case 1:
                    return (dateOfBirth.Date.Day <= 20) ? SunSigns.Capricorn.GetDescription() : SunSigns.Aquarius.GetDescription();
                case 2:
                    return (dateOfBirth.Date.Day <= 19) ? SunSigns.Aquarius.GetDescription() : SunSigns.Pisces.GetDescription();
                case 3:
                    return (dateOfBirth.Date.Day <= 20) ? SunSigns.Pisces.GetDescription() : SunSigns.Aries.GetDescription();
                case 4:
                    return (dateOfBirth.Date.Day <= 20) ? SunSigns.Aries.GetDescription() : SunSigns.Taurus.GetDescription();
                case 5:
                    return (dateOfBirth.Date.Day <= 21) ? SunSigns.Taurus.GetDescription() : SunSigns.Gemini.GetDescription();
                case 6:
                    return (dateOfBirth.Date.Day <= 21) ? SunSigns.Gemini.GetDescription() : SunSigns.Cancer.GetDescription();
                case 7:
                    return (dateOfBirth.Date.Day <= 22) ? SunSigns.Cancer.GetDescription() : SunSigns.Leo.GetDescription();
                case 8:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Leo.GetDescription() : SunSigns.Virgo.GetDescription();
                case 9:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Virgo.GetDescription() : SunSigns.Libra.GetDescription();
                case 10:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Libra.GetDescription() : SunSigns.Scorpio.GetDescription();
                case 11:
                    return (dateOfBirth.Date.Day <= 22) ? SunSigns.Scorpio.GetDescription() : SunSigns.Sagittarius.GetDescription();
                case 12:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Sagittarius.GetDescription() : SunSigns.Capricorn.GetDescription();
                default:
                    return String.Empty;
            }

        }

        private bool CalculateBirthday(DateTime dateOfBirth)
        {
            return DateTime.Now.Day == dateOfBirth.Day && DateTime.Now.Month == dateOfBirth.Month;
        }
    }
}
