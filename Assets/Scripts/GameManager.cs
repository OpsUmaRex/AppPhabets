using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	[SerializeField] Camera theCamera;
    public static GameManager instance = null;
    private RaycastHit2D hit;
    public List<AudioClip> save1Clips = new List<AudioClip>();
    public List<AudioClip> save2Clips = new List<AudioClip>();
    public List<AudioClip> save3Clips = new List<AudioClip>();
    public List<AudioClip> save4Clips = new List<AudioClip>();
    public List<AudioClip> save5Clips = new List<AudioClip>();
    public string save1Alphabet = "";
    public string save2Alphabet = "";
    public string save3Alphabet = "";
    public string save4Alphabet = "";
    public string save5Alphabet = "";

    public int currentIndex = 0;
    public bool hasSaved1;
    public bool hasSaved2;
    public bool hasSaved3;
    public bool hasSaved4;
    public bool hasSaved5;

    void Start()
	{
        if (instance == null)
            instance = this;

        CheckForSaves();
        MusicPlayer.SaveDataStart();
        MusicPlayer.ReloadSounds(this);
    }
    
    public void PlayCurrent(int saveNumber)
    {
        switch (saveNumber)
        {
            case 1:
                MusicPlayer.source.clip = save1Clips[currentIndex];
                break;
            case 2:
                MusicPlayer.source.clip = save2Clips[currentIndex];
                break;
            case 3:
                MusicPlayer.source.clip = save3Clips[currentIndex];
                break;
            case 4:
                MusicPlayer.source.clip = save4Clips[currentIndex];
                break;
            case 5:
                MusicPlayer.source.clip = save5Clips[currentIndex];
                break;
            default:
                break;
        }

        MusicPlayer.source.Play();
    }

    void CheckForSaves()
    {
        MusicPlayer.GetAudioForSave("Save1");
        MusicPlayer.ReloadSounds(this);
        hasSaved1 = (MusicPlayer.clips.Count > 0);
        if (hasSaved1)
        {
            foreach (AudioClip clip in MusicPlayer.clips)
            {
                save1Clips.Add(clip);
            }
        }
        MusicPlayer.GetAudioForSave("Save2");
        MusicPlayer.ReloadSounds(this);
        hasSaved2 = (MusicPlayer.clips.Count > 0);
        if (hasSaved2)
        {
            foreach (AudioClip clip in MusicPlayer.clips)
            {
                save2Clips.Add(clip);
            }
        }
        MusicPlayer.GetAudioForSave("Save3");
        hasSaved3 = (MusicPlayer.clips.Count > 0);
        if (hasSaved3)
        {
            foreach (AudioClip clip in MusicPlayer.clips)
            {
                save3Clips.Add(clip);
            }
        }
        MusicPlayer.GetAudioForSave("Save4");
        MusicPlayer.ReloadSounds(this);
        hasSaved4 = (MusicPlayer.clips.Count > 0);
        if (hasSaved4)
        {
            foreach (AudioClip clip in MusicPlayer.clips)
            {
                save4Clips.Add(clip);
            }
        }
        MusicPlayer.GetAudioForSave("Save5");
        MusicPlayer.ReloadSounds(this);
        hasSaved5 = (MusicPlayer.clips.Count > 0);
        if (hasSaved5)
        {
            foreach (AudioClip clip in MusicPlayer.clips)
            {
                save5Clips.Add(clip);
            }
        }
    }

	// Update is called once per frame
	void Update () 
	{
        if(Input.touchCount > 0)
		    TouchRayCast ();
	}

	void TouchRayCast()
	{
		//for (int i = 0; i < Input.touchCount; ++i) 
		//{
		//	Vector2 test = theCamera.ScreenToWorldPoint (Input.GetTouch (i).position);

		//	if (Input.GetTouch (i).phase == TouchPhase.Began) 
		//	{
		//		test = theCamera.ScreenToWorldPoint (Input.GetTouch (i).position);

		//		RaycastHit2D hit = Physics2D.Raycast (test, (Input.GetTouch (i).position));
		//		if (hit.collider && hit.collider.tag == "Touchable") 
		//		{

		//			AudioSource audioSource = hit.collider.GetComponent<AudioSource> ();
		//			audioSource.Play ();
		//		}
		//	}
		//}
	}
}