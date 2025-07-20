using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // [SerializeField] AudioSource audioSource;
    // void Start()
    // {
    //     audioSource = GetComponent<AudioSource>();
    // }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
