using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PowerUpBase : ItemCollactableBase
{
    [Header("Power Up")]
    public float duration;
    public Transform player;
    private void OnValidate()
    {
        if(player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
                player = p.transform;
        }
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
    }
    protected virtual void StartPowerUp()
    {
        Debug.Log("Start Power Up");
        Invoke(nameof(EndPowerUp), duration);
        StartCoroutine(PlayerScale());
    }
    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up");
    }

    IEnumerator PlayerScale()
    {
        player.transform.DOScale(1.3f, .12f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(.13f);
        player.transform.DOScale(1, .12f).SetEase(Ease.OutBack);
    }
}
