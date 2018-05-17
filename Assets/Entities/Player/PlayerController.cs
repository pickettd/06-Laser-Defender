using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject laser;
	public float projectileSpeed = 10;
	public float projectileRepeatRate = 0.2f;
	
	public float speed = 15.0f;
	public float padding = 1;
	public float health = 200;
	
	public AudioClip fireSound;

	private float xmax = -5;
	private float xmin = 5;
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Die();
			}
		}
	}
	
	void Die(){
		LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Win Screen");
		ScoreKeeper.restarted = true;
		Destroy(gameObject);
	}
	
	void Start(){
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		if (ScoreKeeper.restarted) {
			padding = 0;
		}
		xmin = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		xmax = camera.ViewportToWorldPoint(new Vector3(1,1,distance)).x - padding;
	}

	void Fire(){
		GameObject beam = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.0001f, projectileRepeatRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			float newX;
			if (ScoreKeeper.restarted) {
				newX = transform.position.x - speed * Time.deltaTime * 2;
			}
			else {
				newX = transform.position.x - speed * Time.deltaTime;
			}
			transform.position = new Vector3(
				Mathf.Clamp(newX, xmin, xmax),
				transform.position.y, 
				transform.position.z 
			);
		}else if (Input.GetKey(KeyCode.RightArrow)){
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x + speed * Time.deltaTime, xmin, xmax),
				transform.position.y, 
				transform.position.z 
			);
		}
	}
}
