using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


public class UDPBroacast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPAddress broadcast = IPAddress.Parse("192.168.0.255");

        byte[] sendbuf = Encoding.ASCII.GetBytes("Hello World!");
        IPEndPoint ep = new IPEndPoint(broadcast, 11000);

        s.SendTo(sendbuf, ep);

        Console.WriteLine("Message sent to the broadcast address");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
