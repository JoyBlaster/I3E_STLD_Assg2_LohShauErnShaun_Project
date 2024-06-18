using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CA1 : MonoBehaviour
{

    // Function checks variables if equal
    void EqualCheck(int a, int b)
    {
        // Checks if variables are equal
        if (a == b)
        {
            // Prints that variables are equal
            Debug.Log("Variables are equal.");
        }
        // If different
        else
        {
            // Checks if a more than b
            if(a > b)
            {
                // Prints a
                Debug.Log(a);
            }
            else
            {
                // Prints b
                Debug.Log(b);
            }
        }
    }

    // Calls EqualCheck function
    void OnCompare()
    {
        EqualCheck(8,8);
    }

    // Initialize empty string variable
    string countUp = "";

    // Function with For loop prints 1-10
    void NumberLoops()
    {
        // For loop to add numbers to string 10 times
        for (int i = 1; i <= 10; i++)
        {
            // Add the next numbers to string
            countUp += i;
        }

        // Print the completed string after loop is done.
        Debug.Log(countUp);
    }

    // Calls NumberLoop function
    void OnNumLoop()
    {
        NumberLoops();
    }

    //Initialize iteration variable
    int iterNum = 0;

    //Function that prints "Hello World" 10 times
    void HelloLoop()
    {
        // While loop repeats 10 times
        while(iterNum < 10)
        {
            // Print "Hello World"
            Debug.Log("Hello World");
            // Increase iteration variable
            iterNum++;
        }
    }

    // Calls HelloLoop
    void OnHelloLoop()
    {
        HelloLoop();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
