/*
Write a Program to convert numbers into equivalent characters in a given string.
Input: a2b3cd           Output: abbcccd
Input: 4az2b5c3af3g     Output: aaaazbbcccccaaafggg 
*/

import java.util.Scanner;

public class Number_into_Equivalent_Characters {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the string : ");
        String str = sc.nextLine();

        int count = 1;
        for (int i = 0; i < str.length(); i++) {
            count = 1;
            if (Character.isDigit(str.charAt(i))) {
                count = Character.getNumericValue(str.charAt(i));
                i++;
            }
            while (count > 0) {
                System.out.print(str.charAt(i));
                count--;
            }
        }
        sc.close();
    }
}