using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditButton : MonoBehaviour
{
    public string sceneName = "Credits"; // The name of the scene you want to load

    private void Start()
    {
        // Find the Button component attached to the GameObject
        Button button = GetComponent<Button>();

        // Add a listener to the button's click event
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
