using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowPlayerRank : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private Vector3 P1_position;
    private Vector3 P2_position;
    private Text P1Text;
    private Text P2Text;

    private Text temp;
    // Start is called before the first frame update
    void Awake()
    {
        
        P1Text = (GameObject.Find("Player1Rank")).GetComponent<Text>();

        //  P2Text = GameObject.Find("Player2Rank");
        P1Text.text = "1st";
        // P2Text.text = "1st";

    }
  

    // Update is called once per frame
    void Update()
    {
        P1_position = Player1.transform.position;
        P2_position = Player2.transform.position;
        if( P1_position.z >= P2_position.z)
        {
            P1Text.text = "1st";
            //P2Text.text = "2nd";
        }
        else
        {
            P1Text.text = "2nd";
            //P2Text.text = "1st";

        }

    }
}
