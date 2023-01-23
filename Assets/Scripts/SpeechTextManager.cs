using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class SpeechTextManager : MonoBehaviour
{
    [SerializeField] private string language = "id";
    //en-US
    [SerializeField] private Text uiText;

    [Serializable] 
    public struct VoiceComand
    {
        public string keyword;
        public UnityEvent response;
    }

    public VoiceComand[] voiceComands;

    private Dictionary<string, UnityEvent> comands = new Dictionary<string, UnityEvent>();

    private void Awake()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
        foreach (var comand in voiceComands)
        {
            comands.Add(comand.keyword.ToLower(), comand.response);
        }
        if (PlayerPrefs.GetInt("bahasa") == 0)
        {
            language = "id";
        }
        else
        {
            language = "en-US";
        }

    }


    void Start()
    {
        if (PlayerPrefs.GetInt("bahasa") == 0)
        {
            language = "id";
        }
        else
        {
            language = "en-US";
        }

        //uiText.text = "";
        TextToSpeech.Instance.Setting(language, 1, 1);
        SpeechToText.Instance.Setting(language);

        SpeechToText.Instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.Instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.Instance.onDoneCallback = OnSpeakStop;

#if UNITY_ANDROID
        SpeechToText.Instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
    }
    
    //Speech to text
    public void StartListening()
    {
        uiText.text = "a";
        SpeechToText.Instance.StartRecording();
    }
    public void StopListening()
    {
        SpeechToText.Instance.StopRecording();
    }
    public void OnFinalSpeechResult(string result)
    {
        uiText.text = result;
        if (result != null)
        {
            var response = comands[result.ToLower()];
            if (response != null)
            {
                response?.Invoke();
            }
        }
    }

    public void OnPartialSpeechResult(string result)
    {
        uiText.text = result;
    }

    //text to speech
    public void StartSpeaking(string message)
    {
        TextToSpeech.Instance.StartSpeak(message);
    }
    public void StopSpeaking()
    {
        TextToSpeech.Instance.StopSpeak();
    }

    public void OnSpeakStart()
    {
        Debug.Log("Talking Start...");
    }

    public void OnSpeakStop()
    {
        Debug.Log("Talking stop...");
    }


}
