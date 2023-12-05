/* 
Write a Program to check given number is palindrome or not.
Input: 121      Output: It's palindrome number.
*/

import java.util.*;

public class Palindrome_Number {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the number : ");
        int n = sc.nextInt();

        int x = n, result = 0;

        while (n != 0) {
            result = (result * 10) + n % 10;
            n /= 10;
        }

        if (x == result)
            System.out.println("It's palindrome number");
        else
            System.out.println("It's not palindrome number");

        sc.close();
    }
}