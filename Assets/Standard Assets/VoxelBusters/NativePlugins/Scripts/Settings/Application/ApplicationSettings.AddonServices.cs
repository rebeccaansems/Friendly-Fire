using UnityEngine;
using System.Collections;

namespace VoxelBusters.NativePlugins
{
	using Internal;
	
	public partial class ApplicationSettings 
	{
		[System.Serializable]
		public class AddonServices
		{
			#region Fields
			#endregion
			
			#region Properties
			
			public bool UsesSoomlaGrow
			{
				get
				{
					return false;
				}
			}
			
			public bool UsesOneSignal
			{
				get
				{
					return false;
				}
			}
			
			#endregion
		}
	}
}