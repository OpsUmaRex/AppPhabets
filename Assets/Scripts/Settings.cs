using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Settings : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject settingsPanel;

    [SerializeField]
    Camera theCamera;

    private RaycastHit2D hit;

    void Update()
    {
        TouchRayCast();
    }

    void TouchRayCast()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Vector2 test = theCamera.ScreenToWorldPoint(Input.GetTouch(i).position);

            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                test = theCamera.ScreenToWorldPoint(Input.GetTouch(i).position);

                RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(i).position));
                if (hit.collider && hit.collider.tag == "Touchable")
                {
                    OpenSettingsPanel();
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenSettingsPanel();
    }

    void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
}
