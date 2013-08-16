// ProtoMessage.h : CProtoMessage ������

#pragma once
#include "resource.h"       // ������

#include "ProtoBufCOM_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif

using namespace ATL;


// CProtoMessage

class ATL_NO_VTABLE CProtoMessage :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CProtoMessage, &CLSID_ProtoMessage>,
	public IDispatchImpl<IProtoMessage, &IID_IProtoMessage, &LIBID_ProtoBufCOMLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CProtoMessage();

DECLARE_REGISTRY_RESOURCEID(IDR_PROTOMESSAGE)


BEGIN_COM_MAP(CProtoMessage)
	COM_INTERFACE_ENTRY(IProtoMessage)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:
	STDMETHOD(get_Name)(BSTR* pVal);
	STDMETHOD(put_Name)(BSTR newVal);		
	STDMETHOD(get_ID)(LONG* pVal);
	STDMETHOD(put_ID)(LONG newVal);	
	STDMETHOD(get_Email)(BSTR* pVal);
	STDMETHOD(put_Email)(BSTR newVal);
private:
	CString _name;
	int _id;
	CString _email;
};

OBJECT_ENTRY_AUTO(__uuidof(ProtoMessage), CProtoMessage)
