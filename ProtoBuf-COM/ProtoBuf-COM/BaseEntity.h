// BaseEntity.h : Declaration of the CBaseEntity

#pragma once
#include "resource.h"       // main symbols
#include <string>


#include "ProtoBufCOM_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

using namespace ATL;


// CBaseEntity

class ATL_NO_VTABLE CBaseEntity :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CBaseEntity, &CLSID_BaseEntity>,
	public IDispatchImpl<IBaseEntity, &IID_IBaseEntity, &LIBID_ProtoBufCOMLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CBaseEntity()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_BASEENTITY)


BEGIN_COM_MAP(CBaseEntity)
	COM_INTERFACE_ENTRY(IBaseEntity)
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



};

OBJECT_ENTRY_AUTO(__uuidof(BaseEntity), CBaseEntity)
