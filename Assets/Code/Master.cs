using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {
	public GameObject Camera;
	public GameObject Block;
	GameObject[] Blocks; //Work with later
	int Size = 10;
	public string Mode = "Random";
	float Delay = .3f;

	// Use this for initialization
	void Start () {
		//Camera.GetComponent<Transform>().positon = new Vector3(Size, Size + 5, Size); Fix this shit l8r
		Blocks = new GameObject[Size * Size];
		int i = 0;
		for (int a = 0; a < Size; a++) {
			for (int b = 0; b < Size; b++) {
				GameObject Clone = Instantiate(Block, new Vector3(0 - (Size / 2f) + a, 0, 0 - (Size / 2f) + b), Quaternion.identity);
				Clone.name = "Block " + a + "-" + b;
				Blocks[i] = Clone;
				i++;
			}
		}
	}

	void Update () {
		if (Mode == "Wave") {
			foreach (GameObject x in Blocks) {
				x.transform.position = new Vector3(x.transform.position.x, 0, x.transform.position.z);;
			}
			StartCoroutine(Wave_1());
			StartCoroutine(Wave_2());
			Mode = "Wave_Active";
		}
	}

	public IEnumerator Wave_1 () {
		for (int i = 0; i < Size; i++) {
			Debug.Log(Mathf.Ceil(Size / 2f));
			for (int a = 0; a < Mathf.Ceil(Size / 2f); a++) {
				Blocks[a * 20 + i].GetComponent<Wave_Move>().Active = true;
			}
			yield return new WaitForSeconds(Delay);
		}
	}

	public IEnumerator Wave_2 () {
		for (int i = Size - 1; i >= 0; i--) {
			for (int b = 0; b < Mathf.Floor(Size / 2f); b++) {
				Blocks[b * 20 + i + 10].GetComponent<Wave_Move>().Active = true;
			}
			yield return new WaitForSeconds(Delay);
		}
	}
}
