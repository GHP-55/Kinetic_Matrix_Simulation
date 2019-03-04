using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Move : MonoBehaviour {
	private int i = 0;
	private float Speed;
	private int Direction = 1;
	private int Size;

	void Start () {
		Speed = GameObject.Find("Main Camera").GetComponent<Master>().Speed;
		Size = GameObject.Find("Main Camera").GetComponent<Master>().Size;
		string number = null;
		for (int i = 7; i < this.name.Length; i++) {
			number += this.name[i];
		}
		float pos_y = 2f*(((int.Parse(number))%Size)/(float)(Size-1)); //TODO: Add multi wave adaptability
		this.transform.position = new Vector3(this.transform.position.x, pos_y, this.transform.position.z);
	}
		
	void Update () { //Movement
		if (this.transform.position.y >= 2) {
			this.transform.position = new Vector3(this.transform.position.x, 1.98f, this.transform.position.z);
			Direction = -1;
		}else if (this.transform.position.y <= 0) {
			this.transform.position = new Vector3(this.transform.position.x, .02f, this.transform.position.z);
			Direction = 1;
		}else {
			transform.Translate(Vector3.up * Time.deltaTime * Speed * Direction);
		}
	}
}
