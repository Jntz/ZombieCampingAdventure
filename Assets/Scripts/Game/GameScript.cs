using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	//GameScript is link to another gameobjects and components
	public Transform Player;
	public string gameState; //will be not_resolved/hostile/good
	public bool playAmbientSound = true;	//play ambient sound in outside and not in inside

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if(playAmbientSound) {
			//Logic for ambient sounds and music

		}
	}
}
