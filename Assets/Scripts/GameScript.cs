using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Firebase;
//using Firebase.Database;
//using System.Threading.Tasks;
using System.IO;

public class GameScript : SingletonMonoBehaviour<GameScript> 
{

    public static GameScript instance = null;
    
    // gamen
    [SerializeField] public GameObject _gameCanvas;
    [SerializeField] public List<GameObject> _gemsBase;
    [SerializeField] public GameObject _gameOver;
    [SerializeField] public GameObject _menu;

    [SerializeField] public GameObject _twitter;
    [SerializeField] public GameObject _ok;

    // help
    [SerializeField] public GameObject _helpCanvas;
    [SerializeField] public GameObject _back;
    [SerializeField] public GameObject _rule;
    [SerializeField] public GameObject _quit;

    // Start is called before the first frame update
    void Start()
    {

        GemDeck.Instance.Shuffle();
        
        // drow
        foreach(GameObject gemBase in _gemsBase)
            gemBase.GetComponent<GemBase>().Drow();

    }

    public void ClickHelp()
    {
        _gameCanvas.SetActive(false);
        _helpCanvas.SetActive(true);
    }

    public void ClickBack()
    {
        _helpCanvas.SetActive(false);
        _gameCanvas.SetActive(true);   
    }

    public void ClickTweet()
    {

    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
        _ok.SetActive(true);

        if(PlayerInfo.Instance.GetBestScore() < Sheep.Instance.GetScore())
        {

        }

    }

    public void ClickOk()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }

    public void NextStage()
    {
        if(PlayerInfo.Instance.GetBestScore() < Sheep.Instance.GetScore())
        {

        }
    }

    	//シェア
    /*
	public void Tweet()
	{
        Debug.Log("test");
		StartCoroutine(_Tweet());
	}

	public IEnumerator _Tweet()
	{
		string screenShotPass = Application.persistentDataPath + "/screenShot.png";
		//前回の画像を消す
		File.Delete(screenShotPass);
		//スクリーンショット撮影
		ScreenCapture.CaptureScreenshot("screenShot.png");

		//なんかスクショ撮影のラグがあるから終わるまで待機
		while (true)
		{
			if (File.Exists(screenShotPass)) break;
			yield return null;
		}

		//投稿
		string tweetText = "test";
		string tweetURL = "https://test";
		SocialConnector.PostMessage(SocialConnector.ServiceType.Twitter,tweetText, tweetURL, screenShotPass);
	}
*/

}
