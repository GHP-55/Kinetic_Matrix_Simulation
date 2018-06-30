using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour {
	Material Block_Color;
	int r = 0;
	int g = 0;
	int b = 0;
	int a = 255;

	void Start() {
		Block_Color = this.GetComponent<Renderer>().material;
		//StartCoroutine(Color_Change());
	}

	void Update () {
		if (this.transform.position.y <= 2 / 3f) {
			r = Mathf.RoundToInt(255 * (this.transform.position.y  / (2 / 3f)));
			g = 0;
			b = 0;
		}else if (this.transform.position.y <= 4 / 3f) {
			r = 255;
			g = Mathf.RoundToInt(255 * ((this.transform.position.y - (2 / 3f))  / (2 / 3f)));
			b = 0;
		}else if (this.transform.position.y <= 6 / 3f) {
			r = 255;
			g = 255;
			b = Mathf.RoundToInt(255 * ((this.transform.position.y - (4 / 3f))  / (2 / 3f)));
		}


		/*if (r != 255) {
			r++;
		}else if (g != 255) {
			g++;
		}else if (b != 255) {
			b++;
		}else {
			r = 0;
			g = 0;
			b = 0;
		}*/
		Block_Color.color = new Color(r / 255f, g / 255f, b / 255f, a / 255f);
	}
}
