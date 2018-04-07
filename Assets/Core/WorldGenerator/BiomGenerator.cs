using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] LavaBiom;
    [SerializeField]
    private GameObject[] SandBiom;
    [SerializeField]
    private GameObject[] ForestBiom;

    private GameObject[] _currentPlatforms;

    [SerializeField]
    public Vector3 PositionRight;
    [SerializeField]
    public Vector3 PositionLeft;

    private int _biomSize;

    [SerializeField]
    private float directionLeft;
    [SerializeField]
    private float directionRight;

    private float _currentOffset;
    private Vector3 _currentPosition;


    private Bioms _currentBiom;


    private void Start()
        => this._biomSize = 0;

    public void Generate(string direction)
    {

        if (this._biomSize == 0)
        {
            this._biomSize = Random.Range(90, 250);
            this._currentBiom = (Bioms)Random.Range(0,2);

            switch (this._currentBiom)
            {
                case Bioms.Sand:
                    this._currentPlatforms = this.SandBiom;
                    break;
                case Bioms.Vulkan:
                    this._currentPlatforms = this.LavaBiom;
                    break;
                case Bioms.Forest:
                    this._currentPlatforms = this.ForestBiom;
                    break;
                default:
                    break;
            }
        }

        if (direction == "left")
        {
            this._currentOffset = this.directionLeft;
            this._currentPosition = this.PositionLeft;
        }
        else
        {
            this._currentOffset = this.directionRight;
            this._currentPosition = this.PositionRight;
        }

        int temp = this._biomSize;
        GameObject platform;
        for (int i = 0; i < temp; i++)
        {
            platform = Instantiate(this._currentPlatforms[Random.Range(0, this._currentPlatforms.Length - 1)], this._currentPosition, new Quaternion(0,0,0,0));
            this._currentPosition.x += this._currentOffset;
            this._biomSize--;

            if (direction == "left")
                this.PositionLeft = this._currentPosition;
            else
                this.PositionRight = this._currentPosition;

        }
    }


    public enum Bioms
    {
        Forest,
        Sand,
        Vulkan
    }
}
