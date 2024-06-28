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

    

   
    //method για να κανουμε update το visual state
    private void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString());
        //με την lerp αλλάζουμε σταδιακά τα χρώμματα απο το κάθε block δηλαδή, όσο μεγαλύτερο είναι
        //κόκκινο, οσο μικρότερο ασπρίζει. Αν μεγαλώσω το /10f μεγαλώνω και τα όρια των χρωμμάτων
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
