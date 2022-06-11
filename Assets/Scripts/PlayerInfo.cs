using System;
using UnityEngine;
using TMPro;

public class PlayerInfo : SingletonMonoBehaviour<PlayerInfo> 
{
    // 画面
    private GameObject go;
    private SaveManager _sm;

    private int _playTimes;
    private int _bestScore;
    private DateTime _lastUpdated;

    void Start()
    {
        go = this.gameObject;
        _sm = SaveManager.Instance;

        _sm.Load();
        //_playTimes = _sm._saveData._playTimes;
        //_bestScore = _sm._saveData._bestScore;
        //_lastUpdated = _sm._saveData._lastUpdated;

        go.GetComponent<TextMeshProUGUI>().text = "Play Times : " + _playTimes.ToString() + "\n"
                                                + "Best Score : " + _bestScore.ToString() + "\n"
                                                + "Last Updated : " + _lastUpdated.ToString();
    }
    
    public int GetBestScore()
    {
        return _bestScore;
    }

}
