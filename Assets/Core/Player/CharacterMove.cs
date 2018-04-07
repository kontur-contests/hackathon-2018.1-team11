using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private float _defalutSpeedValue;
    [SerializeField]
    private float _runSpeedValue;

    public float Speed;

    [SerializeField]
    private float _stamina = 50.0f;
    public float Stamina
    {
        get
        {
            if (this._stamina > 10.0f)
                this._stamina = 10.0f;
              
            else if (this._stamina <= 0.0f)
                 this._stamina = 0.0f;

            return this._stamina;
        }
    }

    private bool _isRun;

    private SpriteRenderer _renderer;


    private void Start() 
        => this._renderer = this.gameObject.GetComponent<SpriteRenderer>();

    public void Move()
    {
        float movement = Input.GetAxis("Horizontal") * this.Speed * Time.deltaTime;

        this.transform.position += new Vector3(movement, 0);

        this._renderer.flipX = Input.GetKey(KeyCode.D);


        if (Input.GetKeyDown(KeyCode.LeftShift))
            this._isRun = true;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            this._isRun = false;

        if (this._isRun)
        {
            if (this._stamina != 0f)
            {
                this.Speed = this._runSpeedValue;
                this._stamina--;
            }
            else
            {
                this.Speed = this._defalutSpeedValue;
            }
        }

        if (this._isRun != true)
            this.Speed = this._defalutSpeedValue;

        if (this._stamina == 0f)
            this.StartCoroutine(StaminaRepair());
        

    }


    IEnumerator StaminaRepair()
    {
        yield return new WaitForSeconds(5f);
        while(this._stamina != 50f)
        {
            this._stamina++;
            yield return new WaitForSeconds(10f);
        }

        yield break;
    }
}
