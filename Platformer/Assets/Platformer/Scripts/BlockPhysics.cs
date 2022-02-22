using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockPhysics : MonoBehaviour
{
    public TMP_Text coins;
    public float coinFloat;
    //public float proximityThreshold = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, Vector3.down * proximityThreshold, Color.blue);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 17f) && Input.GetMouseButtonDown(0))
        {
            Debug.Log(hitInfo.transform.name);
            if (hitInfo.transform.name == "QuestionBlock(Clone)")
            {
                Debug.Log("Question");
                coinFloat += 1;
                coins.text = coinFloat.ToString();
            }
            else if (hitInfo.transform.name == "Bricks(Clone)")
            {
                Destroy(hitInfo.transform.gameObject);
            }
        }
    }
}
