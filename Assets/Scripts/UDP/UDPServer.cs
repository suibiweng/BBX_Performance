using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPServer : MonoBehaviour
{
    public string datain;
    public Manager manager;
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
       // if (PrintDebug)
    //        Debug.Log("Received: " + obj);
        datain=obj;

        if (obj.StartsWith("Podium")) {

            string[] data = obj.Split(',');


            int id = int.Parse(data[1]);
            manager.setPodiumColor(id,data[2]);
        }


        if (obj.StartsWith("oxy_present")) {
            string[] data = obj.Split(',');

            string[] num = data[1].Split('e');
            print(num[0]);


            manager.updateTrustValue(double.Parse(num[0]));

        }

        if (obj.StartsWith("oxy_end")) {
            string[] data = obj.Split(',');
            manager.updateTrustValue(double.Parse(data[1]));
            manager.TurnONthePodium();

        }





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

                print (("Ping was sent from " + anyIP.Address.ToString() +
                             " on their port number " + anyIP.Port.ToString()));
             
                string text = Encoding.ASCII.GetString(data);
                OnUDPMessage(text);

            } catch (Exception err) {
                print(err.ToString());
            }
        }
    }



       public void broadcastMsg(string cmd){
       Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
         IPAddress broadcast = IPAddress.Parse("192.168.0.255");
         byte[] sendbuf = Encoding.ASCII.GetBytes(cmd);
         IPEndPoint ep = new IPEndPoint(broadcast, port);
    
         s.SendTo(sendbuf, ep);
    
    }


    



}