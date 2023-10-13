using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class IntermediateGlobal : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audio;
    [SerializeField]
    private int maxAudioSource = 1;
    protected AudioSource[] _Speaker;  // audio source asosicada a la entidad
    [Range(0f, 1f)]
    public float minVol, maxVol, SourceVol;  // volumenes máximo y mínimo establecidos y volumen origintal del source
    [Range(0f, 30f)]
    public float minTime, maxTime;  // intervalo temporal de lanzamiento
    [Range(0, 50)]
    public int distRand, maxDist;
    public float spatialBlend;
    public bool enablePlayMode;
    public bool loop_ = false;
    public bool pitchVariation = false;
    public float ISound = 0.2f;
    public float ISoundCondition = 0.2f;
    // Start is called before the first frame update
    void Awake()
    {
        _Speaker = new AudioSource[maxAudioSource];
        for (int i = 0; i < maxAudioSource; i++)
        {
            _Speaker[i] = gameObject.AddComponent<AudioSource>();
            _Speaker[i].playOnAwake = true;
            _Speaker[i].loop = loop_;
            _Speaker[i].volume = ISound;
        }

    }
    void Start()
    {


    }
    public AudioSource getChannel()
    {
        int ch = 0;
        while (ch < maxAudioSource && _Speaker[ch].isPlaying) ch++;
        if (ch < maxAudioSource)
        {
            return _Speaker[ch];
        }
        else return null;
    }
    void PlaySound(AudioSource source)
    {
        SetSourceProperties(audio[Random.Range(0, audio.Length)], minVol, maxVol, distRand, maxDist, spatialBlend, source);
        if (pitchVariation)
            source.pitch = Random.Range(0.95f, 1.05f);
        Debug.Log($"Canal  Sample  pitch {_Speaker[0].pitch}");
        if (ISound >= ISoundCondition)
            source.Play();


    }



    public void SetSourceProperties(AudioClip audioData, float minVol, float maxVol,
                                    int minDist, int maxDist, float SpatialBlend, AudioSource source)
    {
        source.loop = false;
        source.maxDistance = maxDist - Random.Range(0f, distRand);
        source.spatialBlend = spatialBlend;
        source.clip = audioData;
        source.volume = SourceVol + Random.Range(minVol, maxVol);
    }




    void StopSound()
    {
        enablePlayMode = false;
        Debug.Log("stop");
    }


    void Update()
    {
        
        StartCoroutine("Waitforit");
    }
    IEnumerator Waitforit()
    {
       
        float waitTime = Random.Range(minTime, maxTime);
        if(loop_)waitTime = 0f;

        Debug.Log(waitTime);
        AudioSource source = getChannel();

        // miramos si hay un clip asignado al source (sirve para la primera vez q se ejecuta)
        if (source == null)
            // waitfor seconds suspende la coroutine durante waitTime
            yield return new WaitForSeconds(waitTime);

        // cuando hay clip se añade la long del clip + el tiempo de espera para esperar entre lanzamientos
        else
        {
            float lenght_ = 0;
            if (loop_) lenght_ = 0;
            else if (source.clip != null) lenght_ = source.clip.length;

            yield return new WaitForSeconds(lenght_ + waitTime);
        }


        //// si esta activado reproducimos sonido
        if (enablePlayMode && source) {
            Debug.Log("sonando "+minTime+ " "+maxTime);
            PlaySound(source); }
    }
}
