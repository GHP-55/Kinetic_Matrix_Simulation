using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Move : MonoBehaviour {
	private float Speed;
	private int Direction = 1;

	void Start () {
		Speed = GameObject.Find("Main Camera").GetComponent<Master>().Speed;
		Change();
	}

	void Update () {
		if (GameObject.Find("Main Camera").GetComponent<Master>().Mode == "Random") {
			if (Random.Range(0, 100) == 0) {
				Change();
			}
			if (this.transform.position.y >= 2) {
				this.transform.position = new Vector3(this.transform.position.x, 1.98f, this.transform.position.z);
				Change();
			}else if (this.transform.position.y <= 0) {
				this.transform.position = new Vector3(this.transform.position.x, .02f, this.transform.position.z);
				Change();
			}else {
				transform.Translate(Vector3.up * Time.deltaTime * Speed * Direction);
			}
		}
	}

	void Change () {
		if (Random.Range(0,2) == 1) {
			Direction = 1;
		}else {
			Direction = -1;
		}
	}
}
