// Info from: https://docs.microsoft.com/en-us/windows/win32/shell/knownfolderid

using System;

namespace VDFramework.Utility.Windows
{
	// ReSharper disable UnusedMember.Global
	// ReSharper disable InconsistentNaming

	/// <summary>
	/// An utility class to easily access information about the special folders
	/// </summary>
	public static class SpecialFolders
	{
		public static readonly SpecialFolder AccountPictures = new SpecialFolder(new Guid("{008ca0b1-55b4-4c56-b8a8-4de4b299d3be}"),
			"Account Pictures", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\AccountPictures");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder AddNewPrograms = new SpecialFolder(new Guid("{de61d971-5ebc-4f02-a3a9-6c82895e5c04}"),
			"Get Programs", FolderType.VIRTUAL, string.Empty);

		public static readonly SpecialFolder AdminTools = new SpecialFolder(new Guid("{724EF170-A42D-4FEF-9F26-B60E846FBA4F}"),
			"Administrative Tools", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Start Menu\Programs\Administrative Tools",
			"CSIDL_ADMINTOOLS");

		/// <summary>
		/// Used internally by .NET applications to enable cross-platform app functionality. It is not intended to be used directly from an application.
		/// </summary>
		public static readonly SpecialFolder AppdataDesktop = new SpecialFolder(new Guid("{B2C5E279-7ADD-439F-B28C-C41FE1BBF672}"),
			"AppDataDesktop", FolderType.PERUSER, "LOCALAPPDATA", @"\Desktop");

		/// <summary>
		/// Used internally by .NET applications to enable cross-platform app functionality. It is not intended to be used directly from an application.
		/// </summary>
		public static readonly SpecialFolder AppdataDocuments = new SpecialFolder(new Guid("{7BE16610-1F7F-44AC-BFF0-83E15F2FFCA1}"),
			"AppdataDocuments", FolderType.PERUSER, "LOCALAPPDATA", @"\Documents");

		/// <summary>
		/// Used internally by .NET applications to enable cross-platform app functionality. It is not intended to be used directly from an application.
		/// </summary>
		public static readonly SpecialFolder AppDataFavorites = new SpecialFolder(new Guid("{7CFBEFBC-DE1F-45AA-B843-A542AC536CC9}"),
			"AppDataFavorites", FolderType.PERUSER, "LOCALAPPDATA", @"\Favorites");

		/// <summary>
		/// Used internally by .NET applications to enable cross-platform app functionality. It is not intended to be used directly from an application.
		/// </summary>
		public static readonly SpecialFolder AppDataProgramData = new SpecialFolder(new Guid("{559D40A3-A036-40FA-AF61-84CB430A4D34}"),
			"AppDataProgramData", FolderType.PERUSER, "LOCALAPPDATA", @"\ProgramData");

		public static readonly SpecialFolder ApplicationShortcuts = new SpecialFolder(new Guid("{A3918781-E5F2-4890-B3D9-A7E54332328C}"),
			"Application Shortcuts", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows\Application Shortcuts");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder AppsFolder = new SpecialFolder(new Guid("{1e87508d-89c2-42f0-8a7e-645a0f50ca58}"),
			"Applications", FolderType.VIRTUAL, string.Empty);

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder AppUpdates = new SpecialFolder(new Guid("{a305ce99-f527-492b-8b1a-7e76fa98d6e4}"),
			"Installed Updates", FolderType.VIRTUAL, string.Empty);

		public static readonly SpecialFolder CameraRoll = new SpecialFolder(new Guid("{AB5FB87B-7CE2-4F83-915D-550846C9537B}"),
			"Camera Roll", FolderType.PERUSER, "USERPROFILE", @"\Pictures\Camera Roll");

		public static readonly SpecialFolder CDBurning = new SpecialFolder(new Guid("{9E52AB10-F80D-49DF-ACB8-4330F5687855}"),
			"Temporary Burn Folder", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows\Burn\Burn",
			"CSIDL_CDBURN_AREA");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder ChangeRemovePrograms = new SpecialFolder(new Guid("{df7266ac-9274-4867-8d55-3bd661de872d}"),
			"Programs and Features", FolderType.VIRTUAL, string.Empty);

		public static readonly SpecialFolder CommonAdminTools = new SpecialFolder(new Guid("{D0384E7D-BAC3-4797-8F14-CBA229B392B5}"),
			"Administrative Tools", FolderType.COMMON, "ALLUSERSPROFILE", @"\Microsoft\Windows\Start Menu\Programs\Administrative Tools",
			"CSIDL_COMMON_ADMINTOOLS");

		public static readonly SpecialFolder CommonOEMLinks = new SpecialFolder(new Guid("{C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D}"),
			"OEM Links", FolderType.COMMON, "ALLUSERSPROFILE", @"\OEM Links",
			"CSIDL_COMMON_OEM_LINKS");

		public static readonly SpecialFolder CommonPrograms = new SpecialFolder(new Guid("{0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8}"),
			"Programs", FolderType.COMMON, "ALLUSERSPROFILE", @"\Microsoft\Windows\Start Menu\Programs",
			"CSIDL_COMMON_PROGRAMS");

		public static readonly SpecialFolder CommonStartMenu = new SpecialFolder(new Guid("{A4115719-D62E-491D-AA7C-E74B8BE3B067}"),
			"Start Menu", FolderType.COMMON, "ALLUSERSPROFILE", @"\Microsoft\Windows\Start Menu",
			"CSIDL_COMMON_STARTMENU");

		public static readonly SpecialFolder CommonStartup = new SpecialFolder(new Guid("{82A5EA35-D9CD-47C5-9629-E15D2F714E6E}"),
			"Startup", FolderType.COMMON, "ALLUSERSPROFILE", @"\Microsoft\Windows\Start Menu\Programs\StartUp",
			"CSIDL_COMMON_STARTUP", "CSIDL_COMMON_ALTSTARTUP");

		public static readonly SpecialFolder CommonTemplates = new SpecialFolder(new Guid("{B94237E7-57AC-4347-9151-B08C6C32D1F7}"),
			"Templates", FolderType.COMMON, "ALLUSERSPROFILE", @"\Microsoft\Windows\Templates",
			"CSIDL_COMMON_TEMPLATES");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder ComputerFolder = new SpecialFolder(new Guid("{0AC0837C-BBF8-452A-850D-79D08E667CA7}"),
			"Computer", FolderType.VIRTUAL, string.Empty, null,
			"CSIDL_DRIVES");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder ConflictFolder = new SpecialFolder(new Guid("{4bfefb45-347d-4006-a5be-ac0cb0567192}"),
			"Conflicts", FolderType.VIRTUAL, string.Empty);

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder ConnectionsFolder = new SpecialFolder(new Guid("{6F0CD92B-2E97-45D1-88FF-B0D186B8DEDD}"),
			"Network Connections", FolderType.VIRTUAL, string.Empty, null,
			"CSIDL_CONNECTIONS");

		public static readonly SpecialFolder Contacts = new SpecialFolder(new Guid("{56784854-C6CB-462b-8169-88E350ACB882}"),
			"Contacts", FolderType.PERUSER, "USERPROFILE", @"\Contacts");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder ControlPanelFolder = new SpecialFolder(new Guid("{82A74AEB-AEB4-465C-A014-D097EE346D63}"),
			"Control Panel", FolderType.VIRTUAL, string.Empty, null,
			"CSIDL_CONTROLS");

		public static readonly SpecialFolder Cookies = new SpecialFolder(new Guid("{2B0F765D-C0E9-4171-908E-08A611B84FF6}"),
			"Cookies", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Cookies",
			"CSIDL_COOKIES");

		public static readonly SpecialFolder Desktop = new SpecialFolder(new Guid("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}"),
			"Desktop", FolderType.PERUSER, "USERPROFILE", @"\Desktop",
			"CSIDL_DESKTOP", "CSIDL_DESKTOPDIRECTORY");

		public static readonly SpecialFolder DeviceMetadataStore = new SpecialFolder(new Guid("{5CE4A5E9-E4EB-479D-B89F-130C02886155}"),
			"DeviceMetadataStore", FolderType.COMMON, "ALLUSERSPROFILE", @"\Microsoft\Windows\DeviceMetadataStore");

		public static readonly SpecialFolder Documents = new SpecialFolder(new Guid("{FDD39AD0-238F-46AF-ADB4-6C85480369C7}"),
			"Documents", FolderType.PERUSER, "USERPROFILE", @"\Documents",
			"CSIDL_MYDOCUMENTS", "CSIDL_PERSONAL");

		public static readonly SpecialFolder DocumentsLibrary = new SpecialFolder(new Guid("{7B0DB17D-9CD2-4A93-9733-46CC89022E7C}"),
			"Documents", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Libraries\Documents.library-ms");

		/// <summary>
		/// The default folder where downloaded files are stored.
		/// </summary>
		public static readonly SpecialFolder Downloads = new SpecialFolder(new Guid("{374DE290-123F-4565-9164-39C4925E467B}"),
			"Downloads", FolderType.PERUSER, "USERPROFILE", @"\Downloads");

		public static readonly SpecialFolder Favorites = new SpecialFolder(new Guid("{1777F761-68AD-4D8A-87BD-30B759FA33DD}"),
			"Favorites", FolderType.PERUSER, "USERPROFILE", @"\Favorites");

		public static readonly SpecialFolder Fonts = new SpecialFolder(new Guid("{FD228CB7-AE11-4AE3-864C-16F3910AB8FE}"),
			"Fonts", FolderType.FIXED, "windir", @"\Fonts");

		/// <summary>
		/// Deprecated in Windows 10, version 1803 and later versions. In these versions, it returns 0x80070057 - E_INVALIDARG
		///<para></para>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder Games = new SpecialFolder(new Guid("{CAC52C1A-B53D-4edc-92D7-6B2E8AC19434}"),
			"Games", FolderType.VIRTUAL, string.Empty);

		public static readonly SpecialFolder GameTasks = new SpecialFolder(new Guid("{054FAE61-4DD8-4787-80B6-090220C4B700}"),
			"GameExplorer", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows\GameExplorer");

		public static readonly SpecialFolder History = new SpecialFolder(new Guid("{D9DC8A3B-B784-432E-A781-5A1130A75963}"),
			"History", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows\History",
			"CSIDL_HISTORY");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder HomeGroup = new SpecialFolder(new Guid("{52528A6B-B9E3-4ADD-B60D-588C2DBA842D}"),
			"Homegroup", FolderType.VIRTUAL, string.Empty);

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder HomeGroupCurrentUser = new SpecialFolder(new Guid("{9B74B6A3-0DFD-4f11-9E78-5F7800F2E772}"),
			Environment.UserName, FolderType.VIRTUAL, string.Empty);

		public static readonly SpecialFolder ImplicitAppShortcuts = new SpecialFolder(new Guid("{BCB5256F-79F6-4CEE-B725-DC34E402FD46}"),
			"ImplicitAppShortcuts", FolderType.PERUSER, "APPDATA",
			@"\Microsoft\Internet Explorer\Quick Launch\User Pinned\ImplicitAppShortcuts");

		public static readonly SpecialFolder InternetCache = new SpecialFolder(new Guid("{352481E8-33BE-4251-BA85-6007CAEDCF9D}"),
			"Temporary Internet Files", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows\Temporary Internet Files",
			"CSIDL_INTERNET_CACHE");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder InternetFolder = new SpecialFolder(new Guid("{4D9F7874-4E0C-4904-967B-40B0D20C3E4B}"),
			"The Internet", FolderType.VIRTUAL, string.Empty, null,
			"CSIDL_INTERNET");

		/// <summary>
		/// The folder where libraries like 'Videos', 'Images', 'Documents', 'Music' etc. are stored.
		/// </summary>
		public static readonly SpecialFolder Libraries = new SpecialFolder(new Guid("{1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE}"),
			"Libraries", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Libraries");

		public static readonly SpecialFolder Links = new SpecialFolder(new Guid("{bfb9d5e0-c6a9-404c-b2b2-ae6db6af4968}"),
			"Links", FolderType.PERUSER, "USERPROFILE", @"\Links");

		public static readonly SpecialFolder LocalAppData = new SpecialFolder(new Guid("{F1B32785-6FBA-4FCF-9D55-7B8E7F157091}"),
			"Local", FolderType.PERUSER, "LOCALAPPDATA", string.Empty,
			"CSIDL_LOCAL_APPDATA");

		public static readonly SpecialFolder LocalAppDataLow = new SpecialFolder(new Guid("{A520A1A4-1780-4FF6-BD18-167343C5AF16}"),
			"LocalLow", FolderType.PERUSER, "USERPROFILE", @"\AppData\LocalLow");

		public static readonly SpecialFolder LocalizedResourcesDir = new SpecialFolder(new Guid("{2A00375E-224C-49DE-B8D1-440DF7EF3DDC}"),
			"N/A", FolderType.FIXED, "windir", @"\resources\0409",
			"CSIDL_RESOURCES_LOCALIZED");

		public static readonly SpecialFolder Music = new SpecialFolder(new Guid("{4BD8D571-6D19-48D3-BE97-422220080E43}"),
			"Music", FolderType.PERUSER, "USERPROFILE", @"\Music",
			"CSIDL_MYMUSIC");

		public static readonly SpecialFolder MusicLibrary = new SpecialFolder(new Guid("{2112AB0A-C86A-4FFE-A368-0DE96E47012E}"),
			"Music", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Libraries\Music.library-ms");

		public static readonly SpecialFolder NetHood = new SpecialFolder(new Guid("{C5ABBF53-E17F-4121-8900-86626FC2C973}"),
			"Network Shortcuts", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Network Shortcuts",
			"CSIDL_NETHOOD");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder NetworkFolder = new SpecialFolder(new Guid("{D20BEEC4-5CA8-4905-AE3B-BF251EA09B53}"),
			"Network", FolderType.VIRTUAL, string.Empty, null,
			"CSIDL_NETWORK", "CSIDL_COMPUTERSNEARME");

		public static readonly SpecialFolder Objects3D = new SpecialFolder(new Guid("{31C0DD25-9439-4F12-BF41-7FF4EDA38722}"),
			"3D Objects", FolderType.PERUSER, "USERPROFILE", @"\3D Objects");

		public static readonly SpecialFolder OriginalImages = new SpecialFolder(new Guid("{2C36C0AA-5812-4b87-BFD0-4CD0DFB19B39}"),
			"Original Images", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows Photo Gallery\Original Images");

		public static readonly SpecialFolder PhotoAlbums = new SpecialFolder(new Guid("{69D2CF90-FC33-4FB7-9A0C-EBB0F0FCB43C}"),
			"Slide Shows", FolderType.PERUSER, "USERPROFILE", @"\Pictures\Slide Shows");

		public static readonly SpecialFolder PicturesLibrary = new SpecialFolder(new Guid("{A990AE9F-A03B-4E80-94BC-9912D7504104}"),
			"Pictures", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Libraries\Pictures.library-ms");

		public static readonly SpecialFolder Pictures = new SpecialFolder(new Guid("{33E28130-4E1E-4676-835A-98395C3BC3BB}"),
			"Pictures", FolderType.PERUSER, "USERPROFILE", @"\Pictures",
			"CSIDL_MYPICTURES");

		public static readonly SpecialFolder Playlists = new SpecialFolder(new Guid("{DE92C1C7-837F-4F69-A3BB-86E631204A23}"),
			"Playlists", FolderType.PERUSER, "USERPROFILE", @"\Music\Playlists");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder PrintersFolder = new SpecialFolder(new Guid("{76FC4E2D-D6AD-4519-A663-37BD56068185}"),
			"Printers", FolderType.VIRTUAL, string.Empty, null,
			"CSIDL_PRINTERS");

		public static readonly SpecialFolder PrintHood = new SpecialFolder(new Guid("{9274BD8D-CFD1-41C3-B35E-B13F55A758F4}"),
			"Printer Shortcuts", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Printer Shortcuts",
			"CSIDL_PRINTHOOD");

		public static readonly SpecialFolder Profile = new SpecialFolder(new Guid("{5E6C858F-0E22-4760-9AFE-EA3317B67173}"),
			Environment.UserName, FolderType.FIXED, "USERPROFILE", null,
			"CSIDL_PROFILE");

		public static readonly SpecialFolder ProgramData = new SpecialFolder(new Guid("{62AB5D82-FDC1-4DC3-A9DD-070D1D495D97}"),
			"ProgramData", FolderType.FIXED, "ALLUSERSPROFILE", null,
			"CSIDL_COMMON_APPDATA");

		public static readonly SpecialFolder ProgramFiles = new SpecialFolder(new Guid("{905e63b6-c1bf-494e-b29c-65b732d3d21a}"),
			"Program Files", FolderType.FIXED, "ProgramFiles", null,
			"CSIDL_PROGRAM_FILES");

		/// <summary>
		/// Not supported on 32-bit operating systems. It also is not supported for 32-bit applications running on 64-bit operating systems.
		/// Attempting to use FOLDERID_ProgramFilesX64 in either situation results in an error.
		/// </summary>
		public static readonly SpecialFolder ProgramFilesX64 = new SpecialFolder(new Guid("{6D809377-6AF0-444b-8957-A3773F02200E}"),
			"Program Files", FolderType.FIXED, "ProgramFiles");

		public static readonly SpecialFolder ProgramFilesX86 = new SpecialFolder(new Guid("{7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E}"),
			"Program Files", FolderType.FIXED, "ProgramFiles", null,
			"CSIDL_PROGRAM_FILESX86");

		public static readonly SpecialFolder ProgramFilesCommon = new SpecialFolder(new Guid("{F7F1ED05-9F6D-47A2-AAAE-29D317C6F066}"),
			"Common Files", FolderType.FIXED, "ProgramFiles", @"\Common Files",
			"CSIDL_PROGRAM_FILES_COMMON");

		public static readonly SpecialFolder ProgramFilesCommonX64 = new SpecialFolder(new Guid("{6365D5A7-0F0D-45E5-87F6-0DA56B6A4F7D}"),
			"Common Files", FolderType.FIXED, "ProgramFiles", @"\Common Files");

		public static readonly SpecialFolder ProgramFilesCommonX86 = new SpecialFolder(new Guid("{DE974D24-D9C6-4D3E-BF91-F4455120B917}"),
			"Common Files", FolderType.FIXED, "ProgramFiles", @"\Common Files",
			"CSIDL_PROGRAM_FILES_COMMONX86");

		public static readonly SpecialFolder Programs = new SpecialFolder(new Guid("{A77F5D77-2E2B-44C3-A6A2-ABA601054A51}"),
			"Programs", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Start Menu\Programs",
			"CSIDL_PROGRAMS");

		public static readonly SpecialFolder Public = new SpecialFolder(new Guid("{DFDF76A2-C82A-4D63-906A-5644AC457385}"),
			"Public", FolderType.FIXED, "PUBLIC");

		public static readonly SpecialFolder PublicDesktop = new SpecialFolder(new Guid("{C4AA340D-F20F-4863-AFEF-F87EF2E6BA25}"),
			"Public Desktop", FolderType.COMMON, "PUBLIC", @"\Desktop",
			"CSIDL_COMMON_DESKTOPDIRECTORY");

		public static readonly SpecialFolder PublicDocuments = new SpecialFolder(new Guid("{ED4824AF-DCE4-45A8-81E2-FC7965083634}"),
			"Public Documents", FolderType.COMMON, "PUBLIC", @"\Documents",
			"CSIDL_COMMON_DOCUMENTS");

		public static readonly SpecialFolder PublicDownloads = new SpecialFolder(new Guid("{3D644C9B-1FB8-4f30-9B45-F670235F79C0}"),
			"Public Downloads", FolderType.COMMON, "PUBLIC", @"\Downloads");

		public static readonly SpecialFolder PublicGameTasks = new SpecialFolder(new Guid("{DEBF2536-E1A8-4c59-B6A2-414586476AEA}"),
			"GameExplorer", FolderType.COMMON, "ALLUSERSPROFILE", @"\Microsoft\Windows\GameExplorer");

		public static readonly SpecialFolder PublicLibraries = new SpecialFolder(new Guid("{48DAF80B-E6CF-4F4E-B800-0E69D84EE384}"),
			"Libraries", FolderType.COMMON, "ALLUSERSPROFILE", @"\Microsoft\Windows\Libraries");

		public static readonly SpecialFolder PublicMusic = new SpecialFolder(new Guid("{3214FAB5-9757-4298-BB61-92A9DEAA44FF}"),
			"Public Music", FolderType.COMMON, "PUBLIC", @"\Music",
			"CSIDL_COMMON_MUSIC");

		public static readonly SpecialFolder PublicPictures = new SpecialFolder(new Guid("{B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5}"),
			"Public Pictures", FolderType.COMMON, "PUBLIC", @"\Pictures",
			"CSIDL_COMMON_PICTURES");

		public static readonly SpecialFolder PublicRingtones = new SpecialFolder(new Guid("{E555AB60-153B-4D17-9F04-A5FE99FC15EC}"),
			"Ringtones", FolderType.COMMON, "ALLUSERSPROFILE", @"\Microsoft\Windows\Ringtones");

		public static readonly SpecialFolder PublicUserTiles = new SpecialFolder(new Guid("{0482af6c-08f1-4c34-8c90-e17ec98b1e17}"),
			"Public Account Pictures", FolderType.COMMON, "PUBLIC", @"\AccountPictures");

		public static readonly SpecialFolder PublicVideos = new SpecialFolder(new Guid("{2400183A-6185-49FB-A2D8-4A392A602BA3}"),
			"Public Videos", FolderType.COMMON, "PUBLIC", @"\Videos",
			"CSIDL_COMMON_VIDEO");

		public static readonly SpecialFolder QuickLaunch = new SpecialFolder(new Guid("{52a4f021-7b75-48a9-9f6b-4b87a210bc8f}"),
			"Quick Launch", FolderType.PERUSER, "APPDATA", @"\Microsoft\Internet Explorer\Quick Launch");

		public static readonly SpecialFolder Recent = new SpecialFolder(new Guid("{AE50C081-EBD2-438A-8655-8A092E34987A}"),
			"Recent Items", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Recent",
			"CSIDL_RECENT");

		public static readonly SpecialFolder RecordedTVLibrary = new SpecialFolder(new Guid("{1A6FDBA2-F42D-4358-A798-B74D745926C5}"),
			"Recorded TV", FolderType.COMMON, "PUBLIC", @"\RecordedTV.library-ms");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder RecycleBinFolder = new SpecialFolder(new Guid("{B7534046-3ECB-4C18-BE4E-64CD4CB7D6AC}"),
			"Recycle Bin", FolderType.VIRTUAL, string.Empty, null,
			"CSIDL_BITBUCKET");

		public static readonly SpecialFolder ResourceDir = new SpecialFolder(new Guid("{8AD10C31-2ADB-4296-A8F7-E4701232C972}"),
			"Resources", FolderType.FIXED, "windir", @"\Resources",
			"CSIDL_RESOURCES");

		public static readonly SpecialFolder Ringtones = new SpecialFolder(new Guid("{C870044B-F49E-4126-A9C3-B52A1FF411E8}"),
			"Ringtones", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows\Ringtones");

		public static readonly SpecialFolder RoamingAppData = new SpecialFolder(new Guid("{3EB685DB-65F9-4CF6-A03A-E3EF65729F3D}"),
			"Roaming", FolderType.PERUSER, "APPDATA", null,
			"CSIDL_APPDATA");

		public static readonly SpecialFolder RoamedTileImages = new SpecialFolder(new Guid("{AAA8D5A5-F1D6-4259-BAA8-78E7EF60835E}"),
			"RoamedTileImages", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows\RoamedTileImages");

		public static readonly SpecialFolder RoamingTiles = new SpecialFolder(new Guid("{00BCFC5A-ED94-4e48-96A1-3F6217F21990}"),
			"RoamingTiles", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows\RoamingTiles");

		public static readonly SpecialFolder SampleMusic = new SpecialFolder(new Guid("{B250C668-F57D-4EE1-A63C-290EE7D1AA1F}"),
			"Sample Music", FolderType.COMMON, "PUBLIC", @"\Music\Sample Music");

		public static readonly SpecialFolder SamplePictures = new SpecialFolder(new Guid("{C4900540-2379-4C75-844B-64E6FAF8716B}"),
			"Sample Pictures", FolderType.COMMON, "PUBLIC", @"\Music\Sample Music");

		public static readonly SpecialFolder SamplePlaylists = new SpecialFolder(new Guid("{15CA69B3-30EE-49C1-ACE1-6B5EC372AFB5}"),
			"Sample Playlists", FolderType.COMMON, "PUBLIC", @"\Music\Sample Playlists");

		public static readonly SpecialFolder SampleVideos = new SpecialFolder(new Guid("{859EAD94-2E85-48AD-A71A-0969CB56A6CD}"),
			"Sample Videos", FolderType.COMMON, "PUBLIC", @"\Videos\Sample Videos");

		public static readonly SpecialFolder SavedGames = new SpecialFolder(new Guid("{4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4}"),
			"Saved Games", FolderType.PERUSER, "USERPROFILE", @"\Saved Games");

		public static readonly SpecialFolder SavedPictures = new SpecialFolder(new Guid("{3B193882-D3AD-4eab-965A-69829D1FB59F}"),
			"Saved Pictures", FolderType.PERUSER, "USERPROFILE", @"\Pictures\Saved Pictures");

		public static readonly SpecialFolder SavedPicturesLibrary = new SpecialFolder(new Guid("{E25B5812-BE88-4bd9-94B0-29233477B6C3}"),
			"Saved Pictures Library", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Libraries\SavedPictures.library-ms");

		public static readonly SpecialFolder SavedSearches = new SpecialFolder(new Guid("{7d1d3a04-debb-4115-95cf-2f29da2920da}"),
			"Searches", FolderType.PERUSER, "USERPROFILE", @"\Searches");

		public static readonly SpecialFolder Screenshots = new SpecialFolder(new Guid("{b7bede81-df94-4682-a7d8-57a52620b86f}"),
			"Screenshots", FolderType.PERUSER, "USERPROFILE", @"\Pictures\Screenshots");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder SEARCH_CSC = new SpecialFolder(new Guid("{ee32e446-31ca-4aba-814f-a5ebd2fd6d5e}"),
			"Offline Files", FolderType.VIRTUAL, string.Empty);

		public static readonly SpecialFolder SearchHistory = new SpecialFolder(new Guid("{0D4C3DB6-03A3-462F-A0E6-08924C41B5D4}"),
			"History", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows\ConnectedSearch\History");

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder SearchHome = new SpecialFolder(new Guid("{190337d1-b8ca-4121-a639-6d472d16972a}"),
			"Search Results", FolderType.VIRTUAL, string.Empty);

		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder SEARCH_MAPI = new SpecialFolder(new Guid("{98ec0e18-2098-4d44-8644-66979315a281}"),
			"Microsoft Office Outlook", FolderType.VIRTUAL, string.Empty);
		
		public static readonly SpecialFolder SearchTemplates = new SpecialFolder(new Guid("{7E636BFE-DFA9-4D5E-B456-D7B39851D8A9}"),
			"Templates", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows\ConnectedSearch\Templates");
		
		public static readonly SpecialFolder SendTo = new SpecialFolder(new Guid("{8983036C-27C0-404B-8F08-102D10DCFD74}"),
			"SendTo", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\SendTo",
			"CSIDL_SENDTO");
		
		public static readonly SpecialFolder SidebarDefaultParts = new SpecialFolder(new Guid("{7B396E54-9EC5-4300-BE0A-2482EBAE1A26}"),
			"Gadgets", FolderType.COMMON, "ProgramFiles", @"\Windows Sidebar\Gadgets");
		
		public static readonly SpecialFolder SidebarParts = new SpecialFolder(new Guid("{A75D362E-50FC-4fb7-AC2C-A8BEAA314493}"),
			"Gadgets", FolderType.PERUSER, "LOCALAPPDATA", @"\Microsoft\Windows Sidebar\Gadgets");
		
		/// <summary>
		/// OneDrive
		/// </summary>
		public static readonly SpecialFolder SkyDrive = new SpecialFolder(new Guid("{A52BBA46-E9E1-435f-B3D9-28DAA648C0F6}"),
			"OneDrive", FolderType.PERUSER, "USERPROFILE", @"\OneDrive");
		
		/// <summary>
		/// OneDrive Camera Roll
		/// </summary>
		public static readonly SpecialFolder SkyDriveCameraRoll = new SpecialFolder(new Guid("{767E6811-49CB-4273-87C2-20F355E1085B}"),
			"Camera Roll", FolderType.PERUSER, "USERPROFILE", @"\OneDrive\Pictures\Camera Roll");
		
		/// <summary>
		/// OneDrive Documents
		/// </summary>
		public static readonly SpecialFolder SkyDriveDocuments = new SpecialFolder(new Guid("{24D89E24-2F19-4534-9DDE-6A6671FBB8FE}"),
			"Documents", FolderType.PERUSER, "USERPROFILE", @"\OneDrive\Documents");
		
		/// <summary>
		/// OneDrive Pictures
		/// </summary>
		public static readonly SpecialFolder SkyDrivePictures = new SpecialFolder(new Guid("{339719B5-8C47-4894-94C2-D8F77ADD44A6}"),
			"Pictures", FolderType.PERUSER, "USERPROFILE", @"\OneDrive\Pictures");
		
		public static readonly SpecialFolder StartMenu = new SpecialFolder(new Guid("{625B53C3-AB48-4EC1-BA1F-A1EF4146FC19}"),
			"Start Menu", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Start Menu",
			"CSIDL_STARTMENU");
		
		public static readonly SpecialFolder Startup = new SpecialFolder(new Guid("{B97D20BB-F46A-4C97-BA10-5E3608430854}"),
			"Startup", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Start Menu\Programs\StartUp",
			"CSIDL_STARTUP", "CSIDL_ALTSTARTUP");
		
		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder SyncManagerFolder = new SpecialFolder(new Guid("{43668BF8-C14E-49B2-97C9-747784D784B7}"),
			"Sync Center", FolderType.VIRTUAL, string.Empty);
		
		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder SyncResultsFolder = new SpecialFolder(new Guid("{289a9a43-be44-4057-a41b-587a76d7e7f9}"),
			"Sync Results", FolderType.VIRTUAL, string.Empty);
		
		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder SyncSetupFolder = new SpecialFolder(new Guid("{0F214138-B1D3-4a90-BBA9-27CBC0C5389A}"),
			"Sync Setup", FolderType.VIRTUAL, string.Empty);
		
		/// <summary>
		/// System32
		/// </summary>
		public static readonly SpecialFolder System = new SpecialFolder(new Guid("{1AC14E77-02E7-4E5D-B744-2EB1AE5198B7}"),
			"System32", FolderType.FIXED, "windir", @"\system32",
			"CSIDL_SYSTEM");
		
		public static readonly SpecialFolder SystemX86 = new SpecialFolder(new Guid("{D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27}"),
			"System32", FolderType.FIXED, "windir", @"\system32",
			"CSIDL_SYSTEMX86");
		
		public static readonly SpecialFolder Templates = new SpecialFolder(new Guid("{A63293E8-664E-48DB-A079-DF759E0509F7}"),
			"Templates", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Templates",
			"CSIDL_TEMPLATES");
		
		public static readonly SpecialFolder UserPinned = new SpecialFolder(new Guid("{9E3995AB-1F9C-4F13-B827-48B24B6C7174}"),
			"User Pinned", FolderType.PERUSER, "APPDATA", @"\Microsoft\Internet Explorer\Quick Launch\User Pinned");
		
		public static readonly SpecialFolder UserProfiles = new SpecialFolder(new Guid("{0762D272-C50A-4BB0-A382-697DCD729B80}"),
			"Users", FolderType.FIXED, "SystemDrive", @"\Users");
		
		public static readonly SpecialFolder UserProgramFiles = new SpecialFolder(new Guid("{5CD7AEE2-2219-4A67-B85D-6C9CE15660CB}"),
			"Programs", FolderType.PERUSER, "LOCALAPPDATA", @"\Programs");
		
		public static readonly SpecialFolder UserProgramFilesCommon = new SpecialFolder(new Guid("{BCBD3057-CA5C-4622-B42D-BC56DB0AE516}"),
			"Programs", FolderType.PERUSER, "LOCALAPPDATA", @"\Programs\Common");
		
		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder UsersFiles = new SpecialFolder(new Guid("{f3ce0f7c-4901-4acc-8648-d5d44b04ef8f}"),
			Environment.UserName, FolderType.VIRTUAL, string.Empty);
		
		/// <summary>
		/// <para>VIRTUAL FOLDER: no path available</para>
		/// </summary>
		public static readonly SpecialFolder UsersLibraries = new SpecialFolder(new Guid("{A302545D-DEFF-464b-ABE8-61C8648D939B}"),
			"Libraries", FolderType.VIRTUAL, string.Empty);
		
		public static readonly SpecialFolder Videos = new SpecialFolder(new Guid("{18989B1D-99B5-455B-841C-AB7C74E4DDFC}"),
			"Videos", FolderType.PERUSER, "USERPROFILE", @"\Videos",
			"CSIDL_MYVIDEO");
		
		public static readonly SpecialFolder VideosLibrary = new SpecialFolder(new Guid("{491E922F-5643-4AF4-A7EB-4E7A138D8174}"),
			"Videos", FolderType.PERUSER, "APPDATA", @"\Microsoft\Windows\Libraries\Videos.library-ms",
			"CSIDL_MYVIDEO");
		
		public static readonly SpecialFolder Windows = new SpecialFolder(new Guid("{F38BF404-1D43-42F2-9305-67DE0B28FC23}"),
			"Windows", FolderType.FIXED, "windir", null,
			"CSIDL_WINDOWS");
	}
}