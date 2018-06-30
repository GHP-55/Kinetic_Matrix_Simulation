using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Move : MonoBehaviour {
	int i = 0;
	float Speed = .6f;
	int Direction = 1;
	public bool Active = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Active == true) {
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
}
