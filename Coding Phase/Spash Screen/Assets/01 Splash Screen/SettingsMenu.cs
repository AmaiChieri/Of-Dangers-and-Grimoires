using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {

	#region Variables
	public GUISkin skin;
	public GUIStyle selectionGridStyle;
	public int menuChoice = 0;
	public bool 
		isAudioLoud = false,
		isMusicLoud = false;
	public float 
		musicVolume,
		audioVolume;
	public GameObject mainMenu;

	private Rect menuBox;
	private int menuID = 1;
	private string[] menuChoices = {"reset game", "music", "audio", "back"};
	#endregion
	
	/**************************************************************************
     * This region is used for getters and setters to clamp/validate values
     * passed to the parameters. Every important public values must be clamped
     *************************************************************************/
	#region Clamping
	public int _menuChoice {
		get {
			return menuChoice = Mathf.Clamp(menuChoice, 0, menuChoices.Length - 1);
		}
		set {
			menuChoice = Mathf.Clamp(value, 0, menuChoices.Length - 1);
		}
	}
	public float _musicVolume {
		get {
			return musicVolume = Mathf.Clamp(musicVolume, 0.0f, 100.0f);
		}
		set {
			musicVolume = Mathf.Clamp(value, 0.0f, 100.0f);

			/* Change the audio for music background game object*/
			GameObject musicBackground = GameObject.Find("04 Music Background");
			Debug.Log(_musicVolume);
			musicBackground.audio.volume=(float)_musicVolume/100;
		}
	}
	public float _audioVolume {
		get {
			return audioVolume = Mathf.Clamp(audioVolume, 0.0f, 100.0f);
		}
		set {
			audioVolume = Mathf.Clamp(value, 0.0f, 100.0f);
			
			GameObject buttonNav = GameObject.Find("05 Button Nav");
			buttonNav.audio.volume= (float) audioVolume / 100;
		}
	}
	public bool _isMusicLoud {
		get {
			return isMusicLoud;
		}
		set {
			isMusicLoud = value;
			
			/* Change the audio for music background game object*/
			GameObject musicBackground = GameObject.Find("04 Music Background");
			Debug.Log(_musicVolume);
			musicBackground.audio.volume=value==true?(float)_musicVolume/100:0;
		}
	}
	public bool _isAudioLoud {
		get {
			return isAudioLoud;
		}
		set {
			isAudioLoud = value;

			GameObject buttonNav = GameObject.Find("05 Button Nav");
			Debug.Log("The audio volume is " + _audioVolume);
			buttonNav.audio.volume=value==true?(float)_audioVolume/100:0;
		}
	}
	#endregion

	/* Use this for initialization */
	void Start () {
		menuBox = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 75, 200, 300);

	}
	
	/* Update is called once per frame */
	void Update () {
		
		handleChangeSelection();
		handleMusicVolume();
		handleAudioVolume();
		handleBack();
	}

	void OnGUI() {
		GUI.skin = skin;
		menuBox = GUILayout.Window(menuID, menuBox, doMenu, "settings");

	}

	void handleBack(){
		if(menuChoices[_menuChoice] == "back") {
			if(Input.GetKeyDown(KeyCode.Return)){
				mainMenu.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
	}

	void handleMusicVolume(){
		if(menuChoices[_menuChoice] == "music") {
		   	if(Input.GetKey(KeyCode.RightArrow)){
				_musicVolume+=1;
			}
			else if(Input.GetKey(KeyCode.LeftArrow)){
				_musicVolume-=1;
			}
			else if(Input.GetKeyDown(KeyCode.Return)){
				_isMusicLoud = !_isMusicLoud;
			}
		}

	}
	
	void handleAudioVolume(){
		if(menuChoices[_menuChoice] == "audio") {
			if(Input.GetKey(KeyCode.RightArrow)){
				_audioVolume+=1;
			}
			else if(Input.GetKey(KeyCode.LeftArrow)){
				_audioVolume-=1;
			}
			else if(Input.GetKeyDown(KeyCode.Return)){
				_isAudioLoud = !_isAudioLoud;
			}
		}
	}

	void handleChangeSelection(){
		
		/*handles changes in selection*/
		if (Input.GetKeyDown(KeyCode.DownArrow)) {

			GameObject buttonNav = GameObject.Find("05 Button Nav");
			if(_menuChoice+1 < menuChoices.Length ) {
				buttonNav.audio.Play();
			}

			_menuChoice = _menuChoice + 1;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			
			GameObject buttonNav = GameObject.Find("05 Button Nav");
			if(_menuChoice+1 != 0 ) {
				buttonNav.audio.Play();
			}

			_menuChoice = _menuChoice - 1;
		}
	}

	void doMenu(int iD){
		GUILayout.Space(55);
		_menuChoice = GUILayout.SelectionGrid(_menuChoice, menuChoices, 1, selectionGridStyle);

		if(menuChoices[_menuChoice] == "music"){
			if(_isMusicLoud == true) {
				musicVolume = GUI.HorizontalSlider(new Rect(50,158,98,20),musicVolume,0,100);
			}
			_isMusicLoud = GUI.Toggle(new Rect(150,137,20,20),_isMusicLoud,"");
		}
		else if(menuChoices[_menuChoice] == "audio") {
			if(isAudioLoud == true){
				audioVolume = GUI.HorizontalSlider(new Rect(50,188,98,20),audioVolume,0,100);
			}
			isAudioLoud = GUI.Toggle(new Rect(150,167,20,20),isAudioLoud,"");
		}
	}
}
