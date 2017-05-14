// GetClassNameDlg.h : header file
//

#if !defined(AFX_GETCLASSNAMEDLG_H__B25BF9A3_8E6D_460C_9F41_A0114B7D63F4__INCLUDED_)
#define AFX_GETCLASSNAMEDLG_H__B25BF9A3_8E6D_460C_9F41_A0114B7D63F4__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CGetClassNameDlg dialog

class CGetClassNameDlg : public CDialog
{
// Construction
public:
	CGetClassNameDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CGetClassNameDlg)
	enum { IDD = IDD_GETCLASSNAME_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CGetClassNameDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CGetClassNameDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnGetclassname();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_GETCLASSNAMEDLG_H__B25BF9A3_8E6D_460C_9F41_A0114B7D63F4__INCLUDED_)
