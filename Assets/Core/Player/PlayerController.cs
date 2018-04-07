using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMove))]
public class PlayerController : MonoBehaviour
{
    private CharacterMove _characterMove;

    public BiomGenerator worldController;

    // Use this for initialization
    void Start()
        => this._characterMove = this.gameObject.GetComponent<CharacterMove>();

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Horizontal"))
            this._characterMove.Move();

        if (Input.GetKeyDown(KeyCode.L))
            this.worldController.Generate("right");

        if (Input.GetKeyDown(KeyCode.K))
            this.worldController.Generate("left");

    }
}
 