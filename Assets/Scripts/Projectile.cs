using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage = 100f;
	
	public float GetDamage(){
		return damage;
	}
	
	public void Hit(){
		if (Random.Range(0,10) <= 8) {
			Destroy(gameObject);
		}
	}
}
