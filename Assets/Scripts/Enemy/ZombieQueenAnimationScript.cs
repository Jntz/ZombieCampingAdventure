using UnityEngine;
using System.Collections;

public class ZombieQueenAnimationScript : MonoBehaviour {

	private GameObject game;
	private GameScript gameScript;
	private Animator animator;
	private bool seePlayer = false;

	// Use this for initialization
	void Start () {
		game = GameObject.Find("GAME");
		gameScript = game.GetComponent<GameScript>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.F)) {
			QueenSeePlayer();
		}
		if(seePlayer) {
			if(animator.GetCurrentAnimatorStateInfo(0).IsName("sitting idle")) {
				if(gameScript.gameState == "hostile") {
					animator.SetBool("hostile", true);
				}
				else if(gameScript.gameState == "good") {
					animator.SetBool("hostile", false);
				}
			}
			else {
				//queen animation cycle runs only once!
				seePlayer = false;
				animator.SetBool("seePlayer", false); 

			}


			Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("sitting idle"));
				//10 vertices asignetettu bonea 
		}
	}

	public void QueenSeePlayer() {
		seePlayer = true;

		animator.SetBool("seePlayer", true); 
	}
}
