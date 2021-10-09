using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
public class NewBehaviourScript1 : MonoBehaviour {
	string getcom;
	string get_x,get_y,get_z;
	float angle_x,angle_y,angle_z;
	SerialPort serial1;
	// Use this for initialization
	void Start () {
		serial1=new SerialPort("COM4",9600);
		//Debug.Log ("something");
		if (!serial1.IsOpen)
			serial1.Open ();
		else {
			serial1.Close ();
			serial1.Open ();
			Debug.Log ("Serial close -> serial open");
		}
	}
	
	// Update is called once per frame
	void Update () {
		getcom = serial1.ReadLine ();
		Debug.Log ("get from port= ");
		Debug.Log (getcom);
		getcom= getcom.Remove(getcom.Length -1);
		get_x = getcom.Substring(0, getcom.IndexOf(' '));
		getcom = getcom.Remove(0,getcom.IndexOf(' ')+1);
		get_y = getcom.Substring(0, getcom.IndexOf(' '));
		getcom = getcom.Remove(0,getcom.IndexOf(' '));
		get_z = getcom;
		Single.TryParse (get_x, out angle_x);
		Single.TryParse (get_y, out angle_y);
		Single.TryParse (get_z, out angle_z);
		transform.localEulerAngles = new Vector3(angle_x, angle_y, angle_z);
	}
}
