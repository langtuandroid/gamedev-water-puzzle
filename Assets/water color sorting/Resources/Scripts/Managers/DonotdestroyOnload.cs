using UnityEngine;

namespace water_color_sorting.Resources.Scripts
{
	public class DonotdestroyOnload : MonoBehaviour
	{
		public  static DonotdestroyOnload dontDestroywp;
		void Awake()
		{
			if (dontDestroywp == null) 
			{
				dontDestroywp = gameObject.GetComponent<DonotdestroyOnload>();
				DontDestroyOnLoad (gameObject);
			} 
			else 
			{
				if (this != dontDestroywp)
				{
					print ("dontdestroy");
					Destroy (gameObject);
				}
			}
		}
	}
}
