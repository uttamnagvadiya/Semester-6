/*
Write a Program to check given number is prime or not.
Input: 13       Output: It's prime number.
*/

import java.util.*;

public class Prime_Number {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the number : ");
        int n = sc.nextInt();
        boolean flag = true;

        for (int i = 2; i < n / 2; i++) {
            if (n % i == 0) {
                flag = false;
                break;
            }
        }

        if (flag)
            System.out.println("It's prime number");
        else
            System.out.println("It's not prime number");
        sc.close();
    }
}