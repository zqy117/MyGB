// ProtoMessage.cpp : CProtoMessage ��ʵ��

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
	//����Ҫ��::SysFreeString(*pVal);�ͷ��ڴ�~�������ⲿʹ���й��ִ�����Ҳ��
	//��Ϊ::SysFreeString��ϵͳAPI�����Բ���Ҫ�ϸ���ѭ˭����˭�ͷ�ԭ��������λ�õ��ýԿ�

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
