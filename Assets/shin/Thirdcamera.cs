using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Thirdcamera : MonoBehaviour
{
    public GameObject target;

    public float offsetX = -1.0f;
    public float offsetY = 5.0f;
    public float offsetZ = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 FixedPos =
            new Vector3(
                target.transform.position.x + offsetX,
                target.transform.position.y + offsetY,
                target.transform.position.z + offsetZ);


        transform.position = FixedPos;

        transform.eulerAngles = new Vector3(25, 0, 0);  // 조금 위에서 봐서 훤히 보이게 함 (내려다봄)
           
        
    }
}
