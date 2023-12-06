/*
Arrange the array of 10 elements in a given order. Minimum should be at center. Second minimum
to its right, third minimum to its left, fourth minimum to its right and so on.

 Input: [9, 5, 7, 1, 8, 3, 6, 2, 4, 10]     Output: [9, 7, 5, 3, 1, 2, 4, 6, 8, 10]
*/

import java.util.Arrays;

public class Arrange_Array_Given_Order {
    public static void main(String[] args) {
        int arr[] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int result[] = new int[arr.length];
        Arrays.sort(arr);
        int mid = (arr.length / 2) - 1;

        result[mid] = arr[0];
        int i = 1;
        for (int j = 1; i + 1 < arr.length; i += 2, j++) {
            result[mid + j] = arr[i];
            result[mid - j] = arr[i + 1];
        }
        if (i == arr.length - 1)
            result[arr.length - 1] = arr[arr.length - 1];

        System.out.println(Arrays.toString(result));
    }
}
