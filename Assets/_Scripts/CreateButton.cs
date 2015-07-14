using UnityEngine;

public class CreateButton : MonoBehaviour
{
    private readonly Quaternion _rotate90 = Quaternion.Euler(0, 0, 90);

    public Creator Creator;

    public GameObject CreateObj;

	// Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnMouseDown()
    {
        Creator.Create(CreateObj);
    }
}
