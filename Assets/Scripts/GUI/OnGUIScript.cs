using UnityEngine;
using System.Collections;

public class OnGUIScript : MonoBehaviour {

	//Menubutton
	public Rect menuButtonRect = new Rect(0f, 	//x
	                                   0f,	//y
	                                   0f,	//width
	                                   0f);	//height
	public Rect menuContentButtonRect = new Rect(Screen.width / 2f - 50f, 	//x
                                       		Screen.height / 2f - 25f,		//y
                                       		100f,	//width
                                       		50f);	//height
	private Rect tempMenuContentButtonRect;
	//Healthbar
	public Rect fullHealthBarRect = new Rect(0f, 	//x
	                                     	0f,	//y
	                                     	0f,	//width
	                                     	0f);	//height
	private Rect healthBarRect;	//copy fullHealtBarRect

	public Rect itemRect = new Rect(0f, 	//x
	                                0f,	//y
	                                84f,	//width
	                                84f);	//height
	public int itemCount = 3; //Determinate how many item (what player hold) we want to show in GUI


	private float[] itemXPositions;

	public Texture2D redColorTexture;
	public Texture2D blueColorTexture;
	public Texture2D itemBorderTexture;
	public Texture2D itemBorderSelectedTexture;
	public Texture2D menuContentTexture;
	public Texture2D menuContentButtonTexture;
	private GameObject game;
	private GameScript gameScript;
	private Transform player;

	private int selectedItemIndex = 2;
	private Rect tempItemRect; 

	private MouseLook cameraMouseLookScript;	//y-axes
	private MouseLook playerMouseLookScript; //x-axes

	private float widthRatioToFullHealth; 

	//State machine
	private bool menuOpen = false;
	private bool soundOn = true;



	// Use this for initialization
	void Start () {
		//Rect position initializations
		game = GameObject.Find("GAME");
		gameScript = game.GetComponent<GameScript>();
		cameraMouseLookScript = Camera.main.GetComponent<MouseLook>();
		playerMouseLookScript = gameScript.Player.GetComponent<MouseLook>();
		menuContentButtonRect.x = Screen.width / 2f - 50f;
		menuContentButtonRect.y = Screen.height / 2f - 25f;
	

		fullHealthBarRect.x = Screen.width/2f - fullHealthBarRect.width/2f;
		fullHealthBarRect.y = Screen.height - 5f - fullHealthBarRect.height;

		widthRatioToFullHealth = fullHealthBarRect.width / 100;

		healthBarRect = fullHealthBarRect;

		itemRect.y = Screen.height - 5f - itemRect.height;

		itemXPositions = new float[itemCount];
		for(int i = 0; i < itemXPositions.Length; i++) {
			if(i == 0) {	//first is exception to logic
				itemXPositions[i] = Screen.width - 5f - itemRect.width;
			}
			else {
				itemXPositions[i] = itemXPositions[i - 1] - 10f - itemRect.width;
			}
		}


	}

	void Update () {

		if (Input.GetKeyDown ("0")) {
			ChangeSelectedItemIndex(0);
		}
		else if(Input.GetKeyDown ("1")) {
			ChangeSelectedItemIndex(1);
		}
		else if(Input.GetKeyDown ("2")) {
			ChangeSelectedItemIndex(2);
		}

		else if(Input.GetKeyDown ("3")) {
			ChangeSelectedItemIndex(3);
		}
		else if(Input.GetKeyDown ("4")) {
			ChangeSelectedItemIndex(4);
		}
		else if(Input.GetKeyDown ("5")) {
			ChangeSelectedItemIndex(5);
		}
		else if(Input.GetKeyDown ("6")) {
			ChangeSelectedItemIndex(6);
		}
		else if(Input.GetKeyDown ("7")) {
			ChangeSelectedItemIndex(7);
		}
		else if(Input.GetKeyDown ("8")) {
			ChangeSelectedItemIndex(8);
		}
		else if(Input.GetKeyDown ("9")) {
			ChangeSelectedItemIndex(9);
		}
		else if(Input.GetKeyDown(KeyCode.Escape)) {
			//Open menu
			toggleMenu();
		}
			
	}

	void OnGUI() {
		if(menuOpen) {
			tempMenuContentButtonRect = menuContentButtonRect;

			if(GUI.Button(tempMenuContentButtonRect, "Return to game")) {
				toggleMenu();
			}
			tempMenuContentButtonRect.y += tempItemRect.height + 20f;
			if(GUI.Button(tempMenuContentButtonRect, soundOn ? "Mute" : "Turn sound ON")) {
				//Toggle sound
				//do if you have time
			}
			tempMenuContentButtonRect.y += tempItemRect.height + 20f;
			if(GUI.Button(tempMenuContentButtonRect, "Exit to menu")) {
				Application.LoadLevel(0);
			}
		}
		//draw blue bar (health and maxhealth difference)
		GUI.DrawTexture(fullHealthBarRect, blueColorTexture);
		
		//Draw red bar (health)
		GUI.DrawTexture(healthBarRect, redColorTexture);

		//Draw itemBorderTextures
		tempItemRect = itemRect;

		for(int i = 0; i < itemXPositions.Length; i++) {
			tempItemRect.x = itemXPositions[i];	//change original rect our calculated x value

			//if i == selectedItemIndex => item is selected and border texture is different
			GUI.DrawTexture(tempItemRect, (i == selectedItemIndex) ? itemBorderSelectedTexture : itemBorderTexture); 
		}
	}

	//whichone number user pressed: would be 0 - 9
	public void ChangeSelectedItemIndex(int whichOne) {
		if(whichOne > itemCount) return;
		
		selectedItemIndex = itemCount - whichOne;
	}

	private void toggleMenu() {
		//toggle menu and game timescale

		menuOpen = (menuOpen == false);
		Screen.showCursor = menuOpen ? false : true;
		Debug.Log ("MenuOpen" + menuOpen);
		
		Time.timeScale = ((Time.timeScale == 0) ? 1 : 0);
		Debug.Log ("Timescale: " + Time.timeScale);

		if(cameraMouseLookScript != null)
			Debug.Log("CameraMouseLookScript gamepause state: " + cameraMouseLookScript.toggleGamePause());
		if(playerMouseLookScript != null)
			Debug.Log("PlayerMouseLookScript gamepause state: " + playerMouseLookScript.toggleGamePause());
	}

	public void increaseDecreaseHealth(int amount) {
		if(healthBarRect.width + amount <= fullHealthBarRect.width && healthBarRect.width + amount >= 0)
			healthBarRect.width += amount * widthRatioToFullHealth;
	}
}
