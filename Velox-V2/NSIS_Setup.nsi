; Script generated by the HM NIS Edit Script Wizard.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "Velox"
!define PRODUCT_VERSION "2.0.0"
!define PRODUCT_PUBLISHER "Endev"
!define PRODUCT_WEB_SITE "https://endev.at/p/velox"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\Velox.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

SetCompressor lzma

; MUI 1.67 compatible ------
!include "MUI.nsh"

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "VeloxIcon.ico"
!define MUI_UNICON "VeloxUninstallIcon.ico"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; License page
!insertmacro MUI_PAGE_LICENSE "..\LICENSE"
; Directory page
!insertmacro MUI_PAGE_DIRECTORY
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
!define MUI_FINISHPAGE_RUN "$INSTDIR\Velox.exe"
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "English"

; Reserve files
!insertmacro MUI_RESERVEFILE_INSTALLOPTIONS

; MUI end ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "Velox_Setup.exe"
InstallDir "$PROGRAMFILES\Endev\Velox"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

Section "Velox Main" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite try
  File "Velox\bin\Release\EnvDTE.dll"
  File "Velox\bin\Release\stdole.dll"
  File "Velox\bin\Release\Syncfusion.Core.WinForms.dll"
  File "Velox\bin\Release\Syncfusion.Grid.Base.dll"
  File "Velox\bin\Release\Syncfusion.Grid.Windows.dll"
  File "Velox\bin\Release\Syncfusion.Grid.Windows.XmlSerializers.dll"
  File "Velox\bin\Release\Syncfusion.Licensing.dll"
  File "Velox\bin\Release\Syncfusion.Schedule.Base.dll"
  File "Velox\bin\Release\Syncfusion.Schedule.Windows.dll"
  File "Velox\bin\Release\Syncfusion.SfInput.WinForms.dll"
  File "Velox\bin\Release\Syncfusion.Shared.Base.dll"
  File "Velox\bin\Release\Syncfusion.Shared.Windows.dll"
  File "Velox\bin\Release\Syncfusion.SpellChecker.Base.dll"
  File "Velox\bin\Release\Syncfusion.Tools.Base.dll"
  File "Velox\bin\Release\Syncfusion.Tools.Windows.dll"
  File "Velox\bin\Release\System.Data.SQLite.dll"
  File "Velox\bin\Release\System.Data.SQLite.dll.config"
  File "Velox\bin\Release\Velox.exe"
  CreateDirectory "$SMPROGRAMS\Velox"
  CreateShortCut "$SMPROGRAMS\Velox\Velox.lnk" "$INSTDIR\Velox.exe"
  CreateShortCut "$DESKTOP\Velox.lnk" "$INSTDIR\Velox.exe"
  File "Velox\bin\Release\Velox.pdb"
  File "Velox\bin\Release\WrapSQLBase.dll"
  File "Velox\bin\Release\WrapSQLite.dll"
  SetOutPath "$INSTDIR\x64"
  File "Velox\bin\Release\x64\SQLite.Interop.dll"
  SetOutPath "$INSTDIR\x86"
  File "Velox\bin\Release\x86\SQLite.Interop.dll"
SectionEnd

Section -AdditionalIcons
  SetOutPath $INSTDIR
  WriteIniStr "$INSTDIR\${PRODUCT_NAME}.url" "InternetShortcut" "URL" "${PRODUCT_WEB_SITE}"
  CreateShortCut "$SMPROGRAMS\Velox\Website.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "$SMPROGRAMS\Velox\Uninstall.lnk" "$INSTDIR\uninst.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\Velox.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\Velox.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd


Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) was removed from your computer successfully."
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "Do you want to remove $(^Name) and all of its components?" IDYES +2
  Abort
FunctionEnd

Section Uninstall
  Delete "$INSTDIR\${PRODUCT_NAME}.url"
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\x86\SQLite.Interop.dll"
  Delete "$INSTDIR\x64\SQLite.Interop.dll"
  Delete "$INSTDIR\WrapSQLite.dll"
  Delete "$INSTDIR\WrapSQLBase.dll"
  Delete "$INSTDIR\Velox.pdb"
  Delete "$INSTDIR\Velox.exe"
  Delete "$INSTDIR\System.Data.SQLite.dll.config"
  Delete "$INSTDIR\System.Data.SQLite.dll"
  Delete "$INSTDIR\Syncfusion.Tools.Windows.dll"
  Delete "$INSTDIR\Syncfusion.Tools.Base.dll"
  Delete "$INSTDIR\Syncfusion.SpellChecker.Base.dll"
  Delete "$INSTDIR\Syncfusion.Shared.Windows.dll"
  Delete "$INSTDIR\Syncfusion.Shared.Base.dll"
  Delete "$INSTDIR\Syncfusion.SfInput.WinForms.dll"
  Delete "$INSTDIR\Syncfusion.Schedule.Windows.dll"
  Delete "$INSTDIR\Syncfusion.Schedule.Base.dll"
  Delete "$INSTDIR\Syncfusion.Licensing.dll"
  Delete "$INSTDIR\Syncfusion.Grid.Windows.XmlSerializers.dll"
  Delete "$INSTDIR\Syncfusion.Grid.Windows.dll"
  Delete "$INSTDIR\Syncfusion.Grid.Base.dll"
  Delete "$INSTDIR\Syncfusion.Core.WinForms.dll"
  Delete "$INSTDIR\stdole.dll"
  Delete "$INSTDIR\EnvDTE.dll"

  Delete "$SMPROGRAMS\Velox\Uninstall.lnk"
  Delete "$SMPROGRAMS\Velox\Website.lnk"
  Delete "$DESKTOP\Velox.lnk"
  Delete "$SMPROGRAMS\Velox\Velox.lnk"

  RMDir "$SMPROGRAMS\Velox"
  RMDir "$INSTDIR\x86"
  RMDir "$INSTDIR\x64"
  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd