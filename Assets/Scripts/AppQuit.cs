using UnityEngine;
using System.Collections;

public class AppQuit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if UNITY_ANDROID
        Application.Quit();
#endif

#if UNITY_IOS
        Application.Quit();
#endif

    }
}
