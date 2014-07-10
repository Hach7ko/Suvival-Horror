using UnityEngine;
using System.Collections;

public class PlayAgain : MonoBehaviour {

	void Update () {
		if(Input.GetAxis("Jump") != 0.0f) {
			Application.LoadLevel("map");
		}
	}
}
