using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour {

    [SerializeField] private Explodable _explodable;

	//public ResultUI resultUI;
	public GameObject _hintText;
    [SerializeField] ExplosionForce ef;



    void Start()
	{
        _explodable = GetComponent<Explodable>();
         ef = GameObject.FindObjectOfType<ExplosionForce>();
    }
	void OnMouseDown()
	{
		//Debug.Log("click");
		//resultUI.ResultCalculate();
		_explodable.explode();
		//ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
		ef.doExplosion(transform.position);

		/*if(_hintText.activeSelf && _hintText != null)
        {
			_hintText.SetActive(false);

		}*/
		
	}

	public void ExplodeNow()
    {
        Debug.Log("Explo");
        //resultUI.ResultCalculate();
        _explodable.explode();
		//ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
		ef.doExplosion(transform.position);

		
		/*if (_hintText.activeSelf && _hintText != null)
		{
			_hintText.SetActive(false);

		}*/

	}

	

	
}
