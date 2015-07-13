using UnityEngine;

public class Button : MonoBehaviour
{

    public Creator Creator;

    public int MyNumber;

    private readonly Vector3 _small = new Vector3(0.7f, 0.7f, 0.7f);

	// Use this for initialization
	void Start () {
        gameObject.transform.localScale = MyNumber == Creator.CubeNumber ? Vector3.one : _small;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("mouse 0"))
	    {
            gameObject.transform.localScale = MyNumber == Creator.CubeNumber ? Vector3.one :_small;
	    }
	}

    private void OnMouseDown()
    {
        Creator.CubeNumber = MyNumber;
    }
}
