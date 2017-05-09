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
    AudioClip clip;

	void Awake ()
    {

	}

    void Update()
    {
        UpdateRecordImage();
    }

    List<Sprite> DetermineWhichAlphabet(List<AudioClip> clips)
    {
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
        recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
    }

    public void UpdateInfo()
    {
        letterText.text = foodLetters[0].name;
        switch (whichSaveNumber)
        {
            case 1:
                referenceList = DetermineWhichAlphabet(GameManager.instance.save1Clips);
                recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
                saveInfoText.text = GameManager.instance.save1Clips[0].name;
                break;
            case 2:
                referenceList = DetermineWhichAlphabet(GameManager.instance.save2Clips);
                recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
                saveInfoText.text = GameManager.instance.save2Clips[0].name;
                break;
            case 3:
                referenceList = DetermineWhichAlphabet(GameManager.instance.save3Clips);
                recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
                saveInfoText.text = GameManager.instance.save3Clips[0].name;
                break;
            case 4:
                referenceList = DetermineWhichAlphabet(GameManager.instance.save4Clips);
                recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
                saveInfoText.text = GameManager.instance.save4Clips[0].name;
                break;
            case 5:
                referenceList = DetermineWhichAlphabet(GameManager.instance.save5Clips);
                recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
                saveInfoText.text = GameManager.instance.save5Clips[0].name;
                break;
            default:
                break;
        }
    }
	
    void OnEnable()
    {
        letterText.text = foodLetters[0].name;
        switch (whichSaveNumber)
        {
            case 1:
                referenceList = DetermineWhichAlphabet(GameManager.instance.save1Clips);
                recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
                saveInfoText.text = GameManager.instance.save1Clips[0].name;
                break;
            case 2:
                referenceList = DetermineWhichAlphabet(GameManager.instance.save2Clips);
                recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
                saveInfoText.text = GameManager.instance.save2Clips[0].name;
                break;
            case 3:
                referenceList = DetermineWhichAlphabet(GameManager.instance.save3Clips);
                recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
                saveInfoText.text = GameManager.instance.save3Clips[0].name;
                break;
            case 4:
                referenceList = DetermineWhichAlphabet(GameManager.instance.save4Clips);
                recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
                saveInfoText.text = GameManager.instance.save4Clips[0].name;
                break;
            case 5:
                referenceList = DetermineWhichAlphabet(GameManager.instance.save5Clips);
                recordingIndicator.sprite = referenceList[GameManager.instance.currentIndex];
                saveInfoText.text = GameManager.instance.save5Clips[0].name;
                break;
            default:
                break;
        }
    }
}
