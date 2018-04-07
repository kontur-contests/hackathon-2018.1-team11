using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMove))]
public class PlayerController : MonoBehaviour
{
    private CharacterMove _characterMove;

    // Use this for initialization
    void Start()
        => this._characterMove = this.gameObject.GetComponent<CharacterMove>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
            this._characterMove.Move();
    }
}
 