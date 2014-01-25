using UnityEngine;
using System.Collections;

public class StartingMenuGUIScript : MonoBehaviour {

	public float menuButtonWidth = 100f; //Buttons width
	public float menuButtonHeight = 100f;	//Button height
	public float menuContentWidth = 100f;
	public float menuContentHeight = 100f;
	public float gutter = 5f; //space between buttons (y-pos)

	private Rect startGameRect = new Rect(0f,	//x
	                                      0f,	//y
	                                      0f,	//width
	                                      0f);	//height
	private Rect creditsRect 	= new Rect(0f,	//x
	                                      0f,	//y
	                                      0f,	//width
	                                      0f);	//height
	private Rect guideRect 		= new Rect(0f,	//x
	                                     0f,	//y
	                                     0f,	//width
	                                     0f);	//height
	private Rect menuContentRect = new Rect(0f,	//x
	                                    0f,	//y
	                                    0f,	//width
	                                    0f);	//height

	private float menuButtonX = 0f; 			//buttons x-pos
	private float menuButtonStartingY = 0f; //where is first button Y-pos

	public Texture2D menuButtonTexture = null;
	public Texture2D menuContentTexture = null;
	public string startingScene = "Scene0";

	private bool showMenuContent = false;

	void Start () {

		menuButtonStartingY = Screen.height / 4f;
		menuButtonX = 25f;

		startGameRect.width = menuButtonWidth;
		startGameRect.height = menuButtonHeight;
		startGameRect.x = menuButtonX;
		startGameRect.y = menuButtonStartingY;

		creditsRect.width = menuButtonWidth;
		creditsRect.height = menuButtonHeight;
		creditsRect.x = menuButtonX;
		creditsRect.y = menuButtonStartingY + menuButtonHeight + gutter;

		guideRect.width = menuButtonWidth;
		guideRect.height = menuButtonHeight;
		guideRect.x = menuButtonX;
		guideRect.y = creditsRect.y + menuButtonHeight + gutter;


		menuContentRect.width = menuContentWidth;
		menuContentRect.height = menuContentHeight;
		menuContentRect.x = menuButtonX + menuButtonWidth + gutter;
		menuContentRect.y = menuButtonStartingY;

	}

	void OnGUI() {
		if(menuButtonTexture == null ? GUI.Button(startGameRect, "Start Game") :
   										GUI.Button(startGameRect, menuButtonTexture)) {
			//Start the game!
			Application.LoadLevel(startingScene);
		}
		if(menuButtonTexture == null ? GUI.Button(creditsRect, "Credits") : 
   									GUI.Button(creditsRect, menuButtonTexture)) {
			//Credits
			showMenuContent = (showMenuContent == false);
		}
		if(menuButtonTexture == null ? GUI.Button(guideRect, "Guides") : 
		   								GUI.Button(guideRect, menuButtonTexture)) {
			//Show controls (not required)
		}

		if(showMenuContent) {
			GUI.contentColor = Color.black;
			GUI.DrawTexture(menuContentRect, menuContentTexture);
			GUI.Label(menuContentRect, "Credits:\n\nJoni Ahola - Programmer\nHeikki Tikkanen - Map creator, Programmer" +
				"Music producter\nAki Leinonen - Game Design, 2D Graphics, 3D modelling \nLaura Haapamäki - 3D Modelling\nMimosa Lehtinen 2D Graphics, Concept Art");

		}
	}


}
