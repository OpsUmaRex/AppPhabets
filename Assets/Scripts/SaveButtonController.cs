using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject recordingPanel;
    [SerializeField]
    GameObject deletePrompt;
    [SerializeField]
    GameObject SaveButtonPanel;
    [SerializeField]
    Text deletePromptText;
    
    void Awake()
    {

    }

    public void SaveButtonPressed(int saveNumber)
    {
        switch (saveNumber)
        {
            case 1:
                if (GameManager.instance.hasSaved1)
                {
                    deletePrompt.SetActive(true);
                    deletePromptText.text = "Do you want to delete Save 1?";
                    DeletePanelController.WhichSave = "Save1";
                    SaveButtonPanel.SetActive(false);
                }
                else
                {
                    recordingPanel.SetActive(true);
                    GameManager.instance.currentIndex = GameManager.instance.save1Clips.Count;
                    RecordPanelController.whichSaveNumber = 1;
                    recordingPanel.GetComponent<RecordPanelController>().UpdateInfo();
                    SaveButtonPanel.SetActive(false);
                }
                break;
            case 2:
                if (GameManager.instance.hasSaved2)
                {
                    deletePrompt.SetActive(true);
                    deletePromptText.text = "Do you want to delete Save 2?";
                    DeletePanelController.WhichSave = "Save2";
                    SaveButtonPanel.SetActive(false);
                }
                else
                {
                    recordingPanel.SetActive(true);
                    GameManager.instance.currentIndex = GameManager.instance.save2Clips.Count;
                    RecordPanelController.whichSaveNumber = 2;
                    recordingPanel.GetComponent<RecordPanelController>().UpdateInfo();
                    SaveButtonPanel.SetActive(false);
                }
                break;
            case 3:
                if (GameManager.instance.hasSaved3)
                {
                    deletePrompt.SetActive(true);
                    deletePromptText.text = "Do you want to delete Save 3?";
                    DeletePanelController.WhichSave = "Save3";
                    SaveButtonPanel.SetActive(false);
                }
                else
                {
                    recordingPanel.SetActive(true);
                    GameManager.instance.currentIndex = GameManager.instance.save3Clips.Count;
                    RecordPanelController.whichSaveNumber = 3;
                    recordingPanel.GetComponent<RecordPanelController>().UpdateInfo();
                    SaveButtonPanel.SetActive(false);
                }
                break;
            case 4:
                if (GameManager.instance.hasSaved4)
                {
                    deletePrompt.SetActive(true);
                    deletePromptText.text = "Do you want to delete Save 4?";
                    DeletePanelController.WhichSave = "Save4";
                    SaveButtonPanel.SetActive(false);
                }
                else
                {
                    recordingPanel.SetActive(true);
                    GameManager.instance.currentIndex = GameManager.instance.save4Clips.Count;
                    RecordPanelController.whichSaveNumber = 4;
                    recordingPanel.GetComponent<RecordPanelController>().UpdateInfo();
                    SaveButtonPanel.SetActive(false);
                }
                break;
            case 5:
                if (GameManager.instance.hasSaved5)
                {
                    deletePrompt.SetActive(true);
                    deletePromptText.text = "Do you want to delete Save 5?";
                    DeletePanelController.WhichSave = "Save5";
                    SaveButtonPanel.SetActive(false);
                }
                else
                {
                    recordingPanel.SetActive(true);
                    GameManager.instance.currentIndex = GameManager.instance.save5Clips.Count;
                    RecordPanelController.whichSaveNumber = 5;
                    recordingPanel.GetComponent<RecordPanelController>().UpdateInfo();
                    SaveButtonPanel.SetActive(false);
                }
                break;
            default:

                break;
        }
    }
}
