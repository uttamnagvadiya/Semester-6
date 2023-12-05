/*
Write a Program to convert number from Decimal to Binary. 
Input: 10       Output: 1010
*/

import java.util.*;

public class Decimal_To_Binary {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        ArrayList<Integer> arr = new ArrayList<Integer>();

        System.out.print("Enter the number : ");
        int n = sc.nextInt();

        while (n > 0) {
            arr.add(n % 2);
            n /= 2;
        }

        for (int i = arr.size() - 1; i >= 0; i--) {
            System.out.print(arr.get(i));
        }

        sc.close();
    }
}