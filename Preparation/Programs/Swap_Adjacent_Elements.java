/*
Write a Program to swap adjacent elements of one dimension array.
Input: [10,20,30,40,50,60,70,80,90,100]     Output: [20,10,40,30,60,50,80,70,100,90]
*/

public class Swap_Adjacent_Elements {
    public static void main(String[] args) {
        int arr[] = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        int len = arr.length;

        if (len % 2 != 0) {
            System.out.println("Take Even length array.");
            System.exit(0);
        }

        for (int i = 0; i < len - 1; i += 2) {
            int temp = arr[i];
            arr[i] = arr[i + 1];
            arr[i + 1] = temp;

            System.out.print(arr[i] + ", " + arr[i + 1] + ", ");
        }
    }
}