using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScene;
    
	public void Loadlevel( int sceneIndex)
    {

        StartCoroutine(LoadAsynchronously());

    }

    IEnumerator LoadAsynchronously()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync("NivellCiutat");

        //loadingScene.SetActive(true);

        yield return null;
      
    }
}
