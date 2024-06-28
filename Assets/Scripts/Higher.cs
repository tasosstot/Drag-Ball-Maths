using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Higher : MonoBehaviour
{

    public static int hblock = 0;
    Text highBlock;
    // Start is called before the first frame update
    void Start()
    {
        highBlock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        highBlock.text = "Μεγαλύτερο Κουτί: " + hblock;
    }
}
