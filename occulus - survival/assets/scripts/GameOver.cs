using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	private bool isGameOver;

	void Start() {
		isGameOver = false;
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			Application.LoadLevel("gameover");
		}
	}
}
