using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] enemies = null;
	public CameraEffect EffectTarget = null;
	public SeeEnnemy PlayerTarget = null;
	private int currentEnemy = 0;
	// Use this for initialization
	void Start () {
		currentEnemy = 0;
		ResetEnemies();

	}
	void ResetEnemies()
	{
		for(int i = 0; i < enemies.Length; i++)
		{
			enemies[i].GetComponent<SetDestination>().enabled = false;
			if(i == currentEnemy)
			{
				enemies[i].GetComponent<SetDestination>().enabled = true;
				PlayerTarget.ennemy = enemies[i].gameObject;
				PlayerTarget.ChangeEnemy();
				EffectTarget.target = enemies[i].transform;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void NextEnemy()
	{
		currentEnemy++;
		ResetEnemies();
		enemies[currentEnemy-1].gameObject.SetActive(false);
		//Destroy(enemies[currentEnemy-1].gameObject);

	}
}
