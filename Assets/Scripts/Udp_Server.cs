using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
public class Udp_Server : MonoBehaviour
{//����Ĭ�϶���˽�еĳ�Ա
    Socket socket; //Ŀ��socket
    EndPoint clientEnd; //�ͻ���
    IPEndPoint ipEnd; //�����˿�
    string recvStr; //���յ��ַ���
    string sendStr; //���͵��ַ���
    byte[] recvData = new byte[1024]; //���յ����ݣ�����Ϊ�ֽ�
    byte[] sendData = new byte[1024]; //���͵����ݣ�����Ϊ�ֽ�
    int recvLen; //���յ����ݳ���
    Thread connectThread; //�����߳�
                          //��ʼ��
    void InitSocket()
    {
        //���������˿�,�����κ�IP
        ipEnd = new IPEndPoint(IPAddress.Any, 8001);
        //�����׽�������,�����߳��ж���
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //�������Ҫ��ip
        socket.Bind(ipEnd);
        //����ͻ���
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        clientEnd = (EndPoint)sender;
        print("waiting for UDP dgram");

        //����һ���߳����ӣ�����ģ��������߳̿���
        connectThread = new Thread(new ThreadStart(SocketReceive));
        connectThread.Start();
    }

    void SocketSend(string sendStr)
    {
        //��շ��ͻ���
        sendData = new byte[1024];
        //��������ת��
        sendData = Encoding.ASCII.GetBytes(sendStr);
        //���͸�ָ���ͻ���
        socket.SendTo(sendData, sendData.Length, SocketFlags.None, clientEnd);
    }

    //����������
    void SocketReceive()
    {
        //�������ѭ��
        while (true)
        {
            //��data����
            recvData = new byte[1024];
            //��ȡ�ͻ��ˣ���ȡ�ͻ������ݣ������ø��ͻ��˸�ֵ
            recvLen = socket.ReceiveFrom(recvData, ref clientEnd);
            print("message from: " + clientEnd.ToString()); //��ӡ�ͻ�����Ϣ
                                                            //������յ�������
            recvStr = Encoding.ASCII.GetString(recvData, 0, recvLen);
            print("���Ƿ����������յ��ͻ��˵�����" + recvStr);
            //�����յ������ݾ��������ٷ��ͳ�ȥ
            sendStr = "From Server: " + recvStr;
            SocketSend(sendStr);
        }
    }

    //���ӹر�
    void SocketQuit()
    {
        //�ر��߳�
        if (connectThread != null)
        {
            connectThread.Interrupt();
            connectThread.Abort();
        }
        //���ر�socket
        if (socket != null)
            socket.Close();
        print("disconnect");
    }

    // Use this for initialization
    void Start()
    {
        InitSocket(); //�������ʼ��server
    }
    void OnApplicationQuit()
    {
        SocketQuit();
    }

}
