using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 1.0f;
    public float health = 5.0f;
    private Rigidbody2D phys;
    private bool flipped = false;
    Vector2 pos;
    Vector3 intitialPos = new Vector3(0, 0, 0);
    Vector3 movedPos = new Vector3(0, 0, 0);

    public void takeDamage(float damage)
    {
        Debug.Log("damage taken!");
        health = health - damage;
    }
    void flip()
    {
        flipped = !flipped;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void keyboardMovement()
    {
        Vector3 horizontal = (transform.right * (Input.GetAxis("Horizontal") / 2.0f) * speed * Time.fixedDeltaTime) * 64 * 2;
        Vector3 vertical = (transform.up * (Input.GetAxis("Vertical") / 2.0f) * speed * Time.fixedDeltaTime) * 64 * 2;
        if (horizontal.x > 0 && flipped)
            flip();
        else if (horizontal.x < 0 && !flipped)
            flip();
        transform.position += horizontal;
        transform.position += vertical;
    }
    void tabletMovement()
    {
        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = myTouches[i];
            if (touch.position.x < Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Began)
                    intitialPos = touch.position;
                else if (touch.phase == TouchPhase.Moved)
                    movedPos = touch.position;
                float xDifference = movedPos.x - intitialPos.x;
                float yDifference = movedPos.y - intitialPos.y;
                float actualDifference = Mathf.Sqrt((xDifference * xDifference) + (yDifference * yDifference));

                float ratioDifference = 50 / actualDifference;
                float mX = xDifference * ratioDifference;
                float mY = yDifference * ratioDifference;
                Vector3 horizontal = (transform.right * (mX / 200.0f) * speed * Time.fixedDeltaTime) * 64 * 2;
                Vector3 vertical = (transform.up * (mY / 200.0f) * speed * Time.fixedDeltaTime) * 64 * 2;
                if (horizontal.x > 0 && flipped)
                    flip();
                else if (horizontal.x < 0 && !flipped)
                    flip();
                transform.position += horizontal;
                transform.position += vertical;
            }
        }
    }
    // Use this for initialization
    void Start () {
        
        phys = GetComponent<Rigidbody2D>();
        pos = transform.position;

        Camera.main.GetComponent<CameraMovement>().target = gameObject.transform.GetChild(0).gameObject;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
        }
        if (health <= 0)
            Destroy(gameObject);
    }
    // Update is called once per frame
    void FixedUpdate () {
        keyboardMovement();
        //tabletMovement();
    }

    
}
