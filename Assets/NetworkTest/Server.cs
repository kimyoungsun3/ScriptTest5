using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;

public class Server : MonoBehaviour {
	int port = 10045;
	byte[] receBuf = new byte[1024*4];
	byte[] sendBuf = new byte[1024*4];
	List<Socket> clientSockets = new List<Socket> ();
	Socket serverSocket = new Socket (
		                      AddressFamily.InterNetwork,
		                      SocketType.Stream,
		                      ProtocolType.Tcp);

	void Start () {
		Debug.Log ("Server Start()");
		SetupServer ();
	}

	void SetupServer(){
		Debug.Log ("SetupServer()");
		serverSocket.Bind (new IPEndPoint (IPAddress.Any, port));
		serverSocket.Listen (1);
		serverSocket.BeginAccept (new AsyncCallback (AcceptCallBack), null);
	}

	void AcceptCallBack(IAsyncResult _ar){
		Debug.Log ("AcceptCallBack(IAsyncResult _ar)");
		Socket _socket = serverSocket.EndAccept (_ar);
		clientSockets.Add (_socket);
		_socket.BeginReceive (receBuf, 0, receBuf.Length, SocketFlags.None, new AsyncCallback (ReceiveCallBack), null);
		serverSocket.BeginAccept (new AsyncCallback (AcceptCallBack), null);
	}

	void ReceiveCallBack(IAsyncResult _ar){
		Debug.Log (" ReceiveCallBack(IAsyncResult _ar)");
		Socket _socket = (Socket)_ar.AsyncState;
		int _receSize = _socket.EndReceive (_ar);
		byte[] _tempBuf = new byte[_receSize];
		Array.Copy (receBuf, _tempBuf, _receSize);

		string _text = Encoding.ASCII.GetString (_tempBuf);
		Debug.Log ("Text received:" + _text);

		if (_text.ToLower ().Equals ("get time")) {
			_text = DateTime.Now.ToLongTimeString ();
		} else {
			_text = "Invalied Request";
		}

		byte[] _data = Encoding.ASCII.GetBytes (_text);
		_socket.BeginSend(_data, 0, _data.Length, SocketFlags.None, new AsyncCallback (SendCallBack), null);

	}

	void SendCallBack(IAsyncResult _ar){
		Debug.Log (" SendCallBack(IAsyncResult _ar)");
		Socket _socket = (Socket)_ar.AsyncState;
		_socket.EndSend (_ar);
	}
}
