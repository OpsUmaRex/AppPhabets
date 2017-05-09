using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RecordPanelController : MonoBehaviour
{
    public static int whichSaveNumber = 0;

    [SerializeField]
    List<Sprite> foodLetters = new List<Sprite>();
    [SerializeField]
    List<Sprite> animalLetters = new List<Sprite>();
    [SerializeField]
    List<Sprite> defaultLetters = new List<Sprite>();
    [SerializeField]
    Image recordingIndicator;
    [SerializeField]
    Text saveInfoText;
    [SerializeField]
    Text letterText;

    List<Sprite> referenceList = new List<Sprite>();
    GameManager gameManager;
    AudioClip clip;

	void Awake ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

    void Update()
    {
        UpdateRecordImage();
    }

    List<Sprite> DetermineWhichAlphabet(List<AudioClip> clips)
    {
        saveInfoText.text = clips[0].name;
        letterText.text = foodLetters[0].name;
        List<Sprite> returnList = new List<Sprite>();
        if (clips[0] != null)
        {
            if (clips[0].name == foodLetters[0].name)
                returnList = foodLetters;
            else if (clips[0].name == animalLetters[0].name)
                returnList = animalLetters;
            else if (clips[0].name == defaultLetters[0].name)
                returnList = defaultLetters;
        }

        return returnList;
    }

    public void UpdateRecordImage()
    {
        recordingIndicator.sprite = referenceList[gameManager.currentIndex];
    }
	
    void OnEnable()
    {
        switch (whichSaveNumber)
        {
            case 1:
                referenceList = DetermineWhichAlphabet(gameManager.save1Clips);
                recordingIndicator.sprite = referenceList[gameManager.currentIndex];
                break;
            case 2:
                referenceList = DetermineWhichAlphabet(gameManager.save2Clips);
                recordingIndicator.sprite = referenceList[gameManager.currentIndex];
                break;
            case 3:
                referenceList = DetermineWhichAlphabet(gameManager.save3Clips);
                recordingIndicator.sprite = referenceList[gameManager.currentIndex];
                break;
            case 4:
                referenceList = DetermineWhichAlphabet(gameManager.save4Clips);
                recordingIndicator.sprite = referenceList[gameManager.currentIndex];
                break;
            case 5:
                referenceList = DetermineWhichAlphabet(gameManager.save5Clips);
                recordingIndicator.sprite = referenceList[gameManager.currentIndex];
                break;
            default:
                break;
        }
    }
}
