using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Action : MonoBehaviour
{
    public static Action instance;
    //Variables to move the player
    public Vector3 reStartPosition= new Vector3(67.0f, 42.0f, 35.0f);
    public float speed = 5.0f;
    private float speedStorage=0.0f;
    public float rotateSpeed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float normalSpeedLimit = 10.0f;
    public float sprintLimit = 15.0f;
     
    //Variables to move the camera of the player
    public Camera cameraRotation;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;
    bool hit;
    public bool caninterract;

    //Variables use to interact with the game
    public TextMeshProUGUI info;
    public GameObject inventory;
    public bool inventoryDisplay=false;
    private Rigidbody rb;
    public Animator destroyHammer;
    public GameObject locker;
    public AudioSource waterFallAudio;
    public AudioSource audioLocker;
    public int die;
    //Variables for the scipt
    private int fallTree;
    public bool stopMove;
    public bool craftingMoment;

    void Awake()
    {
        instance = this;
    }

    //Just start with a player who can move
    void Start()
    {
        stopMove = false;
        craftingMoment = false;

        speedStorage = speed;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stopMove==false)//condition which will be used to stop the player and the camera if the player uses something which stop his movement
        {
            MoveCamera();
            Move();
        }
        if(Input.GetKeyDown(KeyCode.C))//to not move the player and the camera when we have the crafting
        {
            stopMove = !stopMove;
            craftingMoment = !craftingMoment;
        }
        if (Input.GetKeyDown(KeyCode.Escape))//to not move the player and the camera when there is the game menu
        {
            stopMove = !stopMove;
            craftingMoment = !craftingMoment;
        }
        if (caninterract && Input.GetKeyDown(KeyCode.F))//if the player interract with a gameobject in the game, to not move until the end of the animation
        {
            stopMove = true;
        }
        if(hit==false && craftingMoment==false)//to move again when the game object is destroyed
        {
            stopMove = false;
            info.text = "+";
        }
    }

    private void MoveCamera()//fonction call in the update to move the gamera
    {
        //Camera an character rotation, change the rotation of the player on the Yaxe when you move the Mouse, and change the rotation of the camera on the Xaxe
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        cameraRotation.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
    private void Move()//methode call in the Update to move the player. To move him, AddForce is used to avoid the teleport problem inside a GO and to stop move when the player touch a GO
    {

        float speedlimit = 0;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            speedlimit = sprintLimit;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedStorage;
            speedlimit = normalSpeedLimit;
        }

        

        //a reference to the players current horizontal velocity
        float currentSpeed = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z).magnitude;


        //Movement
        if(Input.GetKey(KeyCode.W))
        {
            if (currentSpeed < speedlimit)
            {
                rb.AddForce(transform.forward * speed);
            }
            else
            {
                rb.AddForce(transform.forward * 0.0f);
            }         
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (currentSpeed < speedlimit)
            {
                rb.AddForce(-transform.right * speed);
            }
             else
            {
                rb.AddForce(transform.right * 0.0f);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if(currentSpeed<speedlimit)
            {
                rb.AddForce(-transform.forward * speed);
            }
             else
            {
                rb.AddForce(transform.forward * 0.0f);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if(currentSpeed<speedlimit)
            {
                rb.AddForce(transform.right * speed);
            }
             else
            {
                rb.AddForce(transform.right * 0.0f);
            }
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            Vector3 movement = new Vector3(0.0f, -12.0f, 0.0f);
            rb.velocity = movement;
        }

        if (rb.transform.position.y <28)//test if the player is in the water
        {
            transform.position = reStartPosition;
            waterFallAudio.Play();
            die++;
        }

        //to not display the text when we presse F
        if(Input.GetKeyDown(KeyCode.F))
        {
            fallTree = 1;
        }
        if(fallTree==1)
        {
            info.text = "+";
            fallTree = 0;
        }
    }
    

    private void OnCollisionStay(Collision other)//do different thing when the player is in collision with different GO, use CompareTag
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 0.8f))//use a RayCast to know if the player look the GO
        {
            hit = true;
        }
        else
        {
            hit = false;
        }
        if (other.gameObject.CompareTag("Bush"))
        {
            if(hit)
            {
                other.gameObject.GetComponent<DestroyBush>().canInterract = 1;//change the variable canCut in the script DestroyBush to destroy the good bush
                info.text = "Press |F| to collect sticks !";
                caninterract = true;
            }
            else
            {
                other.gameObject.GetComponent<DestroyBush>().canInterract = 0;
                info.text = "+";
                caninterract = false;
            }  
        }
        if (other.gameObject.CompareTag("Tree"))
        {
            if(hit)
            {
                other.gameObject.GetComponent<FallTree>().canInterract = 1;
                if (DisplayUsableItems.instance.inTheHand.id == 10)//test if the player has the good Tool in his hand
                {
                    info.text = "Press |F| to cut the tree !";
                    caninterract = true;
                }
                else
                {
                    info.text = "This isn’t Minecraft. I can’t chop the tree down with my bare hands. An axe would be helpful here.";
                    caninterract = false;
                }
            }
            else
            {
                other.gameObject.GetComponent<FallTree>().canInterract = 0;
                info.text = "+";
                caninterract = false;
            }
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            if(hit)
            {
                other.gameObject.GetComponent<BreakRock>().canInterract = 1;
                if (DisplayUsableItems.instance.inTheHand.id == 1 || DisplayUsableItems.instance.inTheHand.id == 11)
                {
                    info.text = "Press |F| to break the rock !";
                    caninterract = true;
                }
                else
                {
                    info.text = "The rock is too hard to destroy with my bare hands but just a steak will be enough too destroy it.";
                    caninterract = false;
                }
            }
            else
            {
                other.gameObject.GetComponent<BreakRock>().canInterract = 0;
                info.text = "+";
                caninterract = false;
            }
        }
        if (other.gameObject.CompareTag("DarkRock"))
        {
            if (hit)
            {
                if (DisplayUsableItems.instance.inTheHand.id == 11)
                {
                    other.gameObject.GetComponent<BreakRock>().canInterract = 1;
                    info.text = "Press |F| to break the metal !";
                    caninterract = true;
                }
                else
                {
                    info.text = "The rock is too hard to destroy with my bare hands.I need a tool to destroy this. A pickaxe would be helpful here.";
                    caninterract = false;
                }
            }
            else
            {
                other.gameObject.GetComponent<BreakRock>().canInterract = 0;
                info.text = "+";
                caninterract = false;
            } 
        }
        if (other.gameObject.CompareTag("Bridge"))
        {
            bool canBuildBridge = false;
            if (hit)
            {
                for (int i = 0; i < Inventory.instance.Getindex(); i++)//check if the bridge is built in the Inventory
                {
                    if (Inventory.instance.content[i].id == 8)
                        canBuildBridge = true;
                }
                if (canBuildBridge)
                {
                    other.gameObject.GetComponent<SpawnBridge>().canInterract = 1;
                    info.text = "Press |F| to build the bridge !";
                }
                else
                {
                    info.text = "Here is a good place to build my bridge.";
                }
            }
            else
            {
                other.gameObject.GetComponent<SpawnBridge>().canInterract = 0;
                info.text = "+";
            }
        }
        if (other.gameObject.CompareTag("Door1st"))//for the entrance of the prison
        {
            bool keyOk = false;
            for (int i = 0; i < Inventory.instance.Getindex(); i++)//check if the key is built
            {
                if (Inventory.instance.content[i].id == 9)
                    keyOk = true;
            }
            if(keyOk)
            {
                other.gameObject.GetComponent<OpenDoor>().canInterract = 1;
                if(OpenDoor.instance.opened==true)
                    info.text = "Press |F| to close the Door !";
                else
                    info.text = "Press |F| to open the Door !";
            }
            else
                info.text = "I can't open this door... I need a Key !";
        }
        if (other.gameObject.CompareTag("WallToDestroy"))
        {
            if (DisplayUsableItems.instance.inTheHand.id == 12)
            {
                other.gameObject.GetComponent<DestroyWall>().canInterract = 1;
                info.text = "Press |F| to weaken the wall !";
            }
            else
            {
                info.text = "This wall seems to be able to be weakened. A hammer will do the trick !";
                other.gameObject.GetComponent<DestroyWall>().canInterract = 0;
            }
        }
        if (other.gameObject.CompareTag("DoorUsless"))
        {
            if (hit)
            {
              info.text = "I can't open this door even if I have a key... I have to find an other way !";
            }
            else
            {
                info.text = "+";
            }
        }
        if (other.gameObject.CompareTag("Door"))
        {
            info.text = "Press |F| to enter the code !";
            if(Input.GetKeyDown(KeyCode.F))
            {
                locker.GetComponent<Canvas>().enabled = true;
                audioLocker.Play();
                stopMove = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    private void OnCollisionExit(Collision other)//when the player leave the GO, change the text and the variable to interrat with the GO
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            other.gameObject.GetComponent<DestroyBush>().canInterract = 0;
            info.text = "+";
        }
        if (other.gameObject.CompareTag("Tree"))
        {
            info.text = "+";
            other.gameObject.GetComponent<FallTree>().canInterract = 0;
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            info.text = "+";
            other.gameObject.GetComponent<BreakRock>().canInterract = 0;
        }
        if (other.gameObject.CompareTag("DarkRock"))
        {
            info.text = "+";
            other.gameObject.GetComponent<BreakRock>().canInterract = 0;
        }
        if (other.gameObject.CompareTag("Door1st"))
        {
            info.text = "+";
            other.gameObject.GetComponent<OpenDoor>().canInterract = 0;
        }
        if (other.gameObject.CompareTag("WallToDestroy"))
        {
            info.text = "+";
            other.gameObject.GetComponent<DestroyWall>().canInterract = 0;
            stopMove = false;
        }
        if (other.gameObject.CompareTag("DoorUsless"))
        {
            info.text = "+";
        }
        if (other.gameObject.CompareTag("Door"))
        {
            info.text = "+";
        }
        caninterract = false;
    }

    private void OnTriggerEnter(Collider other)//if the player touche the CheckPoint GO, change the coordinate of his respawn point
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            reStartPosition = new Vector3(115.0f,32.0f,184.0f);
        }
    }

    public void CraftingMoment()
    {
        stopMove = !stopMove;
    }

}


