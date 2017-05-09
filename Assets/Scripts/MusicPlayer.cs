﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> clips = new List<AudioClip>();

    [SerializeField]
    [HideInInspector]
    private int currentIndex = 0;

    private FileInfo[] soundFiles;
    private List<string> validExtensions = new List<string> { ".wav" }; // Don't forget the "." i.e. "ogg" won't work - cause Path.GetExtension(filePath) will return .ext, not just ext.
    private string absolutePath = "./"; // relative path to where the app is running - change this to "./music" in your case
    private string appDirectory = "/AppPhabets";
    private const string save1Directory = "/Save1";
    public string Save1Directory
    {
        get { return gallaryDir + appDirectory + save1Directory; }
    }
    private const string save2Directory = "/Save2";
    public string Save2Directory
    {
        get { return gallaryDir + appDirectory + save2Directory; }
    }
    private const string save3Directory = "/Save3";
    public string Save3Directory
    {
        get { return gallaryDir + appDirectory + save3Directory; }
    }
    private const string save4Directory = "/Save4";
    public string Save4Directory
    {
        get { return gallaryDir + appDirectory + save4Directory; }
    }
    private const string save5Directory = "/Save5";
    public string Save5Directory
    {
        get { return gallaryDir + appDirectory + save5Directory; }
    }
    private string gallaryDirDefault = "";
    string gallaryDir = "";

    void Start()
    {

#if UNITY_ANDROID && !UNITY_EDITOR
        string appDirectoryPath = "";
		AndroidJavaClass jc = new AndroidJavaClass("android.os.Environment");
		var state = jc.CallStatic<System.String>("getExternalStorageState");
		var mountState = jc.GetStatic<System.String>("MEDIA_REMOVED");
		
		if (state.Equals(mountState))
		{

			gallaryDir = "mnt/emmc/";
            gallaryDirDefault = "mnt/emmc/";
		}
		else
		{
			var jo = jc.CallStatic<AndroidJavaObject>("getExternalStorageDirectory");
			var sdcardPath = jo.Call<string>("getCanonicalPath");


			gallaryDir = sdcardPath;
            gallaryDirDefault = sdcardPath;

            appDirectoryPath = gallaryDir + appDirectory;

            if (Directory.Exists(appDirectoryPath) == false)
            {
                Directory.CreateDirectory(appDirectoryPath);
            }
            
            appDirectoryPath = gallaryDir + appDirectory + save1Directory;

            if (Directory.Exists(appDirectoryPath) == false)
            {
                Directory.CreateDirectory(appDirectoryPath);
            }
            
            appDirectoryPath = gallaryDir + appDirectory + save2Directory;

            if (Directory.Exists(appDirectoryPath) == false)
            {
                Directory.CreateDirectory(appDirectoryPath);
            }
            
            appDirectoryPath = gallaryDir + appDirectory + save3Directory;

            if (Directory.Exists(appDirectoryPath) == false)
            {
                Directory.CreateDirectory(appDirectoryPath);
            }
            
            appDirectoryPath = gallaryDir + appDirectory + save4Directory;

            if (Directory.Exists(appDirectoryPath) == false)
            {
                Directory.CreateDirectory(appDirectoryPath);
            }
            
            appDirectoryPath = gallaryDir + appDirectory + save5Directory;

            if (Directory.Exists(appDirectoryPath) == false)
            {
                Directory.CreateDirectory(appDirectoryPath);
            }
        
		}        

#endif

        if (source == null) source = gameObject.AddComponent<AudioSource>();

        //ReloadSounds();
    }

    public void GetAudioForSave(string saveName)
    {
        switch (saveName)
        {
            case "Save1":
                gallaryDir = gallaryDirDefault + appDirectory + save1Directory;
                break;
            case "Save2":
                gallaryDir = gallaryDirDefault + appDirectory + save2Directory;
                break;
            case "Save3":
                gallaryDir = gallaryDirDefault + appDirectory + save3Directory;
                break;
            case "Save4":
                gallaryDir = gallaryDirDefault + appDirectory + save4Directory;
                break;
            case "Save5":
                gallaryDir = gallaryDirDefault + appDirectory + save5Directory;
                break;
        }

        ReloadSounds();
    }

    void PlayCurrent()
    {
        source.clip = clips[currentIndex];
        source.Play();
    }

    void ReloadSounds()
    {
        clips.Clear();
        // get all valid files
        var info = new DirectoryInfo(gallaryDir);
        soundFiles = info.GetFiles()
            .Where(f => IsValidFileType(f.Name))
            .ToArray();

        // and load them
        foreach (var s in soundFiles)
            StartCoroutine(LoadFile(s.FullName));
    }

    bool IsValidFileType(string fileName)
    {
        return validExtensions.Contains(Path.GetExtension(fileName));
        // Alternatively, you could go fileName.SubString(fileName.LastIndexOf('.') + 1); that way you don't need the '.' when you add your extensions
    }

    IEnumerator LoadFile(string path)
    {
        WWW www = new WWW("file://" + path);
        print("loading " + path);

        AudioClip clip = www.GetAudioClip(false);
        while (!clip.isReadyToPlay)
            yield return www;

        print("done loading");
        clip.name = Path.GetFileName(path);
        clips.Add(clip);
    }
}
