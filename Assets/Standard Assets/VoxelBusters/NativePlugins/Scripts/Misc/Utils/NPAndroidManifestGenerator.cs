using UnityEngine;
using System.Collections;
using VoxelBusters.Utility;

#if UNITY_EDITOR
using System.Xml;

using PlayerSettings = VoxelBusters.Utility.PlayerSettings;

namespace VoxelBusters.NativePlugins
{
	public class NPAndroidManifestGenerator : AndroidManifestGenerator
	{
		#region Properties

		private			ApplicationSettings.Features		m_supportedFeatures;

		#endregion

		#region Constructors

		public NPAndroidManifestGenerator ()
		{
			m_supportedFeatures	= NPSettings.Application.SupportedFeatures;
		}

		#endregion

		#region Application Methods

		protected override void WriteApplicationProperties (XmlWriter _xmlWriter)
		{
			WriteActivityInfo(_xmlWriter);
			WriteProviderInfo(_xmlWriter);
			WriteReceiverInfo(_xmlWriter);
			WriteServiceInfo(_xmlWriter);
			WriteMetaInfo(_xmlWriter);
		}

		private void WriteActivityInfo (XmlWriter _xmlWriter)
		{
			// Sharing
			if (m_supportedFeatures.UsesSharing)
			{
				WriteActivity(_xmlWriter:		_xmlWriter,
				              _name:			"com.voxelbusters.nativeplugins.features.sharing.SharingActivity",
				              _theme:			"@style/FloatingActivityTheme",
				              _comment:			"Sharing");
			}

			if (m_supportedFeatures.UsesWebView)
			{
				WriteActivity(_xmlWriter:		_xmlWriter,
				              _name:			"com.voxelbusters.nativeplugins.features.webview.FileChooserActivity",
				              _theme:			"@style/FloatingActivityTheme",
				              _comment:			"Webview : For File Choosing");
				WriteActivity(_xmlWriter:		_xmlWriter,
					_name:			"com.voxelbusters.nativeplugins.features.webview.WebviewActivity",
					_theme:			"@style/FloatingActivityTheme",
					_comment:			"Webview : For showing full screen webview's in a different new activity");
			}

			WriteActivity(_xmlWriter:		_xmlWriter,
				_name:			"com.voxelbusters.nativeplugins.features.medialibrary.CameraActivity",
				_theme:			"@style/FloatingActivityTheme",
				_comment:			"Media Library : For custom camera access");


			//Common required activities

			//UIActivity
			WriteActivity(_xmlWriter:		_xmlWriter,
			              _name:			"com.voxelbusters.nativeplugins.features.ui.UiActivity",
			              _theme:			"@style/FloatingActivityTheme",
			              _comment:			"UI  : Generic helper activity for launching Dialogs");

			WriteActivity(_xmlWriter:		_xmlWriter,
				_name:			"com.voxelbusters.nativeplugins.helpers.PermissionRequestActivity",
				_theme:			"@style/FloatingActivityTheme",
				_comment:			"Game Play Services helper activity");
		}

		private void WriteProviderInfo (XmlWriter _xmlWriter)
		{
			// Provider
			_xmlWriter.WriteComment("Custom File Provider. Sharing from internal folders  \"com.voxelbusters.nativeplugins.extensions.FileProviderExtended\"");
			_xmlWriter.WriteStartElement("provider");
			{
				WriteAttributeString(_xmlWriter, "android", "name", null, "com.voxelbusters.nativeplugins.extensions.FileProviderExtended");
				WriteAttributeString(_xmlWriter, "android", "authorities", null, string.Format("{0}.fileprovider", PlayerSettings.GetBundleIdentifier()));
				WriteAttributeString(_xmlWriter, "android", "exported", null, "false");
				WriteAttributeString(_xmlWriter, "android", "grantUriPermissions", null, "true");

				_xmlWriter.WriteStartElement("meta-data");
				{
					WriteAttributeString(_xmlWriter, "android", "name", null, "android.support.FILE_PROVIDER_PATHS");
					WriteAttributeString(_xmlWriter, "android", "resource", null, "@xml/nativeplugins_file_paths");
				}
				_xmlWriter.WriteEndElement();
			}
			_xmlWriter.WriteEndElement();
		}

		private void WriteReceiverInfo (XmlWriter _xmlWriter)
		{
			
		}

		private void WriteServiceInfo (XmlWriter _xmlWriter)
		{
			
		}

        private void WriteMetaInfo(XmlWriter _xmlWriter)
        {
#if USES_GAME_SERVICES
            _xmlWriter.WriteStartElement("meta-data");
            {
                WriteAttributeString(_xmlWriter, "android", "name", null, "com.google.android.gms.games.APP_ID");
                WriteAttributeString(_xmlWriter, "android", "value", null, string.Format("\\u003{0}", NPSettings.GameServicesSettings.Android.PlayServicesApplicationID));// Space Added because its getting considered as integer when added from xml instead of string.
            }
            _xmlWriter.WriteEndElement();
#endif

#if USES_NOTIFICATION_SERVICE
            _xmlWriter.WriteStartElement("meta-data");
            {
                WriteAttributeString(_xmlWriter, "android", "name", null, "com.google.firebase.messaging.default_notification_icon");
                WriteAttributeString(_xmlWriter, "android", "resource", null, "@drawable/ic_stat_ic_notification");// Space Added because its getting considered as integer when added from xml instead of string.
            }
            _xmlWriter.WriteEndElement();

            _xmlWriter.WriteStartElement("meta-data");
            {
                WriteAttributeString(_xmlWriter, "android", "name", null, "com.google.firebase.messaging.default_notification_color");
                WriteAttributeString(_xmlWriter, "android", "resource", null, "@color/colorAccent");
            }
            _xmlWriter.WriteEndElement();
#endif
        }

		#endregion

		#region Permission Methods

		protected override void WritePermissions (XmlWriter _xmlWriter)
		{
			if (m_supportedFeatures.UsesAddressBook)
			{
				WriteUsesPermission(_xmlWriter:	_xmlWriter,
				                    _name: 		"android.permission.READ_CONTACTS",
				                    _comment: 	"Address Book");
			}

			if (m_supportedFeatures.UsesNetworkConnectivity)
			{

				WriteUsesPermission(_xmlWriter:	_xmlWriter,
				                    _name: 		"android.permission.ACCESS_NETWORK_STATE",
				                    _comment: 	"Network Connectivity");
			}



			//Write common permissions here

			if(m_supportedFeatures.UsesNotificationService || NPSettings.Utility.Android.ModifiesApplicationBadge)
			{
				// For badge permissions
				WriteBadgePermissionsForAllPlatforms(_xmlWriter);
			}

			//Internet access - Add by default as many features need this.
			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: 		"android.permission.INTERNET",
			                    _comment:	"Required for internet access");

		}

		private void WriteBadgePermissionsForAllPlatforms (XmlWriter _xmlWriter)
		{
			WriteUsesPermission(_xmlWriter:	_xmlWriter,
					            _name: "com.sec.android.provider.badge.permission.READ",
			                    _comment: "Notifications : Badge Permission for Samsung Devices");

			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.sec.android.provider.badge.permission.WRITE");

			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.htc.launcher.permission.READ_SETTINGS",
			                    _comment: "Notifications : Badge Permission for HTC Devices");
			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.htc.launcher.permission.UPDATE_SHORTCUT");


			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.sonyericsson.home.permission.BROADCAST_BADGE",
			                    _comment: "Notifications : Badge Permission for Sony Devices");
			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.sonymobile.home.permission.PROVIDER_INSERT_BADGE");


			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.anddoes.launcher.permission.UPDATE_COUNT",
			                    _comment: "Notifications : Badge Permission for Apex Devices");


			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.majeur.launcher.permission.UPDATE_BADGE",
			                    _comment: "Notifications : Badge Permission for Solid Devices");

			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.huawei.android.launcher.permission.CHANGE_BADGE",
			                    _comment: "Notifications : Badge Permission for Huawei Devices");
			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.huawei.android.launcher.permission.READ_SETTINGS");
			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.huawei.android.launcher.permission.WRITE_SETTINGS");


			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "android.permission.READ_APP_BADGE",
			                    _comment: "Notifications : Badge Permission for ZUK Devices");


			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.oppo.launcher.permission.READ_SETTINGS",
			                    _comment: "Notifications : Badge Permission for Oppo Devices");
			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "com.oppo.launcher.permission.WRITE_SETTINGS");


			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "me.everything.badger.permission.BADGE_COUNT_READ",
			                    _comment: "Notifications : Badge Permission for EverythingMe Support");
			WriteUsesPermission(_xmlWriter:	_xmlWriter,
			                    _name: "me.everything.badger.permission.BADGE_COUNT_WRITE");

		}

		#endregion
	}
}
#endif
