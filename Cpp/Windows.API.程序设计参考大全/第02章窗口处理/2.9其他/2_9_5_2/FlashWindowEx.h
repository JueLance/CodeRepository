// FlashWindowEx.h : main header file for the FLASHWINDOWEX application
//

#if !defined(AFX_FLASHWINDOWEX_H__FF7992FD_17D5_4A1E_A614_CB8758472E3F__INCLUDED_)
#define AFX_FLASHWINDOWEX_H__FF7992FD_17D5_4A1E_A614_CB8758472E3F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CFlashWindowExApp:
// See FlashWindowEx.cpp for the implementation of this class
//

class CFlashWindowExApp : public CWinApp
{
public:
	CFlashWindowExApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CFlashWindowExApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CFlashWindowExApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_FLASHWINDOWEX_H__FF7992FD_17D5_4A1E_A614_CB8758472E3F__INCLUDED_)
