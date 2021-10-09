using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class NewBehaviourScript : MonoBehaviour {
	SerialPort serial1;
//SerialPort port = new SerialPort ("COM5", 115200);
	string getcom;
	int x,y;
	string xs,ys;
	// Use this for initialization
	void Start () {
		serial1=new SerialPort("COM5",115200);
		Debug.Log ("something");
	}
	
	// Update is called once per frame
	void Update () {
		if (!serial1.IsOpen)
			serial1.Open ();
		else {
			serial1.Close ();
			serial1.Open ();
		}
		getcom = serial1.ReadLine ();
		xs = getcom.Substring (0, getcom.IndexOf (' '));
		Debug.Log("xs= ");
		Debug.Log (xs);
		ys = getcom;
		x = System.Convert.ToInt32 (xs, 10);
		y = System.Convert.ToInt32(ys,10);
		transform.Rotate(new Vector3(x, y, 0) * Time.deltaTime);
		serial1.Close (); 
	}
}
