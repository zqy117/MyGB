// ProtoBuf.cpp : CProtoBuf µÄÊµÏÖ

#include "stdafx.h"
#include "ProtoBuf.h"
#include <string>
#include "simple.pb.h"
#include <comutil.h>
#include <fstream>

using namespace std;

// CProtoBuf

STDMETHODIMP CProtoBuf::Serialize(IProtoMessage* pMessage, BSTR path, VARIANT_BOOL* result)
{
	Simple msg1;
	BSTR name,email;
	LONG id;
	(*pMessage).get_Name(&name);
	(*pMessage).get_Email(&email);
	(*pMessage).get_ID(&id);
	msg1.set_name(_com_util::ConvertBSTRToString(name));
	msg1.set_email(_com_util::ConvertBSTRToString(email));
	msg1.set_id(id);

	fstream output(path, ios::out | ios::trunc | ios::binary); 
	if(msg1.SerializeToOstream(&output)){
		*result = VARIANT_FALSE;
		return S_FALSE;
	}
	*result = VARIANT_TRUE;
	return S_OK;	
}



