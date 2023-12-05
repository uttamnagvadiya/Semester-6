/*
Accept a number between 0 and 999 from the user and display the value in words. For example,
entering 25 should display “Twenty Five”. Appropriate error message should be displayed if the
value entered by the user is out of permissible range.

Input: 123      Output: One Hundred Twenty Three
 */


import java.util.Scanner;

public class Digit_To_Word{
    public static void main(String[] args) {
        String [] oneToTwenty = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                               "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                               "Eighteen", "Nineteen", "Twenty"};
        String [] tens = {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty"};

        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the number : ");
        int n = sc.nextInt();

        if (n < 0 || n > 999){
            System.out.println("Please, Enter the number between 0 to 999.");
            System.exit(0);
        }
        if (n > 99){
            int temp = n / 100;
            System.out.print(oneToTwenty[temp] + " Hundred ");
            n %= 100;
        }

        if (n < 21){
            System.out.println(oneToTwenty[n]);
        }
        else{
            System.out.println(tens[(n / 10)-2] + " " + oneToTwenty[n % 10]);
        }
        sc.close();
    }
}