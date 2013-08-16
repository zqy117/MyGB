// ProtoBuf.h : CProtoBuf ������

#pragma once
#include "resource.h"       // ������
#include <string>



#include "ProtoBufCOM_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif

using namespace ATL;


// CProtoBuf

class ATL_NO_VTABLE CProtoBuf :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CProtoBuf, &CLSID_ProtoBuf>,
	public IDispatchImpl<IProtoBuf, &IID_IProtoBuf, &LIBID_ProtoBufCOMLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CProtoBuf()
	{
	}

	DECLARE_REGISTRY_RESOURCEID(IDR_PROTOBUF)


	BEGIN_COM_MAP(CProtoBuf)
		COM_INTERFACE_ENTRY(IProtoBuf)
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

	STDMETHOD(Serialize)(IProtoMessage* pMessage, BSTR path, VARIANT_BOOL* result);

};

OBJECT_ENTRY_AUTO(__uuidof(ProtoBuf), CProtoBuf)
