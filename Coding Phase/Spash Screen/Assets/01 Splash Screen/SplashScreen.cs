
/******************************************************************************
 * 
 * ***************************************************************************/

#region Namespaces
using UnityEngine;
using System.Collections;
#endregion

public class SplashScreen : MonoBehaviour {

    #region Variables
    private MovieTexture movie;
    private bool
        isMovieStarted = false,
        isSwitchoutStarted = false;
    private Hashtable colorTweenParams = new Hashtable();

    public GameObject loadNext;
    public bool isPlayStartTriggered = false;
    public int fadeOutTime = 3;
    public Color fadeToColor = Color.black;
    #endregion

    void Awake() {

        /* set the parameters for fade out */
        colorTweenParams.Add("name", "colorToTransparent");
        colorTweenParams.Add("from", guiTexture.color);
        colorTweenParams.Add("to", this.fadeToColor);
        colorTweenParams.Add("time", this.fadeOutTime);
        colorTweenParams.Add("easetype", iTween.EaseType.easeOutExpo);
        colorTweenParams.Add("onupdate", "colorChange");

    }

    /* Use this for initialization */
    void Start() {
        movie = guiTexture.texture as MovieTexture;
        
    }

    /* Update is called once per frame */
    void Update() {

        if (isMovieStarted == false) {
            if (movie.isReadyToPlay == true && isPlayStartTriggered == true) {

                /* play both movie and audio together*/
                movie.Play();
                audio.Play();

                /* set flag to true*/
                isMovieStarted = true;
            }
        }
        else if (isMovieStarted == true) {
            /* here the movie already ended */
            if (movie.isPlaying == false) {

                /* start the switchOut if there is any */
                if (isSwitchoutStarted == false) {

                    /* Consider changing this, FPS<60 upon call of ValueTo */
                    iTween.ValueTo(this.gameObject, colorTweenParams);

                    if (loadNext != null) {
                        loadNext.SetActive(true);
                    }

                    isSwitchoutStarted = true;
                }
                else if (isSwitchoutStarted == true) {
                    /* do nothing */
                }
                return;
            }
            else if (movie.isPlaying == true) {
                /* do nothing */
            }
        }
    }

    public void OnGUI() {
        
        GUI.depth = 0; 
    }

    public void colorChange(Color currentColor) {
        guiTexture.color = currentColor;
    }

}
