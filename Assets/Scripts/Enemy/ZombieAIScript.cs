using UnityEngine;
using System.Collections;

public class ZombieAIScript : MonoBehaviour {

	private GameObject game;
	private GameScript gameScript;
	private GameObject player;
	private Animator animator;
	private Vector3 target;

	private CharacterController characterController;

	private bool move = true; 
	public float moveSpeed;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		game = GameObject.Find("GAME");
		gameScript = game.GetComponent<GameScript>();
		player = gameScript.Player.gameObject;
		animator = transform.FindChild("zombi1animated").gameObject.GetComponent<Animator>();


		target = player.transform.position;

		target.y = transform.position.y;
		animator.SetBool("walking1", Random.Range(0, 2) == 0 ? true : false);
		Debug.Log("walking1: " + animator.GetBool("walking1"));
		move = true;
	}

	// Update is called once per frame
	void Update () {
		if(!move) return;

		Vector3 moveDirection = target - transform.position;

		/*if(moveDirection.magnitude < 1f) {
			//very close
			Debug.Log("very close!");
		}
		else {*/
			transform.LookAt(target);
			characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
			//characterController.Move(Vector3.forward * moveSpeed * Time.deltaTime);
		//}
		
	//	Debug.Log (characterController.velocity.magnitude);


		//transform.position += transform.forward * moveSpeed * Time.deltaTime;
		//animator.SetFloat("speed", characterController.velocity.magnitude);
			



		//characterController.Move(player.transform.position);
		

	}


	public void MoveOn() {
		move = true;
	}
}
