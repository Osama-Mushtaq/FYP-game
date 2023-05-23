using UnityEngine;
using System.IO.Ports;

public class ESP : MonoBehaviour
{
    public string portName = "COM3"; // Replace with your NodeMCU ESP8266's serial port name
    public int baudRate = 9600;

    private SerialPort serialPort;

    void Start()
    {
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open(); // Open the serial connection
        serialPort.ReadTimeout = 100; // Set a read timeout
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine(); // Read a line of data from the serial connection
                Debug.Log("Data received: " + data);
            }
            catch (System.TimeoutException)
            {
                // Handle timeout exceptions if needed
            }
        }
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close(); // Close the serial connection when the script is destroyed
        }
    }
}