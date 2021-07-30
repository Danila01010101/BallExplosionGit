using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public void ChangeSize(Vector3 magnificationSize)
    {
        gameObject.transform.localScale += magnificationSize;
    }
}
