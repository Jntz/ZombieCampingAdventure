using UnityEngine;
using System.Collections;

public class ZombieAnimationScript : MonoBehaviour {

	private GameObject game;
	private GameScript gameScript;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		game = GameObject.Find("GAME");
		gameScript = game.GetComponent<GameScript>();


	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("Magnitude: " + characterController.velocity.magnitude); 
	}
}
