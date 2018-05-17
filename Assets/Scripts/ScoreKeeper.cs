using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;
	public static bool restarted = false;
	private Text myText;

	void Start(){
		myText = GetComponent<Text>();
		Reset();
	}
			
	public void Score(int points){
		Debug.Log ("Scored points");
		if (restarted) {
			score += Random.Range(0,points*5);
		}
		else {
			score += points;
		}
		myText.text = score.ToString();
	}
	
	public static void Reset(){
		score = 0;
	}
}
