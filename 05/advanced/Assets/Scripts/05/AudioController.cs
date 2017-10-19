using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource m_AudioSource;
    // Use this for initialization
    void Start()
    {
        m_AudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            m_AudioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_AudioSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_AudioSource.Pause();
        }
    }
}
