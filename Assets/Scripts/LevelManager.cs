using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		// Note that this doesn't work in a webgl build
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
