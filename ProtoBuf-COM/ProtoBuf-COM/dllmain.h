// dllmain.h : 模块类的声明。

class CProtoBufCOMModule : public ATL::CAtlDllModuleT< CProtoBufCOMModule >
{
public :
	DECLARE_LIBID(LIBID_ProtoBufCOMLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_PROTOBUFCOM, "{63752460-FD55-4FDF-A183-A02E90EC45EE}")
};

extern class CProtoBufCOMModule _AtlModule;
