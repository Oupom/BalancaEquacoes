using System;

namespace Models1
{
	[Serializable]
	public class PostNovo
	{

		public string pes;

		public string pos;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}

