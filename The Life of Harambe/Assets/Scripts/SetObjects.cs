using UnityEngine;
using System.Collections;

//sets the size of all Game Objects to be relative to screen size
public class SetObjects : MonoBehaviour {
    Vector3 screen;

    GameObject grass;
    GameObject fence;
    GameObject player;
    GameObject children;
    GameObject wall;
    GameObject ground;
    GameObject rock;
    GameObject tree;
    GameObject bush;


	// Use this for initialization
	void Start ()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        grass = GameObject.Find("Grass");
        grass.transform.position = new Vector2(0, screen.y * -.358f);
        grass.transform.localScale = new Vector2(screen.x * .156f, screen.y * .488f);

        fence = GameObject.Find("Fence");
        fence.transform.position = new Vector2(0, screen.y * .8f);
        fence.transform.localScale = new Vector2(screen.x * .358f, screen.y * .0382f);

        player = GameObject.Find("Gorilla");
        player.transform.position = new Vector2(0, screen.y * -.784f);
        player.transform.localScale = new Vector2(screen.x * .091f, screen.y * .06f);

        wall = GameObject.Find("Brick Wall");
        wall.transform.position = new Vector2(0, 0);
        wall.transform.localScale = new Vector2(screen.x * .0415f, screen.y * .0334f);

        children = GameObject.Find("Children");
        children.transform.position = new Vector2(0, screen.y * .876f);
        children.transform.localScale = new Vector2(screen.x * .061f, screen.y * .025f);

        ground = GameObject.Find("Ground");
        ground.transform.position = new Vector2(0, screen.y * .776f);
        ground.transform.localScale = new Vector2(screen.x * .0988f, screen.y * .00338f);

        rock = GameObject.Find("Rock");
        rock.transform.position = new Vector2(screen.x * -.67f, screen.y * -.768f);
        rock.transform.localScale = new Vector2(screen.x * .0182f, screen.y * .012f);

        tree = GameObject.Find("Tree");
        tree.transform.position = new Vector2(screen.x * -.333f, screen.y * -.472f);
        tree.transform.localScale = new Vector2(screen.x * .121f, screen.y * .08f);

        bush = GameObject.Find("Bush");
        bush.transform.position = new Vector2(screen.x * .56f, screen.y * -.642f);
        bush.transform.localScale = new Vector2(screen.x * .212f, screen.y * .14f);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
