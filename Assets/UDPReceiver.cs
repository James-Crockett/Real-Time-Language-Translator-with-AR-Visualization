using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using TMPro;

public class UDPReceiver : MonoBehaviour
{
    UdpClient udpClient;
    Thread receiveThread;
    public int port = 5065; // Must match Python
    public TextMeshPro textDisplay;  // Assign your TextMeshPro object here (3D or UI)

    private string receivedMessage = "";
    private bool messageReceived = false;

    void Start()
    {
        udpClient = new UdpClient(port);
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
        Debug.Log("UDP Receiver initialized on port " + port);
    }

    void ReceiveData()
    {
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
        while (true)
        {
            try
            {
                byte[] data = udpClient.Receive(ref remoteEndPoint);
                receivedMessage = Encoding.UTF8.GetString(data);
                messageReceived = true;
                Debug.Log($"Received from Python: '{receivedMessage}'");
            }
            catch (System.Exception err)
            {
                Debug.LogError("UDP Receive Error: " + err.ToString());
            }
        }
    }

    void Update()
    {
        if (messageReceived && textDisplay != null)
        {
            textDisplay.text = receivedMessage;
            Debug.Log($"📝 Updated TextMeshPro with: '{receivedMessage}'");
            messageReceived = false;
        }
    }

    void OnApplicationQuit()
    {
        receiveThread?.Abort();
        udpClient?.Close();
        Debug.Log("🔌 UDP Receiver shutdown.");
    }
}
