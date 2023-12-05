/* Write a Program to Given two arrays [1,2,3,4,5] and [2,3,1,0,5].
Find which number is not present in the second array.
Input: Array-1 => [1,2,3,4,5]       Output: 4
       Array-2 => [2,3,1,0,5] 
*/

public class Find_Elements{
    public static void main(String[] args) {
        int [] a = {1,2,3,4,5};
        int [] b = {2,3,1,0,5};

        for (int i=0; i<a.length; i++){
            boolean flag = true;
            for (int j=0; j<b.length; j++){
                if (a[i] == b[j])
                    flag = false;
            }
            if (flag){
                System.out.print(a[i]+", ");
            }
        }
    }
}