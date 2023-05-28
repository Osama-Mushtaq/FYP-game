using UnityEngine;
using System.IO.Ports;
using System.Collections.Generic;

public class ESP : MonoBehaviour
{
    public string portName = "COM4"; // Replace with your NodeMCU ESP8266's serial port name
    public int baudRate = 115200;
    private List<float> myArray;
    public static float xx;
    public static float yy;

    private SerialPort serialPort;

    void Start()
    {
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open(); // Open the serial connection
        serialPort.ReadTimeout = 100; // Set a read timeout
        myArray = new List<float>();
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                var strain_guage = serialPort.ReadLine(); // Read a line of data from the serial connection
                var xRotation = serialPort.ReadLine(); // Read a line of data from the serial connection
                var yRotation = serialPort.ReadLine(); // Read a line of data from the serial connection
                var zRotation = serialPort.ReadLine(); // Read a line of data from the serial connection
                xx = float.Parse(xRotation);
                yy = float.Parse(yRotation);
                myArray.Add(float.Parse(strain_guage));
                myArray.Add(float.Parse(xRotation));
                myArray.Add(float.Parse(yRotation));
                myArray.Add(float.Parse(zRotation));
                // if (myArray.Count == 4)
                // {

                // }
                //Debug.Log("Data received: " + data);
                foreach (var item in myArray)
                {
                    Debug.Log("Data " + myArray.IndexOf(item) + ": " + item);
                }
                myArray.Clear();
            }
            catch (System.TimeoutException)
            {
                // Handle timeout exceptions if needed
            }
        }
    }

    // void OnDestroy()
    // {
    //     if (serialPort != null && serialPort.IsOpen)
    //     {
    //         serialPort.Close(); // Close the serial connection when the script is destroyed
    //     }
    // }
}