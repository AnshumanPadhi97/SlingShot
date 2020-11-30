using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	Camera cam;

	public Ball ball;
	public Trajectory trajectory;
	[SerializeField] float TrajectorypushForce = 1f;
	[SerializeField] float BallpushForce = 1f;

	bool isDragging = false;

	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	Vector2 force2;
	float distance;

	void Start()
	{
		cam = Camera.main;
		ball.DesactivateRb();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			isDragging = true;
			OnDragStart();
		}
		if (Input.GetMouseButtonUp(0))
		{
			isDragging = false;
			OnDragEnd();
		}

		if (isDragging)
		{
			OnDrag();
		}

        if (Input.GetKey(KeyCode.R))
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	void OnDragStart()
	{
		ball.DesactivateRb();
		startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

		trajectory.Show();
	}

	void OnDrag()
	{
		endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
		distance = Vector2.Distance(startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * BallpushForce;
		force2 = direction * distance * TrajectorypushForce;
		
		trajectory.UpdateDots(ball.pos, force2);
	}

	void OnDragEnd()
	{
		ball.ActivateRb();

		ball.Push(force);

		trajectory.Hide();
	}
}
