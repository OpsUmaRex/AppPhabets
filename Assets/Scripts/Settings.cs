using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{
    [SerializeField]
    GameObject settingsPanel;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OpenSettingsPanel();
        }
        else if (Input.touchCount > 0)
        {
            OpenSettingsPanel();

            //Touch t = Input.GetTouch(0);

            //switch (t.phase)
            //{
            //    case TouchPhase.Began:
            //        break;

            //    case TouchPhase.Ended:
            //        break;
            //}
        }
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
}
