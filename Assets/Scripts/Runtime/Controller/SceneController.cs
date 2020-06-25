using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneController<T> : SingletonBehaviour<T> where T : MonoBehaviour
{
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    public void LoadSceneByIndexAdditive(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Additive);
    }

    public void LoadSceneByIndexAsync(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
    }

    public void LoadSceneByIndexAsyncAdditive(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    }

    public void UnLoadSceneByIndexAsync(int index)
    {
        SceneManager.UnloadSceneAsync(index);
    }
}
