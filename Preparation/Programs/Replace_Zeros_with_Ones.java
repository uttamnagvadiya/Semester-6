import java.util.*;
public class Replace_Zeros_with_Ones{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the number : ");
        int n = sc.nextInt();
        int result = 0, temp = 1, rem = 0;
        while(n > 0){
            rem = n % 10;
            result = temp * (rem == 0 ? 1 : rem) + result;
            n /= 10;
            temp *= 10;
        }

        System.out.println(result);
        sc.close();
    }
}