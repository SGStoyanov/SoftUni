package com.company;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

public class Main {

    public static void main(String[] args) {

        /*Problem 6.	Variables
        Usually variables are storages which value may vary. They usually have data type, name and value.
        For example the variable named “name” may have a value “Pesho”, but later it could change to “Gosho”.
        Because this variable contains some kind of text, it’s data type is “String”.
        You task here is to declare these variables in IntelliJ IDEA. Once you have setup your project there’s a line of
        code which says “//write your code here”, and, of course, there’s the place where you should write these three variables. */

        String name = "Dari";
        int age = 23;
        double height = 1.70;

        // Problem 7.	Print on console

        System.out.println("My name is " + name);

        // Problem 8.	Sum two variables and print on console

        int x = 594;
        int y = 231;
        int sum = x + y;

        System.out.format("The sum of %d and %d is %d \n", x, y, sum);

        // Problem 9.	*More complex tasks

        // -	Print on the console the current date

        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd");
        Date date = new Date();
        System.out.println("Today is: " + dateFormat.format(date));

        // -	Print on the console the date after 20 hours

        Calendar cal = Calendar.getInstance();
        cal.setTime(new Date());
        cal.add(Calendar.HOUR_OF_DAY, 20);
        System.out.println("Date with 20 hours plus: " + cal.getTime());
    }
}
