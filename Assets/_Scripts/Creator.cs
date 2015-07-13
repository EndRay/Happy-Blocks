using UnityEngine;

public class Creator : MonoBehaviour
{
    private readonly Quaternion _rotation = Quaternion.Euler(0, 0, -90);

    public Material[] Grass;

    public Sprite[] Background;

    public AudioSource[] Music;

    public GameObject GrassObj;

    public GameObject BackgroundQuad;

    public int CubeNumber;

    public Camera Camera;

    public GameObject[] Cubes;

    public bool Rotate = false;

    public bool IsSun = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("mouse 0"))
	    {
            RaycastHit hit;
	        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, 1<<8) && CubeNumber != -1)
            {
                Vector3 hitPos = hit.point;
                Instantiate(Cubes[CubeNumber], hitPos, Rotate ? _rotation : Quaternion.identity);
            }
            if (Physics.Raycast(ray, out hit, 100f, 1<<9) && CubeNumber == -1)
            {
                var hitObj = hit.transform.gameObject;
                while (hitObj.transform.parent != null)
                {
                    hitObj = hitObj.transform.parent.gameObject;
                }
                Destroy(hitObj);
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
}
