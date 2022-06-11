using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sheep : SingletonMonoBehaviour<Sheep> 
{
    // 画面
    private int _suit;
    private int _number;
    private int _ScoreForSave;

    private GameObject _go;

    [SerializeField] public GameObject _explosion;

    [SerializeField] public Sprite _white;
    [SerializeField] public Sprite _bule;
    [SerializeField] public Sprite _green;
    [SerializeField] public Sprite _orenge;
    [SerializeField] public Sprite _red;

    [SerializeField] public GameObject _hp;
    [SerializeField] public GameObject _Score;

    void Start()
    {
        _go = this.gameObject;
        _suit = 0;
        _number = 0;
    }

    public void ChangeSheep(int suit, int number)
    {
        this._suit = suit;
        this._number = number;

        switch (suit)
        {
            case 1: _go.GetComponent<SpriteRenderer>().sprite = _bule; break;
            case 2: _go.GetComponent<SpriteRenderer>().sprite = _green; break;
            case 3: _go.GetComponent<SpriteRenderer>().sprite = _orenge; break;
            case 4: _go.GetComponent<SpriteRenderer>().sprite = _red; break;
            default: _go.GetComponent<SpriteRenderer>().sprite = _white; break;
        }

        string s;
        switch (number)
        {
            case 1: s = "A";break;
            case 10: s = "T";break;
            case 11: s = "J";break;
            case 12: s = "Q";break;
            case 13: s = "K"; break;
            default: s = number.ToString(); break;
        }

        _go.transform.GetChild(0).GetComponent<TextMeshPro>().text = s;
    }

    public int Suit
    {
        set { this._suit = value; }
        get { return this._suit; }
    }

    public int Number
    {
        set { this._number = value; }
        get { return this._number; }
    }

    public float GetXPositon()
    {
        return _go.transform.position.x;
    }

    public float GetYPositon()
    {
        return _go.transform.position.y;
    }
    
    public void DoExplosion()
    {
        Instantiate(_explosion, this.transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        //StartCoroutine(Sample());
        //_go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f ,0));
    }

    private IEnumerator Sample() 
    {
        _go.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0);
        while (true) 
        {
            // 毎フレームループします
            yield return null;
            if(_go.transform.localPosition.x > 100)
                _go.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 0, 0);

            if(_go.transform.localPosition.x < -100)
                _go.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0);   
        }
    }

    public void TakeDamage()
    {
        _hp.GetComponent<Slider>().value -= 1.0f;
        _ScoreForSave += 1;
        _Score.GetComponent<TextMeshProUGUI>().text =  _hp.GetComponent<Slider>().value.ToString() +"/52";
    } 

    public int GetScore()
    {
        return _ScoreForSave;
    }

}
