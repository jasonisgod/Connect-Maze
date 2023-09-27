using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class SocketClient : MonoBehaviour
{
    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    private Game game;

    // Start is called before the first frame update
    void Start()
    {
        Connect();
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     // SendMessage();
        // }
    }

    private void Connect()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }
    }
    
    private void ListenForData()
    {
        try
        {
            // socketConnection = new TcpClient("8.217.201.173", 9099);
            socketConnection = new TcpClient("jasonisgod.xyz", 9099);
            // socketConnection = new TcpClient("localhost", 12345);
            Debug.Log("Socket connected");
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                // Get a stream object for reading 				
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    // Read incomming stream into byte arrary. 					
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        // Convert byte array to string message. 						
                        string serverMessage = Encoding.ASCII.GetString(incommingData);
                        Debug.Log("server message received as: " + serverMessage);
                        try {
                            game.cmdQueue.Enqueue(serverMessage);
                        }
                        catch (Exception e) {
                            Debug.Log("server /click exception " + e.ToString());
                        }
                        // laneNumber = int.Parse(serverMessage);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy");
        clientReceiveThread.Abort();
    }
}
