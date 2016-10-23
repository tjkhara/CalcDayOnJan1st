using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDayOnJan1st
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcDayOnJan1st();
        }

        static void CalcDayOnJan1st()
        {
            int year = 0;
            
            Console.WriteLine("Please enter a year in the DDMMYYYY format to see what the day is on Jan 1st of that year.");
            year = Convert.ToInt32(Console.ReadLine());

            int LastTwoDigits = year % 100;
            int LastFourDigits = year % 10000;
            int LastTwoDivByFour = LastTwoDigits/4;
            int DayOfTheMonth = year / 1000000;
            int LastTwoDivByFourPlusDayOfTheMonth = LastTwoDivByFour + DayOfTheMonth;

            int monthNum = (year / 10000) % 100;
            int value = 0;

            switch(monthNum)
            {
                case 1:
                    value = 1;
                    break;
                case 2:
                    value = 4;
                    break;
                case 3:
                    value = 4;
                    break;
                case 4:
                    value = 0;
                    break;
                case 5:
                    value = 2;
                    break;
                case 6:
                    value = 5;
                    break;
                case 7:
                    value = 0;
                    break;
                case 8:
                    value = 3;
                    break;
                case 9:
                    value = 6;
                    break;
                case 10:
                    value = 1;
                    break;
                case 11:
                    value = 4;
                    break;
                case 12:
                    value = 6;
                    break;
                default:
                    Console.WriteLine("Invaild month");
                    break;

            }

            bool IsLeapYear = false;
            
            if (LastTwoDigits % 4 == 0)
            {
                if(LastFourDigits % 100 != 0)
                {
                    IsLeapYear = true;
                }
                if (LastFourDigits % 100 == 0 && LastFourDigits % 400 == 0)
                {
                    IsLeapYear = false;
                }
            }

            int PreviousPlusMonthsKey = LastTwoDivByFourPlusDayOfTheMonth + ((IsLeapYear && (monthNum == 1 || monthNum == 2)) ? value-1:value);

            int centuryCode = 0;

            int century = 0;

            century = (LastFourDigits / 100) % 100;
            
            

            if (century > 20 || century < 17)
            {
                if(century > 20)
                {
                    while(century > 20)
                    {
                        century = century - 4;
                    }
                }

                if(century < 17)
                {
                    while(century < 17)
                    {
                        century = century + 4;
                    }
                }
            }

            if (century == 17 || century == 18 || century == 19 || century == 20)

            {
                if (century == 17)
                {
                    centuryCode = 4;
                }
                if (century == 18)
                {
                    centuryCode = 2;
                }
                if (century == 19)
                {
                    centuryCode = 0;
                }
                if (century == 20)
                {
                    centuryCode = 6;
                }
            }

            int PreviousPlusCenturCode = PreviousPlusMonthsKey + centuryCode;

            int PreviousPlusLastTwoDigits = PreviousPlusCenturCode + LastTwoDigits;

            int PreviousDivideBySevenAndTakeRemainder = PreviousPlusLastTwoDigits % 7;

            string DayOfTheWeek = "";

            switch(PreviousDivideBySevenAndTakeRemainder)
            {
                case 1:
                    DayOfTheWeek = "Sunday";
                    break;
                case 2:
                    DayOfTheWeek = "Monday";
                    break;
                case 3:
                    DayOfTheWeek = "Tuesday";
                    break;
                case 4:
                    DayOfTheWeek = "Wednesday";
                    break;
                case 5:
                    DayOfTheWeek = "Thursday";
                    break;
                case 6:
                    DayOfTheWeek = "Friday";
                    break;
                case 0:
                    DayOfTheWeek = "Saturday";
                    break;
                default:
                    Console.WriteLine("Invalid remainder.");
                    break;
            }

            Console.WriteLine("The day of the week on the date {0} is {1}", year, DayOfTheWeek);


            //The below line was for debugging the program and seeing the values in the stages of the calculation.
            //Console.WriteLine("The year is {0},\n the last two digits are {1},\n last two divided by 4 is {2},\n day of the month is {3},\n last two div by 4 plus day of the month is {4},\n the century is {5},\n the century code is {6},\n", year, LastTwoDigits, LastTwoDivByFour,DayOfTheMonth,LastTwoDivByFourPlusDayOfTheMonth,century,centuryCode);



        }
    }
}
