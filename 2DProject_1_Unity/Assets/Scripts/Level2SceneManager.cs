using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    public GameObject potatoChip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void HitChipBag()
    {
        Instantiate(potatoChip, new Vector3(-13, 3.75f, 0), Quaternion.identity);
        Instantiate(potatoChip, new Vector3(-10, .5f, 0), Quaternion.identity);
        Instantiate(potatoChip, new Vector3(-6.5f, -1, 0), Quaternion.identity);
        Instantiate(potatoChip, new Vector3(-2.5f, 3.75f, 0), Quaternion.identity);
        Instantiate(potatoChip, new Vector3(0, -1, 0), Quaternion.identity);
        Instantiate(potatoChip, new Vector3(3, -4, 0), Quaternion.identity);
        Instantiate(potatoChip, new Vector3(3, 2, 0), Quaternion.identity);
        Instantiate(potatoChip, new Vector3(6.5f, 2, 0), Quaternion.identity);
        Instantiate(potatoChip, new Vector3(9.5f, 1, 0), Quaternion.identity);
    }
}
