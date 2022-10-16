using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPServer : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;

    [SerializeField]
    private int port = 8585;

    [SerializeField]
    private bool PrintDebug = false;

    public static event Action<string> OnUDPMessage;

    public void Start()
    {
        init();
        OnUDPMessage += LogMessage;
    }

    private void LogMessage(string obj)
    {
        if (PrintDebug)
            Debug.Log("Received: " + obj);
    }

    private void init()
    {
        receiveThread = new Thread(
            new ThreadStart(ReceiveData));

        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (true) {
            try {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
             
                string text = Encoding.ASCII.GetString(data);
                OnUDPMessage(text);
                print(text);
            } catch (Exception err) {
                print(err.ToString());
            }
        }
    }

}