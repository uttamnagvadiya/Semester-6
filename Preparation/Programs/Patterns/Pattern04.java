/*
Write a program to print following pattern

            *
         *  *
      *  *  *
   *  *  *  *
*  *  *  *  *

*/

import java.util.Scanner;

public class Pattern04 {
   public static void main(String[] args) {
      Scanner sc = new Scanner(System.in);

      System.out.print("Enter the number : ");
      int n = sc.nextInt();

      for (int i = 1; i <= n; i++) {
         for (int j = i; j < n; j++) {
            System.out.print("  ");
         }
         for (int k = 1; k <= i; k++) {
            System.out.print("* ");
         }
         System.out.println();
      }
      sc.close();
   }
}
