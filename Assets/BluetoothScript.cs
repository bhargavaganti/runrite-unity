using UnityEngine;
using System.Collections;

public class BlueToothCoonect : MonoBehaviour {

	public string DeviceName = "RFDuino"; 
	public string ServiceUUID = "2220";
	public string SubscribeUUID = "2221";

	enum States {
		None,
		Scan,
		Connect,
		Subscribe,
		//unsubscirbe??
		Disconnect,
	}

	private bool connected = false;
	private States state = States.None;
	private float timeout = 0f;
	private string deviceAddress;
	private bool foundSubscribeID = false;
	private byte[] dataBytes = null;

	void Reset(){
		connected = false;
		timeout = 0f;
		state = States.None;
		deviceAddress = null;
		foundSubscribeID = false;
		dataBytes = null;
	}
		
	// start state machine 
	void StartBluetooth(){

		Reset (); //resets all instance variables

		// set up interface as central 
		BluetoothLEHardwareInterface.Initialize (true, false, () => { 
			//begin scanning for peripherals 
			setState(States.Scan, 0.1f);
		
		}, (error) => {

			BluetoothLEHardwareInterface.Log ("Error during initialize: " + error);
		
		});
	}

	// update state of state machine
	void setState(States newState, float newTimeout){
		state = newState;
		timeout = newTimeout;
	}

	// Use this for initialization
	void Start () {
		StartBluetooth ();
	}


	//workflow: 
	//(1) scan for devices
	//(2) if device found, connect to device
	//(3) connect successful, scan for services
	//(4) service found, scan for characteristics
	//(5) got characteristics, get value for characteristic
	// 


	// Update is called once per frame
	void Update () {


		// do some stuff with the timeout so as to 
		// not do two things at once
		if (timeout > 0f) {
			timeout -= Time.deltaTime;
			if (timeout <= 0f) {
				timeout = 0f;

				switch (state) {

				case States.None:
					break;

				case States.Scan: //(1) scan for devices
			
				// scan peripherals for peripherals with serviceUUID of serviceUUID = "2220"
					BluetoothLEHardwareInterface.ScanForPeripheralsWithServices (new []{ ServiceUUID }, (address, name) => {
						// callback with adress and name 

						Debug.Log ("addr" + address + "name" + name);

						// GET NAME OF RFDUINO 
						if (name.Contains (DeviceName)) {
							deviceAddress = address;

							// stop scan if we find the arduino
							BluetoothLEHardwareInterface.StopScan ();
							setState (States.Connect, 0.5f);

						}

					}, (address, name, rssi, bytes) => {
					
						//callback with address, name and advertising info 
						Debug.Log ("advertising info addr" + address + " name: " + name + " bytes " + bytes);

					});
			
					break;

				case States.Connect: // (2) if device found, connect to device
					foundSubscribeID = false;


			// no callback for connect or service action, because each are enumerated and would have to carefully
			// set timeouts for all of them - ie: connect would call service actin for every service found,
			// every service found would call charactersitic action for every characteristic it has
			// ultimately, we only care about read characteristic 
					BluetoothLEHardwareInterface.ConnectToPeripheral (deviceAddress, null, null, (address, serviceUUID, characteristicUUID) => {
						// characterstic action
						foundSubscribeID = foundSubscribeID || IsEqual (characteristicUUID, SubscribeUUID);
						if (foundSubscribeID) {
					
							connected = true;
							setState (States.Subscribe, 2f);
						}
					});
					break;

				case States.Subscribe: //service found, subscribe to characteristics
				// which one ?! use subscribecharacteristic NOT readcharacteristic for if characteristic value will change 
				// which eventually it will because sending different packets of data
					BluetoothLEHardwareInterface.SubscribeCharacteristic (deviceAddress, ServiceUUID, SubscribeUUID, (notification) => {
						//notificationAction
						Debug.Log ("notification action is " + notification);
					
					}, (characteristicUUID, bytes) => {
					
						//action
						Debug.Log ("value changed, data: " + bytes);
						dataBytes = bytes;


					});
					break;

				case States.Disconnect:
					BluetoothLEHardwareInterface.DisconnectPeripheral (deviceAddress, (address) => {
						BluetoothLEHardwareInterface.Log ("1");
						BluetoothLEHardwareInterface.DeInitialize (() => {

							connected = false;
							state = States.None;
						});
					});
					break;

				}
			}
		}

	}
		


	bool IsEqual(string uuid1, string uuid2)
	{
		if (uuid1.Length == 4)
			uuid1 = FullUUID (uuid1);
		if (uuid2.Length == 4)
			uuid2 = FullUUID (uuid2);

		return (uuid1.ToUpper().CompareTo(uuid2.ToUpper()) == 0);
	}

	string FullUUID (string uuid)
	{
		return "0000" + uuid + "-0000-1000-8000-00805f9b34fb";
	}

}


