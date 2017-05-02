using UnityEngine;
using System.Collections;

public class MyRecorder : MonoBehaviour
{

    AudioClip recording;
    Microphone mic;
    bool isRecording = false;

	// Use this for initialization
	void Start ()
    {
        mic = GetComponent<Microphone>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isRecording)
        {

        }
        if (!isRecording)
        {
            //recording = Microphone.Start("mic", false, );
        }
	}

    public void ToggleRecording()
    {
        isRecording = !isRecording;
    }
}
