using UnityEngine;
using Ebac.Core.singleton;

public class ItemCollactableCoin : ItemCollactableBase
{
    public Collider collider;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    protected override void OnCollect()
    {
        base.OnCollect();
        //Verificar linha abaixo
        ItemManager.Instance.AddCoins();
        collider.enabled = false;
        collect = true;
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position,
           PlayerController.Instance.transform.position, lerp * Time.deltaTime);
            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) <
           minDistance)
            {
                //HideItens();
                Destroy(gameObject);
            }
        }
    }


}
