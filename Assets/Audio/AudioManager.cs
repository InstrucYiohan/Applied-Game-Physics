using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class AudioItem
    {
        public string name;
        public AudioClip clip;
    }

    public string AudioOnStart;

    public static AudioManager Instance;
    void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        VolumeAdjust(PlayerPrefs.GetFloat("volume", .5f));

        PlayBGM(AudioOnStart);
    }

    public List<AudioItem> AudioList = new List<AudioItem>();

    [SerializeField]
    private AudioSource BGMSource;
    [SerializeField]
    private AudioSource SFXSource;

    public void PlayBGM(string name)
    {
        for (int i = 0; i < AudioList.Count; i++)
        {
            if (AudioList[i].name == name)
            {
                StartCoroutine(PlayLoop(AudioList[i].clip));
                return;
            }
        }
    }

    public void PlayOneshot(string name)
    {
        if (SFXSource == null)
        {
            SFXSource = gameObject.AddComponent<AudioSource>();
        }
        for (int i = 0; i < AudioList.Count; i++)
        {
            if (AudioList[i].name == name)
            {
                SFXSource.PlayOneShot(AudioList[i].clip);

                return;
            }
        }
    }

    IEnumerator PlayLoop(AudioClip clip)
    {
        if (BGMSource == null)
        {
            BGMSource = gameObject.AddComponent<AudioSource>();
        }

        BGMSource.clip = clip;
        BGMSource.loop = true;
        BGMSource.Play();
        yield return null;
    }

    public void VolumeAdjust(float volume)
    {

        BGMSource.volume = volume;
        SFXSource.volume = volume;

        PlayerPrefs.SetFloat("volume", volume);
    }

    public void StopBGM()
    {
        BGMSource.Stop();
    }
}

