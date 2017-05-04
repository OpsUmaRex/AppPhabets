using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    [SerializeField]
    string sceneToLoad;
        public void NextScene(string sceneToLoad)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown (0))
        {
            NextScene(sceneToLoad);
        }
        else if (Input.touchCount > 0)
        {
            NextScene(sceneToLoad);

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
}