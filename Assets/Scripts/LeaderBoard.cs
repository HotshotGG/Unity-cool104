using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using Firebase.Database;

public class LeaderBoard : SingletonMonoBehaviour<LeaderBoard> 
{

    private GameObject go;
    //private FirebaseManager fb = FirebaseManager.Instance;
    //private DataSnapshot snapshot = null;

    void Start()
    {
        go = this.gameObject;
        //StartCoroutine(fb.GetLogData2());
        //Debug.Log(result);
    }

    public void setText(string s)
    {
        go.GetComponent<Text>().text = s;
    }

    public string getText()
    {
        return go.GetComponent<TextMeshProUGUI>().text.ToString();
    }

}
