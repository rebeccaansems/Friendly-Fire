using UnityEngine;
using System.Collections;

namespace VoxelBusters.NativePlugins
{
	using Internal;

	public partial class ApplicationSettings 
	{
		[System.Serializable]
		public partial class Features
		{
			#region Fields

			[SerializeField]
			[NotifyNPSettingsOnValueChange]
			[Tooltip("If enabled, Address Book feature will be active within your application.")]
			private		bool						m_usesAddressBook 	= true;
			[SerializeField]
			[NotifyNPSettingsOnValueChange]
			[Tooltip("If enabled, Network Connectivity feature will be active within your application.")]
			private		bool						m_usesNetworkConnectivity = true;
            
			[SerializeField]
			[NotifyNPSettingsOnValueChange]
			[Tooltip("If enabled, Sharing feature will be active within your application.")]
			private		bool						m_usesSharing 		= true;
           

			#endregion

			#region Properties

			public bool UsesAddressBook
			{
				get
				{
					return m_usesAddressBook;
				}
			}

			public bool UsesBilling
			{
				get
				{
					return false;
				}
			}

			public bool UsesCloudServices
			{
				get
				{
					return false;
				}
			}
			
			public bool UsesGameServices
			{
				get
				{
					return false;
				}
			}
			
			public bool UsesMediaLibrary
			{
				get
				{
					return false;
				}
			}

			public MediaLibraryFeature MediaLibrary
			{
				get
				{
					return null;
				}
			}

			public bool UsesNetworkConnectivity
			{
				get
				{
					return m_usesNetworkConnectivity;
				}
			}
			
			public bool UsesNotificationService
			{
				get
				{
					return false;
				}
			}

			public NotificationServiceFeature NotificationService
			{
				get
				{
					return null;
				}
			}

			public bool UsesSharing
			{
				get
				{
					return m_usesSharing;
				}
			}

			public bool UsesTwitter
			{
				get
				{
					return false;
				}
			}

			public bool UsesWebView
			{
				get
				{
					return false;
				}
			}
			
			#endregion

			#region Nested Types

			[System.Serializable]
			public class MultiComponentFeature
			{
				#region Fields

				public	bool	value		= true;

				#endregion
			}

			[System.Serializable]
			public class MediaLibraryFeature : MultiComponentFeature
			{
				#region Fields

				public	bool	usesCamera		= true;
				public	bool	usesPhotoAlbum	= true;

				#endregion
			}

			[System.Serializable]
			public class NotificationServiceFeature : MultiComponentFeature
			{
				#region Fields

				public	bool	usesLocalNotification	= true;
				public	bool	usesRemoteNotification	= true;

				#endregion
			}

			#endregion
		}
	}
}