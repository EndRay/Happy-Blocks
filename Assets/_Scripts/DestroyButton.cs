using UnityEngine;

public class DestroyButton : MonoBehaviour
{

    public Creator Creator;

    private readonly Vector3 _small = new Vector3(0.7f, 0.7f, 0.7f);

	// Use this for initialization
	void Start () {
        gameObject.transform.localScale = Creator.Delete ? Vector3.one : _small;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("mouse 0"))
	    {
            gameObject.transform.localScale = Creator.Delete ? Vector3.one :_small;
	    }
	}

    private void OnMouseDown()
    {
        Creator.Delete = !Creator.Delete;
    }
}
