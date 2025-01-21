using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image _imagePanel;
    [SerializeField] private DeathCharacter _deathCharacter;
    [SerializeField] private Transform _transformCamera;
    [SerializeField] private Transform _gameOverMenu;
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartGame);
    }


    private void Start()
    {
        _transformCamera.DOMove(new Vector3(-0.5f, -0.5f, -10), 1f );
        _imagePanel.DOFade(0, 2f);

        _deathCharacter.Death += ShowGameOverMenu;
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveAllListeners();
    }

    private void ShowGameOverMenu()
    {
        _imagePanel.DOFade(1, 2f);
        _gameOverMenu.DOScale(new Vector3(3, 5, 1), 0.5f);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
}
