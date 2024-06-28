using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Block : MonoBehaviour
{
    private int hitsRemaining;
    public SpriteRenderer spriteRenderer;
    private TextMeshPro text;
   
   


    private void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }

    

   
    //method ��� �� ������� update �� visual state
    private void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString());
        //�� ��� lerp ��������� �������� �� �������� ��� �� ���� block ������, ��� ���������� �����
        //�������, ��� ��������� ��������. �� �������� �� /10f �������� ��� �� ���� ��� ���������
        spriteRenderer.color = Color.Lerp(Color.white, Color.black, hitsRemaining / 50f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining--;
        if (hitsRemaining > 0)
            UpdateVisualState();
        else if (hitsRemaining == 0)
        { 
            Sounds.PlaySound("break");
        Destroy(gameObject);
        }
        else
        Destroy(gameObject);
        


    }
   // public void Gameover()
   // {
    //    if (gameObject.transform.position.y <= -4.83)
     //   {
     //       Debug.Log("mpika");
    //        GameOverScript.Setup();
   //     }
  //  }


    internal void SetHits(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();

    }
  
}
