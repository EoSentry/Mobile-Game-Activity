using System.Collections.Generic;
using UnityEngine;

public class CreateManagers : MonoBehaviour
{
    public List<GameObject> objects;

    public Transform container;


    private void Awake()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            Instantiate(objects[i], container);
        }
    }
}
