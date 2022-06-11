using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Gem : MonoBehaviour
{   

    [SerializeField] public int _suit;
    [SerializeField] public int _number;

    private MiniGemBase _mg;

    private bool _lookAtOn = false;

    private EventSystem _es;

    // gem
    private GameObject _go;

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

    public void Awake()
    {
        _go = this.gameObject;
        _mg = MiniGemBase.Instance;

        _es = EventSystem.current;
    }

    public void Delete() 
    {
        Destroy(this);
    }

    void Update() {
        if(_lookAtOn)
            TransformExtensions.LookAt2D(this.transform, Vector3.zero,Vector2.up);
    }

    public void GemClick (BaseEventData eventData)
	{
        _es.enabled = false;

        // base取得
        GemBase gm = this.transform.parent.gameObject.GetComponent<GemBase>();

        // 押せるかどうか
        if(gm._labelObject.activeSelf)
        {
            Sheep.Instance.Suit  = this._suit;
            Sheep.Instance.Number = this._number;
        }
        else
        {
            _es.enabled =　true;
            return;
        }

        _es.enabled =　true;
        
        // move
        this.Move(this._suit, this._number);

        // miniGem
        _mg.DeleteMiniGem(this._suit, this._number);

        // drow
        this.transform.parent.gameObject.GetComponent<GemBase>().Drow();
    
        // CheckStatus
        bool isAllfalse = false;
        foreach(GameObject gemBase in GameScript.Instance._gemsBase)
        {
            bool isLabelOn = gemBase.GetComponent<GemBase>().setLabel();
            if(isLabelOn)
                isAllfalse = true;
        }

        if(!isAllfalse)
            GameScript.Instance.GameOver();
	}

    // move
    public void Move(int suit, int number)
    {
        float xrand = Random.Range(-2.5f, 2.5f);
        float yrand = Random.Range(-2.0f, -1.0f);
    
		// オーブの軌跡設定
		Vector3[] path = {
			//new Vector3(this.transform.parent.position.x + xrand, this.transform.parent.position.y + yrand, 0f), //中間点
            new Vector3(xrand, yrand, 0f), //中間点
			new Vector3(Sheep.Instance.GetXPositon(), Sheep.Instance.GetYPositon(), 0f)		    //終点
		};

        _lookAtOn = true;

        var sequence = DOTween.Sequence(); //Sequence生成
        sequence.Append(this.transform.DOPath(path, 0.5f, PathType.CatmullRom))
                .AppendCallback(() => 
                {
                    Sheep.Instance.ChangeSheep(suit, number);
                });    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        Sheep.Instance.DoExplosion();
        Sheep.Instance.TakeDamage();
    }
}
