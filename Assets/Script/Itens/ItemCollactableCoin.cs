using UnityEngine;
using Ebac.Core.singleton;

public class ItemCollactableCoin : ItemCollactableBase
{

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
    }
}
