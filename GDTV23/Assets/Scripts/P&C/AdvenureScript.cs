using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Vector3 mousePos;
    public Camera mainCam;
    public Vector3 mouseWorld;
    public Vector2 mouseWorl2D;
    public RaycastHit2D hit;
    public GameObject player;
    public Vector2 targetPos;
    public float speed;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            print("Maustaste wude gedrückt.");

            mousePos = Input.mousePosition;

            print("Screen = " + mousePos);

            mouseWorld = mainCam.ScreenToWorldPoint(mousePos);

            print("World = " + mouseWorld);

            mouseWorl2D = new Vector2(mouseWorld.x, mouseWorld.y);

            //Raycast2D
            hit = Physics2D.Raycast(mouseWorl2D, Vector2.zero);

            if(hit.collider != null)
            {
                print("Collider getroffen ");

                print(hit.collider.gameObject.name);

                if (hit.collider.gameObject.tag == "Boden")
                {
                    //Player Position verändern
                    //player.transform.position = hit.point;
                    targetPos = hit.point;

                    isMoving = true;
                    //Überrprüfe ob SpriteFlip notwendig
                    CheckSpriteFlip();
                }

            }
            else
            {
                print("Kein Collider ");
            }
        }
    }

    private void FixedUpdate()
    {
        //Abfrage, ob Spieler sich bewegt
        if (isMoving)
        {
            //SPieler bewegt sich
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed);

            if(player.transform.position.x == targetPos.x && player.transform.position.y == targetPos.y)
            {
                isMoving = false;
                print("Spieler steht");
            }
        }

    }

    void CheckSpriteFlip()
    {
        if(player.transform.position.x > targetPos.x)
        {
            //links gucken
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            //rechts gucken
            player.GetComponent<SpriteRenderer>().flipX = false;
        }

    }


}
