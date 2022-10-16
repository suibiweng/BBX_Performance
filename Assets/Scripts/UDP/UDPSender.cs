using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPSender : MonoBehaviour
{
    [SerializeField]
    private string IP = "127.0.0.1";

    [SerializeField]
    private int port = 8051;

    IPEndPoint remoteEndPoint;
    UdpClient client;
    //TcpClient clientTCP;

    public void Start()
    {
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
        //
      //  clientTCP = new TcpClient();
    }

    public void SendString(string message)
    {
        try {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);
        } catch (Exception err) {
            print(err.ToString());
        }
    }
}
