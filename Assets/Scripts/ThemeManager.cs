using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class ThemeManager : MonoBehaviour
{
    [SerializeField]
    Toggle animalToggle;
    [SerializeField]
    Toggle foodToggle;
    [SerializeField]
    Toggle meteorToggle;
    [SerializeField]
    GameObject animalBackground;
    [SerializeField]
    GameObject foodBackground;
    [SerializeField]
    GameObject meteorBackground;
    [SerializeField]
    GameObject defaultBackground;
    [SerializeField]
    ToggleGroup bgToggleGroup;

    List<Toggle> bgToggles;
    Toggle activeToggle;

    // Use this for initialization
    void Start ()
    {
        defaultBackground.SetActive(true);
        bgToggles = new List<Toggle>();
        AddTogglesToList();
    }

    void AddTogglesToList()
    {
        bgToggles.Add(animalToggle);
        bgToggles.Add(foodToggle);
        bgToggles.Add(meteorToggle);
    }
	
    public void ToggleBackground(Toggle activatingToggle)
    {
        
        if (activatingToggle.isOn)
        {
            if (activatingToggle == animalToggle)
            {
                defaultBackground.SetActive(false);
                animalBackground.SetActive(true);
            }
            else if (activatingToggle == foodToggle)
            {
                defaultBackground.SetActive(false);
                foodBackground.SetActive(true);
            }
            else if (activatingToggle == meteorToggle)
            {
                defaultBackground.SetActive(false);
                meteorBackground.SetActive(true);
            }
        }
        else
        {
            animalBackground.SetActive(false);
            foodBackground.SetActive(false);
            meteorBackground.SetActive(false);
            defaultBackground.SetActive(true);
        }

        //if (activeToggle == activatingToggle)
        //{
        //    animalBackground.SetActive(false);
        //    foodBackground.SetActive(false);
        //    meteorBackground.SetActive(false);
        //    defaultBackground.SetActive(true);
        //}
    }

    public void StartButtonLoad()
    {
        bool hasActiveToggle = false;

        foreach(Toggle tog in bgToggles)
        {
            if (tog.isOn)
            {
                activeToggle = tog;
                hasActiveToggle = true;
                break;
            }
            else
                hasActiveToggle = false;
        }

        Debug.Log(hasActiveToggle);

        if (hasActiveToggle)
        {
            Debug.Log(activeToggle.name);
            switch (activeToggle.name)
            {
                case "AnimalToggle":
                    SceneManager.LoadScene("AnimalScene");
                    break;
                case "FoodToggle":
                    SceneManager.LoadScene("FoodScene");
                    break;
                case "MeteorToggle":
                    SceneManager.LoadScene("MeteorScene");
                    break;
                default:
                    SceneManager.LoadScene("MainMenu");
                    break;
            }
        }
        else
        {
            SceneManager.LoadScene("AlphabetSongScene");
        }

    }

	// Update is called once per frame
	void Update ()
    {
	
	}
}
