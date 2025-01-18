using System;
using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Display7Segment : MonoBehaviour
{
    [SerializeField] Material materialOff;
    [SerializeField] Material materialOn;
    [SerializeField] GameObject[] digits;
    [SerializeField] GameObject dots;

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;                            // Gets the current time
        int hours = currentTime.Hour;                                   // Gets the hours
        int minutes = currentTime.Minute;                               // Gets the minutes
        int millis = currentTime.Millisecond;                           // Gets the milliseconds

        SetDigit(0, hours / 10);                                        // Sets the first digit
        SetDigit(1, hours % 10);                                        // Sets the second digit
        SetDigit(2, minutes / 10);                                      // Sets the third digit
        SetDigit(3, minutes % 10);                                      // Sets the fourth digit

        ToggleDots(millis);                                             // Toggles the dots
    }

    // Sets a given digit to a specific value by setting the right segments
    void SetDigit(int digitIndex, int value)
    {
        switch (value) 
        {
            case 0:
                SetSegments(digitIndex, new bool[7] {true, true, true, true, true, true, false});
                break;
            case 1:
                SetSegments(digitIndex, new bool[7] {false, false, false, true, true, false, false});
                break;
            case 2:
                SetSegments(digitIndex, new bool[7] {true, false, true, true, false, true, true});
                break;
            case 3:
                SetSegments(digitIndex, new bool[7] {false, false, true, true, true, true, true});
                break;
            case 4:
                SetSegments(digitIndex, new bool[7] {false, true, false, true, true, false, true});
                break;
            case 5:
                SetSegments(digitIndex, new bool[7] {false, true, true, false, true, true, true});
                break;
            case 6:
                SetSegments(digitIndex, new bool[7] {true, true, true, false, true, true, true});
                break;
            case 7:
                SetSegments(digitIndex, new bool[7] {false, false, true, true, true, false, false});
                break;
            case 8:
                SetSegments(digitIndex, new bool[7] {true, true, true, true, true, true, true});
                break;
            case 9:
                SetSegments(digitIndex, new bool[7] {false, true, true, true, true, true, true});
                break;
            default:
                SetSegments(digitIndex, new bool[7] {false, false, false, false, false, false, false});
                break;
        }
    }

    // Activates the required segments in the given digit
    void SetSegments(int digitIndex, bool[] segmentState)
    {
        if (segmentState.Length == 7)
        { 
            for (int i = 0; i < 7; i++)
            {
                if (segmentState[i] == true)
                {
                    digits[digitIndex].transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = materialOn;
                }
                else
                {
                    digits[digitIndex].transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = materialOff;
                }
            }
        }
        else
        {
            Debug.LogError("Invalid segmentState length in Display7Segment.SetSegments call.");
        }
    }

    // Toggles the dots
    void ToggleDots(int millis)
    {
        if (millis < 500)
        {
            dots.GetComponent<MeshRenderer>().material = materialOn;
        }
        else
        {
            dots.GetComponent<MeshRenderer>().material = materialOff;
        }
    }
}