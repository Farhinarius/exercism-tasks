using System;

public static class Leap
{
    public static bool IsLeapYearMy(int year) => 
    year % 4 == 0 ? year % 100 == 0 ? year % 400 == 0 ? true : false : true : false;

    public static bool IsLeapYear(int year) => year % 100 == 0 ? year % 400 == 0 : year % 4 == 0;
}
