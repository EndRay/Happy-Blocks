using UnityEngine;
using System.Collections;

public class RotateButton : MonoBehaviour {

    public Creator Creator;

    private readonly Vector3 _small = new Vector3(0.7f, 0.7f, 0.7f);

	// Use this for initialization
	void Start () {
        gameObject.transform.localScale = Creator.Rotate ? Vector3.one : _small;
	}
	
	// Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Creator.Rotate = !Creator.Rotate;
        gameObject.transform.localScale = Creator.Rotate ? Vector3.one : _small;
    }
}
