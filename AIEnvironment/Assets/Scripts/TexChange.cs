// Change renderer's texture each changeInterval/
// seconds from the texture array defined in the inspector.

//---------base taken from unity documentation-----------//

using UnityEngine;
using System.Collections;

public class TexChange : MonoBehaviour {
	public Texture[] textures;
	//public float changeInterval = 0.33F;
	public Renderer rend;
	
	void Start() {
		rend = GetComponent<Renderer>();
		float num= Random.Range(0,textures.Length);
		rend.material.mainTexture = textures[(int)num];
	}
	
	void Update() {
		//if (textures.Length == 0)
		//	return;

		//test change
		if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)) {
			float num= Random.Range(0,textures.Length);
			rend.material.mainTexture = textures[(int)num];
		}
		//int index = Mathf.FloorToInt(Time.time / changeInterval);
		//index = index % textures.Length;
		//float num= Random.Range(0,4);
		//rend.material.mainTexture = textures[(int)num];
	}
}