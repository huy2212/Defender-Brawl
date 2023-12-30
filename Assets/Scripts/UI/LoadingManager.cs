using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance { get; private set; }
    public delegate void LoadSceneDelegate(int sceneIndex);
    public event LoadSceneDelegate OnSceneLoaded;
    public event System.Action OnLoadScene;
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject LoadingBar;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public void LoadScene(int sceneIndex)
    {
        OnLoadScene?.Invoke();
        StartCoroutine(LoadAsynchronously(sceneIndex));
        OnSceneLoaded?.Invoke(sceneIndex);
    }

    public void ReLoadScene()
    {
        OnLoadScene?.Invoke();
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex));
        OnSceneLoaded?.Invoke(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        LoadingScreen?.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        Slider slider = LoadingBar?.GetComponent<Slider>();

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
        LoadingScreen?.SetActive(false);
        slider.value = 0f;
    }
}