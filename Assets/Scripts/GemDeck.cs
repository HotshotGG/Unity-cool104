using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GemDeck : SingletonMonoBehaviour<GemDeck> 
{
    // 画面
    [SerializeField] public List<GameObject> _gemDeck;

    private static GemDeck instance = null;

    void  Start() {
        
    }
    
    public void Shuffle()
    {
        _gemDeck = _gemDeck.OrderBy(x => Guid.NewGuid ()).ToList();
    }

    public List<GameObject> GetGemDeck()
    {
        return _gemDeck;
    }

     public int GetGemCount()
    {
        return _gemDeck.Count();
    }
    public GameObject GetTopGem()
    {
        return _gemDeck.First();
    }

    public void RemoveTopGem()
    {
        _gemDeck.RemoveAt(0);
    }

}
