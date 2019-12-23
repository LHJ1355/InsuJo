using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreate : MonoBehaviour
{
    public GameObject flag;
    GameObject Trap;
    public GameObject TrapPrefab;
    public GameObject mainChar;
    Vector3 pos;
    int RandomX, RandomZ;
    // Start is called before the first frame update
    public void FlagPosition()
    {
        pos = flag.transform.position;
        RandomX = Random.Range(-45, 45);
        RandomZ = Random.Range(-45, 45);
        
        pos.x = RandomX;
        pos.z = RandomZ;

        flag.transform.position = pos;
    }
    public void TrapPosition()
    {
        RandomX = Random.Range(-45, 45);
        RandomZ = Random.Range(-45, 45);
        pos.x = RandomX;
        pos.z = RandomZ;
        pos.y = 0;
        while (Mathf.Abs((mainChar.transform.position - pos).magnitude) < 5  || Mathf.Abs((flag.transform.position - pos).magnitude) < 2)
        {
            RandomX = Random.Range(-45, 45);
            RandomZ = Random.Range(-45, 45);
            pos.x = RandomX;
            pos.z = RandomZ;
        }
        Trap = (GameObject)Instantiate(TrapPrefab, pos, Quaternion.identity);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
