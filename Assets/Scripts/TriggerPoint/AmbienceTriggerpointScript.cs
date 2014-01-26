using UnityEngine;
using System.Collections;

public class AmbienceTriggerpointScript : MonoBehaviour {

	private GameObject game;
	private GameScript gameScript;


	// Use this for initialization
	void Start () {
		game = GameObject.Find("GAME");
		gameScript = game.GetComponent<GameScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

	}
}
