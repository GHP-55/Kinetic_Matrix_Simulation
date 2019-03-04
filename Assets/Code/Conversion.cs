using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Conversion : MonoBehaviour {
	public TextAsset Input_Text;
	public string[] Input_Hexs;
	private StreamReader Input;
	private string[] Lines;
	private int Size;

	void Start () {
		Size = 10;
		Input = new StreamReader(new MemoryStream(Input_Text.bytes));
		Lines = new string[94]; //TODO: Make adaptable
		BinarytoNumbers();
	}

	void BinarytoNumbers () { //Without Spacing
		string Line;
		for (int i = 0; (Line = Input.ReadLine()) != null; i++) {
			for (int a = 0; a < Line.Length; a++) {
				if (Line[a] == '1') {
					//Print to file
					if (Lines[i] != null) {
						Lines[i] += "," + Rearrange(a).ToString();
					}else {
						Lines[i] += Rearrange(a).ToString();
					}
				}
			}
		}
		System.IO.File.WriteAllLines("Assets/Resources/Matrix_Positions.txt", Lines); //Output File
		Debug.Log("Done");
	}

	void Base10toBinary () {
		string Line;
		for (int x = 0; (Line = Input.ReadLine()) != null; x++) {
			Input_Hexs = new string[10];
			Input_Hexs[0] = "0"; //Padding Left
			Input_Hexs[9] = "0"; //Padding Right
			for (float i = 0; i < Line.Length; i += 4) {
				int temp = int.Parse(Mathf.Floor(i/4f+1).ToString());
				Input_Hexs[temp] += Line[int.Parse((i).ToString())];
				Input_Hexs[temp] += Line[int.Parse((i+1).ToString())];
				Input_Hexs[temp] += Line[int.Parse((i+2).ToString())];
			}

			for (int i = 0; i < Input_Hexs.Length; i++) {
				Input_Hexs[i] = Convert.ToString(int.Parse(Input_Hexs[i]), 2);
				Input_Hexs[i] = Input_Hexs[i].PadLeft(9,'0'); //Padding Left
				Input_Hexs[i] += '0'; //Padding Right
				Lines[x] += Input_Hexs[i];
			}
		}
		System.IO.File.WriteAllLines("Assets/Resources/Matrix_Positions.txt", Lines); //Output File
		Debug.Log("Done");
	}

	void HexToBase10 () {
		string Line;
		for (int x = 0; (Line = Input.ReadLine()) != null; x++) {
			Input_Hexs = new string[8];
			for (float i = 2; i < Line.Length; i += 5) {
				int temp = int.Parse(Mathf.Floor(i/5f).ToString());
				Input_Hexs[temp] += Line[int.Parse((i).ToString())];
				Input_Hexs[temp] += Line[int.Parse((i+1).ToString())];
			}
			for (int i = 0; i < Input_Hexs.Length; i++) {
				Input_Hexs[i] = int.Parse(Input_Hexs[i],System.Globalization.NumberStyles.HexNumber).ToString();
				if (i != 0) {
					Lines[x] += " ";
				}
				if (Input_Hexs[i].Length == 1) {
					Input_Hexs[i] = "00" + Input_Hexs[i];
				}else if (Input_Hexs[i].Length == 2) {
					Input_Hexs[i] = "0" + Input_Hexs[i];
				}
				Lines[x] += Input_Hexs[i];
			}
		}
		System.IO.File.WriteAllLines("Assets/Resources/Matrix_Positions.txt", Lines); //Output File
		Debug.Log("Done");
	}

	int Rearrange (int Input) { //Linear to Matrix
		int x = Input % Size;
		int y = (int)Mathf.Floor(Input / Size);
		int temp_x = x; //Optimize?
		if (x % 2 == 0) {
			x = Size-y-1;
		}else {
			x = y;
		}
		y = Size-temp_x-1;
		x = (int)Mathf.Floor(x / Size) + (Size - (x % Size) - 1); //Optimize?
		return 99-(y*Size+x);
	}
}
