/* Write a Program to Print all natural numbers upto N without using semi-colon. */

import java.util.Scanner;

public class Natural_Numbers_Without_Semicolon {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the number : ");
        int n = sc.nextInt();

        for (int i = 1; i <= n; System.out.println(i++));
        sc.close();
    }
}
