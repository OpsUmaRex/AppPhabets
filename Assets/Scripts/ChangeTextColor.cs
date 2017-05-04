using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour
{

    [SerializeField]
    Toggle toggleBool;
    [SerializeField]
    Color disabledTextColor;
    [SerializeField]
    Color enabledTextColor;
    [SerializeField]
    Text textToChangeColor;
	
	// Update is called once per frame
	void Update ()
    {
        if (toggleBool.isOn)
            textToChangeColor.color = enabledTextColor;
        else
            textToChangeColor.color = disabledTextColor;
	}
}
