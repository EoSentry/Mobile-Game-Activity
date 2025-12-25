using Unity.VisualScripting;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Transform obj;
    public float speed = 2;

    private void Awake()
    {
        if(obj == null)
            obj = GetComponent<Transform>();
    }

    void Update()
    {
        obj.transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
