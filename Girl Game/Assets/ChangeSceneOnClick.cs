using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    public string sceneName; // The name of the scene you want to load

    private void Start()
    {
        // Attach the OnClick event to your Text element
        Text textElement = GetComponent<Text>();
        textElement.GetComponent<Button>().onClick.AddListener(LoadTargetScene);
    }

    private void LoadTargetScene()
    {
        // Load the target scene when the Text element is clicked
        SceneManager.LoadScene(sceneName);
    }
}
