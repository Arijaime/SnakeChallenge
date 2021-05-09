using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SnakeHead : MonoBehaviour
{
    enum Direction
    {
        up,
        down,
        left,
        right
    }

    Direction direction;

    public List<Transform> tail = new List<Transform>();

    public float framerate = 0.2f;
    public float step = 1.6f;

    public GameObject TailPrefab;

    public Vector2 horizontalRange;
    public Vector2 verticalRange;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move",framerate,step);
    }

    void Move()
    {
        lastPos  = transform.position;
        
        Vector3 nextPos = Vector3.zero;
        if(direction == Direction.up)
            nextPos = Vector3.up;
        else if (direction == Direction.down)
            nextPos = Vector3.down;
        else if(direction == Direction.left)
            nextPos = Vector3.left;
        
        else  if(direction == Direction.right)
            nextPos = Vector3.right;

        nextPos *= step;
        transform.position += nextPos;
        MoveTail();
    }

    Vector3 lastPos;
    void MoveTail()
    {
        for (int i = 0; i < tail.Count; i++)
        {
            Vector3 temp = tail[i].position;
            tail[i].position = lastPos;
            lastPos = temp;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&& (direction!=Direction.down))
        {
         //  gameObject.GetComponent<SpriteRenderer>().flipY = false;
            direction = Direction.up;
        }
        

        
        if (Input.GetKeyDown(KeyCode.DownArrow)&& (direction!=Direction.up))
        {
         //   gameObject.GetComponent<SpriteRenderer>().flipY = true;
            direction = Direction.down;
            
        }

        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (direction!=Direction.right))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            direction = Direction.left;
        }


        if (Input.GetKeyDown(KeyCode.RightArrow) && (direction!=Direction.left))
        {    gameObject.GetComponent<SpriteRenderer>().flipX = false;
            direction = Direction.right;
        }

        

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            print("hai perso la partita");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else if (col.CompareTag("Food"))
        {
            

            tail.Add( Instantiate(TailPrefab, tail[tail.Count - 1].position, Quaternion.identity).transform);
            tail.Add( Instantiate(TailPrefab, tail[tail.Count - 1].position, Quaternion.identity).transform);
         
         col.transform.position = new Vector2(Random.Range(horizontalRange.x,horizontalRange.y),Random.Range(verticalRange.x,verticalRange.y));
        }
    }
}
