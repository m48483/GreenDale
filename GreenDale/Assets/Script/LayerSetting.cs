using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LayerSetting : MonoBehaviour
{
    // Start is called before the first frame update
    TilemapRenderer sr;
    void Start()
    {
        sr = GetComponent<TilemapRenderer>();
        sr.sortingOrder = Mathf.RoundToInt(transform.position.y) * -1;
    }

}
