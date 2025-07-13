using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] float invokeDelayTime = 2f;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip successSFX;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;

    AudioSource audioSource;

    bool isControllable = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (!isControllable){ return; }
        switch (other.gameObject.tag)
        {
            case "Launch Pad":
                Debug.Log("Ready");
                return;
            case "Landing Pad":
                LevelPassSequence();
                return;
            default:
                CrashSequence();
                return;
        }
    }

    private void LevelPassSequence()
    {
        isControllable = false;
        successParticle.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("LoadNextLevel", invokeDelayTime);

    }
    private void CrashSequence()
    {
        isControllable = false;
        crashParticle.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("LoadSameLevel", invokeDelayTime);
    }
    private void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        //Need to change again when we are adding End menu!!
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
    private void LoadSameLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
