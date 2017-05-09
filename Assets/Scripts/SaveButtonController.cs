using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveButtonController : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    GameObject recordingPanel;
    [SerializeField]
    GameObject deletePrompt;
    [SerializeField]
    Text deletePromptText;
    
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void SaveButtonPressed(int saveNumber)
    {
        switch (saveNumber)
        {
            case 1:
                if (gameManager.hasSaved1)
                {
                    deletePrompt.SetActive(true);
                    deletePromptText.text = "Do you want to delete Save 1?";
                    DeletePanelController.WhichSave = "Save1";
                }
                else
                {
                    recordingPanel.SetActive(true);
                    gameManager.currentIndex = gameManager.save1Clips.Count;
                    RecordPanelController.whichSaveNumber = 1;
                }
                break;
            case 2:
                if (gameManager.hasSaved2)
                {
                    deletePrompt.SetActive(true);
                    deletePromptText.text = "Do you want to delete Save 2?";
                    DeletePanelController.WhichSave = "Save2";
                }
                else
                {
                    recordingPanel.SetActive(true);
                    gameManager.currentIndex = gameManager.save2Clips.Count;
                    RecordPanelController.whichSaveNumber = 2;
                }
                break;
            case 3:
                if (gameManager.hasSaved3)
                {
                    deletePrompt.SetActive(true);
                    deletePromptText.text = "Do you want to delete Save 3?";
                    DeletePanelController.WhichSave = "Save3";
                }
                else
                {
                    recordingPanel.SetActive(true);
                    gameManager.currentIndex = gameManager.save3Clips.Count;
                    RecordPanelController.whichSaveNumber = 3;
                }
                break;
            case 4:
                if (gameManager.hasSaved4)
                {
                    deletePrompt.SetActive(true);
                    deletePromptText.text = "Do you want to delete Save 4?";
                    DeletePanelController.WhichSave = "Save4";
                }
                else
                {
                    recordingPanel.SetActive(true);
                    gameManager.currentIndex = gameManager.save4Clips.Count;
                    RecordPanelController.whichSaveNumber = 4;
                }
                break;
            case 5:
                if (gameManager.hasSaved5)
                {
                    deletePrompt.SetActive(true);
                    deletePromptText.text = "Do you want to delete Save 5?";
                    DeletePanelController.WhichSave = "Save5";
                }
                else
                {
                    recordingPanel.SetActive(true);
                    gameManager.currentIndex = gameManager.save5Clips.Count;
                    RecordPanelController.whichSaveNumber = 5;
                }
                break;
            default:

                break;
        }
    }
}
