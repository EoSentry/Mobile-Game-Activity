using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    public PlayerController controller;

    private Vector3 _correctScale;

    private void Awake()
    {
        _correctScale = transform.localScale;
    }

    private void Start()
    {
        controller.transform.localScale = Vector3.zero;
        StartCoroutine(PlayerScaleCoroutine());
    }

    public void PlayerInitialScale()
    {
        controller.transform.DOScale(1, .2f).SetEase(Ease.OutBack);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            PlayerInitialScale();
        }
    }

    IEnumerator PlayerScaleCoroutine()
    {
        yield return new WaitForSeconds(.3f);
        PlayerInitialScale();
    }

    public void PlayerScaleOnCollect()
    {
        transform.DOScale(1.2f, .02f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutBack);
    }
}
