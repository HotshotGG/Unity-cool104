using UnityEngine;

public class MiniGemBase : SingletonMonoBehaviour<MiniGemBase> 
{

    private GameObject _go;
    private GemDeck _gd;

    private static MiniGemBase instance = null;
    public static MiniGemBase GetInstance()
    {
        return instance;
    }

    public void Start()
    {
        _go = this.gameObject;
    }
    
        // deleteMinigem
    public void DeleteMiniGem(int suit, int number)
    {
         foreach(var child in _go.GetComponentsInChildren<Gem>())
         {
            if(child._suit == suit && child._number == number)
            {
                Destroy(child.transform.gameObject);
            }
            else if (child._suit == suit || child._number == number)
            {
                child.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                child.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            }
         }
        
    }

}
