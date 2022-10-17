using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


public class UDPBroacast : MonoBehaviour
{

public int PORT = 9876;
UdpClient udpClient = new UdpClient();


    // Start is called before the first frame update
    void Start()
    {

        udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void broadcastTo(string cmd){
        var from = new IPEndPoint(0, 0);
        var data = Encoding.UTF8.GetBytes(cmd);
        udpClient.Send(data, data.Length, "255.255.255.255", PORT);
    }


}
