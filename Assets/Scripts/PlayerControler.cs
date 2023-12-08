using UnityEngine;


public class PlayerControler : MonoBehaviour
{

	public float speed = 4.0f;

	private const string horizontal = "Horizontal";
	private const string vertical = "Vertical";


	private Animator animator;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		animator.SetFloat(horizontal, 0);
		animator.SetFloat(vertical, 0);

		
		var horizontalAxisRaw = Input.GetAxisRaw(horizontal);
		var verticalAxisRaw = Input.GetAxisRaw(vertical);


		if (Mathf.Abs(horizontalAxisRaw) > 0.5)
		{
			transform.Translate(new Vector3(horizontalAxisRaw * speed * Time.deltaTime, 0, 0));
		}

		if (Mathf.Abs(verticalAxisRaw) > 0.5)
		{
			transform.Translate(new Vector3(0, verticalAxisRaw * speed * Time.deltaTime, 0));
		}

		animator.SetFloat(horizontal, horizontalAxisRaw);
		animator.SetFloat(vertical, verticalAxisRaw);
	}


}
