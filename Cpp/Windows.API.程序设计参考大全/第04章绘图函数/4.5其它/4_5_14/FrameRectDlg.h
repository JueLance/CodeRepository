// FrameRectDlg.h : header file
//

#if !defined(AFX_FRAMERECTDLG_H__58A58793_C6FE_437E_8C22_293DBEF791EB__INCLUDED_)
#define AFX_FRAMERECTDLG_H__58A58793_C6FE_437E_8C22_293DBEF791EB__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CFrameRectDlg dialog

class CFrameRectDlg : public CDialog
{
// Construction
public:
	CFrameRectDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CFrameRectDlg)
	enum { IDD = IDD_FRAMERECT_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CFrameRectDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CFrameRectDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnFramerect();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_FRAMERECTDLG_H__58A58793_C6FE_437E_8C22_293DBEF791EB__INCLUDED_)
