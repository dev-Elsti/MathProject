using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_to_Target : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    public int targed_Index = 0; Transform tr;
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        targed_Index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move_update();
    }

    void Move_update()
    {
        if (target.Length <= 0)
            return;
        Vector3 dir = target[targed_Index].position - tr.position;
        dir.Normalize(); dir = dir * speed * Time.deltaTime;
        tr.position += dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform == target[targed_Index])
            ChangeTarget();
    }

    void ChangeTarget()
    {
        targed_Index++;
        if (targed_Index > target.Length - 1)
            targed_Index = 0;
    }
}
