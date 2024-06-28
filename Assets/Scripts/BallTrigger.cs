using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallTrigger : MonoBehaviour
{
    private Vector3 startDragPosition;
    private Vector3 endDragPosition;
    private InitBlocks blockInitialiser;
    private LaunchPreview launchPreview;
    private List<Ball> balls = new List<Ball>();
    private int ballsReady;
    //private InitBlocks blockSpawner;

    [SerializeField]
    private Ball ballPrefab;




    private void Awake()
    {
        blockInitialiser = FindObjectOfType<InitBlocks>();
        //launchprevie, παίρνουμε το component ωστέ να το παραμετροποιήσουμε, (to kanoyme cache)
        launchPreview = GetComponent<LaunchPreview>();
        CreateBall();

    }

    public void ReturnBall()
    {
        ballsReady++;
        if (ballsReady == balls.Count)
        {
            blockInitialiser.InitRowOfBlocks();
            CreateBall();

        }
    }

    private void CreateBall()
    {
        var pos = new Vector3(1, -5);
        var ball = Instantiate(ballPrefab, pos, Quaternion.identity);
        balls.Add(ball);
        ballsReady++;
        CurrentBalls.scoreValue ++;
     }




    private void Update()
    {
        // don't let the player launch until all balls are back.
       // if (ballsReady != balls.Count)
           // return;
       // Camera.main.ScreenToWorldPoint(Input.mousePosition) --> μας δίνει το σημείο που κάναμε το κλικ
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;

        if (Input.GetMouseButtonDown(0)) // αν ακουμπήσουμε το object μπαίνει
        {
            StartDrag(worldPosition); //περνάμε το σημείο του κόσμου που ακουμπήσαμε
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition); // ean sunexisei na kanei drag mpainei edw
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }

    }

    private void EndDrag()
    {
        //Vector3 direction = endDragPosition - startDragPosition;
        // direction.Normalize(); // To fernei sthn arxikh toy thesi

        // var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity); //bazei thn mpala sto world. Spawn the ball to the folder that belongs ?
        // ball.GetComponent<Rigidbody2D>().AddForce(-direction); // pairnei anapoda to direction, dhladh travas thn mpala apo thn mia meria kai auth paei apo thn antitheth. Opposite from the direction you drag
        StartCoroutine(LaunchBalls());
    }

    private IEnumerator LaunchBalls()
    {
        Vector3 direction = endDragPosition - startDragPosition;
        direction.Normalize();

        foreach (var ball in balls)
        {
            //εμφανίζουμε κάθε επόμενη μπάλα ανα τόσα δευτερα όσα λέει στο return
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(0.3f);
        }
        ballsReady = 0;
    }

    private void ContinueDrag(Vector3 worldPosition)
    {
        endDragPosition = worldPosition;
        Vector3 direction = endDragPosition - startDragPosition;
        launchPreview.SetEndPoint(transform.position - direction);
    }

    private void StartDrag(Vector3 worldPosition)
    {
        startDragPosition = worldPosition;
        launchPreview.SetStartPoint(transform.position);
    }
}
