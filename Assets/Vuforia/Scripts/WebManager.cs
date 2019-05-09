using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class WebManager : MonoBehaviour
{

    public static string SITE_LINK;

    public static string jsonString;
    private static string streamingPath;

    void Start() {
        
        #if UNITY_ANDROID
            streamingPath = "jar:file://" + Application.dataPath + "!/assets/";
        #endif

        #if UNITY_IOS
            streamingPath = Application.dataPath + "/Raw";
        #endif

        #if UNITY_EDITOR
            streamingPath = Application.dataPath + "/StreamingAssets";
        #endif

        StartCoroutine(GetText());
    }

    public static void WebSaveData(){

        string directoryPath = streamingPath + @"/FeneartSave";

        print(Directory.Exists(directoryPath));
        if(!Directory.Exists(directoryPath)){
            Directory.CreateDirectory(directoryPath);
        }
        
        string path = directoryPath + @"/feneart2019.txt";

        if(File.Exists(path)){
            File.Delete(path);
        }

        if(!File.Exists(path)){
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(jsonString);
            }
        }
    }

    public static string WebLoadData(){

        string path = streamingPath + @"/FeneartSave/feneart2019.txt";

        if(File.Exists(path)){
            using (StreamReader sr = new StreamReader(path))
            {
                jsonString += sr.ReadLine();
                print(jsonString);
            }
        }

        return jsonString;
    }
 
    IEnumerator GetText() {

        UnityWebRequest www = UnityWebRequest.Get(SITE_LINK);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            jsonString = www.downloadHandler.text;
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }

        WebLoadData();
    }
}
