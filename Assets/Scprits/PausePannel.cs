using UnityEngine;

public class PausePannel : MonoBehaviour
{
public GameObject PausePanel; // Drag your Pause UI panel here in Inspector

    void Start()
    {
        // Make sure the game starts unpaused
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausePanel.activeSelf)
                Continue();
            else
                Pause();
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
