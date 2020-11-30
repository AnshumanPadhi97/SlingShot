
using UnityEngine;

public class Trajectory : MonoBehaviour
{
	[SerializeField] int dotsNumber;
	[SerializeField] GameObject dotsParent;
	[SerializeField] GameObject dotPrefab;
	[SerializeField] float dotSpacing;
	[SerializeField] [Range (0.01f, 0.3f)] float dotMinScale;
	[SerializeField] [Range (0.3f, 1f)] float dotMaxScale;

	Transform[] dotsList;

	Vector2 pos;

	float spacing;

	void Start ()
	{
		Hide ();
		PrepareDots ();
		directionOfPlanetFromDot = Vector3.zero;
	}

	void PrepareDots ()
	{
		dotsList = new Transform[dotsNumber];
		dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

		float scale = dotMaxScale;
		float scaleFactor = scale / dotsNumber;

		for (int i = 0; i < dotsNumber; i++) {
			dotsList [i] = Instantiate (dotPrefab, null).transform;
			dotsList [i].parent = dotsParent.transform;

			dotsList [i].localScale = Vector3.one * scale;
			if (scale > dotMinScale)
				scale -= scaleFactor;
		}
	}

	public float customGravity;
	public Vector3 directionOfPlanetFromDot;

	public void UpdateDots (Vector3 ballPos, Vector2 forceApplied)
	{
		spacing = dotSpacing;
		for (int i = 0; i < dotsNumber; i++) {

			//customGravity = dotsList[i].GetComponent<Dots>().gravity;

			//directionOfPlanetFromDot = dotsList[i].transform.position - dotsList[i].GetComponent<Dots>().planetPos;
			//transform.right = Vector3.Cross(directionOfPlanetFromDot, Vector3.forward);

			//pos.x = (ballPos.x + forceApplied.x * spacing) +(transform.right.magnitude) * (customGravity * spacing * spacing) / 2f;
			//pos.y = (ballPos.y + forceApplied.y * spacing) + (transform.right.magnitude) * (customGravity * spacing * spacing) / 2f;

			pos.x = (ballPos.x + forceApplied.x * spacing);
			pos.y = (ballPos.y + forceApplied.y * spacing);
			

			dotsList[i].position = pos;

			spacing += dotSpacing;
		}
	}

	public void Show ()
	{
		dotsParent.SetActive (true);
	}

	public void Hide ()
	{
		dotsParent.SetActive (false);
	}
}
