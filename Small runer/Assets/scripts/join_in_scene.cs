using UnityEngine;
using UnityEngine.SceneManagement;
using static Library;
public class join_in_scene : MonoBehaviour
{


    int NumberScene;
    public void SceneChange(int NumberScene)
    {
        SceneManager.LoadScene(NumberScene);
    }
    public void Exit()
    {
        mainmenu.instance.activeSave.MaxTime = StaticHolder.MaxTime;
        mainmenu.instance.save();
        Application.Quit();
    }

    
    void Update()
    {

    }
}
