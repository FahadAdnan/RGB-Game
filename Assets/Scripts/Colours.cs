using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colours : MonoBehaviour
{
    int ColorListSize, change;
    public static byte[] Red = new byte[11];
    public static byte[] Green = new byte[11];
    public static byte[] Blue = new byte[11];

     void Awake()
    {
        ColorListSize = Red.Length;
        change = (int)Mathf.Floor(255 / ColorListSize);

        Debug.Log("The change value is: " + change);
        int OtherColors = 255;
        if (true) // Color is red 
        {
            for (int i = 0; i < ColorListSize -1; i++)
            {
                Red[i] = 255;
                Green[i] = (byte)Mathf.Abs(OtherColors);
                Blue[i] = (byte)Mathf.Abs(OtherColors);
                OtherColors = OtherColors - change;
            }
            Red[ColorListSize - 1] = 255;
            Green[ColorListSize - 1] = 0;
            Blue[ColorListSize - 1] = 0;
        }
    }
}
