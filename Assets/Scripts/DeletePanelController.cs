using UnityEngine;
using System.Collections;

public class DeletePanelController : MonoBehaviour
{
    public static string WhichSave = "";

    [SerializeField]
    GameObject recordPanel;
    [SerializeField]
    GameObject deletePanel;

    public void YesButton()
    {
        MusicPlayer.DeleteSaveData(WhichSave);
        recordPanel.SetActive(true);
        deletePanel.SetActive(false);
        GameManager.instance.currentIndex = 0;
    }

    public void NoButton()
    {
        recordPanel.SetActive(true);
        deletePanel.SetActive(false);
    }
}
