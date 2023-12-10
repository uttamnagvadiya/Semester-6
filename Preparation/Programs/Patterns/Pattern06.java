/*
Write a program to print following pattern

*  *  *  *  *  *  *  *  *
   *  *  *  *  *  *  *
      *  *  *  *  *
         *  *  *
            *
*/

import java.util.Scanner;

public class Pattern06 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the number : ");
        int n = sc.nextInt();

        for (int i = n; i > 0; i--) {
            for (int j = n - i; j > 0; j--) {
                System.out.print("5 ");
            }
            for (int k = 1; k <= i * 2 - 1; k++) {
                System.out.print("* ");
            }
            System.out.println();
        }
        sc.close();
    }
}
