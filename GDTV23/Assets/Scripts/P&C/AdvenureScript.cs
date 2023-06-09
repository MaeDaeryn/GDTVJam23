using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool key = false;
    public int soul = 0;
    public GameObject lever;
    public GameObject cageUp;
    public GameObject cageDown;
    public GameObject feuerUp;
    public GameObject feuerDown;
    public GameObject cageOpen;
    public GameObject feuerFree;
    public GameObject BatIgnore;
    public GameObject Bat;
    public GameObject GreenNo;
    public GameObject GreenYes;
    public GameObject porno;
    public GameObject uhr;
    public GameObject BlueNo;
    public GameObject BlueYes;
    public GameObject clarice;
    public GameObject brian;
    public GameObject gilbert;
    public GameObject clariceFlame;
    public GameObject brianFlame;
    public GameObject gilbertFlame;
    public int end = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DIalogManager.isActive == true)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            print("Maustaste wude gedr�ckt.");

            mousePos = Input.mousePosition;

            print("Screen = " + mousePos);

            mouseWorld = mainCam.ScreenToWorldPoint(mousePos);

            print("World = " + mouseWorld);

            mouseWorl2D = new Vector2(mouseWorld.x, mouseWorld.y);

            //Raycast2D
            hit = Physics2D.Raycast(mouseWorl2D, Vector2.zero);

            if (hit.collider != null)
            {
                print("Collider getroffen ");

                print(hit.collider.gameObject.name);

                //Abfrage oob der Collider vom Boden getroffen wurde
                if (hit.collider.gameObject.tag == "Boden")
                {
                    //Player Position ver�ndern
                    //player.transform.position = hit.point;
                    targetPos = hit.point;

                    isMoving = true;
                    //�berrpr�fe ob SpriteFlip notwendig
                    CheckSpriteFlip();
                }
                //Der key f�r den Cage wird eingesammelt
                if (hit.collider.gameObject.tag == "CageKey")
                {

                    //Grafik Deaktivieren
                    hit.collider.gameObject.SetActive(false);
                    //Schl�sssel in Script abspeichern
                    key = true;
                }
                if (hit.collider.gameObject.tag == "Soul")
                {
                    hit.collider.gameObject.SetActive(false);
                    soul = soul + 1;
                }
                if (hit.collider.gameObject.tag == "Lever")
                {
                    // Flip lever object on the X-axis
                    if (lever != null)
                    {
                        lever.transform.localScale = new Vector3(-lever.transform.localScale.x, lever.transform.localScale.y, lever.transform.localScale.z);
                    }
                    // Make CageUp object disappear
                    if (cageUp != null)
                    {
                        cageUp.SetActive(false);
                    }

                    // Make CageDown object appear
                    if (cageDown != null)
                    {
                        cageDown.SetActive(true);
                    }
                    // Make FeuerUp object disappear
                    if (feuerUp != null)
                    {
                        feuerUp.SetActive(false);
                    }

                    // Make FeuerDown object appear
                    if (feuerDown != null)
                    {
                        feuerDown.SetActive(true);
                    }
                }
                if (hit.collider.gameObject.tag == "CageDown")
                {
                    if (key)
                    {
                        // Make CageDown object disappear
                        if (cageDown != null)
                        {
                            cageDown.SetActive(false);
                        }

                        // Make CageOpen object appear
                        if (cageOpen != null)
                        {
                            cageOpen.SetActive(true);
                        }

                        // Make FeuerUp object disappear
                        if (feuerDown != null)
                        {
                            feuerDown.SetActive(false);
                        }

                        // Make feuerFree object appear
                        if (feuerFree != null)
                        {
                            feuerFree.SetActive(true);
                        }
                    }
                    else
                    {
                        print("kein Key vorhanden");
                    }
                }
                if (hit.collider.gameObject.tag == "NextLevel")
                {
                    if (soul == 1)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
                if (hit.collider.gameObject.tag == "MP3")
                {
                    hit.collider.gameObject.SetActive(false);

                    // Make BatIgnore object disappear
                    if (BatIgnore != null)
                    {
                        BatIgnore.SetActive(false);
                    }
                    // Make Bat object appear
                    if (Bat != null)
                    {
                        Bat.SetActive(true);
                    }

                }
                if (hit.collider.gameObject.tag == "Rechner")
                {
                    hit.collider.gameObject.SetActive(false);

                    // Make GreenNo object disappear
                    if (GreenNo != null)
                    {
                       GreenNo.SetActive(false);
                    }

                    // Make GreenYes object appear
                    if (GreenYes != null)
                    {
                        GreenYes.SetActive(true);
                    }                  
                }
                if (hit.collider.gameObject.tag == "Porno")
                {
                    hit.collider.gameObject.SetActive(false);

                    // Make uhr object appear
                    if (uhr != null)
                    {
                        uhr.SetActive(true);
                    }
                }
                if (hit.collider.gameObject.tag == "Uhr")
                {
                    hit.collider.gameObject.SetActive(false);

                    // Make BlueNo object disappear
                    if (BlueNo != null)
                    {
                        BlueNo.SetActive(false);
                    }

                    // Make BlueYes object appear
                    if (BlueYes != null)
                    {
                        BlueYes.SetActive(true);
                    }
                }
                if (hit.collider.gameObject.tag == "Brian")
                {
                    hit.collider.gameObject.SetActive(false);

                    // Make brianFlame object disappear
                    if (brianFlame != null)
                    {
                        brianFlame.SetActive(false);
                    }

                    // Make brian object appear
                    if (brian != null)
                    {
                        brian.SetActive(true);
                    }

                    end = end + 1;
                    if (end == 3)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
                if (hit.collider.gameObject.tag == "Clarice")
                {
                    hit.collider.gameObject.SetActive(false);

                    // Make clariceFlame object disappear
                    if (clariceFlame != null)
                    {
                        clariceFlame.SetActive(false);
                    }

                    // Make clarice object appear
                    if (clarice != null)
                    {
                        clarice.SetActive(true);
                    }

                    end = end + 1;
                    if (end == 3)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
                if (hit.collider.gameObject.tag == "Gilbert")
                {
                    hit.collider.gameObject.SetActive(false);

                    // Make gilbertFlame object disappear
                    if (gilbertFlame != null)
                    {
                        gilbertFlame.SetActive(false);
                    }

                    // Make gilbert object appear
                    if (gilbert != null)
                    {
                        gilbert.SetActive(true);
                    }

                    end = end + 1;
                    if (end == 3)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }











                    else
                {
                    print("Kein Collider ");
                }
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
