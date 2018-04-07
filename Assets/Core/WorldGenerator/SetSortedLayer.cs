using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSortedLayer : MonoBehaviour
{
    public int ID;

    private SpriteRenderer _renderer;

    private void Start()
    {
        this._renderer = this.GetComponent<SpriteRenderer>();
        this._renderer.sortingLayerID = this.ID;
    }

}
