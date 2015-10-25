using System;
using System.Collections;
using System.Collections.Generic;

namespace UTSHelps.DependencyServices
{
	public interface ISetting
	{
		string GetSettingValue (string key);
		void SetSettingValue (string key, string value);
		void RemoveSettingValue (string key);
	}
}

