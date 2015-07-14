using UnityEngine;

public class Creator : MonoBehaviour
{
    private readonly Quaternion _rotation = Quaternion.Euler(0, 0, -90);

    private Quaternion _dragedObjQ;

    private GameObject _dragedObj;

    public Material[] Grass;

    public Sprite[] Background;

    public AudioSource[] Music;

    public GameObject GrassObj;

    public GameObject BackgroundQuad;

    public bool Delete;

    public Camera Camera;

    public GameObject[] Cubes;

    public bool Rotate = false;

    public bool IsSun = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButton("mouse 0"))
	    {
            RaycastHit hit;
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, 1 << 9) && !Delete && _dragedObj == null)
            {
                var hitObj = hit.transform.gameObject;
                hitObj = hitObj.transform.parent.gameObject;
                _dragedObj = hitObj;
                _dragedObj.GetComponent<Rigidbody2D>().angularVelocity = 0;
                _dragedObjQ = _dragedObj.transform.rotation;
            }
            if (Physics.Raycast(ray, out hit, 100f, 1 << 8) && !Delete && _dragedObj != null)
            {
                _dragedObj.transform.rotation = _dragedObjQ;
                _dragedObj.transform.position = new Vector3(hit.point.x, hit.point.y, 4);
            }
	        if (Physics.Raycast(ray, out hit, 100f, 1 << 9) && Delete)
	        {
	            var hitObj = hit.transform.gameObject;
	            hitObj = hitObj.transform.parent.gameObject;
	            Destroy(hitObj);
	        }
	    }
	    else
	    {
	        if (_dragedObj != null)
	        {
                _dragedObj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _dragedObj = null;
	        }
	    }
	}

    public void SunChange()
    {
        IsSun = !IsSun;
        GrassObj.GetComponent<Renderer>().material = Grass[IsSun ? 1 : 0];
        BackgroundQuad.GetComponent<SpriteRenderer>().sprite = Background[IsSun ? 1 : 0];
        Music[IsSun ? 0 : 1].GetComponent<AudioSource>().Stop();
        Music[IsSun ? 1 : 0].GetComponent<AudioSource>().Play();
    }

    public void Create(GameObject obj)
    {
        RaycastHit hit;
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f, 1 << 8))
        {
            Delete = false;
            Instantiate(obj, hit.point, Rotate ? _rotation : Quaternion.identity);
        }
    }
}
