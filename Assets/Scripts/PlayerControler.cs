using UnityEngine;


public class PlayerControler : MonoBehaviour
{

	

	public float speed = 4.0f;
	public Vector2 lastMovement = Vector2.zero;


	// Player Animations
	private bool walkingBool = false;

	private const string horizontal = "Horizontal";
	private const string vertical = "Vertical";

	private string lastVertical = "LastVertical";
	private string lastHorizontal = "LastHorizontal";

	private string walking = "Walking";



	private Animator animator;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update()
	{
		//animator.SetFloat(horizontal, 0);
		//animator.SetFloat(vertical, 0);

		walkingBool = false;

		
		var horizontalAxisRaw = Input.GetAxisRaw(horizontal);
		var verticalAxisRaw = Input.GetAxisRaw(vertical);


		if (Mathf.Abs(horizontalAxisRaw) > 0.5)
		{
			transform.Translate(new Vector3(horizontalAxisRaw * speed * Time.deltaTime, 0, 0));
			walkingBool = true;
			lastMovement = new Vector2 (horizontalAxisRaw, 0);
		}

		if (Mathf.Abs(verticalAxisRaw) > 0.5)
		{
			transform.Translate(new Vector3(0, verticalAxisRaw * speed * Time.deltaTime, 0));
			walkingBool = true;
			lastMovement = new Vector2(0, verticalAxisRaw);
		}

		animator.SetFloat(horizontal, horizontalAxisRaw);
		animator.SetFloat(vertical, verticalAxisRaw);
		animator.SetFloat(lastHorizontal, lastMovement.x);
		animator.SetFloat(lastVertical, lastMovement.y);
		animator.SetBool(walking, walkingBool);

	}


}
