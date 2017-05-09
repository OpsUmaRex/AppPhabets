using UnityEngine;
using System.IO;
using System.Collections;
using UnityEngine.UI;

public class Recorder : MonoBehaviour
{
    
    public string state;//The recorder state
	AudioClip clip;//Audio clip we use to save the record
    [SerializeField]
    AudioSource source;
    [SerializeField]
    Camera theCamera;
    [SerializeField]
    Image recordButton;
    [SerializeField]
    Text saveInfoText;

    string gallaryDir = "";

    void Start () 
	{
		state = "Not Recording";//The first state
    }

    // Update is called once per frame
    void Update () 
	{
        if (Input.touchCount > 0)
            TouchRayCast();
        //     if (Input.touchCount > 0) {//If there is any touch

        //	Touch t = Input.GetTouch (0);//Get first touch finger

        //	switch (t.phase) {
        //	case TouchPhase.Began://When the user start to touch 
        //	    state = "Recording.....";
        //		clip = Microphone.Start ("", false, 5, 44100);
        //		Debug.Log ("start to record");
        //		break;

        //	case TouchPhase.Ended://End of the touch

        //		if (Microphone.IsRecording ("")) {//if the recorder is recording
        //				Debug.Log ("End record");

        //				Microphone.End ("");//stop to record
        //		}

        //		Debug.Log ("start to save");
        //	    state = "Successful save";
        //		WavHelper.Save ("FileName ", clip);//Save the voice recorded

        //                 source.clip = clip;
        //                 source.Play();

        //		break;

        //	}
        //}

        //debugText.text = WavHelper.debugFilePath;
    }

    void TouchRayCast()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Vector2 test = theCamera.ScreenToWorldPoint(Input.GetTouch(i).position);

            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                test = theCamera.ScreenToWorldPoint(Input.GetTouch(i).position);

                RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(i).position));
                if (hit.collider && hit.collider.tag == "Touchable")
                {
                    recordButton.color = Color.red;
                    state = "Recording.....";
                    clip = Microphone.Start("", false, 2, 44100);
                }
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                if (Microphone.IsRecording(""))
                {//if the recorder is recording
                    Debug.Log("End record");

                    Microphone.End("");//stop to record
                }

                recordButton.color = Color.green;
                string filename = GameObject.Find("ImageOfRecording").GetComponent<Image>().sprite.name;

                Debug.Log("start to save");
                state = "Successful save";
                WavHelper.Save(filename, clip, saveInfoText.text);//Save the voice recorded

                source.clip = clip;
                source.Play();
            }
        }
    }

    IEnumerator WaitForAudioToPlay()
    {
        yield return new WaitForSeconds(clip.length);

        GameManager.instance.currentIndex++;
    }
 //   void OnGUI()
	//{

	//	GUI.enabled = false;//to make the text not editable
	//	GUI.Label (new Rect (0, 0, 300, 100), "Tap to record then release to save your record");//Info label
	//	GUI.Label (new Rect (0, 100, 100, 100), state);//To view recorder state
	//	GUI.enabled = true;//return the gui to normal state


	//}
}
