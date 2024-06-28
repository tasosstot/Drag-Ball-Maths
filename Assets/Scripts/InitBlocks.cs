using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InitBlocks : MonoBehaviour
{
    [SerializeField]
    public Block blockPrefab;
    // poses sthles na emfanisei
    private int playWidth = 8;
    private float distanceBetweenBlocks = 0.9f;
    private int rowsInitiated;
    int maxrowsInitiated = 0;
    public GameOverScript GameOverScript;
    public Transform block;
    bool avoidLoops = false;


    private List<Block> blocksInitiated = new List<Block>();

    //this function enables when the object is created
    private void OnEnable()
    {
        for (int i = 0; i < 1; i++)
        {
            InitRowOfBlocks();
        }
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        block = GameObject.FindGameObjectWithTag("Block").transform;
        Gameover();       
    }


public void InitRowOfBlocks()
    {
        foreach(var block in blocksInitiated) 
        {
            if (block != null)
            {
                block.transform.position += Vector3.down * distanceBetweenBlocks;
            }
        }
        for (int i = 0; i < playWidth; i++)
        {
            if(UnityEngine.Random.Range(0,100) <= 75)
            {
                var block = Instantiate(blockPrefab, GetPosition(i), Quaternion.identity);
                int hits = UnityEngine.Random.Range(1, 4) + rowsInitiated;
                


                block.SetHits(hits);
                //loop με τα blocks μου
                blocksInitiated.Add(block);
               
                    
            }
        }
        // ανα πόσο να ανεβαίνουν οι ζωές τον block
        rowsInitiated += 3;
        maxrowsInitiated = rowsInitiated;
        Higher.hblock = maxrowsInitiated;


    }

    public void Gameover()
    {
        
        if (avoidLoops == false)
        {
            bool flag = true;
            if (block.transform.position.y <= -2.03 && flag == true)
            {
                flag = false;
              //  Sounds.PlaySound("alert");
            }
            if (block.transform.position.y <= -4.83)
            {
               // Debug.Log("mpika");
                GameOverScript.Setup(maxrowsInitiated);
                Sounds.PlaySound("lose");
                avoidLoops = true;
            }

        }
      
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * distanceBetweenBlocks;
        return position;
    }
}
