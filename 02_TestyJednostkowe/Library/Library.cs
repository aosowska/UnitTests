using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library_methods
{
    public class Library
    {
        /// <summary>
        /// Methods check if user is over 18
        /// </summary>
        /// <param name="yearOfBirth"></param>
        /// <returns></returns>
        public bool Over18Check(int yearOfBirth)
        {
            return (DateTime.Now.Year - yearOfBirth > 18) ? true : throw new System.ArgumentException("Person should be over 18.");
        }

        public List<string> Alphabetical(List<string> nameList)
        {
            nameList.Sort();
            return nameList;
        }

        /// <summary>
        /// Body Mass Index
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public double BMICalculator(double weight, double height)
        {
            if (height > 0 && weight > 0)
            {
                var heightParam = height * height;
                return weight / heightParam;
            }
            else if (height < 0 || weight < 0)
                throw new NotSupportedException("The parameters can't be less than zero!");
            else
                throw new ArgumentNullException("Height or weigh can't be equal zero");
        }

        public string BMIDescription(double BMI)
        {
            switch (BMI)
            {
                case var bmi when ((0 < BMI) && (BMI < 18.5)):
                    return "underweight";
                case var bmi when ((18.5 <= BMI) && (BMI < 25.0)):
                    return "healthy weight";
                case var bmi when ((25.0 <= BMI) && (BMI < 30.0)):
                    return "overweight";
                case var bmi when ((30.0 <= BMI) && (BMI < 35.0)):
                    return "obese I";
                case var bmi when ((35.0 <= BMI) && (BMI < 40.0)):
                    return "obese II";
                case var bmi when (40.0 <= BMI):
                    return "obese III";
                default:
                    throw new ArgumentOutOfRangeException("Unknow value as a parameter");
            }
        }
    }

    public class Person
    {
        string Name;
        int YearOfBirth;
        double Height;
        double Weight;

        public Person(string parName, int parYearOfBirth, double parHeight, double parWeight)
        {
            Name = parName;
            YearOfBirth = parYearOfBirth;
            Height = parHeight;
            Weight = parWeight;
        }
    }
}