using UnityEngine;
using UnityEngine.SceneManagement;
public class join_in_scene : MonoBehaviour
{


    int NumberScene;
    public void SceneChange(int NumberScene)
    {
        SceneManager.LoadScene(NumberScene);
    }
    public void Exit()
    {
        Application.Quit();
    }

    
    void Update()
    {

    }
}
