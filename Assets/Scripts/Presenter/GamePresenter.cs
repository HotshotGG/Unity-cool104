using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GamePresenter : MonoBehaviour
{
    // View
    [SerializeField]
    private GameView _view;

    // Model
    private GameModel _model;

    // キャラクターのPresenter
    [SerializeField]
    private CharacterPresenter _character;

    // 経過時間のPresenter
    [SerializeField]
    private TimePresenter _time;

    // Start処理
    private void Start()
    {
        _model = new GameModel();

        _character.Initialize(_model.GameSetting.CharacterSpeed);
        _time.Initialize();

        Bind();
        SetEvents();
    }

    // Update処理
    private void FixedUpdate()
    {
        var deltaTime = Time.fixedDeltaTime;

        if (_model.IsFinished)
        {
            return;
        }
        _character.ManualUpdate(deltaTime);
        _time.ManualUpdate(deltaTime);
    }

    // Bind処理
    private void Bind()
    {
        _model.IsFinishedProperty
            .Subscribe(_view.SetGoalVisible)
            .AddTo(this);
    }

    // イベント設定
    private void SetEvents()
    {
        _character.OnDistanceChangedCallback = OnDistanceChanged;
    }

    // 進行距離が変更された際に呼ばれる
    private void OnDistanceChanged(float distance)
    {
        if (distance >= _model.GoalDistance)
        {
            _model.SetIsFinished(true);
        }
    }
}