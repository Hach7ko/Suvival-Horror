using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public GameManager main = null;

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		main.NextEnemy();
		Destroy(this.gameObject);
	}
}
