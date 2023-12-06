/*
Write a program to print following pattern
1  2  3  4  5
10 9  8  7  6
11 12 13 14 15
20 19 18 17 16
21 22 23 24 25
 
(row(i)%2 == 0) ? -- : ++
*/

import java.util.Scanner;

public class Pattern {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the number : ");
        int rows = sc.nextInt();

        int count = 1;

        for (int i=0; i<rows; i++){
            if (i%2==0){
                for (int j = 0; j < rows; j++) {
                    System.out.print(count+ "\t");
                    count++;
                }
            }
            else{
                int temp = count+rows-1;
                for (int k = rows-1; k >= 0; k--) {
                    System.out.print(temp+ "\t");
                    temp--;
                }
                count += rows;
            }
            System.out.println();
        }
    }
}
