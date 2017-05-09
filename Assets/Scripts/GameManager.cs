using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	[SerializeField] Camera theCamera;
    [SerializeField] MusicPlayer musicPlayer;
    [SerializeField] AudioSource source;

    private RaycastHit2D hit;
    public List<AudioClip> save1Clips = new List<AudioClip>();
    public List<AudioClip> save2Clips = new List<AudioClip>();
    public List<AudioClip> save3Clips = new List<AudioClip>();
    public List<AudioClip> save4Clips = new List<AudioClip>();
    public List<AudioClip> save5Clips = new List<AudioClip>();

    public int currentIndex = 0;
    public bool hasSaved1;
    public bool hasSaved2;
    public bool hasSaved3;
    public bool hasSaved4;
    public bool hasSaved5;

    void Start()
	{
        CheckForSaves();
    }
    
    public void PlayCurrent(int saveNumber)
    {
        switch (saveNumber)
        {
            case 1:
                source.clip = save1Clips[currentIndex];
                break;
            case 2:
                source.clip = save2Clips[currentIndex];
                break;
            case 3:
                source.clip = save3Clips[currentIndex];
                break;
            case 4:
                source.clip = save4Clips[currentIndex];
                break;
            case 5:
                source.clip = save5Clips[currentIndex];
                break;
            default:
                break;
        }

        source.Play();
    }

    void CheckForSaves()
    {
        musicPlayer.GetAudioForSave("Save1");
        hasSaved1 = (musicPlayer.clips.Count > 0);
        if (hasSaved1)
        {
            foreach (AudioClip clip in musicPlayer.clips)
            {
                save1Clips.Add(clip);
            }
        }
        musicPlayer.GetAudioForSave("Save2");
        hasSaved2 = (musicPlayer.clips.Count > 0);
        if (hasSaved2)
        {
            foreach (AudioClip clip in musicPlayer.clips)
            {
                save2Clips.Add(clip);
            }
        }
        musicPlayer.GetAudioForSave("Save3");
        hasSaved3 = (musicPlayer.clips.Count > 0);
        if (hasSaved3)
        {
            foreach (AudioClip clip in musicPlayer.clips)
            {
                save3Clips.Add(clip);
            }
        }
        musicPlayer.GetAudioForSave("Save4");
        hasSaved4 = (musicPlayer.clips.Count > 0);
        if (hasSaved4)
        {
            foreach (AudioClip clip in musicPlayer.clips)
            {
                save4Clips.Add(clip);
            }
        }
        musicPlayer.GetAudioForSave("Save5");
        hasSaved5 = (musicPlayer.clips.Count > 0);
        if (hasSaved5)
        {
            foreach (AudioClip clip in musicPlayer.clips)
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
		for (int i = 0; i < Input.touchCount; ++i) 
		{
			Vector2 test = theCamera.ScreenToWorldPoint (Input.GetTouch (i).position);

			if (Input.GetTouch (i).phase == TouchPhase.Began) 
			{
				test = theCamera.ScreenToWorldPoint (Input.GetTouch (i).position);

				RaycastHit2D hit = Physics2D.Raycast (test, (Input.GetTouch (i).position));
				if (hit.collider && hit.collider.tag == "Letter") 
				{

					AudioSource audioSource = hit.collider.GetComponent<AudioSource> ();
					audioSource.Play ();
				}
			}
		}
	}
}