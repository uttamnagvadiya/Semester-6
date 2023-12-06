/* 
Write a program to calculate the angle between the hour hand and the minute hand of a clock if
the time is given in a string format.
Input: h = 12:00        Output: 165 degree 
       m = 30.00
*/

import java.util.*;

public class Angle_Between_Hour_and_Minute {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the hours : ");
        int hour = sc.nextInt();
        System.out.print("Enter the minutes : ");
        int minute = sc.nextInt();

        if (hour < 0 || minute < 0 || hour > 12 || minute > 60) {
            System.out.println("Please, Enter the Hour between 0 to 12 & Minute between 0 to 60.");
            System.exit(0);
        }

        double deg = Math.abs((hour * 60 + minute) * 0.5 - (minute * 6));

        System.out.println(Math.min(360 - deg, deg));

        sc.close();
    }
}