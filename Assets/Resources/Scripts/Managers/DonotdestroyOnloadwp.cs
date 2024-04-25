using UnityEngine;

namespace water_color_sorting.Resources.Scripts.Managers
{
	public class DonotdestroyOnloadwp : MonoBehaviour
	{
		public static DonotdestroyOnloadwp dontDestroywp;
		private void Awake()
		{
			if (dontDestroywp == null) 
			{
				dontDestroywp = gameObject.GetComponent<DonotdestroyOnloadwp>();
				DontDestroyOnLoad (gameObject);
			} 
			else 
			{
				if (this != dontDestroywp)
				{
					Destroy (gameObject);
				}
			}
		}
	}
}

