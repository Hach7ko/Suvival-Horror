using UnityEngine;
using System.Collections;

//A drag'n'drop sur l'ennemy, qui possedera un NavMeshAgent
[RequireComponent(typeof(NavMeshAgent))]
public class SetDestination : MonoBehaviour
{
	NavMeshAgent agent;
	private int i = 0;
	public Transform[] destination;
	private bool _canMove = true;
	
	public bool CanMove
	{
		get
		{
			return this._canMove;
		}
		set
		{
			this._canMove = value;
		}
	}
	// Je récupère le component NavMeshAgent de l'ennemy.
	void Start()
	{
		this.agent = this.GetComponent<NavMeshAgent>();
	}

	// Si le joeur ne le voit pas, il set sa destination sur la position du joueur, sinon il ne bouge plus.
	void Update()
	{
		if(_canMove)
			this.agent.SetDestination(this.destination[i].position);
		else
			this.agent.ResetPath();
	}

	// Ne sert à rien pour le moment, mais pourrait permettre aux ennemis de faire des rondes, ou d'allez de points A a point B.
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.GetInstanceID() != this.destination[i].GetInstanceID())
			return;
	}

	IEnumerator NextDestination()
	{
		yield return new WaitForSeconds(2);
		i++;
		if(i >= this.destination.Length)
			i = 0;

		this.agent.SetDestination(this.destination[i].position);
	}
}