using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image _imagePanel;
    [SerializeField] private Transform _transformCamera;

    private void Start()
    {
        _transformCamera.DOMove(new Vector3(-0.5f, -0.5f, -10), 1f );
        _imagePanel.DOFade(0, 2f);
    }
}
