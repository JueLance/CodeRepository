; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CFlashWindowExDlg
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "FlashWindowEx.h"

ClassCount=4
Class1=CFlashWindowExApp
Class2=CFlashWindowExDlg
Class3=CAboutDlg

ResourceCount=3
Resource1=IDD_ABOUTBOX
Resource2=IDR_MAINFRAME
Resource3=IDD_FLASHWINDOWEX_DIALOG

[CLS:CFlashWindowExApp]
Type=0
HeaderFile=FlashWindowEx.h
ImplementationFile=FlashWindowEx.cpp
Filter=N

[CLS:CFlashWindowExDlg]
Type=0
HeaderFile=FlashWindowExDlg.h
ImplementationFile=FlashWindowExDlg.cpp
Filter=D
BaseClass=CDialog
VirtualFilter=dWC

[CLS:CAboutDlg]
Type=0
HeaderFile=FlashWindowExDlg.h
ImplementationFile=FlashWindowExDlg.cpp
Filter=D

[DLG:IDD_ABOUTBOX]
Type=1
Class=CAboutDlg
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308480
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889

[DLG:IDD_FLASHWINDOWEX_DIALOG]
Type=1
Class=CFlashWindowExDlg
ControlCount=1
Control1=IDC_FLASHWINDOWEX,button,1342242816

