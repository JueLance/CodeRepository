; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CInvertRectDlg
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "InvertRect.h"

ClassCount=4
Class1=CInvertRectApp
Class2=CInvertRectDlg
Class3=CAboutDlg

ResourceCount=3
Resource1=IDD_ABOUTBOX
Resource2=IDR_MAINFRAME
Resource3=IDD_INVERTRECT_DIALOG

[CLS:CInvertRectApp]
Type=0
HeaderFile=InvertRect.h
ImplementationFile=InvertRect.cpp
Filter=N

[CLS:CInvertRectDlg]
Type=0
HeaderFile=InvertRectDlg.h
ImplementationFile=InvertRectDlg.cpp
Filter=D
BaseClass=CDialog
VirtualFilter=dWC

[CLS:CAboutDlg]
Type=0
HeaderFile=InvertRectDlg.h
ImplementationFile=InvertRectDlg.cpp
Filter=D

[DLG:IDD_ABOUTBOX]
Type=1
Class=CAboutDlg
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308480
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889

[DLG:IDD_INVERTRECT_DIALOG]
Type=1
Class=CInvertRectDlg
ControlCount=1
Control1=IDC_INVERTRECT,button,1342242816

