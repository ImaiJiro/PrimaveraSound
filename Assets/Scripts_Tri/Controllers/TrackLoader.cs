using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TrackLoader : MonoBehaviour
{

    private int currentLoop = 1;
    private string streamingAssetsPath;
    //-----------------------------------------------Controllers----------------------------------------
    public DJControllerwTracks controller;
    public DJControllerwTracks controller2;
    // ----------------------------------------------ClipsData------------------------------------------
    private float[] tempArray;
    public string[] Clips;
    [HideInInspector]
    public float[] Loop1;
    [HideInInspector]
    public float[] Loop2;
    [HideInInspector]
    public float[] Loop3;
    [HideInInspector]
    public float[] Loop4;
    [HideInInspector]
    public float[] Loop5;
    
    [Obsolete]
    IEnumerator Start()
    {
        //Go Through all the Clips
        for (int i = 0; i < Clips.Length; i++)
        {
            streamingAssetsPath = Application.streamingAssetsPath;

            string filePath = $"{streamingAssetsPath}/{Clips[i]}";

            using (UnityWebRequest www = UnityWebRequest.Get(filePath))
            {
#if UNITY_2017_2_OR_NEWER
                yield return www.SendWebRequest();
#else
            yield return www.Send();
#endif

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.LogError($"Error downloading file: {www.error}");
                    Debug.Log(filePath);
                }
                else
                {
                    string text = www.downloadHandler.text;
                    string loadedDataString = text;
                    string[] loadedDataArray = loadedDataString.Split(',');
                    tempArray = Array.ConvertAll(loadedDataArray, float.Parse);
                    //Load All Clips One By One
                    switch (currentLoop)
                    {
                        case 1:
                            Loop1 = tempArray;
                            currentLoop = 2;
                            break;
                        case 2:
                            Loop2 = tempArray;
                            currentLoop = 3;
                            break;
                        case 3:
                            Loop3 = tempArray;
                            currentLoop = 4;
                            break;
                        case 4:
                            Loop4 = tempArray;
                            currentLoop = 5;
                            break;
                        case 5:
                            Loop5 = tempArray;
                            currentLoop = 1;
                            break;
                        default:
                            Debug.LogError("Invalid loop number");
                            break;
                    }
                }
            }
        }
        Debug.Log("done");
        //Tell The Controllers That We Are Ready To Go!
        controller.Loaddone = true;
        controller2.Loaddone = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
