using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    public Text text;
    MyHttp http = new MyHttp();
    // Use this for initialization
    void Start()
    {
        text = text.GetComponent<Text>();
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, Screen.width * 0.2f, Screen.height * 0.1f), "start"))
        {
            //Important: can not contain"?"when create file, you should choose a new download url for testing(ps. or rename the download file's name)
            string url = "http://153.37.232.46/sqdd.myapp.com/myapp/qqteam/AndroidQQ/mobileqq_android.apk?mkey=56417d90de3bd6cf&f=8f5d&p=.apk";
            string file = Application.persistentDataPath + "/download";
            http.Download(url, file);
        }
        if (GUI.Button(new Rect(0, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.1f), "stop"))
        {
            http.Close();
        }
    }
    float testProgress;
    void Update()
    {
        if (testProgress != http.progress)
        {
            testProgress = http.progress;
            text.text = string.Format("下载进度: {0}%", testProgress);
        }
    }
    public void OnApplicationFocus(bool focus)
    {
        if (!focus)
            http.Close();
    }
    public void OnApplicationQuit()
    {
        http.Close();
    }
}