using UnityEngine;
using System.Collections;

// Script à mettre sur le joeur
public class SeeEnnemy : MonoBehaviour {
	
	public int range; // Portée pour voir l'ennemi
	public GameObject ennemy; // Drag'n'drop le gameobject ennemy ici. A changer en tableau pour stopper plusieurs ennemis.
	private SetDestination _authorizeEnnemyMove; 
	
	void Start () {
		// Récupère le script de l'ennemi.
		_authorizeEnnemyMove = ennemy.GetComponent<SetDestination>();
	}
	public void ChangeEnemy()
	{
		_authorizeEnnemyMove = ennemy.GetComponent<SetDestination>();
	}
	void Update () {
		
		// this.Alarme renvoie true quand le joueur est dans le champ de vision, à portée, et face au joueur.
		// Il appelle une method de l'ennemie et lui autorise à bouger ou non.
		if (this.Alarme()){
			_authorizeEnnemyMove.CanMove = false;
		}
		else{
			_authorizeEnnemyMove.CanMove = true;
		}
	}
	
	bool Alarme()
	{
		Vector3 mPosition = this.transform.position;
		Vector3 pPosition = ennemy.transform.position;
		
		float ennemyDistance = Vector3.Distance(pPosition, mPosition);
		
		if(ennemyDistance > this.range){
			return false;
		}
		
		if(Vector3.Angle(pPosition - mPosition, this.transform.forward)>45)
			return false;	
		
		Ray ray = new Ray(mPosition ,pPosition - mPosition);
		Debug.DrawLine(ray.origin, ray.origin + pPosition - mPosition);
		RaycastHit info;
		
		if(Physics.Raycast(ray, out info, ennemyDistance))
		{
			if(info.transform.tag== "Enemy")
			{
				return true;
			}
		}
		return false;
	}
}
