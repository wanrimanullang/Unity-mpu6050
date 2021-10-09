﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Head : MonoBehaviour {  
	string getcom;
	string get_x,get_y,get_z,get_number;
	float angle_x,angle_y,angle_z;
	float number;
	Quaternion originRotation;
	Quaternion next;
	void Start () {
		originRotation = transform.rotation;
	}

	void Update () {
		getcom = GameObject.Find ("ScriptHolder").GetComponent<Receiver> ().getcom;
		getcom= getcom.Remove(getcom.Length -1);
		get_number = getcom.Substring (0, getcom.IndexOf (' '));
		getcom = getcom.Remove(0,getcom.IndexOf(' ')+1);
		get_x = getcom.Substring(0, getcom.IndexOf(' '));
		getcom = getcom.Remove(0,getcom.IndexOf(' ')+1);
		get_y = getcom.Substring(0, getcom.IndexOf(' '));
		getcom = getcom.Remove(0,getcom.IndexOf(' '));
		get_z = getcom;
		Single.TryParse (get_number, out number);
		if (number == 2) {
			Single.TryParse (get_x, out angle_x);
			Single.TryParse (get_y, out angle_y);
			Single.TryParse (get_z, out angle_z);
			Quaternion rotation_x = Quaternion.AngleAxis (angle_z*(-1), Vector3.right);
			Quaternion rotation_y = Quaternion.AngleAxis (angle_x*(-1), Vector3.up);
			Quaternion rotation_z = Quaternion.AngleAxis (angle_y*(-1)-50, new Vector3 (0,0,1));
			transform.rotation = originRotation * rotation_x; 
			next = originRotation * rotation_x;
			transform.rotation = next * rotation_y;
			next = next * rotation_y;
			transform.rotation = next * rotation_z;
		}
	}
}
