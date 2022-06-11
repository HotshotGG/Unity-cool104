using UnityEngine;

public class GemBase : MonoBehaviour
{

    // label
    [SerializeField] public GameObject _labelObject;
    
    private GameObject _go;
    private GameObject _gem;
    private GameObject _label;
    private GemDeck _gd;

    public void Awake()
    {
        _go = this.gameObject;
        _label = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void Drow()
    {
        if (GemDeck.Instance.GetGemCount() <= 0)
        {
            _gem = null;
            return;
        }
            
        _gem = (GameObject)Instantiate(GemDeck.Instance.GetTopGem());
        _gem.transform.SetParent(_go.transform, false);   
        _gem.transform.SetSiblingIndex(1);
        GemDeck.Instance.RemoveTopGem();
    }

    public bool setLabel()
    {
        if (_gem == null)
        {
            this._label.SetActive(false);
            return false;
        }
        
        if((Sheep.Instance.Suit == _gem.GetComponent<Gem>().Suit || Sheep.Instance.Number == _gem.GetComponent<Gem>().Number) ||
            (Sheep.Instance.Suit == 0 && Sheep.Instance.Number == 0))
        {
            this._label.SetActive(true);
            return true;
        }
        else
        {
            this._label.SetActive(false);
            return false;
        }
    }

    public GameObject GetGem()
    {
        return _gem;
    }

        

}
