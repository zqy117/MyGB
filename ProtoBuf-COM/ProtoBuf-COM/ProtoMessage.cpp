// ProtoMessage.cpp : CProtoMessage 的实现

#include "stdafx.h"
#include "ProtoMessage.h"
#include "atlstr.h"


// CProtoMessage

CProtoMessage::CProtoMessage()
	: _id(-1)
{

}

STDMETHODIMP CProtoMessage::get_Name(BSTR* pVal)
{
	if(NULL == pVal)
	{
		return E_INVALIDARG;
	}
	
	*pVal = _name.AllocSysString();
	//用完要用::SysFreeString(*pVal);释放内存~或者在外部使用托管字串保存也可
	//因为::SysFreeString是系统API，所以不需要严格遵循谁创建谁释放原则，在任意位置调用皆可

	return S_OK;
}

STDMETHODIMP CProtoMessage::put_Name(BSTR newVal)
{
	_name = newVal;

	return S_OK;
}


STDMETHODIMP CProtoMessage::get_ID(LONG* pVal)
{
	if(0 == pVal)
	{
		return E_INVALIDARG;
	}
	*pVal = (LONG)_id;

	return S_OK;
}


STDMETHODIMP CProtoMessage::put_ID(LONG newVal)
{
	_id = (int)newVal;

	return S_OK;
}


STDMETHODIMP CProtoMessage::get_Email(BSTR* pVal)
{
	if(NULL == pVal)
	{
		return E_INVALIDARG;
	}
	*pVal = _email.AllocSysString();

	return S_OK;
}


STDMETHODIMP CProtoMessage::put_Email(BSTR newVal)
{
	_email = newVal;

	return S_OK;
}
