using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
public class BluetoothScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Connect ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void Connect(){
		SerialPort BlueToothConnection = new SerialPort();
		BlueToothConnection.BaudRate = (9600);
		BlueToothConnection.PortName = "COM4";

		BlueToothConnection.Open();
		if (BlueToothConnection.IsOpen)
		{
			int length = BlueToothConnection.ReadByte ();
			for (int i = 0; i < length; i++) {
				print(BlueToothConnection.ReadByte ().ToString ());
			}


		}
	}


}
