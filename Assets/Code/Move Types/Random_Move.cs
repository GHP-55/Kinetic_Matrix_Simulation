using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Move : MonoBehaviour {
	int i = 0;
	int Max;
	float Speed = .4f;
	int Direction = 1;

	void Start () {
		Change();
	}

	void Update () {
		if (GameObject.Find("Main Camera").GetComponent<Master>().Mode == "Random") {
			if (i < Max) {
				if (this.transform.position.y >= 2) {
					this.transform.position = new Vector3(this.transform.position.x, 1.98f, this.transform.position.z);
					Change();
				}else if (this.transform.position.y <= 0) {
					this.transform.position = new Vector3(this.transform.position.x, .02f, this.transform.position.z);
					Change();
				}else {
					transform.Translate(Vector3.up * Time.deltaTime * Speed * Direction);
					i++;
				}
			}else if (i == Max) {
				Change();
			}
		}
	}

	void Change () {
		Max = Random.Range(0, 200);
		i = 0;
		if (Random.Range(0,2) == 1) {
			Direction = 1;
		}else {
			Direction = -1;
		}
	}
}
