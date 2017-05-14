// FrameRect.h : main header file for the FRAMERECT application
//

#if !defined(AFX_FRAMERECT_H__C546606F_D723_4872_A68F_18C01B9580E0__INCLUDED_)
#define AFX_FRAMERECT_H__C546606F_D723_4872_A68F_18C01B9580E0__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CFrameRectApp:
// See FrameRect.cpp for the implementation of this class
//

class CFrameRectApp : public CWinApp
{
public:
	CFrameRectApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CFrameRectApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CFrameRectApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_FRAMERECT_H__C546606F_D723_4872_A68F_18C01B9580E0__INCLUDED_)
